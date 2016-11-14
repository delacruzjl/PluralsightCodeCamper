(function () {

    QUnit.config.testTimeout = 10000;
    
    module("Webapi GET endpoints respond successfully");

    var apiUrls = [
        "/api/lookups/all/",
        "/api/lookups/rooms/",
        "/api/lookups/timeslots/",
        "/api/lookups/all/",
        "/api/sessions/",
        "/api/persons/",
        "/api/speakers/"
    ];

    var endpointTest = function (url) {
        console.log("here" + url);
        
        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            success: function(result) {
                ok(true, "GET succeded for " + url);
                ok(!!result, "GET retrieved some data");
                start();
            },
            error: function(reason) {
                ok(false, `GET on \"${url}\" failed with status \"${reason.status}\": ${reason.responseText}`);
                start();
            }
        });
    };

    var endpointTestGenerator = function (url) {
        console.log("generator");

        return function() { endpointTest(url); };
    };

    for (var i = 0; i < apiUrls.length; i ++) {
        var apiUrl = apiUrls[i];
        
        asyncTest("api can be reached: " + apiUrl,
                endpointTestGenerator(apiUrl));
    }
})();