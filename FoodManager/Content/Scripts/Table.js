var objects = ["Role", "Dealer", "Region", "Company", "Department", "Job", "Disease", "Worker", "Branch", "Tip", "Warning", "Ingredient", "IngredientGroup", "Saucer", "SaucerConfiguration"];

var displayTitle = {
    Code: "C&oacute;digo",
    Name: "Nombre",
    FirstName: "Nombre",
    LastName: "Apellidos",
    UserName: "Alias",
    Email: "Correo",
    Color: "Color",
    TypeLabel: "Tipo",
    MealTypeLabel: "Tipo",
    DayWeekLabel: "D&iacute;a",
    StartDate: "Fecha inicio",
    EndDate: "Fecha fin",
    Role: "Rol",
    Dealer: "Concesionario",
    Region: "Regi&oacute;n",
    Company: "Compa&ntilde;&iacute;a",
    Department: "Departamento",
    Job: "Puesto",
    Disease: "Enfermedad",
    Worker: "Colaborador",
    Branch: "Sucursal",
    Tip: "Consejo",
    Warning: "Advertencia",
    IngredientGroup: "Grupo",
    Saucer: "Platillo",
    LimitEnergy: "Ingesta Calorica",
    FullName: "Nombre",
    Imss: "NSS",
    BranchId: "Id Sucursal",
    CompanyToWorker: "Compañía"
};

function createTable(options) {

    //VARIABLES
    var tableId = "#Table";
    var controller = "";
    var action = "Filter";
    var configurationToDetailsButton = { TitleTooltip: "Detalles", IsList: false, ObjectToRead: "", PorpertiesToRead: [], Icon: "list-ul" };
    var configurationToSecondDetailsButton = { TitleTooltip: "Detalles", IsList: false, ObjectToRead: "", PorpertiesToRead: [], Icon: "list-ul" };
    var cardView = { ApplyCardView: false, IsCardView: false, WidthPerApply: 800 };
    var sortingAndPagination = { StartPage: "1", EndPage: "10", SortBy: "Id", Sort: "ASC" };
    var filters = [];
    var clickToSelect = false;
    var columns = [];
    var buttons = { OperateEvents: {} };

    //OPTIONS
    if (options.TableId) tableId = options.TableId;
    if (options.Controller) controller = options.Controller;
    if (options.Action) action = options.Action;
    if (options.Filters) filters = options.Filters;

    //CHECKBOX
    if (options.ClickToSelect) {
        clickToSelect = options.ClickToSelect;
        eventToClickDeleteMany();
        addCheck();
    }

    //COLUMNS
    if (options.Columns) {
        $(options.Columns).each(function (index, column) {

            if (elementExistInArray(column, objects)) {
                addColumnByObject(column, displayTitle[column]);
            } else if (column == "Color") {
                addColor();
            } else {
                addColumn(column, displayTitle[column]);
            }
        });
    }

    //BUTTONS
    if (options.Buttons) {
        var widthButtons = 45;
        if (options.Buttons.NetWeight) addNetWeight();
        if (options.Buttons.ChangeStatus) addStatus();
        if (options.Buttons.Details) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.SecondDetails) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.Multimedia) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.ChangeStatus) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.Edit) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.EditDisabled) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.Delete) widthButtons = SumValues(widthButtons, 30);
        if (options.Buttons.Assign) widthButtons = SumValues(widthButtons, 30);

        columns.push({
            field: 'Buttons',
            title: 'Operaciones',
            align: 'center',
            valign: 'middle',
            width: widthButtons,
            clickToSelect: false,
            formatter: function(value, row) {
                var formatter = "<div class='buttonsColumn' style='min-width:" + widthButtons + "px'>";
                if (options.Buttons.Details) formatter += addButtonDetails();
                if (options.Buttons.SecondDetails) formatter += addSecondButtonDetails(row);
                if (options.Buttons.Multimedia) formatter += addButtonMultimedia(row);
                if (options.Buttons.ChangeStatus) formatter += addButtonChangeStatus(row);
                if (options.Buttons.Edit) formatter += addButtonEdit();
                if (options.Buttons.EditDisabled) formatter += addButtonEditDisabled(row);
                if (options.Buttons.Delete) formatter += addButtonDelete(row);
                if (options.Buttons.Assign) formatter += addButtonAssign(row);
                formatter += "</div>";

                return formatter;
            },
            events: window.operateEvents = buttons.OperateEvents
        });
    }

    //CONFIGURATIONTODETAILSBUTTON
    if (options.ConfigurationToDetailsButton) {
        if (options.ConfigurationToDetailsButton.TitleTooltip) configurationToDetailsButton.TitleTooltip = options.ConfigurationToDetailsButton.TitleTooltip;
        if (options.ConfigurationToDetailsButton.IsList) configurationToDetailsButton.IsList = options.ConfigurationToDetailsButton.IsList;
        if (options.ConfigurationToDetailsButton.ObjectToRead) configurationToDetailsButton.ObjectToRead = options.ConfigurationToDetailsButton.ObjectToRead;
        if (options.ConfigurationToDetailsButton.PorpertiesToRead) configurationToDetailsButton.PorpertiesToRead = options.ConfigurationToDetailsButton.PorpertiesToRead;
        if (options.ConfigurationToDetailsButton.Icon) configurationToDetailsButton.Icon = options.ConfigurationToDetailsButton.Icon;
    }

    if (options.ConfigurationToSecondDetailsButton) {
        if (options.ConfigurationToSecondDetailsButton.TitleTooltip) configurationToSecondDetailsButton.TitleTooltip = options.ConfigurationToSecondDetailsButton.TitleTooltip;
        if (options.ConfigurationToSecondDetailsButton.IsList) configurationToSecondDetailsButton.IsList = options.ConfigurationToSecondDetailsButton.IsList;
        if (options.ConfigurationToSecondDetailsButton.ObjectToRead) configurationToSecondDetailsButton.ObjectToRead = options.ConfigurationToSecondDetailsButton.ObjectToRead;
        if (options.ConfigurationToSecondDetailsButton.PorpertiesToRead) configurationToSecondDetailsButton.PorpertiesToRead = options.ConfigurationToSecondDetailsButton.PorpertiesToRead;
        if (options.ConfigurationToSecondDetailsButton.Icon) configurationToSecondDetailsButton.Icon = options.ConfigurationToSecondDetailsButton.Icon;
    }

    //CARDVIEW
    if (options.CardView) {
        if (options.CardView.ApplyCardView) cardView.ApplyCardView = options.CardView.ApplyCardView;
        if (options.CardView.WidthPerApply) cardView.WidthPerApply = options.CardView.WidthPerApply;
    }

    //QUERY
    if (options.SortingAndPagination) {
        if (options.SortingAndPagination.StartPage) sortingAndPagination.StartPage = options.SortingAndPagination.StartPage;
        if (options.SortingAndPagination.EndPage) sortingAndPagination.EndPage = options.SortingAndPagination.EndPage;
        if (options.SortingAndPagination.SortBy) sortingAndPagination.SortBy = options.SortingAndPagination.SortBy;
        if (options.SortingAndPagination.Sort) sortingAndPagination.Sort = options.SortingAndPagination.Sort;
    }

    //INSTANCE
    $("#" + controller).find(tableId).bootstrapTable({
        method: 'Get',
        url: root + controller + "/" + action,
        classes: "withoutBorder table table-hover",
        showColumns: false,
        showExport: false,
        cardView: cardView.ApplyCardView && $(window).width() < cardView.WidthPerApply,
        checkboxEnable: true,
        checkboxHeader: true,
        showToggle: false,
        cache: false,
        striped: true,
        exportTypes: ['excel'],
        clickToSelect: clickToSelect,
        pagination: true,
        pageSize: 10,
        pageList: [10, 25, 50, 100, 200],
        iconSize: "sm",
        sidePagination: "server",
        minimumCountColumns: 2,
        rowStyle: function(row) {
            if (clickToSelect) {
                if (row.IsReference) {
                    return { classes: 'inactive' };
                } else {
                    return { classes: 'active' };
                }
            }
            return { classes: '' };
        },
        queryParams: function(params) {
            addOpacity();
            params.StartPage = sortingAndPagination.StartPage != 0 ? params.offset + 1 : 0;
            params.EndPage = sortingAndPagination.EndPage != 0 ? params.limit + params.offset : 0;
            params.SortBy = params.sort != undefined ? params.sort : sortingAndPagination.SortBy;
            params.Sort = sortingAndPagination.Sort.toUpperCase();

            $(filters).each(function(index, filter) {
                params[filter] = $("#" + controller).find("#" + filter).val();
            });

            return params;
        },
        responseHandler: function(response) {
            checkResponseToAjax(response);
            if (response.Result == resultType.Ok) {
                $("#" + controller).find(tableId).parent().parent().show();
                actionToResizaWindow();
                toggleDeleteMany();
                clearOpacity();
                return { rows: response.Records, total: response.Count };
            }
            $("#" + controller).find(tableId + "Loading").html("<i class='fa fa-warning'></i> " + response.Message + "...</span> ");
            checkResponseToAjax(response);
            clearOpacity();
            return null;
        },
        columns: columns
    }).on('load-success.bs.table', function() {
        eventToLoadSuccessTable();
        styleModal();
    }).on('check.bs.table uncheck.bs.table uncheck-all.bs.table load-error.bs.table', function() {
        eventToManyEventsTable();
    }).on('check-all.bs.table', function() {
        eventToCheckAllTable();
    });

    showLoading();
    eventToClickFilter();
    eventToClickExport();

    //INTERNAL
    function showLoading() {
        $(".fixed-table-container").hide();
        $("#" + controller).find(tableId + "LoadingText").html(" Cargando registros...");
    };

    function eventToClickToPageList() {
        $(".dropdown-page-list li a").click(function() {
            removeTooltips();
        });
    };

    function actionToResizaWindow() {
        removeTooltips();

        $(window).resize(function() {
            if ($("#" + controller).find(tableId).width() < cardView.WidthPerApply && cardView.ApplyCardView && !cardView.IsCardView) {
                $("#" + controller).find(tableId).bootstrapTable('toggleView');
                addToolTips();
                aplyStyleToCardView();
            }

            if ($("#" + controller).find(tableId).width() > cardView.WidthPerApply && cardView.ApplyCardView && cardView.IsCardView) {
                $("#" + controller).find(tableId).bootstrapTable('toggleView');
                addToolTips();
                aplyStyleToTableView();
            }
        });
    }

    function pageListHover() {
        $('.page-list .dropup').hover(function() {
            $(this).addClass("open");
        }, function() {
            $(this).removeClass("open");
        });
    }

    function eventToLoadSuccessTable() {
        $("#" + controller).find(tableId + "Loading").hide();
        if (cardView.ApplyCardView && $(window).width() < cardView.WidthPerApply)
            aplyStyleToCardView();
        eventToClickToPageList();
        addToolTips();
        addTouchSpin();
        pageListHover();
    }

    function eventToCheckAllTable() {
        var selectedRows = $("#" + controller).find(tableId).find('tr[class="inactive"]');
        $(selectedRows).each(function(index, element) {
            $("#" + controller).find(tableId).bootstrapTable('uncheck', $(element).data("index"));
        });
        toggleDeleteMany();
    }

    function eventToManyEventsTable() {
        toggleDeleteMany();
    }

    function styleModal() {
        if ($("#cards-selectable").length > 0) {
            $("#" + controller).find("thead").remove();
            $('.bootstrap-dialog-message').slimScroll({
                height: '350px',
                railVisible: true,
                alwaysVisible: true
            });
        }
    }

    function addTouchSpin() {
        if (options.Buttons && options.Buttons.NetWeight) {
            createTouchSpin({ Postfix: gram, Decimals: 2, Step: .01, Element: $("#" + controller).find(".touchSpin") });
            $("#" + controller).find(".touchSpin").on("change", function () {
                var touchSpinToClick = this;
                ($("#" + controller + "Content").find("[name*='" + controller + "Id']")).each(function () {
                    if ($(touchSpinToClick).attr("data-id") == $(this).val()) {
                        var selectableContent = $(this).closest(".SelectableContent");
                        var netWeight = selectableContent.attr("data-netweight");
                        
                        selectableContent.attr("data-netweight", $(touchSpinToClick).val());
                        selectableContent.find(".inputNetWeight").attr("value", $(touchSpinToClick).val());

                        selectableContent.find(".medition").each(function () {
                            var realMedition = dividerValues($(this).html(), netWeight);
                            $(this).html(multiplyValues(realMedition, $(touchSpinToClick).val()));
                        });
                    }
                });
            });
        }
    }

    //FILTER
    function eventToClickFilter() {
        $("#" + controller).find(".btnFilter").click(function() {
            $("#" + controller).find("#Table").bootstrapTable('refresh');
        });

        $(filters).each(function (index, filter) {
            $("#" + controller).find("#" + filter).keyup(function (e) {
                if (e.keyCode == 13)
                    $("#" + controller).find(".btnFilter").trigger("click");
                if (isInValidFilter($(this).val())) {
                    var str = $(this).val();
                    var newstr = str.replace(regExprToFilter, '');
                    $(this).val(newstr);
                    return false;
                }
                return true;
            });
        });
    }

    //EXPORT
    function eventToClickExport() {
        $("#" + controller).find(".btnExport").click(function() {
            alertInfo("Obteniendo informaci&oacute;n, su descarga estar&aacute; disponible en un momento.");
            var parameters = "?SortBy=" + sortingAndPagination.SortBy + "&Sort=" + sortingAndPagination.Sort;
            $(filters).each(function(index, filter) {
                parameters += ("&" + filter + "=" + $("#" + filter).val());
            });

            redirect(controller, "Export", parameters);
        });
    }

    //DELETEMANY
    function eventToClickDeleteMany() {
        $("#" + controller).find(".btnDeleteMany").click(function() {
            createDialog({
                Entity: controller,
                Root: root + controller,
                Title: "Eliminar",
                Message: "<p>¿Deseas eliminar los registros seleccionados?<span class='smallDetail margin-left-5'> " + numberRowSelecteds() + " registros</span></p>",
                Type: BootstrapDialog.TYPE_DANGER,
                Buttons: { Cancel: true, DeleteMany: true }
            });
        });
    }

    function toggleDeleteMany() {
        numberRowSelecteds() > 1 ? $("#" + controller).find(".btnDeleteMany").prop("disabled", false) : $("#" + controller).find(".btnDeleteMany").prop("disabled", true);
    };

    function numberRowSelecteds() {
        return $("#" + controller).find(tableId).bootstrapTable('getSelections').length;
    };

    //ASSIGN
    function addButtonAssign(formatterRow) {
        var icon = "check";
        var title = "Asignar";
        var classButton = "success";
        var readData = "";
        
        if (controller === "Ingredient") {
            readData = "ingredient";
        }
        if (controller === "Saucer") {
            readData = "saucer";
        }
        if (controller === "Dealer") {
            readData = "dealer";
        }
            

        $(".selected").each(function(index, element) {
            var id = $(element).data(readData).Id;
            if (id == formatterRow.Id) {
                icon = "times";
                title = "Remover";
                classButton = "danger";
            }
        });

        buttons.OperateEvents['click .btnAssign'] = function (event, value, row) {
            var template =[];
            if ($(this).hasClass("btn-success")) {
                if (controller === "Ingredient") {
                    template.push("<div class='SelectableContent selected not-format' data-ingredient='" + JSON.stringify(row) + "' data-name='" + row.Name + "' data-netweight='" + row.NetWeight + "'>");
                    template.push('<input name="SaucerConfigurations.Index" type="hidden" value="' + row.Id + '" hidden="hidden">');
                    template.push('<input name="SaucerConfigurations[' + row.Id + '].SaucerId" type="text" value="' + $("#Id").val() + '" hidden="hidden">');
                    template.push(' <input name="SaucerConfigurations[' + row.Id + '].NetWeight" type="text" value="' + row.NetWeight + '" class="inputNetWeight" hidden="hidden">');
                    template.push('<input name="SaucerConfigurations[' + row.Id + '].IngredientId" type="text" value="' + row.Id + '" hidden="hidden">');
                    template.push('</div>');
                    $(this).closest("tr").find("#NetWeight").val(row.NetWeight);
                    $(this).closest("tr").find(".touchspinCustom").removeClass("hidden");

                }
                if (controller === "Dealer") {
                    template.push("<div class='SelectableContent selected not-format' data-dealer='" + JSON.stringify(row) + "' data-name='" + row.Name + "'>");
                    template.push('<input name="dealers.Index" type="hidden" value="' + row.Id + '" hidden="hidden">');
                    template.push('<input name="dealers[' + row.Id + '].Id" type="text" value="' + row.Id + '" hidden="hidden">');
                    template.push('</div>');
                }
                $("#cards-selectable").append(template.join(''));
                $(this).removeClass("btn-success").addClass("btn-danger");
                $(this).children().removeClass("fa-check").addClass("fa-times");
                refreshTooltip(this, "Remover");
                createdCards();
            } else {
                $(".selected").each(function (index, element) {
                    var id = $(element).data(readData).Id;
                    if (id == row.Id) {
                        $(element).remove();
                    }
                });
                $(this).removeClass("btn-danger").addClass("btn-success");
                $(this).children().removeClass("fa-times").addClass("fa-check");
                $(this).closest("tr").find(".touchspinCustom").addClass("hidden");
                refreshTooltip(this, "Asignar");
            }
        };

        return " <button class='btnAssign btn btn-" + classButton + " btn-sm' data-toggle='tooltip' title='" + title + "'><i class='fa fa-" + icon + "'></i></button>";
    }

    //COLUMNS
    function addCheck() {
        columns.push({
            field: 'Check',
            checkbox: true,
            valign: 'middle',
            align: 'center',
            formatter: function(value, row) {
                var attribute = { disabled: false };
                if (row.IsReference) attribute.disabled = true;
                return attribute;
            }
        });
    }

    function addColor() {
        columns.push({
            field: 'Color',
            title: 'Color',
            align: 'left',
            sortable: false,
            width: '80',
            valign: 'middle',
            formatter: function(value) {
                return '<div class="colorColumn" style="background-color:' + value + ';height: 9px;width: 46px; border-radius:5px;"></div>';
            }
        });
    }

    function addColumn(field, title) {
        columns.push({
            field: field,
            title: title,
            align: 'left',
            sortable: false,
            valign: 'middle',
            formatter: function (value, row) {
                extractValue(field, row);
                return valueExtracted;
            }
        });
    }

    function addColumnByObject(field, title) {
        columns.push({
            field: field,
            title: title,
            align: 'left',
            sortable: false,
            valign: 'middle',
            formatter: function(value) {
                return value.Name;
            }
        });
    }

    function addStatus() {
        columns.push({
            field: 'Status',
            title: 'Estado',
            align: 'center',
            sortable: false,
            width: "80",
            valign: 'middle',
            formatter: function(value) {
                var labelColor = value ? "success" : "danger";
                var labelValue = value ? "Activo" : "Inactivo";
                return '<div class="statusColumn label label-' + labelColor + '" style="width:100%; display:block">' + labelValue + '</div>';
            }
        });
    }

    function addNetWeight() {
        columns.push({
            field: 'NetWeight',
            title: 'Peso neto',
            align: 'center',
            sortable: false,
            width: "180",
            valign: 'middle',
            formatter: function (value, row) {
                var hiddenClass = "hidden";
                var realValue = value;
                $($("#" + controller + "Content").find("[name*='" + controller + "Id']")).each(function () {
                    if ($(this).val() == row["Id"]) {
                        hiddenClass = "";
                        realValue = $(this).parent().attr("data-netweight");
                    }
                });

                var formatter = '<div class="col-md-12 touchspinCustom ' + hiddenClass + '"><input data-id="' + row.Id + '" value="' + realValue + '" class = "form-control touchSpin postFixCustom" placeholder = "0.0" id = "NetWeight"/></div>';
                return formatter;
            }
        });
    }

    //BUTTONS
    function addButtonDetails() {
        buttons.OperateEvents['click .btnDetails'] = function (event, value, row) {
            if (elementExistInArray(configurationToDetailsButton.ObjectToRead, objects)) {
                var data = controller + "Id=" + row.Id;
                var callbackSuccess = function (response) {
                    createModalDetails({
                        Title: '<i class="fa fa-' + configurationToDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToDetailsButton.TitleTooltip,
                        ObjectToRead: "Records",
                        Row: response,
                        PorpertiesToRead: configurationToDetailsButton.PorpertiesToRead,
                        IsList: configurationToDetailsButton.IsList
                    });
                };
                filterPerAjax(configurationToDetailsButton.ObjectToRead, data, callbackSuccess);

            } else {
                if (configurationToDetailsButton.ObjectToRead == "") {
                    createModalDetails({
                        Title: '<i class="fa fa-' + configurationToDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToDetailsButton.TitleTooltip,
                        ObjectToRead: configurationToDetailsButton.ObjectToRead,
                        Row: row,
                        PorpertiesToRead: configurationToDetailsButton.PorpertiesToRead,
                        IsList: configurationToDetailsButton.IsList
                    });
                } else {
                    callbackSuccess = function (response) {
                        createModalDetails({
                            Title: '<i class="fa fa-' + configurationToDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToDetailsButton.TitleTooltip,
                            ObjectToRead: "Record",
                            Row: response,
                            PorpertiesToRead: configurationToDetailsButton.PorpertiesToRead,
                            IsList: configurationToDetailsButton.IsList
                        });
                    };
                    getPerAjax(controller, configurationToDetailsButton.ObjectToRead + "/" + row.Id, callbackSuccess);
                }
            }
        };

        return " <button class='btnDetails btn btn-default btn-sm' data-toggle='tooltip' title='" + configurationToDetailsButton.TitleTooltip + "'><i class='fa fa-" + configurationToDetailsButton.Icon + "'></i></button>";
    }

    function addSecondButtonDetails(formatterRow) {
        var disabledAttribute = configurationToSecondDetailsButton.IsList && formatterRow[configurationToSecondDetailsButton.ObjectToRead].length == 0 ? "disabled='disabled'" : "";
        buttons.OperateEvents['click .btnSecondDetails'] = function(event, value, row) {
            var data = controller + "Id=" + row.Id;
            var callbackSuccess;
            if (elementExistInArray(configurationToSecondDetailsButton.ObjectToRead, objects)) {
                callbackSuccess = function(response) {
                    createModalDetails({
                        Title: '<i class="fa fa-' + configurationToSecondDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToSecondDetailsButton.TitleTooltip,
                        ObjectToRead: "Records",
                        Row: response,
                        PorpertiesToRead: configurationToSecondDetailsButton.PorpertiesToRead,
                        IsList: configurationToSecondDetailsButton.IsList
                    });
                };
                filterPerAjax(configurationToSecondDetailsButton.ObjectToRead, data, callbackSuccess);

            } else {
                if (configurationToSecondDetailsButton.ObjectToRead == "") {
                    createModalDetails({
                        Title: '<i class="fa fa-' + configurationToSecondDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToSecondDetailsButton.TitleTooltip,
                        ObjectToRead: configurationToSecondDetailsButton.ObjectToRead,
                        Row: row,
                        PorpertiesToRead: configurationToSecondDetailsButton.PorpertiesToRead,
                        IsList: configurationToSecondDetailsButton.IsList
                    });
                } else {
                    callbackSuccess = function (response) {
                        createModalDetails({
                            Title: '<i class="fa fa-' + configurationToSecondDetailsButton.Icon + ' padding-right-5"></i> ' + configurationToSecondDetailsButton.TitleTooltip,
                            ObjectToRead: "Record",
                            Row: response,
                            PorpertiesToRead: configurationToSecondDetailsButton.PorpertiesToRead,
                            IsList: configurationToSecondDetailsButton.IsList
                        });
                    };
                    getPerAjax(controller, configurationToSecondDetailsButton.ObjectToRead + "/" + row.Id, callbackSuccess);
                }
            }
        };

        return " <button class='btnSecondDetails btn btn-default btn-sm' data-toggle='tooltip' title='" + configurationToSecondDetailsButton.TitleTooltip + "' " + disabledAttribute + "><i class='fa fa-" + configurationToSecondDetailsButton.Icon + "'></i></button>";
    }

    function addButtonMultimedia() {
        buttons.OperateEvents['click .btnMultimedia'] = function (event, value, row) {
            var entity = controller + "Multimedia";
            var data = controller + "Id=" + row.Id;
            var callbackSuccess = function (response) {
                createModalMultimedia({
                    Multimedias: response.Records
                });
            };
            filterPerAjax(entity, data, callbackSuccess);
        };

        return " <button class='btnMultimedia btn btn-default btn-sm' data-toggle='tooltip' title='Multimedia'><i class='fa fa-picture-o'></i></button>";
    }

    function addButtonChangeStatus(formatterRow) {
        var toggle = formatterRow.Status ? "on" : "off";
        var title = formatterRow.Status ? "Desactivar" : "Activar";

        buttons.OperateEvents['click .btnChangeStatus'] = function(event, value, row) {
            createDialog({
                Id: row.Id,
                Entity: controller,
                Root: root + controller,
                Title: "Cambiar estado",
                Message: "¿Deseas " + (row.Status ? "Desactivar" : "Activar") + " el registro?",
                Status: row.Status,
                Buttons: { Cancel: true, ChangeStatus: true }
            });
        };

        return " <button class='btnChangeStatus btn btn-default btn-sm' data-toggle='tooltip' title='" + title + "'><i class='fa fa-toggle-" + toggle + "'></i></button>";
    }

    function addButtonEdit() {
        buttons.OperateEvents['click .btnEdit'] = function (event, value, row) {
            redirect(controller, "Edit", row.Id);
        };

        return " <button class='btnEdit btn btn-default btn-sm' data-toggle='tooltip' title='Editar'><i class='fa fa-pencil'></i></button>";
    }

    function addButtonEditDisabled(formatterRow) {
        var disabledAttribute = formatterRow.IsReference ? "disabled='disabled'" : "";
        buttons.OperateEvents['click .btnEdit'] = function (event, value, row) {
            redirect(controller, "Edit", row.Id);
        };

        return " <button class='btnEdit btn btn-default btn-sm' data-toggle='tooltip' title='Editar' " + disabledAttribute + "><i class='fa fa-pencil'></i></button>";
    }

    function addButtonDelete(formatterRow) {
        var disabledAttribute = formatterRow.IsReference ? "disabled='disabled'" : "";
        buttons.OperateEvents['click .btnDelete'] = function(event, value, row) {
            if (!row.IsReference) {
                createDialog({
                    Id: row.Id,
                    Entity: controller,
                    Root: root + controller,
                    Title: "Eliminar",
                    Message: "¿Deseas eliminar el registro?",
                    Type: BootstrapDialog.TYPE_DANGER,
                    Buttons: { Cancel: true, Delete: true }
                });
            }
        };

        return " <button class='btnDelete btn btn-danger btn-sm' data-toggle='tooltip' title='Eliminar' " + disabledAttribute + "><i class='fa fa-trash-o'></i></button>";
    }

    //CARDVIEW
    function aplyStyleToCardView() {
        //Buttons
        $("#" + controller).find(tableId).find(".buttonsColumn").css("margin-left", "-5px");
        $("#" + controller).find(tableId).find(".buttonsColumn").css("display", "inline");

        //Titles
        $("#" + controller).find(tableId).find(".title").css("min-width", "140px");
        $("#" + controller).find(tableId).find(".title").css("width", "140px");

        //Align Checkbox ant Status
        $($("#" + controller).find(tableId).find("[name=btSelectItem]")).each(function(index, element) {
            $("#" + controller).find(tableId).find("tr[data-index='" + index + "']").find(".statusColumn").closest(".card-view").find(".title").remove();
            $(element).parent().append($("#" + controller).find(tableId).find("tr[data-index='" + index + "']").find(".statusColumn"));
        });
        if ($("#" + controller).find(tableId).find("[name=btSelectItem]").length > 0) {
            $("#" + controller).find(tableId).find("[name=btSelectItem]").parent().css("width", "100%");
            $("#" + controller).find(tableId).find("[name=btSelectItem]").css("float", "none");
            $("#" + controller).find(tableId).find("[name=btSelectItem]").css("margin", "0");
            $("#" + controller).find(tableId).find(".statusColumn").css("margin-left", "125px");
        }
        $("#" + controller).find(tableId).find(".statusColumn").css("width", "100px");
        $("#" + controller).find(tableId).find(".statusColumn").css("display", "inline-block");

        //Color
        $("#" + controller).find(tableId).find(".colorColumn").css("display", "inline-block");
        $("#" + controller).find(tableId).find(".colorColumn").css("width", "100px");

        cardView.IsCardView = true;
    }

    function aplyStyleToTableView() {
        cardView.IsCardView = false;
    }

}

