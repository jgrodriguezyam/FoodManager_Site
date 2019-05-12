//VARIABLES ==================================================================
var colorBreakFast = "#8fb735";
var colorLunch = "#56cae4";
var colorDinner = "#f25e5c";
var valueExtracted = "";
var minPortion = 0.5;
var defaultValuePie = [100];
var defaultColorPie = ['#A4A4A4'];
var root = $("#wrapper").data("root");
var allowedFileExtensions = $("#wrapper").attr("data-allowedfileextensions");
var maxrequestlength = $("#wrapper").attr("data-maxrequestlength");
var sourceWithoutMultimedia = $("#wrapper").attr("data-withoutmultimedia");
var session = $("#LogoutForm").attr("data-session");
var gram = "g";
var kiloCalorie = "Kcal";
var formatDate = 'DD/MM/YYYY';
var requetType = { Post: "POST", Get: "GET"};
var fileType = { Image: "Imagen", Pdf: "PDF", Text: "TXT", Video: "Video" };
var resultType = { Ok: "Success", LostSession: "LostSession", InvalidSerial: "InvalidSerial", Precondition: "Precondition", Failure: "Failure" };
var regExprToRequestForm = /&#|<!|<\?|<\/|<[a-zA-Z]/;
var regExprToFilter = /&#|<!|<\?|<\/|<[a-zA-Z]|{|}/;
var loading = "</div><div class='col-lg-12' style='text-align: center; font-size: 25px; padding: 50px; opacity: .5;'><i class='fa fa-cog fa-spin'></i><span> Cargando contenido... </span></div>";
var dateNow = function () {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10)
        dd = '0' + dd;

    if (mm < 10)
        mm = '0' + mm;

    today = dd + '/' + mm + '/' + yyyy;
    return today;
};

//GENERAL ==================================================================
function require(script) {
    var len = $('script').filter(function () {
        return ($(this).attr('src') == script);
    }).length;

    if (len === 0) {
        $.ajaxSetup({ async: false });
        $.getScript(script);
        $.ajaxSetup({ async: true });
    }
}

function randomColor() {
    //return '#' + (Math.random() * 0xFFFFFF << 0).toString(16);
    return '#' + Math.floor(Math.random() * 16777215).toString(16);
}

function redirect(controller, action, parameters) {

    window.location.href = root + controller + "/" + action + "/" + parameters;
}

function clearOpacity() {
    $('.page-content').addClass('page-content-ease-in');
}

function addOpacity() {
    $('.page-content').removeClass('page-content-ease-in');
}

function isNumberKeyUp(evt) {
    var charCode = (evt.keyCode.which) ? evt.keyCode.which : event.keyCode;
    if (charCode == 45 || (charCode != 46 && (charCode > 31))
      && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKeyDow(evt) {
    if (evt.keyCode != 86 || !evt.ctrlKey)
        return false;

    return true;
}

function elementExistInArray(element, array) {
    return $.inArray(element, array) > -1;
}

function formatNumber() {
    $('input.number').number(true, 0);
}

function SumValues(value1, value2) {
    return (parseFloat(value1) + parseFloat(value2)).toFixed(2);
}

function deductValues(value1, value2) {
    return parseFloat(value1) - parseFloat(value2);
}

function dividerValues(value1, value2) {
    return parseFloat(value1) / parseFloat(value2);
}

function multiplyValues(value1, value2) {
    return (parseFloat(value1) * parseFloat(value2)).toFixed(2);
}

function isGreaterThan(value1, value2) {
    return (parseFloat(value1) > parseFloat(value2));
}

function isInValidRequestForm(value) {
    return regExprToRequestForm.test(value);
}

function isInValidFilter(value) {
    return regExprToFilter.test(value);
}

function tryActiveElement($element, isActive) {
    if (!$element.parent().hasClass("active") && isActive) {
        $element.parent().trigger("click");
    }
    if ($element.parent().hasClass("active") && !isActive) {
        $element.parent().trigger("click");
    }
}

//EXTEND ARRAY ==================================================================
Array.prototype.First = function (expr) {
    if (expr == null || expr == "") expr = "true";

    var result = ($.grep(this, function (item, index) {
        return (eval(itemParser(expr)));
    }));

    return (result.length > 0 ? result[0] : null);
};
    
function itemParser(str) {
    var result;
    result = str.replace(/item/gi, "");
    result = result.replace(/\[/g, "item[");

    return result;
}

//PASSWORD ==================================================================
function actionToClickTopreviewPassword() {
    viewPasswordElement
        .mousedown(function () { $(this).closest(".form-group").find("input").attr('type', 'text'); })
        .mouseup(function () { $(this).closest(".form-group").find("input").attr('type', 'password'); });
}

//PROGRESSBAR ==================================================================
function updateProgressBar(options) {
    var progressBarId = "#progress-bar";
    var percentage = "0";
    var maxPercentage = "0";
    var withAlert = false;

    if (options.ProgressBarId) progressBarId = options.ProgressBarId;
    if (options.Percentage) percentage = options.Percentage;
    if (options.MaxPercentage) maxPercentage = options.MaxPercentage;
    if (options.WithAlert) withAlert = options.WithAlert;

    $(progressBarId).css("width", dividerValues(percentage, maxPercentage) * 100 + "%");
    $(progressBarId + " span").html(percentage);
    if (maxPercentage > 0) {
        if (percentage >= maxPercentage) {
            $(progressBarId).removeClass("progress-bar-success").removeClass("progress-bar-warning").addClass("progress-bar-danger");
            if (withAlert) {
                hideAllAlerts();
                alertInfo("Ha superado la ingesta cal&oacute;rica recomendada");

            }
        } else if (percentage >= dividerValues(maxPercentage, 2)) {
            $(progressBarId).removeClass("progress-bar-success").removeClass("progress-bar-danger").addClass("progress-bar-warning");
        } else {
            $(progressBarId).removeClass("progress-bar-warning").removeClass("progress-bar-danger").addClass("progress-bar-success");
        }
    } else {
        hideAllAlerts();
        alertInfo("Actualmente no tiene configurada una ingesta cal&oacute;rica.");
    }
}

//TOUCHSPIN ==================================================================
function createTouchSpin(options) {
    var postfix = "";
    var decimals = 0;
    var step = 0;
    var element = ".touchSpin";

    if (options) {
        if (options.Postfix) postfix = options.Postfix;
        if (options.Decimals) decimals = options.Decimals;
        if (options.Step) step = options.Step;
        if (options.Element) element = options.Element;
    }

    $(element).TouchSpin({
        min: 0,
        max: 10000,
        step: step,
        decimals: decimals,
        boostat: 5,
        maxboostedstep: 10,
        postfix: postfix
    }).on('touchspin.on.stopspin', function () {
        $(this).trigger("input");
    });
}

//MULTIMEDIA==================================================================
function convertMultimediaInCards(options) {
    //VARIABLES
    var otherClass = "";

    //OPTIONS
    if (options) {
        if (options.OtherClass) otherClass = options.OtherClass;
    }

    //INSTANCE
    appendCards();
    if (!$("#cards-multimedia").hasClass("disable-actions")) {
        eventToClickBtnRemoveMultimedia();
    }

    //INTERNAL
    function appendCards() {
        $(".multimedia-preview" + otherClass).each(function () {
            var source = $(this).data("source");
            var path = $(this).data("path");
            var type = $(this).data("type");

            var htmlCards = [];
            htmlCards.push('<div class="col-sm-3">');
            htmlCards.push('<a class="btn btn-sm btn-danger btn-remove-multimedia" style="float: right;margin-top: -10px; margin-left: -19px; position:relative;">');
            htmlCards.push('<i class="fa fa-times"></i>');
            htmlCards.push('</a>');
            htmlCards.push('<a class="thumbnail text-center" style="text-decoration: none;">');
            if (type == fileType.Image)
                htmlCards.push('<img src="' + source + '" data-title="" data-description="" class="img-responsive">');
            if (type == fileType.Video)
                htmlCards.push('<video style="height:100%; width:100%;"controls src="' + path + '" type="video/mp4"></video>');
            htmlCards.push('</a>');
            htmlCards.push('</div>');
            $(this).append(htmlCards.join(''));
        });
    }

    function eventToClickBtnRemoveMultimedia() {
        $(".multimedia-preview").find(".btn-remove-multimedia").click(function() {
            $(this).closest(".multimedia-preview").html("").addClass("hide");
        });
    }

}

function extractValue(value, row, portion, netWeight) {
    switch (value) {
        case "Region":
        case "Company":
        case "Branch":
        case "Disease":
        case "IngredientGroup":
        case "Dealer":
        case "Department":
        case "Job":
        case "Saucer":
        case "Role":
            valueExtracted = row[value].Name;
            break;
        case "Protein":
        case "Carbohydrate":
        case "Sugar":
        case "Lipid":
        case "Sodium":
        case "NetWeight":
            var rowValue = row[value];
            if (portion)
                rowValue = multiplyValues(row[value], portion);
            if (netWeight)
                rowValue = multiplyValues(dividerValues(row[value], row["NetWeight"]), netWeight);
            valueExtracted = "<span class='medition'>" + rowValue + "</span> " + gram;
            break;
        case "Energy":
        case "LimitEnergy":
            var energyValue = row[value];
            if (portion)
                energyValue = multiplyValues(row[value], portion);
            if (netWeight)
                energyValue = multiplyValues(dividerValues(row[value], row["NetWeight"]), netWeight);
            valueExtracted = "<span class='medition'>" + energyValue + "</span> " + kiloCalorie;
            break;
        case "Comment":
            valueExtracted = row[value] == null ? "-" : row[value];
            break;
        case "SaucerMultimedias":
            valueExtracted = "<button class='btnMultimedia btn btn-default btn-xs' data-toggle='tooltip' title='Multimedia'>Ver multimedia</button>";
            break;
        case "Status":
            var classBySpan = row["Status"] == true ? "success" : "danger";
            var displayBySpan = row["Status"] == true ? "activo" : "inactivo";
            valueExtracted = '<span class="label label-' + classBySpan + ' pull-right" style="margin-top: 8px;">' + displayBySpan + '</span>';
            break;
        case "CompanyToWorker":
            valueExtracted = row["Branch"]["Company"].Name;
            break;
        default:
            valueExtracted = row[value];
            break;
    }
}

function resolveFileType(item) {
    var extension = item.type.substr((item.type.lastIndexOf('.') + 1));
    switch (extension) {
    case 'image/jpg':
        case 'image/jpeg':
        case 'image/gif':
        case 'image/bmp':
        case 'image/png':
        return fileType.Image;
        case 'video/mp4':
        return fileType.Video;
    }
}

//DATE & TIME ==================================================================
function createStartDateAndEndDateRangePicker() {
    //VARIABLES
    var startDateElement = $("#StartDate");
    var endDateElement = $("#EndDate");
    var formElement = $("#Form");
    var minDate = moment();
    var startDate = moment();
    var endDate = moment();

    //INSTANCE
    resolveMinDate();
    resolveStartDate();
    resolveEndDate();
    startDateRangePicker();
    endDateRangePicker();

    //INTERNAL
    function resolveMinDate() {
        if (startDateElement.val() != "" && moment(startDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            minDate = startDateElement.val();
    }
    function resolveStartDate() {
        if (startDateElement.val() != "" && moment(startDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            startDate = startDateElement.val();
    }
    function resolveEndDate() {
        if (endDateElement.val() != "" && moment(endDateElement.val(), formatDate) > moment(dateNow(), formatDate))
            endDate = endDateElement.val();
    }

    function startDateRangePicker() {
        startDateElement.daterangepicker({
            "singleDatePicker": true,
            "locale": {
                format: formatDate
            },
            "autoApply": true,
            "linkedCalendars": false,
            "minDate": minDate,
            "startDate": startDate
        }).change('input', function () {
            formElement.bootstrapValidator('revalidateField', 'StartDate');
            formElement.bootstrapValidator('revalidateField', 'EndDate');
        });
    }

    function endDateRangePicker() {
        endDateElement.daterangepicker({
            "singleDatePicker": true,
            "locale": {
                format: formatDate
            },
            "autoApply": true,
            "linkedCalendars": false,
            "minDate": minDate,
            "startDate": endDate
        }).change('input', function() {
            formElement.bootstrapValidator('revalidateField', 'StartDate');
            formElement.bootstrapValidator('revalidateField', 'EndDate');
        });
    }

}

function createDateRangePicker() {
    $(".dateRangePicker").daterangepicker({
        "singleDatePicker": true,
        "locale": {
            format: formatDate
        },
        "autoApply": true,
        "linkedCalendars": false,
        "minDate": moment(),
        "startDate": moment()
    });
}

function clock() {
    // Create two variable with the names of the months and days in an array
    var monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    var dayNames = ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"];

    // Create a newDate() object
    var newDate = new Date();
    // Extract the current date from Date object
    newDate.setDate(newDate.getDate());
    // Output the day, date, month and year   
    $('#Date').html(dayNames[newDate.getDay()] + ", " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

    $("#sec").html((new Date().getSeconds() < 10 ? "0" : "") + new Date().getSeconds());
    $("#min").html((new Date().getMinutes() < 10 ? "0" : "") + new Date().getMinutes());
    $("#hours").html((new Date().getHours() < 10 ? "0" : "") + new Date().getHours());

    setInterval(function () {
        // Create a newDate() object and extract the seconds of the current time on the visitor's
        var seconds = new Date().getSeconds();
        // Add a leading zero to seconds value
        $("#sec").html((seconds < 10 ? "0" : "") + seconds);
    }, 1000);

    setInterval(function () {
        // Create a newDate() object and extract the minutes of the current time on the visitor's
        var minutes = new Date().getMinutes();
        // Add a leading zero to the minutes value
        $("#min").html((minutes < 10 ? "0" : "") + minutes);
    }, 1000);

    setInterval(function () {
        // Create a newDate() object and extract the hours of the current time on the visitor's
        var hours = new Date().getHours();
        // Add a leading zero to the hours value
        $("#hours").html((hours < 10 ? "0" : "") + hours);
    }, 1000);
}

function clickToIconCalendar() {
    $('.dateRangePicker i').click(function () {
        $(this).parent().find('input').click();
    });
}

//TOOL CALCULATOR ==================================================================
function calculator(id, title) {
    var form = '<form class="form-inline  text-center">' +
                    '<div class="form-group margin-bottom-none">' +
                        '<input type="text" class="form-control number value padding-12" id="value1" placeholder="0" maxlength="4" Autocomplete="off">' +
                    '</div>' +
                    '<div class="form-group margin-bottom-none">' +
                        '<label class="padding-left-right-10">x</label>' +
                        '<input type="text" class="form-control number value padding-12" id="value2" placeholder="0" maxlength="4" Autocomplete="off" style="display: block;">' +
                    '</div>' +
                    '<div class="form-group margin-bottom-none">' +
                        '<label class="padding-left-right-10">=</label>' +
                        '<input type="text" class="form-control padding-12 number" id="totalValue" placeholder="0" readonly="readonly" style="display: block;">' +
                    '</div>' +
                '</form>';

    BootstrapDialog.show({
        title: title,
        message: form,
        size: BootstrapDialog.SIZE_SMALL,
        onshown: function () {
            formatNumber();
            changeValue();
            $(".sumValues").prop("disabled", true);
        },
        type: BootstrapDialog.TYPE_PRIMARY,
        buttons: [
            {
                label: 'Guardar',
                cssClass: 'btn-primary sumValues',
                action: function (dialog) {
                    if ($("#value1").val() > 0 && $("#value2").val() > 0) {
                        var total = parseFloat($("#value1").val()) * $("#value2").val();
                        $('#' + id).val(total).trigger("input");
                    }
                    dialog.close();
                }
            }, {
                label: 'Cancelar',
                action: function (dialog) {
                    dialog.close();
                }
            }
        ]
    });
}

function changeValue() {
    $('.value').on('input', function () {
        var activateButtonCreate = true;
        if ($("#value1").val() > 0 && $("#value2").val() > 0) {
            var total = parseFloat($("#value1").val()) * $("#value2").val();
            $("#totalValue").val(total);
        } else {
            $("#totalValue").val(0);
        }

        $(".value").each(function (index, content) {
            var amount = $(content).val() > 0 ? $(content).val() : 0;
            if (amount > 0) {
                $(content).parent().removeClass("has-error");
                $(content).parent().addClass("has-success");
            } else {
                $(content).parent().removeClass("has-success");
                $(content).parent().addClass("has-error");
                activateButtonCreate = false;
            }
        });

        activateButtonCreate ? $(".sumValues").prop("disabled", false) : $(".sumValues").prop("disabled", true);
    });
}

//FORMS ==================================================================
function maxLength() {
    $('input[maxlength]').maxlength();
    $("input[tabindex]").attr("maxlength", "20").maxlength();
}

function submitButtons(options) {
    var disabledSelectize = false;
    if (options) {
        if (options.DisabledSelectize) disabledSelectize = true;
    }

    $("#View").val($("#Create").data("redirectto"));
    $('.submitBtn').click(function () {
        $("#View").val($(this).data("redirectto"));
        $("#Create").trigger("click");
    });
    $('.Save').click(function () {
        if (disabledSelectize) {
            $("#Date").attr("disabled", false);
            $("#DealerId")[0].selectize.enable();
        }
        $("#Create").trigger("click");
    });
}

//SELECTIZE ==================================================================
function destroySelectize(input) {
    $(input)[0].selectize.clear();
    $(input)[0].selectize.destroy();
}

//SLIMSCROLL ==================================================================
function createSlimScroll(id, height) {
    height = height == false ? "400px" : height;

    $(id).slimScroll({
        start: 'top',
        height: height,
        alwaysVisible: true,
        disableFadeOut: false,
        size: 5,
        wheelStep: "50",
    });
}

//TOOLTIP ==================================================================
function refreshTooltip(item, title) {
    $(item).tooltip('hide').attr('data-original-title', title).tooltip('fixTitle').tooltip('show');
}

function tooltipToRequired() {
    $('.required-icon').tooltip({
        placement: 'top',
        title: 'Requerido'
    });
}

function removeTooltips() {
    $(".tooltip").remove();
}

//TABLE ==================================================================
function truncateString(value, length, useWordBoundary) {
    length = (length == undefined || length == null) ? 16 : length;
    useWordBoundary = (useWordBoundary == undefined || useWordBoundary == null) ? false : useWordBoundary;

    if (value != undefined && value != null && (typeof value == "string" || value instanceof string !== false)) {
        var toLong = value.length > length;
        var s = toLong ? value.substr(0, length) : value;

        if (useWordBoundary) {
            s = useWordBoundary && toLong ? s.substr(0, s.lastIndexOf(' ')) : s;
        }

        value = toLong ? s + '&hellip;' : s;
    }

    return value;
}

//AJAX ==================================================================

function filterPerAjax(entity, data, callbackSuccess, callbackError) {
    $.ajax({
        url: root  + entity + '/Filter',
        type: requetType.Get,
        dataType: 'json',
        async: true,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function getPerAjax(entity, action, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/' + action,
        type: requetType.Get,
        dataType: 'json',
        async: true,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function deletePerAjax(entity, id, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/Delete',
        type: requetType.Post,
        async: true,
        data: { id: id },
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function changeStatusPerAjax(entity, id, status, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/ChangeStatus',
        type: requetType.Post,
        async: true,
        data: { id: id, status: status },
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function changeLoginTypePerAjax(loginType, callbackSuccess, callbackError) {
    $.ajax({
        url: root + "Account/ChangeLoginType",
        type: requetType.Post,
        async: true,
        data: { loginType: loginType },
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}
 
function savePerAjax(entity, callbackSuccess) {
    $.ajax({
        url: root + entity + '/Save',
        type: requetType.Post,
        async: true,
        data: $("#Form").serialize(),
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            alertError("No se ha podido establecer conexi&oacute;n con el servicio.");
        }
    });
}

function otherFilterPerAjax(entity, action, data, callbackSuccess, callbackError) {
    $.ajax({
        url: root + entity + '/' + action,
        type: requetType.Get,
        dataType: 'json',
        async: true,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (callbackSuccess) callbackSuccess(response);
        },
        error: function () {
            if (callbackError) callbackError();
            alertError("Error al intentar recuperar los registros.");
        }
    });
}

function checkResponseToAjax(response) {
    if (response.Result == resultType.LostSession || response.Result == resultType.InvalidSerial) {
        alertError(response.Message);
        setTimeout(function () {
            return window.location.href = root + session + "/Login/";
        }, 2000);
    } 
}

//NOTIFICATIONS ==================================================================
var options = { extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right', theme: 'flat' };

function alertInfo(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'info',
        showCloseButton: true
    });
}

function alertSuccess(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'success',
        showCloseButton: true
    });
}

function alertError(message) {
    Messenger.options = options;

    Messenger().post({
        message: message,
        type: 'error',
        showCloseButton: true
    });
}

function hideAllAlerts() {
    Messenger().hideAll();
}

//AJAX ==================================================================
$(document).ajaxSend(function () {
    addOpacity();
});
$(document).ajaxComplete(function () {
    clearOpacity();
});
$(document).ajaxSuccess(function (event, httpRequest, settings, response) {
    checkResponseToAjax(response);
});
