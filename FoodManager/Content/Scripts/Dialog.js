function createDialog(options) {

    //VARIABLES
    var id = 0;
    var inputId = "";
    var entity = "";
    var title = "";
    var message = "";
    var status = false;
    var type = BootstrapDialog.TYPE_PRIMARY;
    var buttons = [];
    var withScroll = false;
    var onshown = false;

    //OPTIONS
    if (options.Id) id = options.Id;
    if (options.Entity) inputId = "#" + options.Entity;
    if (options.Entity) entity = options.Entity;
    if (options.Title) title = options.Title;
    if (options.Message) message = options.Message;
    if (options.Status) status = options.Status;
    if (options.Type) type = options.Type;
    if (options.WithScroll) withScroll = options.WithScroll;
    if (options.Onshown) onshown = options.Onshown;

    //BUTTONS
    if (options.Buttons) {
        if (options.Buttons.Cancel) buttons.push(addCancel());
        if (options.Buttons.Delete) buttons.push(addDelete());
        if (options.Buttons.DeleteMany) buttons.push(addDeleteMany());
        if (options.Buttons.Create) buttons.push(addCreate());
        if (options.Buttons.ChangeStatus) buttons.push(addChangeStatus());
        if (options.Buttons.Accept) buttons.push(addAccept());
    }

    //INSTANCE
    BootstrapDialog.show({
        title: title,
        message: message,
        type: type,
        buttons: buttons,
        onshown: function () {
            if (onshown) onshown();

            if (withScroll && $(".modal-body").height() > 350) {
                $('.bootstrap-dialog-message').slimScroll({
                    height: '350px',
                    railVisible: true,
                    alwaysVisible: true
                });
            }
        }
    });
    //INTERNAL
    function addCancel() {
        return{
            label: 'Cancelar',
            action: function(dialog) {
                dialog.close();
            }
        };
    }

    function addAccept() {
        return {
            label: 'Aceptar',
            action: function (dialog) {
                dialog.close();
            }
        };
    }

    function addDelete() {
        return {
            label: 'Eliminar',
            cssClass: 'btn-danger',
            action: function(dialog) {
                this.spin();
                dialog.enableButtons(false);
                dialog.setClosable(false);

                var callbackSuccessDelete = function (response) {
                    hideAllAlerts();
                    if (response.Result == resultType.Ok) {
                        $(inputId).find("#Table").bootstrapTable('refresh');
                        alertSuccess(response.Message);
                    } else {
                        alertError(response.Message);
                    }
                    dialog.close();
                };
                var callbackErrorDelete = function() {
                    dialog.close();
                };
                deletePerAjax(entity, id, callbackSuccessDelete, callbackErrorDelete);
            }
        };
    }

    function addDeleteMany() {
        return {
            label: 'Eliminar',
            cssClass: 'btn-danger',
            action: function (dialog) {
                this.spin();
                dialog.enableButtons(false);
                dialog.setClosable(false);

                var selectedRows = $(inputId).find("#Table").bootstrapTable('getSelections');
                var countSuccess = 0;
                var countError = 0;

                addOpacity();
                alertInfo("Eliminando registros, se notificar&aacute; el progreso en un momento.");

                $(selectedRows).each(function (index, value) {
                    var callbackSuccessDeleteMany = function (response) {
                        if (response.Result == resultType.Ok) {
                            $(inputId).find("#Table").bootstrapTable('remove', { field: 'Id', values: [value.Id] });
                            countSuccess++;
                            checkIfFinishDelete();
                        } else {
                            countError++;
                            checkIfFinishDelete();
                        }
                    };
                    var callbackErrorDeleteMany = function () {
                        countError++;
                        checkIfFinishDelete();
                    };
                    deletePerAjax(entity, value.Id, callbackSuccessDeleteMany, callbackErrorDeleteMany);
                });

                function checkIfFinishDelete() {
                    if ((parseFloat(countSuccess) + countError) == selectedRows.length) {
                        hideAllAlerts();

                        if (countSuccess == 1)
                            alertSuccess("1 registro eliminado exitosamente.");
                        if (countSuccess > 1)
                            alertSuccess(countSuccess + " registros eliminados exitosamente.");
                        if (countError == 1)
                            alertError("1 registro no se ha podido eliminar.");
                        if (countError > 1)
                            alertError(countError + " registros no se han podido eliminar.");

                        $(inputId).find(".btnDeleteMany").prop("disabled", true);
                        $(inputId).find("#Table").bootstrapTable('refresh');
                        dialog.close();
                        clearOpacity();
                    }
                }
            }
        };
    }

    function addCreate() {
        return {
            label: 'Guardar',
            cssClass: 'btn-success',
            action: function (dialog) {
                this.spin();
                dialog.enableButtons(false);
                dialog.setClosable(false);

                if (options.Password && options.ConfirmPassword) {
                    $("#NewPasswordContent").css("display", "none");
                    $("#NewPassword").attr("type", "text");

                    $("#ConfirmPasswordContent").css("display", "none");
                    $("#ConfirmPassword").attr("type", "text");
                }
                $(e.target).data('bootstrapValidator').defaultSubmit();
            }
        };
    }

    function addChangeStatus() {
        var display = status ? "Desactivar" : "Activar";
        var changeTo = status ? false : true;
        return {
            label: display,
            cssClass: 'btn-primary',
            action: function (dialog) {
                this.spin();
                addOpacity();
                dialog.enableButtons(false);
                dialog.setClosable(false);

                var callbackSuccessChangeStatus = function (response) {
                    hideAllAlerts();
                    if (response.Result == resultType.Ok) {
                        $(inputId).find("#Table").bootstrapTable('refresh');
                        alertSuccess(response.Message);
                    } else {
                        alertError(response.Message);
                    }
                    clearOpacity();
                    dialog.close();
                };
                var callbackErrorChangeStatus = function () {
                    alertError("Error al intentar " + display + " el registro.");
                    clearOpacity();
                    dialog.close();
                };
                changeStatusPerAjax(entity, id, changeTo, callbackSuccessChangeStatus, callbackErrorChangeStatus);
            }
        };
    }

}

