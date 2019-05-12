//INSTANCES
createTable({
    Controller: "Saucer",
    ClickToSelect: true,
    Columns: ["Name", "TypeLabel"],
    Buttons: { Details: true, SecondDetails: true, Multimedia: true, ChangeStatus: true, Edit: true, Delete: true },
    ConfigurationToDetailsButton: { TitleTooltip: "Ingredientes", IsList: true, ObjectToRead: "SaucerConfiguration", PorpertiesToRead: ["Ingredient.Name", "NetWeight", "Status"] },
    ConfigurationToSecondDetailsButton: { TitleTooltip: "Informaci&oacute;n Nutricional", IsList: false, Icon: "pie-chart", ObjectToRead: "NutritionInformation", PorpertiesToRead: ["Energ&iacute;a,Energy", "Prote&iacute;nas,Protein", "Carbohidratos,Carbohydrate", "Az&uacute;car,Sugar", "L&iacute;pidos,Lipid", "Sodio,Sodium"] },
    Filters: ["Name"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Name" }
});
