//ELEMENTS
var tabUserElement = $("#TabUser");
var tabPasswordElement = $("#TabPassword");
var formButtonsElement = $("#FormButtons");
var PasswordButtonsElement = $("#PasswordButtons");
var createAndNewElement = $("#CreateAndNew");
var cleanPassswordElement = $("#CleanPassword");
var createElement = $("#Create");

//INSTANCES
actionsForClickToTabs();
validateUser();

//INTERNAL
function actionsForClickToTabs() {
    tabUserElement.click(function () {
        formButtonsElement.css("display", "block");
        PasswordButtonsElement.css("display", "none");

        createElement.removeAttr("disabled");
        createAndNewElement.removeAttr("disabled");
        cleanPassswordElement.trigger("click");
    });

    tabPasswordElement.click(function () {
        formButtonsElement.css("display", "none");
        PasswordButtonsElement.css("display", "block");

        createElement.attr("disabled", "disabled");
        createAndNewElement.attr("disabled", "disabled");
    });
}

function validateUser() {
    validateForm({
        Name: true,
        Role: true
    });
}