// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function klikNaCheckbox() {
    console.log(document.getElementById("soukroma").checked);

    if (document.getElementById("soukroma").checked == true)
        document.getElementById("heslo").style.visibility = "visible";
    else
        document.getElementById("heslo").style.visibility = "hidden";

    console.log(document.getElementById("heslo").style.visibility);
}