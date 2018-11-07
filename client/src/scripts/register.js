// Variables
var provincesWithPlaces;

// Functions right after page enter
{
    // Load global variable only once, places will be dynamically hinted when user types his place
    // provincesWithPlaces = getProvincesWithPlaces();
}

// Functions Onload
window.onload = function(){
    // promise... https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise
    provincesWithPlaces = getProvincesWithPlaces();
};

function getProvincesWithPlaces(){
    var result = [];

    fetch("http://localhost:58481/api/provinces")
    .then(resp => resp.json())
    .then(resp => {
        resp.forEach(function(province){
            result.push(province);
        })
    })

    return result;
};

function loadProvincesToSelect(){
    // need to wait for fetch? - YES
    provincesWithPlaces.forEach(function(province){
        var option = document.createElement("option");
        option.text = province['ProvinceName'];
        option.value = province['ProvinceName'];

        document.getElementById('province').appendChild(option);
    })

    /*
    var option = document.createElement("option");
    option.text = "Text";
    option.value = "myvalue";

    var el = document.getElementById('province');
    el.style.backgroundColor = 'blue';
    el.appendChild(option);//"<option value=\"volvo\">Volvo</option>"
    */
};