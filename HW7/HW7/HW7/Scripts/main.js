
function commitFun(id) {
    var Repository = document.getElementById("RespositoryID " + id).innerText;
    console.log(Repository);
    var user = document.getElementById("UserNameID " + id).innerText;
    console.log(user);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/CommitHistory?user=" + user + "&repo=" + Repository,
        data: { 'userName': user, 'repoName': Repository },
        success: displayCommits,
        error: errorOnAjax
    });
};


function errorOnAjax() {
    console.log('Error on AJAX return');
}


