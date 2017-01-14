var questApp = angular.module('internalMoneyApp', ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when('/test',
        {
            templateUrl: 'Views/test.html',
            controller: 'TestController'
        });
    });