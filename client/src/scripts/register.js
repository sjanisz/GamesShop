// Variables
var provincesWithPlaces = [];
var registrationFormElem;
var loginInputElem;
var provinceSelectElem;
var placeInputElem;

// Call onload after whole document will be loaded and all DOM elemnts will be available
window.onload = function(){
    // Get DOM elements e.g. for reacting on their events
    registrationFormElem =
        document.forms["registration"];
    // Main user data
    loginInputElem =
        registrationFormElem.elements["registration"].elements["mainData"].elements["login"];
    // Remaining user data
    provinceSelectElem = 
        registrationFormElem.elements["registration"].elements["remainingData"].elements["province"];
    placeInputElem =
        registrationFormElem.elements["registration"].elements["remainingData"].elements["place"];
    

    asyncOnloadFunctions().then(function(){
        loadProvincesToSelect();

        // addEventListeners
        registrationFormElem.addEventListener(
            "submit", registrationForm_onSubmit, false);
        registrationFormElem.addEventListener(
            "change", registrationForm_onChange, false);
        loginInputElem.addEventListener(
            "change", loginInputElem_onChange, false);
        provinceSelectElem.addEventListener(
            "change", attachPlacesListForProvinceToPlaceTextInput_onChange, false);
    }).catch(function(){
        //Catch ANY (first) onload promises error
    })
};

function asyncOnloadFunctions(){
    // add more promises there
    var promiseGetProvincesWithPlaces = getProvincesWithPlaces();
    
    return Promise.all([promiseGetProvincesWithPlaces]);
}

function getProvincesWithPlaces(){
    var promise = fetch("http://localhost:58481/api/provincesWithPlaces")
    .then(resp => resp.json())
    .then(resp => {
        resp.forEach(function(province){
            provincesWithPlaces.push(province);
        })
    })

    return promise;
};

// 
function loadProvincesToSelect(){
    // Create default province option element with proper properties
    var defaultOption = document.createElement("option");
    defaultOption.disabled = true;
    defaultOption.selected = true;
    defaultOption.text = "Choose province";

    provinceSelectElem.appendChild(defaultOption);

    provincesWithPlaces.forEach(function(province){
        var option = document.createElement("option");
        option.textContent = province['ProvinceName'];
        option.value = province['ProvinceID'];

        provinceSelectElem.appendChild(option);
    })
};

function attachPlacesListForProvinceToPlaceTextInput_onChange(){
    var placesList = document.getElementById('selectedProvincePlacesList');
    
    if(placesList===null)
    {
        placesList = document.createElement("datalist");
        placesList.id = "selectedProvincePlacesList";

        document.body.appendChild(placesList);
    }else{
        placesList.innerHTML = "";
    }

    var selectedProvinceName = provinceSelectElem.options[provinceSelectElem.selectedIndex].text;

    var selectedProvince;

    for(province of provincesWithPlaces)
    {
        if(province["ProvinceName"] === selectedProvinceName)
        {
            selectedProvince = province;
            break;
        }
    }

    if(selectedProvince !== undefined)
    {
        placeInputElem.removeAttribute("disabled");
        placeInputElem.removeAttribute("placeholder");

        for(place of selectedProvince["Places"])
        {
            var placeOption = document.createElement("option");
            placeOption.value = place["PlaceName"];

            placesList.appendChild(placeOption);
        }
    }else{
        //selectedProvince undefined/null? still block place input
        placeInputElem.disabled = true;
        placeInputElem.placeholder = "Choose province first";
    }
}

function registrationForm_onSubmit(e){
    e.preventDefault();
    var formData = new FormData(registrationFormElem);

    validateProvinceSelectElem();
    
    // Get formData, validate from GUI point of view
    // failure: stay on site and print error
    // ok: go to another page with "Successful" message

    validationResult = validateRegisterFormData();

}

function registrationForm_onChange()
{
    provinceSelectElem.setCustomValidity("");
}

function loginInputElem_onChange()
{
    loginInputElem.setCustomValidity("");
}

function validateProvinceSelectElem()
{
    var provinceNotSelected = provinceSelectElem.options[provinceSelectElem.selectedIndex].disabled;
    if(provinceNotSelected === true)
    {
        provinceSelectElem.setCustomValidity("Select province");
    }
}

function validateRegisterFormData()
{
    validationResult = new Boolean(true);
    var formData = new FormData(registrationFormElem);

    var login = formData.get("login");
    var loginRegex = /(?=[^0-9])(?=[^a-z])(?=[^A-Z])/; //(?= expr) - using for ANDing
    if(loginRegex.test(login))
    {
        loginInputElem.setCustomValidity("Wrong characters");
    }
}