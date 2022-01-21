// Variables
let provincesWithPlaces = [];
let registrationFormElem;
let loginInputElem;
let provinceSelectElem;
let placeInputElem;
let bottomLoadingDivElem;

const apiURL = "http://localhost:58481/api/";

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
    bottomLoadingDivElem = document.getElementById("bottomLoading");

    // Loading resources bottom bar show (hide at the end of async functions load)
    applyCSSAndHTMLBeforeLoadingResources();
    
    // TODO: move it to end of async after completion
    // setTimeout(() => {
    //     applyCSSAndHTMLAfterLoadingResources();
    // }, 4000);
    
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

        applyCSSAndHTMLAfterLoadingResources();
    }).catch(function(){
        //Catch ANY (first) onload promises error
    })
};

function asyncOnloadFunctions(){
    // add more promises there
    let promiseGetProvincesWithPlaces = getProvincesWithPlaces();
    
    return Promise.all([promiseGetProvincesWithPlaces]);
}

function getProvincesWithPlaces(){
    let promise = fetch(`${apiURL}provincesWithPlaces`)
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
    let defaultOption = document.createElement("option");
    defaultOption.disabled = true;
    defaultOption.selected = true;
    defaultOption.text = "Choose province";

    provinceSelectElem.appendChild(defaultOption);

    provincesWithPlaces.forEach(function(province){
        let option = document.createElement("option");
        option.textContent = province['ProvinceName'];
        option.value = province['ProvinceID'];

        provinceSelectElem.appendChild(option);
    })
};

function attachPlacesListForProvinceToPlaceTextInput_onChange(){
    let placesList = document.getElementById('selectedProvincePlacesList');
    
    if(placesList===null)
    {
        placesList = document.createElement("datalist");
        placesList.id = "selectedProvincePlacesList";

        document.body.appendChild(placesList);
    }else{
        placesList.innerHTML = "";
    }

    let selectedProvinceName = provinceSelectElem.options[provinceSelectElem.selectedIndex].text;

    let selectedProvince;

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
            let placeOption = document.createElement("option");
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
    let formData = new FormData(registrationFormElem);

    
    
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
    let provinceNotSelected = provinceSelectElem.options[provinceSelectElem.selectedIndex].disabled;
    if(provinceNotSelected === true)
    {
        provinceSelectElem.setCustomValidity("Select province");
    }
}

function validateRegisterFormData()
{
    validationResult = new Boolean(true);
    
    validateProvinceSelectElem();

    let formData = new FormData(registrationFormElem);

    let login = formData.get("login");
    let loginRegex = /(?=[^0-9])(?=[^a-z])(?=[^A-Z])/; //(?= expr) - using for ANDing
    if(loginRegex.test(login))
    {
        loginInputElem.setCustomValidity("Wrong characters");
    }
}

function applyCSSAndHTMLBeforeLoadingResources()
{
    bottomLoadingDivElem.classList.add("bottomLoadingMoveUp");
}

function applyCSSAndHTMLAfterLoadingResources()
{
    bottomLoadingDivElem.classList.remove("bottomLoadingMoveUp");
    bottomLoadingDivElem.classList.add("bottomLoadingMoveDown");
}