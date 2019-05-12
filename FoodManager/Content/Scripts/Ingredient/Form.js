//ELEMENTS
var unitElement = $("#Unit");

//VARIABLES
var callbackSelectize = function () { UnitTextResolver(); };

//INSTANCES
validateForm({ Name: true, NetWeight:true, Energy: true, Protein: true, Carbohydrate: true, Sugar: true, Lipid: true, Sodium: true, IngredientGroup: true, Unit: true });
createSelectize({ InputId: "IngredientGroupId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "Unit", ValueField: "Value", CallbackSelectize: callbackSelectize });
createTouchSpin({ Postfix: gram, Decimals: 2, Step: 0.01 });
createTouchSpin({ Element:"#Energy", Postfix: kiloCalorie, Decimals: 2, Step: 0.01 });
eventToChangeUnit();
maxLength();
submitButtons();
tooltipToRequired();
clearOpacity();

//INTERNAL
function eventToChangeUnit() {
   
    unitElement.change(function() {
        UnitTextResolver();
    });
}

function UnitTextResolver() {
    var postFixCustomElement = $(".postFixCustom").closest(".touchspinCustom").find(".bootstrap-touchspin-postfix");
    if (unitElement.val() > 0) {
        var selectize = $(unitElement)[0].selectize;
        var tag = selectize.getItem(selectize.getValue());
        var text = tag.text();

        $(postFixCustomElement).html(text);
    } else {
        $(postFixCustomElement).html("-");
    }
}