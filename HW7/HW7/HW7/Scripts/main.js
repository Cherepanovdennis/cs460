
$('#request').click(function () {
    var count = $('#id').val();
    var source = '/Home/GitToken?token=' + count;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: displayNumbers,
        error: errorOnAjax
    });


function errorOnAjax() {
    console.log('Error on AJAX return');
}

function displayNumbers(data) {
    console.log(data);
    $('#picture').
    $('#message').text(data.message);
    $('#num').text(data["num"]);
    $('#numbers').text(data.numbers);
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