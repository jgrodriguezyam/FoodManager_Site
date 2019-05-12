//INSTANCES
createSelectize({ InputId: "BranchId" });
createTable({
    Controller: "Worker",
    ClickToSelect: true,
    Columns: ["Code", "FirstName", "LastName", "Email", "Branch"],
    Buttons: { Details: true, ChangeStatus: true, Edit: true },
    ConfigurationToDetailsButton: { TitleTooltip: "Detalles", IsList: false, PorpertiesToRead: ["C&oacute;digo,Code", "Nombre,FirstName", "Apellidos,LastName", "Correo,Email", "Imss,Imss", "G&eacute;nero,GenderLabel", "Gaffete,Badge", "Ingesta cal&oacute;rica,LimitEnergy", "Sucursal,Branch", "Departamento,Department", "Puesto,Job", "Rol,Role"] },
    Filters: ["Name", "BranchId"],
    CardView: { ApplyCardView: true, WidthPerApply: 850 },
    SortingAndPagination: { SortBy: "FirstName" }
});