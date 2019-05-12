//INSTANCES
validateForm({ Code: true, FirstName: true, LastName: true, Email: true, Imss: true, Gender: true, Badge: true, LimitEnergy: true, Branch: true, Department: true, Job: true, Role:true });
createSelectize({ InputId: "BranchId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "DepartmentId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "JobId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "RoleId", Data: { OnlyStatusActivated: true } });
createTouchSpin({ Element: "#LimitEnergy", Postfix: kiloCalorie, Decimals: 0, Step: 10 });
maxLength();
submitButtons();
tooltipToRequired();