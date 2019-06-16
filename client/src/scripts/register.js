// Variables
var provincesWithPlaces = [];
var provinceSelectElem;
var placeInputElem;
var registrationFormElem;

// Call onload after whole document will be loaded and all DOM elemnts will be available
window.onload = function(){
    // Get DOM elements e.g. for reacting on their events
    registrationFormElem =
        document.forms["registration"];
    provinceSelectElem = 
        registrationFormElem.elements["registration"].elements["remainingData"].elements["province"];
    placeInputElem =
        registrationFormElem.elements["registration"].elements["remainingData"].elements["place"];

    asyncOnloadFunctions().then(function(){
        loadProvincesToSelect();

        // addEventListeners
        provinceSelectElem.addEventListener(
            "change", attachPlacesListForProvinceToPlaceTextInput_onChange, false);
        registrationFormElem.addEventListener(
            "submit", registrationForm_onSubmit, false);
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
    
    // Get formData, validate from GUI point of view
    // failure: stay on site and print error
    // ok: go to another page with "Successful" message

    
}