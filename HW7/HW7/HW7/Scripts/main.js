
$('#request').click(function () {
    var source = '/Home/GitToken';
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: displayNumbers,
        error: errorOnAjax
    });
});


function errorOnAjax() {
    console.log('Error on AJAX return');
}

function displayNumbers(data) {
    console.log(data);
    $('#message').text(data.x);
    $('#numbers').text(data.y);
}

function plotAirQuality(data) {
    var trace = {
        //x: data.x,
        x: data.xdate,
        y: data.y,
        mode: 'lines',
        type: 'scatter'
    };
    console.log(data.xdate);
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('theplot', plotData, layout);
}