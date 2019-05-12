//INSTANCES
createSelectize({ InputId: "DiseaseId", Data: { OnlyStatusActivated: true } });
validateForm({ Name: true, Code: true, Disease: true });
maxLength();
submitButtons();
tooltipToRequired();