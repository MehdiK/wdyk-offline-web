require.config({
    paths: {
        'jquery': 'jquery-1.6.2',
        'jquery/ui': 'jquery-ui-1.8.11'
    },
    shim: {
        'jquery/ui': ['jquery'],
        "amplify": {
            deps: ["jquery"],
            exports: "amplify"
        }
    }
});

require(['jquery', 'amplify', 'offline/connectivity', 'jquery/ui'],
    function ($, amplify, connectivity) {
            connectivity.init();
    });
