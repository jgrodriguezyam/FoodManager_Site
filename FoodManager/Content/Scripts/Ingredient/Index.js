//INSTANCES
createSelectize({ InputId: "IngredientGroupId" });
createTable({
    Controller: "Ingredient",
    ClickToSelect: true,
    Columns: ["Name", "IngredientGroup"],
    Buttons: { Details: true, ChangeStatus: true, EditDisabled: true, Delete: true },
    ConfigurationToDetailsButton: { TitleTooltip: "Detalles", IsList: false, PorpertiesToRead: ["Ingrediente,Name", "Grupo,IngredientGroup", "Peso neto,NetWeight", "Energ&iacute;a,Energy", "Prote&iacute;nas,Protein", "Carbohidratos,Carbohydrate", "Az&uacute;car,Sugar", "L&iacute;pidos,Lipid", "Sodio,Sodium"] },
    Filters: ["Name", "IngredientGroupId"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Name" }
});