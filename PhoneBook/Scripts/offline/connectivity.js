App.connectivity = (function () {
    var publisher;

    var publishConnectivityStatus = function (status) {
        if (status.type === "error")
            publisher.publish('app-is-offline');
        else
            publisher.publish('app-is-online');
    };

    var init = function (pubsub) {
        publisher = pubsub;
        window.applicationCache.addEventListener("error", publishConnectivityStatus);
        window.applicationCache.addEventListener("noupdate", publishConnectivityStatus);
        window.applicationCache.addEventListener("cached", publishConnectivityStatus);
        window.applicationCache.addEventListener("updateready", publishConnectivityStatus);
    };

    return {
        init: init
    };
}());