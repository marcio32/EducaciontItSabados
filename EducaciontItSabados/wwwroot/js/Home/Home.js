$(function () {
    debugger
    if ($("#Token").val() != "") {
        setCookie("Token", $("#Token").val(), 1);
        setCookie("AjaxUrl", $("#AjaxUrl").val(), 1);
    }
});