//ELEMENTS
var btnAddDealerElement = $("#btnAddDealer");

//INSTANCES
validateForm({ Name: true, Code: true, Company: true, Region:true });
createSelectize({ InputId: "CompanyId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "RegionId", Data: { OnlyStatusActivated: true } });
createdCards();
eventToClickBtnAddDealer();
maxLength();
submitButtons();
tooltipToRequired();
clearOpacity();

//INTERNAL
function createdCards() {
    convertCardInSelectable({
        AttributeToRead: "dealer",
        ClassCol: "col-md-2",
        WithRemove: true,
        DisplayDetail: "none"
    });
}

function eventToClickBtnAddDealer() {
    if ($(btnAddDealerElement).attr("disabled") != "disabled") {
        $(btnAddDealerElement).click(function () {

            var message = "<div id='Dealer' style='margin: 0 13px;'>";
            message += "<div class='container-fluid'>";
            message += "<div class='row'>";
            message += "<div class='col-lg-9 container-left'><input type='text' id='Name' class='form-control' data-role='none' placeholder='Nombre' autocomplete='off'></div>";
            message += "<div class='col-lg-2 container-right'><button type='button' class='btn btn-info btn-block btnFilter'><i class='fa fa-filter'></i> Filtrar</button></div>";
            message += "</div>";
            message += "</div>";
            message += "<table id='Table'></table>";
            message += "</div>";

            createDialog({
                Title: "Asignar Concesionarios",
                Message: message,
                WithScroll: true,
                Onshown: function() {
                    createTable({
                        Controller: "Dealer",
                        Buttons: { Assign: true },
                        Columns: ["Name"],
                        Filters: ["Name"],
                        SortingAndPagination: { SortBy: "Name" }
                    });
                }
            });
        });
    }
}