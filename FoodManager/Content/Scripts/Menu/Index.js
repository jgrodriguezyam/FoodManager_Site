//INSTANCES
createSelectize({ InputId: "DealerId" });
createSelectize({ InputId: "SaucerId", OptgroupField:"Type" });
createTable({
    Controller: "Menu",
    ClickToSelect: true,
    Columns: ["MealTypeLabel", "DayWeekLabel", "StartDate", "EndDate", "Dealer", 'Saucer'],
    Buttons: { Details: true, ChangeStatus: true, Edit: true, Delete: true },
    ConfigurationToDetailsButton: { TitleTooltip: "Detalles", IsList: false, PorpertiesToRead: ["Tipo,MealTypeLabel", "D&iacute;a,DayWeekLabel", "Fecha inicio,StartDate", "Fecha fin,EndDate", "Concesionario,Dealer", "Platillo,Saucer", "Comentario,Comment"] },
    Filters: ["SaucerId", "DealerId"],
    CardView: { ApplyCardView: true, WidthPerApply: 900 },
    SortingAndPagination: { SortBy: "Id", Sort:"DESC" }
});