var internalMoneyApp = angular.module('internalMoneyApp', ["ngRoute"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/question',
        {
            templateUrl:'Views/question.html',
            controller:'QuestionController'
        });
        $routeProvider.when('/answer',
        {
            templateUrl:'Views/answer.html',
            controller:'AnswerController'
        });
        $routeProvider.when(
            "/test",
            {
                templateUrl:'Views/test.html',
                controller:'TestController'
            }
        );
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });
});