//ELEMENTS
var changePasswordElement = $("#ChangePassword");
var changePasswordFormElement = $("#ChangePasswordForm");
var cleanPasswordElement = $("#CleanPassword");
var viewPasswordElement = $(".previewPassword");
var tabUserElement = $("#TabUser");
var typePasswordElement = $("[type=password]");
var userNameElement = $("#UserName");
var oldPasswordElement = $("#OldPassword");
var newPasswordElement = $("#NewPassword");

//INSTANCES
validateChangePasswordForm();
disabledSubmitButton();
actionToCleanPassword();
actionToChangePassword();
actionToClickTopreviewPassword();
clearOpacity();

//INTERNAL
function validateChangePasswordForm() {
    var callback = function () {
        if ($(".form-group.has-success").length == changePasswordFormElement.find(".form-group").length) {
            changePasswordElement.removeAttr("disabled").css("cursor", "pointer");
        }
    };

    validateForm({
        Id: "#ChangePasswordForm",
        OldPassword: true,
        NewPassword: true,
        ConfirmPassword: true,
        Callback: callback
    });
}

function disabledSubmitButton() {
    changePasswordElement.prop("disabled", true);
}

function actionToChangePassword() {
    changePasswordElement.click(function (e) {
        e.preventDefault();

        var root = changePasswordFormElement.data("root");
        var data = { UserName: userNameElement.val(), OldPassword: oldPasswordElement.val(), NewPassword: newPasswordElement.val() };
        var callbackSuccess = function (response) {
            if (response.Result == resultOk)
                alertSuccess(response.Message);
            else
                alertError(response.Message);

            cleanPasswordElement.click();
            tabUserElement.click();
        };

        changePasswordPerAjax(root, data, callbackSuccess, false);
    });
}

function actionToCleanPassword() {
    cleanPasswordElement.click(function () {
        typePasswordElement.val("");
        changePasswordFormElement.bootstrapValidator('resetForm');
    });
}