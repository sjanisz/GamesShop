// Variables
var provincesWithPlaces = [];

const promiseGetProvincesWithPlaces = getProvincesWithPlaces();
// Functions Onload
window.onload = function(){
    // TODO: Full page load bar?
    promiseGetProvincesWithPlaces.then(function(){
        loadProvincesToSelect();
        document.getElementById('province').addEventListener(
            "change", attachPlacesListForProvinceToPlaceTextInput, false);
        
        console.log("promise ok");
    }, function(){
        console.log("promise error");
    })
};

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

function loadProvincesToSelect(){
    var defaultOption = document.createElement("option");
    defaultOption.setAttribute("disabled", "");
    defaultOption.setAttribute("selected", "");
    defaultOption.setAttribute("value", "");
    defaultOption.setAttribute("text", "Choose province");

    document.getElementById('province').appendChild(defaultOption);

    provincesWithPlaces.forEach(function(province){
        var option = document.createElement("option");
        option.text = province['ProvinceName'];
        option.value = province['ProvinceID'];

        document.getElementById('province').appendChild(option);
    })
};

function attachPlacesListForProvinceToPlaceTextInput(){
    var placesList = document.getElementById('selectedProvincePlacesList');
    
    if(placesList===null)
    {
        placesList = document.createElement("datalist");
        placesList.setAttribute("id", "selectedProvincePlacesList");
        document.body.appendChild(placesList);
    }else{
        placesList.innerHTML = "";
    }

    var provinceSelect = document.getElementById('province');
    var selectedProvinceName = provinceSelect.options[provinceSelect.selectedIndex].text;

    var selectedProvince;

    for(province of provincesWithPlaces)
    {
        if(province["ProvinceName"] === selectedProvinceName)
        {
            selectedProvince = province;
            break;
        }
    }

    var placeInput = document.getElementById('place');

    if(selectedProvince !== undefined)
    {
        placeInput.removeAttribute("disabled");
        placeInput.removeAttribute("placeholder");

        for(place of selectedProvince["Places"])
        {
            var placeOption = document.createElement("option");
            placeOption.setAttribute("value", place["PlaceName"]);

            placesList.appendChild(placeOption);
        }
    }else{
        //selectedProvince undefined/null? still block place input
        placeInput.setAttribute("disabled", "");
        placeInput.setAttribute("placeholder", "Choose province first");
    }
}
/*
list="xList"

for place:
<datalist id="xList">
                            <option value="Internet Explorer">
                            <option value="Firefox">
                            <option value="Chrome">
                            <option value="Opera">
                            <option value="Safari">
                        </datalist>
*/