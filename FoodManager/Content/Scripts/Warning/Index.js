//INSTANCES
createSelectize({ InputId: "DiseaseId" });
createTable({
    Controller: "Warning",
    ClickToSelect: true,
    Columns: ["Code", "Name", "Disease"],
    Buttons: { ChangeStatus: true, Edit: true, Delete: true },
    Filters: ["Name", "DiseaseId"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Name" }
});