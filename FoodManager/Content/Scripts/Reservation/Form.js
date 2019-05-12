//ELEMENTS
var btnBuenComerElement = $(".btnGoodEat");
var selectableContentElement = $(".SelectableContent");
var btnhistoryElement = $(".btnHistory");
var btnCreateElement = $("#Create");
var inputsElement = $("#inputs");
var dealerIdElement = $("#DealerId");
var dateElement = $("#Date");

//VARIABLES
var mealTypeSaucer = "Platillo";
var selectableTemplate = [];
var callbackSelectize = function (response) {
    if (response.Count > 0) {
        var firstDealer = response.Records[0];
        var selectize = $("#DealerId")[0].selectize;
        var sltOption = { id: firstDealer.Id, title: firstDealer.Name };
        selectize.addOption(sltOption);
        selectize.addItem(parseInt(firstDealer.Id));
    }
    loadMenus();
    actionToChangeFilters();
};

//INSTANCES
createSelectize({ InputId: "DealerId", Data: { OnlyStatusActivated: true }, CallbackSelectize: callbackSelectize });
createDateRangePicker();
actionToClickToBtnGoodEat();
actionToClickToBtnHistory();
actionToClickBtnCreate();
createSlimScroll();
loadSaucerPie();
loadGeneralPie();
loadIngredientGroups();
showRandomTips();
submitButtons({ DisabledSelectize: true});
maxLength();
clearOpacity();

//INTERNAL
function actionToClickToBtnGoodEat() {
    btnBuenComerElement.click(function () {
        createModalMultimedia({
            Multimedias: [{ IsImage: true, Source: btnBuenComerElement.data("source") }],
            Title: "Plato del Buen Comer"
        });
    });
}

function actionToClickToBtnHistory() {
    btnhistoryElement.click(function () {
        var caloriesToProgressBar = 0;
        var reservations = { Selecteds: [] };

        $(".SelectableContent.selected").each(function() {
            var saucer = $(this).data("saucer");
            var mealTypeValue = $(this).closest(".SelectableContent").attr("data-mealtype");
            var mealTypeLabel = $(this).data("mealtypelabel");
            var portion = $(this).closest(".SelectableContent").attr("data-portion");

            var caloriesWithPortion = multiplyValues(portion, $(inputsElement).find("[name*='Reservations[" + saucer.Id + "_" + mealTypeValue + "].Energy']").val());
            caloriesToProgressBar = SumValues(caloriesToProgressBar, caloriesWithPortion);

            reservations.Selecteds.push({ Name: saucer.Name, MealType: mealTypeLabel, Type: saucer.TypeLabel, Calories: caloriesToProgressBar + " Kcal" });
        });



        createModalDetails({
            Title: "Historial del d&iacute;a",
            ObjectToRead: "Selecteds",
            Row: reservations,
            PorpertiesToRead: ["Name", "MealType", "Type", "Calories"],
            IsList:true
        });
    });
}

function actionToChangeFilters() {
    $(dealerIdElement.selector + "," + dateElement.selector).on('change', function () {
        inputsElement.html("");
        loadMenus();
        $("#SaucerPie").sparkline([100], {
            type: 'pie',
            height: 120,
            sliceColors: ['#A4A4A4']
        });

        $("#GeneralPie").sparkline([100], {
            type: 'pie',
            height: 200,
            sliceColors: ['#A4A4A4']
        });
    });
}

function actionToClickBtnCreate() {
    $("#Create").click(function (e) {
        e.preventDefault();
        var callbackSuccess = function(response) {
            alertSuccess(response.Message);
            $(dateElement).attr("disabled", false); $(dealerIdElement)[0].selectize.enable() 
        }
        savePerAjax("Reservation", callbackSuccess);
    });
}

function createSlimScroll() {
    $('.cards-selectable').slimScroll({
        height: '450px',
        width: "96.5%",
        size: '12px',
        railVisible: true,
        alwaysVisible: true
    }).bind('slimscroll', function (e, pos) {
        if (pos == "bottom") {
            //console.log($(e.currentTarget).find(".SelectableContent").length);
        }
    });
}
    
function loadMenus() {
    var entity = isGreaterThan($(dealerIdElement).val(), 0) ? "Menu" : "Saucer";
    var data = {
        DealerId: $(dealerIdElement).val(),
        Date: $(dateElement).val(),
        Sort: "ASC",
        SortBy: "Name"
    };

    var callbackSuccess = function (response) {
        $(".menuType").each(function (indexMenuType, elementMenuType) {
            removeTooltips();
            cleanTemplate();
            readRows(entity, elementMenuType, response.Records);
            insertTemplate(elementMenuType);
            createdCards();
        });
        loadInitialReservations();
    };
    otherFilterPerAjax("Reservation", "MenusOrSaucers", data, callbackSuccess);
}

function loadIngredientGroups() {
    var callbackSuccess = function (response) {
        var templateIngredientGroups = [];
        templateIngredientGroups.push("<span style=';border-radius:.25em; padding:1px 8px; color:#fff; background-color:#A4A4A4'>Sin elegir</span>");
        $(response.Records).each(function (index, ingredientGroup) {
            templateIngredientGroups.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + ingredientGroup.Color + "'>" + ingredientGroup.Name + "</span>");
        });

        $("#ingredientGroups").html(templateIngredientGroups.join(' '));
    };

    filterPerAjax("IngredientGroup", {}, callbackSuccess);
}

function showRandomTips() {

    var callbackSuccess = function (response) {
        var tipTemplate = "<strong>Recomendaci&oacute;n: </strong>";
        var defaultTip = "Una alimentaci&oacute;n sana es el mejor recurso para evitar todas las formas de malnutrici&oacute;n y sus enfermedades asociadas";

        if (response.Count > 0) {
            setInterval(function () {
                var rand = response.Records[Math.floor(Math.random() * response.Records.length)];
                $("#tip").html(tipTemplate + rand.Name);
            }, 30000);

            $("#tip").html(tipTemplate + response.Records[0].Name);
        } else {
            $("#tip").html(tipTemplate + defaultTip);
        }
    };

    filterPerAjax("Tip", {OnlyStatusActivated:true}, callbackSuccess);
}

function loadInitialReservations() {
    var data = {
        OnlyStatusActivated: true,
        DealerId: $(dealerIdElement).val(),
        WithoutDealer: !$(dealerIdElement).val() > 0,
        Date: $(dateElement).val(),
        Sort: "ASC",
        SortBy: "Name"
    };

    var callbackSuccess = function (response) {
        $(response.Records).each(function (index, element) {
            var mealType = element.MealType == 0 ? mealTypeSaucer : element.MealType;
            var selectableContent = $(".cardImage[data-saucerid='" + element.SaucerId + "'].mealtype_" + mealType).closest(".SelectableContent");

            selectableContent.attr("data-portion", element.Portion);
            selectableContent.find(".portion").html(element.Portion);

            if (element.Portion == minPortion)
                selectableContent.find(".btn-minus").attr("disabled", "disabled");

            selectableContent.find(".btn-check").trigger("click");
        });
        $(dateElement).attr("disabled", false);
        $(dealerIdElement)[0].selectize.enable();
        updateEnergyToSelecteds();
    };
    filterPerAjax("Reservation", data, callbackSuccess);
}

function createdCards() {
    var callbackToClickBtnCheck = function (selectableContent) {
        $(dateElement).attr("disabled", true);
        $(dealerIdElement)[0].selectize.disable();
        addReservation(selectableContent);
        generateGeneralPie();
    };

    var callbackToClickBtnDeselected = function (selectableContent) {
        $(dateElement).attr("disabled", true);
        $(dealerIdElement)[0].selectize.disable();
        removeReservation(selectableContent);
        updateEnergyToSelecteds();
        generateGeneralPie();
    };

    var callbackToClickThumbnail = function (selectableContent) {
        generateSaucerPie(selectableContent);
    };

    var callbackToClickMultimedia = function (selectableContent) {
        var saucer = $(selectableContent).closest(".SelectableContent").data("saucer");
        createModalMultimedia({
            Multimedias: saucer.SaucerMultimedias
        });
    };

    var callbackToClickBtnPlus = function (selectableContent) {
        generateSaucerPie(selectableContent);
        updateEnergyToSelecteds();
        generateGeneralPie();
    };

    var callbackToClickBtnMinus = function (selectableContent) {
        generateSaucerPie(selectableContent);
        updateEnergyToSelecteds();
        generateGeneralPie();
    };

    convertCardInSelectable({
        CallbackToClickBtnCheck: callbackToClickBtnCheck,
        CallbackToClickBtnDeselected: callbackToClickBtnDeselected,
        CallbackToClickThumbnail: callbackToClickThumbnail,
        CallbackToClickMultimedia: callbackToClickMultimedia,
        CallbackToClickBtnPlus: callbackToClickBtnPlus,
        CallbackToClickBtnMinus: callbackToClickBtnMinus,
        WidthImage: "auto",
        WidthDetail: "auto",
        StyleDetail: "color:#ccc; font-size:95%; left:0; font-weight: bold;position: absolute;top: 45px;background: rgba(0, 0, 0, 0.4);color: #fff;padding: 10px 15px;text-shadow: 0px 0px 2px rgba(0,0,0,0.3);",
        AttributeToRead:"saucer",
        WithCheck: true,
        WithDeselected: true,
        WithPortion: true,
        WithPositioned: true,
        WithStyleInText: true,
        WithImage: true,
        WithType: true
    });
}

function addReservation(selectableContent) {
    if ($(selectableContent).closest(".SelectableContent").hasClass("selected")) {
        var mealType = $(selectableContent).closest(".SelectableContent").attr("data-mealtype");
        var portion = $(selectableContent).closest(".SelectableContent").attr("data-portion");
        var saucer = $(selectableContent).closest(".SelectableContent").data("saucer");
        var saucerId = saucer.Id;
        var inputs = [];
        var caloriesByConfiguration = 0;
        $(saucer.SaucerConfigurations).each(function (index, element) {
            var caloriesByGram = dividerValues(element.Ingredient.Energy, element.Ingredient.NetWeight);
            caloriesByConfiguration = SumValues(caloriesByConfiguration, multiplyValues(caloriesByGram, element.NetWeight));
        });
        inputs.push('<input id="Reservations_Index" name="Reservations.Index" type="hidden" value="' + saucerId + '_' + mealType + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].Id" type="text" value="0">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].Date" type="text" value="' + dateElement.val() + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].SaucerId" type="text" value="' + saucerId + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].DealerId" type="text" value="' + dealerIdElement.val() + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].MealType" type="text" value="' + mealType + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].Portion" type="text" value="' + portion + '">');
        inputs.push('<input name="Reservations[' + saucerId + '_' + mealType + '].Energy" type="text" value="' + caloriesByConfiguration + '">');
            inputsElement.append(inputs.join(''));
            updateEnergyToSelecteds();
    }
};

function removeReservation(selectableContent) {
    var saucer = $(selectableContent).closest(".SelectableContent").data("saucer");
    var mealType = $(selectableContent).closest(".SelectableContent").attr("data-mealtype");
    var saucerId = saucer.Id;

    if (!$(selectableContent).closest(".SelectableContent").hasClass("selected")) {
        $(inputsElement).find("#Reservations_Index[value='" + saucerId + "_" + mealType + "']").remove();
        $(inputsElement).find("[name*='Reservations[" + saucerId + "_" + mealType + "]']").remove();
    }
};

function cleanTemplate() {
    selectableTemplate = [];
}

function readRows(entity, elementMenuType, records) {
    $(records).each(function (index, record) {
        var valueMenuType = $(elementMenuType).data("value");
        var recordType = entity == "Saucer" ? record.Type : record.Saucer.Type;
        if (valueMenuType == recordType) {
            createTemplate(entity, record);
        }
    });

    if (selectableTemplate.length == 0) {
        createAlternativeTemplate();
    }
}

function createTemplate(entity, record) {
    var saucer = entity == "Saucer" ? record : record.Saucer;
    var comment = entity == "Saucer" ? "" : record.Comment;
    var saucerMultimedias = entity == "Saucer" ? record.SaucerMultimedias : record.Saucer.SaucerMultimedias;
    var mealTypeLabel = entity == "Saucer" ? mealTypeSaucer : record.MealTypeLabel;
    var mealType = entity == "Saucer" ? mealTypeSaucer : record.MealType;
    var imagePreview = saucerMultimedias.length > 0 ? saucerMultimedias[0].Source : "";
    selectableTemplate.push("<div class='SelectableContent not-format' data-saucer='" + JSON.stringify(saucer) + "' data-portion='1' data-mealtype='" + mealType + "'  data-name='" + saucer.Name + "' data-comment='" + comment + "' data-mealtypelabel='" + mealTypeLabel + "' data-source='" + imagePreview + "' >");
    selectableTemplate.push("</div>");
}

function createAlternativeTemplate() {
    var sourcerEmpty = $("#Reservation").data("withoutsaucer");
    selectableTemplate.push("<div class='text-center text-muted' style='font-size:30px;'>");
    selectableTemplate.push("<div style='opacity: .4;'>Sin elementos</div>");
    selectableTemplate.push("<img src='" + sourcerEmpty + "' alt='' />");
    selectableTemplate.push("</div>");
}

function insertTemplate(elementMenuType) {
    $(elementMenuType).find(".cards-selectable").html(selectableTemplate.join(''));
}

//PIES
function loadSaucerPie(values, colors) {
    values = values && values.length > 0 ? values : defaultValuePie;
    colors = colors && colors.length > 0 ? colors : defaultColorPie;

    $("#SaucerPie").sparkline(values, {
        type: 'pie',
        height: 120,
        sliceColors: colors
    });
}

function loadGeneralPie(values, colors) {
    values = values && values.length > 0 ? values : defaultValuePie;
    colors = colors && colors.length > 0 ? colors : defaultColorPie;

    $("#GeneralPie").sparkline(values, {
        type: 'pie',
        height: 200,
        sliceColors: colors
    });
}

function generateSaucerPie(selectableContent) {
    var ingredientIds = [];
    var calories = [];
    var colors = [];
    var saucer = $(selectableContent).data("saucer");
    var portion = $(selectableContent).attr("data-portion");
    var hasSaucerConfiguration = saucer.SaucerConfigurations.length > 0;

    if (hasSaucerConfiguration) {
        var callbacktToSuccessIngredient = function(responseIngredient) {
            $(responseIngredient.Records).each(function(indexIngredient, elementIngredient) {
                var netWeightToSaucerConfiguration = saucer.SaucerConfigurations.First("['IngredientId']=='" + elementIngredient.Id + "'").NetWeight;
                var colorToIngredientGroup = elementIngredient.IngredientGroup.Color;
                var existsColorInArray = elementExistInArray(colorToIngredientGroup, colors);
                var caloriesByGram = dividerValues(elementIngredient.Energy, elementIngredient.NetWeight);
                var caloriesToConfiguration = multiplyValues(caloriesByGram, netWeightToSaucerConfiguration);
                var caloriesToConfigurationWithPortion = multiplyValues(caloriesToConfiguration, portion);
                if (existsColorInArray) {
                    var indexToColor = jQuery.inArray(colorToIngredientGroup, colors);
                    calories[indexToColor] = SumValues(calories[indexToColor], caloriesToConfigurationWithPortion);
                } else {
                    calories.push(caloriesToConfigurationWithPortion);
                    colors.push(colorToIngredientGroup);
                }
            });
            loadSaucerPie(calories, colors);
        };

        $(saucer.SaucerConfigurations).each(function(index, saucerConfiguration) {
            ingredientIds.push(saucerConfiguration.IngredientId);
        });
        filterPerAjax("Ingredient", { WithIds: ingredientIds.join(",") }, callbacktToSuccessIngredient);
    } else {
        loadSaucerPie();
    }
}

function generateGeneralPie() {
    var calories = [];
    var colors = [];
    var selecteds = $(".SelectableContent.selected");
    var hasSelecteds = selecteds.length > 0;
    if (hasSelecteds) {
        $(selecteds).each(function(indexSelectable, selectableContent) {
            var ingredientIds = [];
            var saucer = $(selectableContent).data("saucer");
            var portion = $(selectableContent).attr("data-portion");
            var hasSaucerConfiguration = saucer.SaucerConfigurations.length > 0;

            if (hasSaucerConfiguration) {
                var callbacktToSuccessIngredient = function(responseIngredient) {
                    $(responseIngredient.Records).each(function(indexIngredient, elementIngredient) {
                        var netWeightToSaucerConfiguration = saucer.SaucerConfigurations.First("['IngredientId']=='" + elementIngredient.Id + "'").NetWeight;
                        var colorToIngredientGroup = elementIngredient.IngredientGroup.Color;
                        var existsColorInArray = elementExistInArray(colorToIngredientGroup, colors);
                        var caloriesByGram = dividerValues(elementIngredient.Energy, elementIngredient.NetWeight);
                        var caloriesToConfiguration = multiplyValues(caloriesByGram, netWeightToSaucerConfiguration);
                        var caloriesToConfigurationWithPortion = multiplyValues(caloriesToConfiguration, portion);
                        if (existsColorInArray) {
                            var indexToColor = jQuery.inArray(colorToIngredientGroup, colors);
                            calories[indexToColor] = SumValues(calories[indexToColor], caloriesToConfigurationWithPortion);
                        } else {
                            calories.push(caloriesToConfigurationWithPortion);
                            colors.push(colorToIngredientGroup);
                        }
                    });
                    loadGeneralPie(calories, colors);
                };

                $(saucer.SaucerConfigurations).each(function(index, saucerConfiguration) {
                    ingredientIds.push(saucerConfiguration.IngredientId);
                });
                filterPerAjax("Ingredient", { WithIds: ingredientIds.join(",") }, callbacktToSuccessIngredient);
            } else {
                loadGeneralPie();
            }
        });
    } else {
        loadGeneralPie();
    }
}

//PROGRESS BAR
function updateEnergyToSelecteds() {
    var title = "";
    var caloriesToProgressBar = 0;
    var mealTypes = [];
    var mealTypeValues = [];
    var typeLabels = [];
    $(".SelectableContent.selected").each(function () {
        var selectableContent = this;
        var mealTypeValue = $(selectableContent).closest(".SelectableContent").attr("data-mealtype");
        var mealTypeLabel = $(selectableContent).closest(".SelectableContent").attr("data-mealtypelabel");
        var portion = $(selectableContent).closest(".SelectableContent").attr("data-portion");
        var saucer = $(selectableContent).closest(".SelectableContent").data("saucer");
        var existsMealTypeInArray = elementExistInArray(mealTypeValues, mealTypes);
        var saucerId = saucer.Id;
        var caloriesWithPortion = multiplyValues(portion, $(inputsElement).find("[name*='Reservations[" + saucerId + "_" + mealTypeValue + "].Energy']").val());
        caloriesToProgressBar = SumValues(caloriesToProgressBar, caloriesWithPortion);

        if (existsMealTypeInArray) {
            var indexToMealType = jQuery.inArray(mealTypeLabel, mealTypeValues);
            mealTypeValues[indexToMealType] = SumValues(mealTypeValues[indexToMealType], caloriesWithPortion);
        } else {
            mealTypeValues.push(caloriesWithPortion);
            mealTypes.push(mealTypeLabel);
            typeLabels.push(saucer.TypeLabel)
        }
    });

    $(mealTypes).each(function (index) { title += mealTypes[index] + "/" + typeLabels[index] + ": " + mealTypeValues[index] + " Kcal</br>"; });
    $(".progress").tooltip('hide').attr('data-original-title', title).tooltip('fixTitle');

    updateProgressBar({
        ProgressBarId: "#progress-bar-energy",
        Percentage: caloriesToProgressBar,
        MaxPercentage: $("#progress-bar-energy").data("maxpercentage"),
        WithAlert: true
    });
}



