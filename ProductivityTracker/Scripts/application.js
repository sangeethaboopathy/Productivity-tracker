function pickAccount(accountId, userId) {
    var projectId = parseInt($('#project_select').val());
    $.ajax({
        url: '/Accounts/PickAccount',
        data: {
            id: accountId, projectId: projectId
        },
        type : "POST",
        success: function (result) {
            $("#accountInfo").empty();
            $("#accountInfo").html(result);
            alert('Update successful!');
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}

function completeAccount() {
    var accountId = $('#hdnAccountId').val();
    var timeLogId = $('#hdnTimeLogId').val();
    var statusId = $('#hdnStatusId').val();
    var projectId = $('#hdnProjectId').val();
    var comment = $('#txtComments').val();
    var url = 'Accounts/CompleteAccount';
    var data = { timeLogId: timeLogId, accountId: accountId, statusId: statusId, comments: comment, projectId: projectId };

    $.ajax({
        url: '/Accounts/CompleteAccount',
        data: data,
        type: "POST",
        success: function (result) {
            $("#accountInfo").empty();
            $("#accountInfo").html(result);
            alert('Update successful!');
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}

function showModal(timeLogId, accountId, statusId) {
    var projectId = parseInt($('#project_select').val());
    $('#commentsModal').modal('show');
    $('#hdnTimeLogId').val(timeLogId);
    $('#hdnAccountId').val(accountId);
    $('#hdnStatusId').val(statusId);
    $('#hdnProjectId').val(projectId);
}

function showHistory(id) {
    $('#' + id.id).modal('show');
}

function PopulateAccountsForProject() {
    var select = parseInt($('#project_select').val());
    $.ajax({
        url: '/Accounts/GetAccountsDetails',
        data: {
            projectId: select
        },
        success: function (result) {
            $('.accounts-list-container').empty();
            $('.accounts-list-container').html(result);
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}