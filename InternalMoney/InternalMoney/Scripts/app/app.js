var internalMoneyApp = angular.module('internalMoneyApp', ["ngRoute"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider
        .when(
            "/login",
            {
                templateUrl: 'Views/login.html',
                controller: 'LoginController',
                controllerAs: 'vm'
            }
        )
        .when(
            "/registration",
            {
                templateUrl: 'Views/registration.html',
                controller: 'RegistrationController',
                controllerAs: 'vm'
            }
        )
        .otherwise({ redirectTo: '/login' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });
});