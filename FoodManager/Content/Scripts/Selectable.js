function convertCardInSelectable(options) {
    //VARIABLES
    var attributeToRead = "";
    var propertiesToRead = "";
    var classCol = "col-sm-6";
    var widthDetail = "45%";
    var displayDetail = "inline-block";
    var styleDetail = "";
    var widthImage = "55%";
    var withStyleInText = "";
    var witCheck = false;
    var withRemove = false;
    var withDeselected = false;
    var withPortion = false;
    var withNetWeight = false;
    var withPositioned = false;
    var withImage = false;
    var withType = false;
    var callbackToClickBtnCheck = false;
    var callbackToClickBtnDeselected = false;
    var callbackToClickThumbnail = false;
    var callbackToClickMultimedia = false;
    var callbackToClickBtnPlus = false;
    var callbackToClickBtnMinus = false;

    //OPTIONS
    if (options) {
        if (options.AttributeToRead) attributeToRead = options.AttributeToRead;
        if (options.PropertiesToRead) propertiesToRead = options.PropertiesToRead;
        if (options.ClassCol) classCol = options.ClassCol;
        if (options.WidthDetail) widthDetail = options.WidthDetail;
        if (options.DisplayDetail) displayDetail = options.DisplayDetail;
        if (options.StyleDetail) styleDetail = options.StyleDetail;
        if (options.WidthImage) widthImage = options.WidthImage;
        if (options.WithCheck) witCheck = options.WithCheck;
        if (options.WithRemove) withRemove = options.WithRemove;
        if (options.WithDeselected) withDeselected = options.WithDeselected;
        if (options.WithPortion) withPortion = options.WithPortion;
        if (options.WithNetWeight) withNetWeight = options.WithNetWeight;
        if (options.WithPositioned) withPositioned = options.WithPositioned;
        if (options.WithImage) withImage = options.WithImage;
        if (options.WithType) withType = options.WithType;
        if (options.CallbackToClickBtnCheck) callbackToClickBtnCheck = options.CallbackToClickBtnCheck;
        if (options.CallbackToClickBtnDeselected) callbackToClickBtnDeselected = options.CallbackToClickBtnDeselected;
        if (options.CallbackToClickThumbnail) callbackToClickThumbnail = options.CallbackToClickThumbnail;
        if (options.CallbackToClickMultimedia) callbackToClickMultimedia = options.CallbackToClickMultimedia;
        if (options.CallbackToClickBtnPlus) callbackToClickBtnPlus = options.CallbackToClickBtnPlus;
        if (options.CallbackToClickBtnMinus) callbackToClickBtnMinus = options.CallbackToClickBtnMinus;
        if (options.WithStyleInText) withStyleInText = "margin-left:-4px;width: 100%; font-weight: bold;position: absolute;bottom: 0px;background: rgba(0, 0, 0, 0.4);color: #fff;padding: 10px 15px;text-shadow: 0px 0px 2px rgba(0,0,0,0.3); ";
    }

    //INTERNAL
    function appendCards() {
        $(".SelectableContent.not-format").each(function () {
            var styleButton = "z-index: 1000; position: relative;float: right;margin-top: -10px; margin-left: 5px;";
            var element = $(this);
            var body = [];
            var card = [];
            var portion = $(element).data("portion");
            var netWeight = $(element).data("netweight");
            var name = $(element).data("name");
            var type = $(element).data("type");
            var mealType = $(element).closest(".SelectableContent").attr("data-mealtype");
            var source = $(element).data("source") == "" ? '<i class="fa fa-file-image-o" style="font-size: 139px;opacity: .1;color: #000;"></i>' : '<img src="' + $(element).data("source") + '" alt="" style="max-width: 328px; margin:-18px 0px -53px -4px;height: 210px;">';
            var comment = $(element).data("comment") ? " - <span style='color:#ccc; font-size:95%;'>" + $(element).data("comment") + "</span>" : "";
            var row = $(element).data(attributeToRead);

            if (withPortion) {
                body.push('<span>Porci&oacute;n:</span><span class="portion"> ' + portion + '</span>');
            }

            $(propertiesToRead).each(function (indexEmlement, property) {
                var label = property.split(",")[0];
                var value = property.split(",")[1];
                if (withPortion)
                    extractValue(value, row, portion);
                else if (withNetWeight)
                    extractValue(value, row, false, netWeight);
                else
                    extractValue(value, row);
                body.push((label != '' ? label + ': ' : '') + '<div class="text-muted">' + valueExtracted + ' </div><br/>');
            });

            card.push('<div class="' + classCol + '">');
            if (witCheck) {
                card.push('<a class="btn btn-sm btn-success btn-check" data-toggle="tooltip" title="Seleccionar" style="' + styleButton + '">');
                card.push('<i class="fa fa-check"></i>');
                card.push('</a>');
            }
            if (withRemove) {
                card.push('<a class="btn btn-sm btn-danger btn-remove" data-toggle="tooltip" title="Remover" style="' + styleButton + '">');
                card.push('<i class="fa fa-times"></i>');
                card.push('</a>');
            }
            if (withDeselected) {
                card.push('<a class="btn btn-sm btn-danger btn-deselected" data-toggle="tooltip" title="Deseleccionar" style="' + styleButton + '">');
                card.push('<i class="fa fa-times"></i>');
                card.push('</a>');
            }
            if (withPortion) {
                card.push('<a data-saucerid="' + row.Id + '" class="btn btn-sm btn-primary btn-plus" data-toggle="tooltip" title="Aumentar porci&oacute;n" style="' + styleButton + '">');
                card.push('<i class="fa fa-plus"></i>');
                card.push('</a>');
                card.push('<a data-saucerid="' + row.Id + '" class="btn btn-sm btn-primary btn-minus" data-toggle="tooltip" title="Disminuir porci&oacute;n"  style="' + styleButton + '">');
                card.push('<i class="fa fa-minus"></i>');
                card.push('</a>');
            }
            if (withImage) {
                card.push('<a class="btn btn-sm btn-primary btn-multimedia" data-toggle="tooltip" title="Ver multimedias" style="' + styleButton + '">');
                card.push('<i class="fa fa-picture-o"></i>');
                card.push('</a>');
            }
            card.push('<a data-toggle="tooltip" data-html="true" title="' + name + comment + '" class="thumbnail text-center iconPointer" style="position: relative; text-decoration: none; padding-top:18px; padding-bottom:18px;">');
            card.push('<div style="' + withStyleInText + '">' + truncateString(name, 22) + '</div>');

            if (withType) {
                type = type ? type : "Platillo";
                card.push('<span style="color:#ccc; font-size:95%; left:0; font-weight: bold;position: absolute;top: 0px;background: rgba(0, 0, 0, 0.4);color: #fff;padding: 10px 15px;text-shadow: 0px 0px 2px rgba(0,0,0,0.3);">' + type + '</span>');
            }
            if (withImage) {
                card.push('<div data-saucerid="' + row.Id + '" class="cardImage mealtype_' + mealType + '" style="margin-bottom: 36px;width: ' + widthImage + '">' + source + '</div>');
            }
            card.push('<div class="cardDetail" style="' + styleDetail + ' display:' + displayDetail + '; width: ' + widthDetail + ';">');
            card.push(body.join(''));
            card.push('</div>');
            card.push('</a>');
            card.push('</div>');
            $(element).append(card.join(''));
            addToolTips();
        });
    }

    function eventToClickMultimedia() {
        $(".SelectableContent.not-format div .btn-multimedia").click(function () {
            if (callbackToClickMultimedia) callbackToClickMultimedia(this);
        });
    }

    function eventToClickThumbnail() {
        $(".SelectableContent.not-format div .thumbnail").click(function () {
            var selectableContent = $(this).closest(".SelectableContent");
            $(".SelectableContent.positioned").each(function () {
                $(this).removeClass("positioned");
            });

            selectableContent.addClass("positioned");
            if (callbackToClickThumbnail) callbackToClickThumbnail(selectableContent);
        });
    }

    function eventToClickBtnCheck() {
        $(".SelectableContent.not-format div .btn-check").click(function () {
            var selectableContent = $(this).closest(".SelectableContent");

            removeTooltips();
            selectableContent.removeClass("positioned");
            selectableContent.addClass("selected");
            if (callbackToClickBtnCheck) callbackToClickBtnCheck(selectableContent);
        });
    }

    function eventToClickBtnRemove() {
        $(".SelectableContent.not-format div .btn-remove").click(function () {
            $(this).closest(".SelectableContent").remove();
            removeTooltips();
        });
    }

    function eventToClickBtnDeselected() {
        $(".SelectableContent.not-format div .btn-deselected").click(function () {
            var selectableContent = $(this).closest(".SelectableContent");
            selectableContent.removeClass("selected");
            if ($(".SelectableContent.positioned").length == 0) {
                selectableContent.addClass("positioned");
            }
            removeTooltips();
            if (callbackToClickBtnDeselected) callbackToClickBtnDeselected(selectableContent);
        });
    }

    function eventToClickBtnPlus() {
        $(".SelectableContent.not-format div .btn-plus").click(function () {
            var selectableContent = $(this).closest(".SelectableContent");
            var saucerId = $(this).attr("data-saucerid");
            var portion = selectableContent.attr("data-portion");
            var mealType = selectableContent.closest(".SelectableContent").attr("data-mealtype");
            selectableContent.find(".portion").html(SumValues(portion, .50));
            selectableContent.attr("data-portion", SumValues(portion, .50));
            $("[name='Reservations[" + saucerId + "_" + mealType + "].Portion']").attr("value", SumValues(portion, .50));
            selectableContent.find(".btn-minus").removeAttr("disabled");
            if (callbackToClickBtnPlus) callbackToClickBtnPlus(selectableContent);
        });
    }

    function eventToClickBtnMinus() {
        $(".SelectableContent.not-format div .btn-minus").click(function () {
            var selectableContent = $(this).closest(".SelectableContent");
            var saucerId = $(this).attr("data-saucerid");
            var portion = selectableContent.attr("data-portion");
            var mealType = selectableContent.closest(".SelectableContent").attr("data-mealtype");
            var portionToInsert = deductValues(portion, .50);

            if (portionToInsert == minPortion)
                $(this).attr("disabled", "disabled");

            if (portionToInsert >= minPortion) {
                selectableContent.find(".portion").html(portionToInsert);
                selectableContent.attr("data-portion", portionToInsert);
                $("[name='Reservations[" + saucerId + "_" + mealType + "].Portion']").attr("value", portionToInsert);
            }

            if (callbackToClickBtnMinus) callbackToClickBtnMinus(selectableContent);

        });
    }

    //INSTANCE
    appendCards();
    if (!$("#cards-selectable").hasClass("disable-actions")) {
        if (withPositioned) {
            eventToClickThumbnail();
        }
        eventToClickMultimedia();
        eventToClickBtnCheck();
        eventToClickBtnRemove();
        eventToClickBtnDeselected();
        eventToClickBtnPlus();
        eventToClickBtnMinus();
    }
    $(".SelectableContent.not-format").removeClass("not-format");
}