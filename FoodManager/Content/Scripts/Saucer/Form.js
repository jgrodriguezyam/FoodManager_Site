//ELEMENTS
var btnAddMultimediaElement = $("#btnAddMultimedia");
var btnAddIngredientElement = $("#btnAddIngredient");
var multimediaContentElement = $("#MultimediaContent");
var idElement = $("#Saucer_Id");

//INSTANCES
validateForm({ Name: true, Type: true });
loadInitialMultimedias();
createdCards();
eventToClickBtnAddMultimedia();
eventToClickBtnAddIngredient();
maxLength();
submitButtons();
tooltipToRequired();
clearOpacity();

//INTERNAL
function loadInitialMultimedias() {
    convertMultimediaInCards();
}

function eventToClickBtnAddMultimedia() {
    if ($(btnAddMultimediaElement).attr("disabled") != "disabled") {
        $(btnAddMultimediaElement).click(function () {
            removeMultimedia();
            addMultimedia();
        });
    }
}

function addMultimedia() {
    var index = $(".multimedia-preview").length;
    var inputs = [];

    inputs.push('<div class="multimedia-preview withoutCard">');
    inputs.push('<input name="SaucerMultimedias.Index" type="hidden" value="' + index + '"/>');
    inputs.push('<input type="file" name="SaucerMultimedias[' + index + '].FileBase" class="hide multimediaVoid" accept="' + allowedFileExtensions + '"/>');
    inputs.push('</div>');

    multimediaContentElement.append(inputs.join(''));
    $('[name="SaucerMultimedias[' + index + '].FileBase"]').trigger("click");
    eventToSelectFile(index);
}

function removeMultimedia() {
    $(".multimediaVoid").closest(".multimedia-preview").remove();
}

function eventToSelectFile(index) {
    $("[name='SaucerMultimedias[" + index + "].FileBase']").change(function () {
        var isvalidFile = true;
        var fileToClick = $(this);
        var files = $(this)[0].files;
        validFileType();

        if (isvalidFile) {
            $.each(files, function (i, item) {
                validAllowedFileExtensions(item);
                validMaxRequestLength(item);
                if (isvalidFile) {
                    var reader = new FileReader();
                    reader.onload = function(e) {
                        $(fileToClick).closest(".multimedia-preview").attr('data-source', e.target.result).attr('data-path', e.target.result).attr('data-type', resolveFileType(item));
                        convertMultimediaInCards({ OtherClass: ".withoutCard" });
                        $(fileToClick).removeClass("multimediaVoid").closest(".multimedia-preview").removeClass("withoutCard");
                        $(fileToClick).closest(".multimedia-preview").removeAttr('data-source').removeAttr('data-href');
                    };
                    reader.readAsDataURL(item);
                } else {
                    removeMultimedia();
                }
            });
        }

        function validFileType() {
            if (!files || files.length == 0) {
                removeMultimedia();
                isvalidFile = false;
            } 
        }

        function validAllowedFileExtensions(item) {
            if (!elementExistInArray(item.type, allowedFileExtensions.replace(/ /g, "").split(","))) {
                removeMultimedia();
                var extensions = [];

                $(allowedFileExtensions.replace(/ /g, "").split(",")).each(function (indexExtension, element) {
                    extensions.push(element.replace(element.split("/")[0], ".").replace("/", ""));
                });

                alertInfo("Extensiones permitidas " + extensions.join(" "));
                isvalidFile = false;
            }
        }

        function validMaxRequestLength(item) {
            if (isGreaterThan(item.size, maxrequestlength)) {
                removeMultimedia();
                alertInfo("El archivo multimedia es muy grande, seleccionar uno de menor tama&ntilde;o.");
                isvalidFile = false;
            }
        }

    });
}

function eventToClickBtnAddIngredient() {
    if ($(btnAddIngredientElement).attr("disabled") !== "disabled") {
        $(btnAddIngredientElement).click(function () {

            var message = "<div id='Ingredient' style='margin: 0 13px;'>";
            message += "<div class='container-fluid'>";
            message += "<div class='row'>";
            message += "<div class='col-lg-9 container-left'><input type='text' id='Name' class='form-control' data-role='none' placeholder='Nombre' autocomplete='off'></div>";
            message += "<div class='col-lg-2 container-right'><button type='button' class='btn btn-info btn-block btnFilter'><i class='fa fa-filter'></i> Filtrar</button></div>";
            message += "</div>";
            message += "</div>";
            message += "<table id='Table'></table>";
            message += "</div>";

            createDialog({
                Title: "Asignar Ingredientes",
                Message: message,
                WithScroll: true,
                Onshown: function() {
                    createTable({
                        Controller: "Ingredient",
                        Buttons: { Assign: true, NetWeight: true },
                        Columns: ["Name"],
                        Filters: ["Name"],
                        SortingAndPagination: { SortBy: "Name" }
                    });

                }
            });


        });
    }
}

function createdCards() {
    convertCardInSelectable({
        AttributeToRead: "ingredient",
        PropertiesToRead: ["Peso neto,NetWeight", "Energ&iacute;a,Energy", "Prote&iacute;nas,Protein", "Carbohidratos,Carbohydrate", "Az&uacute;car,Sugar", "L&iacute;pidos,Lipid", "Sodio,Sodium"],
        ClassCol: "col-md-3",
        WidthDetail: "100%",
        StyleDetail: "font-size:95%;",
        WithRemove: true,
        WithNetWeight:true
    });
}

