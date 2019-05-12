//INSTANCES
tooltipToRequired();
clearOpacity();





$("#TabGraphic").click(function () {
    var myInterval = setInterval(function () {

        $("#SparklineSumary").sparkline([3,2], {
            type: 'pie',
            height: 250,
            sliceColors: ['#f39c12', '#3F3CE7']
        });

        clearInterval(myInterval);
    }, 300);
});
