//INSTANCES
createTable({
    Controller: "Company",
    ClickToSelect: true,
    Columns: ["Name"],
    Buttons: { ChangeStatus: true, Edit: true, Delete: true },
    Filters: ["Name"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Name" }
});