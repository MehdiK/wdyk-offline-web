App.persistence = (function () {
    var areWeOffline = false;

    var prepareForOfflinePersistence = function () {
        $(':submit').click(function (e) {
            var that = $(this);
            var form;
            var offlineEntry;

            if (areWeOffline) {
                e.preventDefault();

                form = that.parents('form');
                offlineEntry = {
                    id: guid(),
                    url: window.location.href,
                    data: form.serialize()
                    };
                
                localStorage.setItem(offlineEntry.id, JSON.stringify(offlineEntry));
                window.history.back();
            }
        });
    };

    var guid = function () {
        var s4 = function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        };
        return (s4() + s4() + "-" + s4() + "-" + s4() + "-" + s4() + "-" + s4() + s4() + s4());
    };

    var init = function () {
        amplify.subscribe('app-is-offline', function () { areWeOffline = true; });
        prepareForOfflinePersistence();
    };

    return {
        init: init
    };
}());