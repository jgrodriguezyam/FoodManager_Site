function validateForm(options) {

    //VARIABLES
    var id = "#Form";
    var callback = false;
    var validateFields = {};
    var applyDialog;
    var interval = { UserName: null, Imss: null, Badge: null };

    //OPTIONS
    if (options.Id) id = options.Id;
    if (options.Callback) callback = options.Callback;
    if (options.ApplyDialog) applyDialog = options.ApplyDialog;

    //VALIDATORS
    if (options.UserNameLogin) addUserNameLogin();
    if (options.BadgeLogin) addBadgeLogin();
    if (options.Password) addPassword();
    if (options.NewPassword) addNewPassword();
    if (options.ConfirmPassword) addConfirmPassword();
    if (options.OldPassword) addOldPassword();
    if (options.Name) addName();
    if (options.FirstName) addFirstName();
    if (options.LastName) addLastName();
    if (options.UserName) addUserName();
    if (options.Comment) addComment();
    if (options.Code) addCode();
    if (options.Email) addEmail();
    if (options.Imss) addImss();
    if (options.Badge) addBadge();
    if (options.LimitEnergy) addLimitEnergy();
    if (options.Region) addRegion();
    if (options.Company) addCompany();
    if (options.Branch) addBranch();
    if (options.Disease) addDisease();
    if (options.IngredientGroup) addIngredientGroup();
    if (options.Dealer) addDealer();
    if (options.DealerNotNullable) addDealerNotNullable();
    if (options.Department) addDepartment();
    if (options.Saucer) addSaucer();
    if (options.Job) addJob();
    if (options.Unit) addUnit();
    if (options.Color) addColor();
    if (options.Energy) addEnergy();
    if (options.NetWeight) addNetWeight();
    if (options.Protein) addProtein();
    if (options.Carbohydrate) addCarbohydrate();
    if (options.Sugar) addSugar();
    if (options.Lipid) addLipid();
    if (options.Sodium) addSodium();
    if (options.Type) addType();
    if (options.DayWeek) addDayWeek();
    if (options.StartDate) addStartDate();
    if (options.EndDate) addEndDate();
    if (options.MaxAmount) addMaxAmount();
    if (options.Role) addRole();

    //INSTANCE
    $(id).bootstrapValidator({
        fields: validateFields
    }).on('success.field.bv', function(e, data) {
        $("#CreateAndNew").css("cursor", "pointer");
        $("#CreateAndNew").attr("disabled", false);
        $("#Save").css("cursor", "pointer");
        $("#Save").attr("disabled", false);
        $("#" + $(data.element).attr("id") + "Message").css("display", "none");
        if (callback) callback(e);
    }).on('error.field.bv', function(e, data) {
        $("#CreateAndNew").css("cursor", "not-allowed");
        $("#CreateAndNew").attr("disabled", true);
        $("#ChangePassword").css("cursor", "not-allowed");
        $("#ChangePassword").attr("disabled", true);
        $("#Save").css("cursor", "not-allowed");
        $("#Save").attr("disabled", true);
        $("#" + $(data.element).attr("id") + "Message").css("display", "inline-block");
    }).on('success.form.bv', function(e) {
        addOpacity();
        if (applyDialog) {
            e.preventDefault();
            $("#Create").removeAttr("disabled");
            $("#CreateAndNew").removeAttr("disabled");
            $("#Save").removeAttr("disabled");
            $("#ChangePassword").removeAttr("disabled");

            createDialog({
                Title: "Confirmar",
                Message: "&iquest;Desea guardar el registro?",
                Type: BootstrapDialog.TYPE_SUCCESS,
                Buttons: { Cancel: true, Create: true }
            });
        }
    });


    //IMPLEMENTS
    function addUserNameLogin() {
        validateFields["UserName"] = {
            excluded: false,
            selector: "#UserName",
            container: "#UserNameMessage",
            validators: {
                notEmpty: {
                    message: 'El Usuario es requerido.'
                },
                callback: {
                    callback: function(value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Usuario contiene una cadena inv&aacute;lida' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addBadgeLogin() {
        validateFields["Badge"] = {
            excluded: false,
            selector: "#Badge",
            container: "#BadgeMessage",
            validators: {
                notEmpty: {
                    message: 'El Gaffete es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Gaffete contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addPassword() {
        validateFields["Password"] = {
            excluded: false,
            selector: "#Password",
            container: "#PasswordMessage",
            validators: {
                notEmpty: {
                    message: 'La Contrase&ntilde;a es requerida.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'La Contrase&ntilde;a contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addNewPassword() {
        validateFields["NewPassword"] = {
            excluded: false,
            selector: "#NewPassword",
            container: "#NewPasswordMessage",
            validators: {
                notEmpty: {
                    message: 'La Contrase&ntilde;a es requerida.'
                },
                identical: {
                    field: "ConfirmPassword",
                    message: 'La Contrase&ntilde;a y la confirmaci&oacute;n no coinciden.'
                },
            }
        };
    }

    function addConfirmPassword() {
        validateFields["ConfirmPassword"] = {
            excluded: false,
            selector: "#ConfirmPassword",
            container: "#ConfirmPasswordMessage",
            validators: {
                notEmpty: {
                    message: 'La Contrase&ntilde;a es requerida.'
                },
                identical: {
                    field: "NewPassword",
                    message: 'La Contrase&ntilde;a y la confirmaci&oacute;n no coinciden.'
                },
            }
        };
    }

    function addOldPassword() {
        validateFields["OldPassword"] = {
            excluded: false,
            selector: "#OldPassword",
            container: "#OldPasswordMessage",
            validators: {
                notEmpty: {
                    message: 'La Contrase&ntilde;a es requerida.'
                }
            }
        };
    }

    function addName() {
        var nameOptions = {
            excluded: false,
            selector: "#Name",
            container: "#NameMessage",
            validators: {
                notEmpty: {
                    message: 'El Nombre es requerido.'
                },
                callback: {
                    callback: function(value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Nombre contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };

        if ($("[name='Name']").length > 0) validateFields["Name"] = nameOptions;
    }

    function addUserName() {
        validateFields["UserName"] = {
            excluded: false,
            selector: "#UserName",
            container: "#UserNameMessage",
            validators: {
                notEmpty: {
                    message: 'El Alias es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Alias contiene un valor inv&aacute;lido' };
                        }

                        clearInterval(interval.UserName);
                        var entity = $("#UserName").data("entity");
                        var firstValue = $("#UserName").data("first");
                        if (value != '') {
                            interval.UserName = setInterval(function() {
                                clearInterval(interval.UserName);
                                var callbackSuccessToFilter = function(response) {
                                    if (response.Count > 0) {
                                        $("#Form #UserNameMessage [data-bv-validator='callback']").html('El Alias ya est&aacute; asignado');
                                        $("#Form").bootstrapValidator('updateStatus', 'UserName', 'INVALID', 'callback');
                                    }
                                };
                                if (value != firstValue)
                                    filterPerAjax(entity, { UserName: value }, callbackSuccessToFilter, false);
                            }, 1000);
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addComment() {
        validateFields["Comment"] = {
            excluded: false,
            selector: "#Comment",
            container: "#CommentMessage",
            validators: {
                callback: {
                    message: '',
                    callback: function () {
                        return true;
                    }
                }
            }
        };
    }

    function addCode() {
        var validField = "Code";
        if ($("[name='Branch.Code']").length > 0) validField = "Branch.Code";

        validateFields[validField] = {
            excluded: false,
            selector: "#Code",
            container: "#CodeMessage",
            validators: {
                notEmpty: {
                    message: 'El C&oacute;digo es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El C&oacute;digo contiene un valor inv&aacute;lido' };
                        }

                        clearInterval(interval.Code);
                        var entity = $("#Code").data("entity");
                        var firstValue = $("#Code").data("first");
                        if (value != '') {
                            interval.Code = setInterval(function () {
                                clearInterval(interval.Code);
                                var callbackSuccessToFilter = function (response) {
                                    if (response.Count > 0) {
                                        $("#Form #CodeMessage [data-bv-validator='callback']").html('El C&oacute;digo ya est&aacute; asignado');
                                        $("#Form").bootstrapValidator('updateStatus', validField, 'INVALID', 'callback');
                                    }
                                };
                                if (value != firstValue)
                                    filterPerAjax(entity, { Code: value }, callbackSuccessToFilter, false);
                            }, 1000);
                        }
                        return true;
                    }
                }
            }
        };;
        
    }

    function addEmail() {
        validateFields["Email"] = {
            excluded: false,
            selector: "#Email",
            container: "#EmailMessage",
            validators: {
                emailAddress: {
                    message: "Se requiere un Correo v&aacute;lido."
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Correo contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addImss() {
        validateFields["Imss"] = {
            excluded: false,
            selector: "#Imss",
            container: "#ImssMessage",
            validators: {
                notEmpty: {
                    message: 'El N&uacute;mero de Seguro Social es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El N&uacute;mero de Seguro Social contiene un valor inv&aacute;lido' };
                        }

                        clearInterval(interval.imss);
                        var entity = $("#Imss").data("entity");
                        var firstValue = $("#Imss").data("first");
                        if (value != '') {
                            interval.imss = setInterval(function() {
                                clearInterval(interval.imss);
                                var callbackSuccessToFilter = function(response) {
                                    if (response.Count > 0) {
                                        $("#Form #ImssMessage [data-bv-validator='callback']").html('El N&uacute;mero de Seguro Social ya est&aacute; asignado');
                                        $("#Form").bootstrapValidator('updateStatus', 'Imss', 'INVALID', 'callback');
                                    }
                                };
                                if (value != firstValue)
                                    filterPerAjax(entity, { Imss: value }, callbackSuccessToFilter, false);
                            }, 1000);
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addBadge() {
        validateFields["Badge"] = {
            excluded: false,
            selector: "#Badge",
            container: "#BadgeMessage",
            validators: {
                notEmpty: {
                    message: 'El Gaffete es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El C&oacute;digo de Gaffete contiene un valor inv&aacute;lido' };
                        }

                        clearInterval(interval.Badge);
                        var entity = $("#Badge").data("entity");
                        var firstValue = $("#Badge").data("first");
                        if (value != '') {
                            interval.Badge = setInterval(function() {
                                clearInterval(interval.Badge);
                                var callbackSuccessToFilter = function(response) {
                                    if (response.Count > 0) {
                                        $("#Form #BadgeMessage [data-bv-validator='callback']").html('El C&oacute;digo de Gaffete ya est&aacute; asignado');
                                        $("#Form").bootstrapValidator('updateStatus', 'Badge', 'INVALID', 'callback');
                                    }
                                };
                                if (value != firstValue)
                                    filterPerAjax(entity, { Badge: value }, callbackSuccessToFilter, false);
                            }, 1000);
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addLimitEnergy() {
        validateFields["LimitEnergy"] = {
            excluded: false,
            selector: "#LimitEnergy",
            container: "#LimitEnergyMessage",
            validators: {
                notEmpty: {
                    message: 'La ingesta cal&oacute;rica es requerida.'
                }
            }
        };
    }

    function addRegion() {
        validateFields["RegionId"] = {
            excluded: false,
            selector: "#RegionId",
            container: "#RegionIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar una Regi&oacute;n.'
                }
            }
        };
    }

    function addCompany() {
        validateFields["CompanyId"] = {
            excluded: false,
            selector: "#CompanyId",
            container: "#CompanyIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar una Compa&ntilde;&iacute;a.'
                }
            }
        };
    }

    function addBranch() {
        validateFields["BranchId"] = {
            excluded: false,
            selector: "#BranchId",
            container: "#BranchIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar una Sucursal.'
                }
            }
        };
    }

    function addDisease() {
        validateFields["DiseaseId"] = {
            excluded: false,
            selector: "#DiseaseId",
            container: "#DiseaseIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar una Enfermedad.'
                }
            }
        };
    }

    function addIngredientGroup() {
        validateFields["IngredientGroupId"] = {
            excluded: false,
            selector: "#IngredientGroupId",
            container: "#IngredientGroupIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un Grupo.'
                }
            }
        };
    }

    function addDealer() {
        validateFields["DealerId"] = {
            excluded: false,
            selector: "#DealerId",
            container: "#DealerIdMessage",
            validators: {
                callback: {
                    message: '',
                    callback: function () {
                        return true;
                    }
                }
            }
        };
    }

    function addDealerNotNullable() {
        validateFields["DealerId"] = {
            excluded: false,
            selector: "#DealerId",
            container: "#DealerIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un Concesionario.'
                }
            }
        };
    }

    function addDepartment() {
        validateFields["DepartmentId"] = {
            excluded: false,
            selector: "#DepartmentId",
            container: "#DepartmentIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un Departamento.'
                }
            }
        };
    }

    function addJob() {
        validateFields["JobId"] = {
            excluded: false,
            selector: "#JobId",
            container: "#JobIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un Puesto.'
                }
            }
        };
    }

    function addSaucer() {
        validateFields["SaucerId"] = {
            excluded: false,
            selector: "#SaucerId",
            container: "#SaucerIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un Platillo.'
                }
            }
        };
    }

    function addUnit() {
        validateFields["Unit"] = {
            excluded: false,
            selector: "#Unit",
            container: "#UnitMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar una Unidad.'
                }
            }
        };
    }

    function addColor() {
        validateFields["Color"] = {
            excluded: false,
            selector: "#Color",
            container: "#ColorMessage",
            validators: {
                notEmpty: {
                    message: 'El Color es requerido.'
                },
                hexColor: {
                    message:'El C&oacute;digo de Color no es v&aacute;lido.'
                }
            }
        };
    }

    function addEnergy() {
        validateFields["Energy"] = {
            excluded: false,
            selector: "#Energy",
            container: "#EnergyMessage",
            validators: {
                notEmpty: {
                    message: 'La Energ&iacute;a es requerida.'
                }
            }
        };
    }


    function addNetWeight() {
        validateFields["NetWeight"] = {
            excluded: false,
            selector: "#NetWeight",
            container: "#NetWeightMessage",
            validators: {
                notEmpty: {
                    message: 'El Peso neto es requerido..'
                },
                greaterThan: {
                    value: .01,
                    message: 'El Peso neto de Gramos debe ser .01 como m&iacute;nimo.'
                }
            }
        };
    }

    function addProtein() {
        validateFields["Protein"] = {
            excluded: false,
            selector: "#Protein",
            container: "#ProteinMessage",
            validators: {
                notEmpty: {
                    message: 'Las Prote&iacute;nas son requeridas.'
                }
            }
        };
    }

    function addCarbohydrate() {
        validateFields["Carbohydrate"] = {
            excluded: false,
            selector: "#Carbohydrate",
            container: "#CarbohydrateMessage",
            validators: {
                notEmpty: {
                    message: 'Los Carbohidratos son requeridos.'
                }
            }
        };
    }

    function addSugar() {
        validateFields["Sugar"] = {
            excluded: false,
            selector: "#Sugar",
            container: "#SugarMessage",
            validators: {
                notEmpty: {
                    message: 'El Az&uacute;car es  requerida.'
                }
            }
        };
    }

    function addLipid() {
        validateFields["Lipid"] = {
            excluded: false,
            selector: "#Lipid",
            container: "#LipidMessage",
            validators: {
                notEmpty: {
                    message: 'Los L&iacute;pidos son requeridos.'
                }
            }
        };
    }

    function addSodium() {
        validateFields["Sodium"] = {
            excluded: false,
            selector: "#Sodium",
            container: "#SodiumMessage",
            validators: {
                notEmpty: {
                    message: 'El Sodio es requerido.'
                }
            }
        };
    }

    function addType() {
        var typeOptions = {
            excluded: false,
            selector: ".Type",
            container: "#TypeMessage",
            validators: {
                notEmpty: {
                    message: 'Se requeire seleccionar un Tipo.'
                },
                greaterThan: {
                    value: 0,
                    message: 'Se requeire seleccionar un Tipo.'
                }
            }
        };
        if ($("[name='Type']").length > 0) validateFields["Type"] = typeOptions;
        if ($("[name='MealType']").length > 0) validateFields["MealType"] = typeOptions;
    }

    function addDayWeek() {
        validateFields["DayWeek"] = {
            excluded: false,
            selector: "[Name='DayWeek']",
            container: "#DayWeekMessage",
            validators: {
                notEmpty: {
                    message: 'Se requeire seleccionar un Tipo.'
                },
                greaterThan: {
                    value: 0,
                    message: 'Se requeire seleccionar un Tipo.'
                }
            }
        };
    }

    function addFirstName() {
        validateFields["FirstName"] = {
            excluded: false,
            selector: "#FirstName",
            container: "#FirstNameMessage",
            validators: {
                notEmpty: {
                    message: 'El Nombre es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Nombre contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addLastName() {
        validateFields["LastName"] = {
            excluded: false,
            selector: "#LastName",
            container: "#LastNameMessage",
            validators: {
                notEmpty: {
                    message: 'El Apellido es requerido.'
                },
                callback: {
                    callback: function (value) {
                        if (isInValidRequestForm(value)) {
                            return { valid: false, message: 'El Apellido contiene un valor inv&aacute;lido' };
                        }
                        return true;
                    }
                }
            }
        };
    }

    function addStartDate() {
        validateFields["StartDate"] = {
            excluded: false,
            selector: "#StartDate",
            container: "#StartDateMessage",
            validators: {
                notEmpty: {
                    message: 'La Fecha de inicio es requerida.'
                },
                callback: {
                    message: 'La Fecha de inicio debe ser menor a la Fecha fin.',
                    callback: function () {
                        return moment($("#StartDate").val(), formatDate) <= moment($("#EndDate").val(), formatDate);
                    }
                }
            }
        };
    }

    function addEndDate() {
        validateFields["EndDate"] = {
            excluded: false,
            selector: "#EndDate",
            container: "#EndDateMessage",
            validators: {
                notEmpty: {
                    message: 'La Fecha de finalizaci&oacute;n es requerida.'
                },
                callback: {
                    message: 'La Fecha de fin debe ser menor a la Fecha inicio.',
                    callback: function () {
                        return moment($("#StartDate").val(), formatDate) <= moment($("#EndDate").val(), formatDate);
                    }
                }
            }
        };
    }

    function addMaxAmount() {
        validateFields["MaxAmount"] = {
            excluded: false,
            selector: "#MaxAmount",
            container: "#MaxAmountMessage",
            validators: {
                notEmpty: {
                    message: 'La Cantidad de platillos es requerido.'
                },
                greaterThan: {
                    value: 1,
                    message: 'La Cantidad de platillos no puede ser 0.'
                }
            }
        };
    }

    function addRole() {
        validateFields["RoleId"] = {
            excluded: false,
            selector: "#RoleId",
            container: "#RoleIdMessage",
            validators: {
                notEmpty: {
                    message: 'Se requiere seleccionar un  Rol.'
                }
            }
        };
    }
}
