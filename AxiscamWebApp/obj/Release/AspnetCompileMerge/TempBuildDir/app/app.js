
var app = angular.module('AxisCamApp', ['ngRoute', 'googlechart', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {
   
    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "app/views/home.html"
    });
   

    $routeProvider.otherwise({ redirectTo: "/home" });

});


var serviceBase = "http://10.63.216.83:8080/";

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});



