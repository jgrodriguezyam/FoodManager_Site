//INSTANCES
clearOpacity();
loadPies();

//INTERNAL
function loadPies() {

    var colorCalories = [colorBreakFast, colorLunch, colorDinner];

    var templateCalories = [];
    templateCalories.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + colorBreakFast + "'>Desayuno</span>");
    templateCalories.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + colorLunch + "'>Almuerzo</span>");
    templateCalories.push("<span style='border-radius:.25em; padding:1px 8px; color:#fff; background-color:" + colorDinner + "'>Cena</span>");


    $($(".pie-calorie")).each(function (index, pie) {
        var calories = $(pie).data("calories");
        var countCalories = [calories.BreakFast, calories.Lunch, calories.Dinner];

        $(pie).sparkline(countCalories, {
            type: 'pie',
            height: 200,
            sliceColors: colorCalories
        });

        $(pie).closest(".tab-content").find(".concepts").html(templateCalories.join(' '));
    });
}