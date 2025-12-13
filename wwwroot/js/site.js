// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//faz os alert pelo site desaparecer em T segundos
$(document).ready(()=>{
    setTimeout(()=>{
        $(".alert").fadeOut("slow", ()=>{
            $(this).alert("close")
        })
    }, 4000)
})