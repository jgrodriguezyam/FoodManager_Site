var display = {
    RegionId: "Todas las regiones",
    CompanyId: "Todas las compañías",
    BranchId: "Todas las sucursales",
    DiseaseId: "Todas las enfermedades",
    IngredientGroupId: "Todos los grupos",
    DealerId: "Todos los concesionarios",
    DepartmentId: "Todos los departamentos",
    JobId: "Todos los puestos",
    SaucerId: "Todos los platillos",
    Unit: "Todas las unidades",
    RoleId: "Todos los roles",
    Month: "Todos los meses"
};

function createSelectize(options) {
    //VARIABLES
    var inputId = "";
    var entity = "";
    var action = "";
    var valueField = "Id";
    var containerId = ".selectize-container";
    var searchField = "Name";
    var sortField = "Name";
    var sortDirection = "asc";
    var placeholder = "Seleccionar...";
    var optgroupField = "";
    var optgroups = [];
    var data = { StartPage: 1, EndPage: 10, Sort: "ASC", SortBy: "Name", OnlyStatusActivated: false, OnlyStatusDeactivated: false };
    var callbackSelectize = false;
    var onItemAdd = false;
    var onItemRemove = false;

    //OPTIONS
    if (options) {
        if (options.InputId) inputId = "#" + options.InputId;
        if (options.InputId) entity = $("#" + options.InputId).data("entity");
        if (options.InputId) action = $("#" + options.InputId).data("action");
        if (options.InputId) placeholder = display[options.InputId];
        if (options.ValueField) valueField = options.ValueField;
        if (options.ContainerId) containerId = options.ContainerId;
        if (options.SearchField) searchField = options.SearchField;
        if (options.SortField) sortField = options.SortField;
        if (options.SortDirection) sortDirection = options.SortDirection;
        if (options.OptgroupField) optgroupField = options.OptgroupField;
        if (options.CallbackSelectize) callbackSelectize = options.CallbackSelectize;
        if (options.OnItemAdd) onItemAdd = options.OnItemAdd;
        if (options.OnItemRemove) onItemRemove = options.OnItemRemove;
    }

    //DATA
    if (options.Data) {
        if (options.Data.Sort) data.Sort = options.Data.Sort;
        if (options.Data.SortBy) data.SortBy = options.Data.SortBy;
        if (options.Data.OnlyStatusActivated) data.OnlyStatusActivated = options.Data.OnlyStatusActivated;
        if (options.Data.OnlyStatusDeactivated) data.OnlyStatusDeactivated = options.Data.OnlyStatusDeactivated;
    }

    //GROUPS
    if ($("#" + options.InputId).attr("data-groups") != undefined) {
        $(JSON.parse($("#" + options.InputId).attr("data-groups"))).each(function () {
            optgroups.push({ label: this.Name, value: this.Value });
        });
    }

    //INSTANCE
    var callbackSuccess = function (response) {
        var value = $(inputId).val();
        var text = $(inputId).text();
        $(inputId).selectize({
            valueField: valueField,
            labelField: 'Name',
            searchField: searchField,
            sortField: sortField,
            sortDirection: sortDirection,
            placeholder: "" + placeholder,
            options: response.Records,
            optgroups:  optgroups,
            optgroupField: optgroupField,
            create: false,
            onInitialize: function () {
                addOptionSelected(value, text);
            },
            onItemAdd: function (id) {
                $(inputId).closest(containerId).find("input[tabindex]").css("width", "1px");
                if (onItemAdd) onItemAdd(id);
            },
            onItemRemove: function () {
                if (onItemRemove) onItemRemove();
            },
            load: function(keyWord, callbackLoad) {
                if (!keyWord.length)
                    return callbackLoad();

                data[searchField] = keyWord;
                var callbackSuccessLoadFilter = function(responseLoadFilter) {
                    callbackLoad(responseLoadFilter.Records);
                };

                filterPerAjax(entity, data, callbackSuccessLoadFilter);
                if (action == undefined) {
                    filterPerAjax(entity, data, callbackSuccessLoadFilter);
                } else {
                    getPerAjax(entity, action, callbackSuccessLoadFilter);
                }
            }
        });

        if (callbackSelectize)
            callbackSelectize(response);
    };

    var callbackError = function() {
        $(inputId).attr("disabled", "disabled");
    };
    
    if (action == undefined) {
        filterPerAjax(entity, data, callbackSuccess, callbackError);
    } else {
        getPerAjax(entity, action, callbackSuccess, callbackError);
    }

    //INTERNAL
    function addOptionSelected(value, text) {
        var selectize = $(inputId)[0].selectize;
        $(inputId).children().each(function (index, option) {
            if ( value> 0) {
                var sltOption = { Id: value, Name: text };
                if (optgroupField !== "") {
                    sltOption = { Id: value, Name: text, Type: option[optgroupField] };
                }
                selectize.addOption(sltOption);
                selectize.addItem(parseInt(value));
            }
        });
    }
}
