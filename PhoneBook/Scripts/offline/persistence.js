App.persistence = (function () {
    var areWeOffline = false;

    var serializeForm = function (form) {
        var o = {};
        var a = form.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

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
                    form: form.serialize(),
                    data: serializeForm(form)
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