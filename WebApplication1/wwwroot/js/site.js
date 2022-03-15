// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var urlParams;
(window.onpopstate = function () {
    var match,
        pl = /\+/g,
        search = /([^&=]+)=?([^&]*)/g,
        decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
        query = window.location.search.substring(1);

    urlParams = {};
    while (match = search.exec(query))
        urlParams[decode(match[1])] = decode(match[2]);
})();

if (document.getElementById('group') != null) {
    const select = document.querySelector('#group').getElementsByTagName('option');

    for (let i = 0; i < select.length; i++) {
        if (select[i].value === urlParams['Group']) select[i].selected = true;
    }
}

if (document.getElementById('subject') != null) {
    const select = document.querySelector('#subject').getElementsByTagName('option');

    for (let i = 0; i < select.length; i++) {
        if (select[i].value === urlParams['Subject']) select[i].selected = true;
    }
}

if (localStorage["Permission"]) {
    var userColor;
    if (localStorage["Permission"] == "Admin") {
        userColor = "#a15eff";
    }
    else if (localStorage["Permission"] == "Teacher") {
        userColor = "#47ffc8";
    }
    localStorage["userColor"] = userColor;
    $('header').css({ "box-shadow": `0 8px 2px 0 ${userColor}` })
    $('.switch').css({ "background-color": userColor })
}

function incdate() {
    let date = new Date(Date.parse(document.getElementById('date').value));
    date.setDate(date.getDate() + 1);
    document.getElementById('date').value = date.toISOString().replace(/T.*Z/, '');
}

function decdate() {
    let date = new Date(Date.parse(document.getElementById('date').value));
    date.setDate(date.getDate() - 1);
    document.getElementById('date').value = date.toISOString().replace(/T.*Z/, '');
}

function ShowPass() {
    if ($('#password').get(0).type == 'password') $('#password').get(0).type = 'text';
    else { $('#password').get(0).type = 'password' }
}

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 250) {
            $('#scroll').fadeIn();
        } else {
            $('#scroll').fadeOut();
        }
    });
    $('#scroll').css("background-color", localStorage["userColor"]);
    $('#scroll').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });
});