'use strict';
app.factory('camlogService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var camLogFactory = {};

    var _getcamLogs = function () {

        return $http.get(serviceBase + 'api/camlog/logs').then(function (results) {
            return results;
        });
    };

    camLogFactory.getCamLogs = _getcamLogs;

    return camLogFactory;
}]);