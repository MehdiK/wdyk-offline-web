App.syncUp = (function () {
    var removeRecord = function (record) {
        localStorage.removeItem(record.id);
    };

    var post = function (key, row) {
        var record = JSON.parse(localStorage.getItem(key));
        $.ajax({ data: record.form, url: record.url, type: 'POST' })
            .done(function (response) {
                removeRecord(record);
                row.removeClass('syncing').addClass('synced');
                row.find('.status').html('synced :)');
            });
    };

    var syncUp = function () {
        var key, i, $offlineRow;
        for (i = 0; i < localStorage.length; i = i + 1) {
            key = localStorage.key(i);

            $offlineRow = $('tr#' + key);
            $offlineRow
                .removeClass('offlineRecord')
                .addClass('syncing');

            $offlineRow.find('.status').html('syncing...');

            post(key, $offlineRow);
        }
    };

    var init = function () {
        amplify.subscribe('app-is-online', syncUp);
    };

    return {
        init: init
    };
}());