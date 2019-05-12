//INSTANCES
tooltipToRequired();
clearOpacity();





$("#TabGraphic").click(function () {
    var myInterval = setInterval(function () {

        $("#SparklineSumary").sparkline([340, 120, 108, 93, 84], {
            type: 'pie',
            height: 250,
            sliceColors: ['#5cb85c', '#f39c12', '#3F3CE7', '#D94FB5', '#59B2BB']
        });

        clearInterval(myInterval);
    }, 300);
});

$("#TabGoodEating").click(function () {
    var myInterval2 = setInterval(function () {

        $("#SparklineSumary2").sparkline([10, 20, 30], {
            type: 'pie',
            height: 250,
            sliceColors: ['#5cb85c', '#f39c12', '#D94F4F']
        });

        clearInterval(myInterval2);
    }, 300);
});
