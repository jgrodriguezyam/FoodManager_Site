//INSTANCES
validateLoginUser();
validateLoginWorker();
eventToClickTabs();

//INTERNAL
function validateLoginUser() {
    validateForm({
        Id: "#LoginUser",
        UserNameLogin: true,
        Password: true
    });
}

function validateLoginWorker() {
    validateForm({
        Id: "#LoginWorker",
        BadgeLogin: true
    });
    $("#Badge").focus();
}

function eventToClickTabs() {
    $(".change-login-type").click(function() {
        var loginType = $(this).attr("data-logintype");
        changeLoginTypePerAjax(loginType);
    });
}