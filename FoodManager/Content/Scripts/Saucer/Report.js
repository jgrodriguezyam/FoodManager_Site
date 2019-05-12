//INSTANCES
clearOpacity();
loadMainPie();
loadGarrisonPie();

//INTERNAL
function loadMainPie() {
    var mains = $("#MainPie").data("mains");
    var templateMains = [];
    var countMains = [];
    var colorMains = [];

    $(mains).each(function (index, main) {
        var color = randomColor();
        templateMains.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + color + "'>" + main.Name + "</span>");
        countMains.push(main.Count);
        colorMains.push(color);
    });

    $("#MainPie").sparkline(countMains, {
        type: 'pie',
        height: 200,
        sliceColors: colorMains
    });

    $("#mains").html(templateMains.join(' '));
}

function loadGarrisonPie() {
    var mains = $("#GarrisonPie").data("garrisons");
    var templateGarrisons = [];
    var countGarrisons = [];
    var colorGarrisons = [];

    $(mains).each(function (index, garrison) {
        var color = randomColor();
        templateGarrisons.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + color + "'>" + garrison.Name + "</span>");
        countGarrisons.push(garrison.Count);
        colorGarrisons.push(color);
    });

    $("#GarrisonPie").sparkline(countGarrisons, {
        type: 'pie',
        height: 200,
        sliceColors: colorGarrisons
    });

    $("#garrisons").html(templateGarrisons.join(' '));
}