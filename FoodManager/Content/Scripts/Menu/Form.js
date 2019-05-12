//INSTANCES
validateForm({ Comment: true, DayWeek: true, Type: true,StartDate: true, EndDate: true,  DealerNotNullable: true, Saucer: true });
createSelectize({ InputId: "DealerId", Data: { OnlyStatusActivated: true } });
createSelectize({ InputId: "SaucerId", Data: { OnlyStatusActivated: true }, OptgroupField: "Type" });
createStartDateAndEndDateRangePicker();
createTouchSpin({ Step: 1 });
maxLength();
submitButtons();
tooltipToRequired();
clearOpacity();