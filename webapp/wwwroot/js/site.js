// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*const { data } = require("jquery");*/

// Write your JavaScript code.



(function () {
    var caseTotal = document.getElementById('case');
    var activeCase = document.getElementById('active_case');
    var recoverCase = document.getElementById('recover_case');
    var deathCase = document.getElementById('death_case');



    fetch('https://coronavirus-19-api.herokuapp.com/all')
        .then(response => response.json())
        .then(data => {
            setTimeout(() => {
                caseTotal.innerHTML = data.cases.toLocaleString();
                activeCase.innerHTML = (data.cases - data.recovered - data.deaths).toLocaleString();
                recoverCase.innerHTML = data.recovered.toLocaleString();
                deathCase.innerHTML = data.deaths.toLocaleString();
            }, 5000)
        });

})()

