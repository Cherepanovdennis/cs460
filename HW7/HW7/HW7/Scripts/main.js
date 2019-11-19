
function commitFun(id) {
    var Repository = document.getElementById("RespositoryID " + id).innerText;
    console.log(Repository);
    var user = document.getElementById("UserNameID " + id).innerText;
    console.log(user);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/commits?user=" + user + "&repo=" + Repository,
        data: { 'userName': user, 'repoName': Repository },
        success: Commits,
        error: errorOnAjax
    });
};


function errorOnAjax() {
    console.log('Error on AJAX return');
}

function Commits(info) {
    $("#newtable").empty();
    var table = document.getElementById("newtable");
    var header = table.createTHead();
    var row = header.insertRow(0);
    var cell = row.insertCell(0);
    var cell1 = row.insertCell(1);
    var cell2 = row.insertCell(2);
    var cell3 = row.insertCell(3);
    cell.innerHTML = "<b>SHA</b>";
    cell1.innerHTML = "<b>TimeStamp</b>";
    cell2.innerHTML = "<b>Commiter</b>";
    cell3.innerHTML = "<b>Message</b>";

    for (var i = info.length - 1; i != 0; i--) {
        var insertrow = 1;
        var row = table.insertRow(insertrow);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = row.insertCell(3);
        cell1.innerHTML = '<a href="' + info[i].CommitUri + '">' + info[i].Hash + '</a>';
        cell2.innerHTML = info[i].CommitDateTime;
        cell3.innerHTML = info[i].WhoCommited;
        cell4.innerHTML = info[i].CommitMessage;
        insertrow++;

    }

}

