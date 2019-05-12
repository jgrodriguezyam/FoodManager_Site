//INSTANCES
createTable({
    Controller: "User",
    Columns: ["Name", "UserName", "Role", "Dealer"],
    Buttons: { ChangeStatus: true, Edit: true },
    Filters: ["Name"],
    CardView: { ApplyCardView: true, WidthPerApply: 600 },
    SortingAndPagination: { SortBy: "Name" }
});
