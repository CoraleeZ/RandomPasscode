// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ajaxCall() {
    // <!-- console.log("hello"); -->
    $.ajax({
        type: "POST",
        url: "/rand",
        success: (data) => {
            console.log(data);
            $(".count").html(data.count);
            $(".randomPass").html(data.randomstring);

        },
        error: console.log("error")
    });
}