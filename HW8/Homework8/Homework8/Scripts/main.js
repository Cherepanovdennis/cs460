function myfunction(id) {
    var athlete = document.getElementById(id).innerText;
    var distance1 = "value " + id;
    var e = document.getElementById(distance1);
    var distance = e.options[e.selectedIndex].value;
    console.log(distance1);
    console.log(distance);
    console.log(athlete);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/convert?athlete=" + athlete + "&distance=" + distance,
        success: graph,
        error: errorOnAjax
    });
}

    function graph(data) {
        var trace = {
            //x: data.x,
            x: data.dates,
            y: data.time,
            mode: 'lines',
            type: 'scatter'
        };
        console.log(data.dates);
        var plotData = [trace];
        var layout = {};
        Plotly.newPlot('graph', plotData, layout);
    
}

    function errorOnAjax() {
        console.log('Error on AJAX return');
}

