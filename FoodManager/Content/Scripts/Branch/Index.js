//INSTANCES
createSelectize({ InputId: "RegionId" });
createTable({
    Controller: "Branch",
    ClickToSelect: true,
    Columns: ["Code", "Name", "Region", "Company"],
    Buttons: { Details: true, ChangeStatus: true, Edit: true, Delete: true },
    ConfigurationToDetailsButton: { TitleTooltip: "Concesionarios", IsList: true, ObjectToRead: "Dealer", PorpertiesToRead: ["Name", "Status"] },
    Filters: ["Name", "RegionId"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Code" }
});