App.syncUp = (function () {
    var removeRecord = function (record) {
        localStorage.removeItem(record.id);
    };

    var syncUp = function () {
        var key, record, i;
        for (i = 0; i < localStorage.length; i = i + 1) {
            key = localStorage.key(i);

            record = JSON.parse(localStorage.getItem(key));
            $.ajax({ data: record.form, url: record.url, type: 'POST' })
                .done(function (response) { removeRecord(record); });
        }
    };

    var init = function () {
        amplify.subscribe('app-is-online', syncUp);
    };

    return {
        init: init
    };
}());