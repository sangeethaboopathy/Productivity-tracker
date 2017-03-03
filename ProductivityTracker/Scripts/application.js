function pickAccount(accountId, userId) {
    debugger;
    var url = 'Home/PickAccount';
    var data = { id: accountId };

    $.post(url, data, function (result) {
        $("#accountInfo").html(result);
        alert('Update successful!');
    });
}

function completeAccount() {
    debugger;
    var accountId = $('#hdnAccountId').val();
    var timeLogId = $('#hdnTimeLogId').val();
    var statusId = $('#hdnStatusId').val();
    var comment = $('#txtComments').val();
    var url = 'Home/CompleteAccount';
    var data = { timeLogId: timeLogId, accountId: accountId, statusId: statusId, comments: comment };

    $.post(url, data, function (result) {
        $("#accountInfo").html(result);
        alert('Update successful!');
    });
}

function showModal(timeLogId, accountId, statusId) {
    $('#commentsModal').modal('show');
    $('#hdnTimeLogId').val(timeLogId);
    $('#hdnAccountId').val(accountId);
    $('#hdnStatusId').val(statusId);
}

function showHistory(id) {
    debugger;
    $('#' + id.id).modal('show');
}

function PopulateAccountsForProject() {
    debugger;
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