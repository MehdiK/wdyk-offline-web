define(['amplify'], function (amplify) {
    var publishConnectivityStatus = function (status) {
        if (status.type === "error")
            amplify.publish('app-is-offline');
        else
            amplify.publish('app-is-online');
    };

    var init = function () {
        window.applicationCache.addEventListener("error", publishConnectivityStatus);
        window.applicationCache.addEventListener("noupdate", publishConnectivityStatus);
        window.applicationCache.addEventListener("cached", publishConnectivityStatus);
        window.applicationCache.addEventListener("updateready", publishConnectivityStatus);
    };

    return {
        init: init
    };
});