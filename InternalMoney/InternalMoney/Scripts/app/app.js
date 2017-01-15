var internalMoneyApp = angular.module('internalMoneyApp', ["ngRoute"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/question',
        {
            templateUrl:'Views/question.html',
            controller:'QuestionController'
        })
        .when('/answer',
        {
            templateUrl:'Views/answer.html',
            controller:'AnswerController'
        })
        .when(
            "/test",
            {
                templateUrl:'Views/test.html',
                controller:'TestController'
            }
        )
        .when(
            "/login",
            {
                templateUrl: 'Views/login.html',
                controller: 'LoginController',
                controllerAs: 'vm'
            }
        )
        .otherwise({ redirectTo: '/login' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });
});