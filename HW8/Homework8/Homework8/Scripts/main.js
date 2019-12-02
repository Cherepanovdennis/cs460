function myfunction(id) {
    var athlete = document.getElementById(id).innerText;
    var distance = $("#value " + id + ":selected").val();
    console.log(distance);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/home/covert?athlete=" + athlete + "&distance=" + distance,
        success: graph,
        error: errorOnAjax
    });
}

    function graph() {

}

    function errorOnAjax() {
        console.log('Error on AJAX return');
}

