//INSTANCES
validateForm({ Name: true, Color: true });
createMiniColor();
maxLength();
submitButtons();
tooltipToRequired();
clearOpacity();

//INTERNAL
function createMiniColor() {
    $('#Color').minicolors({
        control: "wheel",
        letterCase: "uppercase",
        theme: 'bootstrap'
    });
}