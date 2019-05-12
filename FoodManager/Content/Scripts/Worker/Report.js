//INSTANCES
createSelectize({ InputId: "CompanyId" });
createSelectize({ InputId: "BranchId" });
createSelectize({ InputId: "DepartmentId" });
createSelectize({ InputId: "JobId" });
createSelectize({ InputId: "Month", ValueField: "Value", SortField:"Value" });
createTable({
    Controller: "Worker",
    Columns: ["CompanyToWorker", "Branch", "Department", "Job", "Code", "FullName"],
    Filters: ["CompanyId", "BranchId", "DepartmentId", "JobId", "IsReport", "Month"],
    CardView: { ApplyCardView: true, WidthPerApply: 850 },
    SortingAndPagination: { SortBy: "FirstName" }
});