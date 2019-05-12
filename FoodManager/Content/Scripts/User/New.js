//ELEMENTS
var viewPasswordElement = $(".previewPassword");
var passwordElement = $("#Password");
var confirmPasswordElement = $("#ConfirmPassword");

//INSTANCES
actionToClickTopreviewPassword();
validateUser();

//INTERNAL
function validateUser() {
    var callback = function() {
        passwordElement.val(confirmPasswordElement.val());
    };

    validateForm({
        Name: true,
        UserName: true,
        NewPassword: true,
        ConfirmPassword:true,
        Dealer: true,
        Role: true,
        Callback: callback
    });
}