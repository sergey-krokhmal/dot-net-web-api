var internalMoneyApp = angular.module('internalMoneyApp', ["ngRoute", "ngCookies"])
    .config(function ($routeProvider, $locationProvider, $cookiesProvider) {
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
        .when(
            "/home",
            {
                templateUrl: 'Views/home.html',
            }
        )
        .otherwise({ redirectTo: '/home' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });
        $cookiesProvider.defaults.path = '/';
    })
    .run(function ($rootScope, $location, $cookieStore, $http) {

        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        console.log("rootScope:");
        console.log($rootScope.globals);
        console.log("-rootScope:");
        console.log($rootScope.globals.currentUser);
        $rootScope.logedIn = false;
        if ($rootScope.globals.currentUser) {
            $rootScope.logedIn = true;
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + $rootScope.globals.currentUser.token;
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            console.log($rootScope.globals.currentUser);
            if ($location.path() !== '/login' && !$rootScope.globals.currentUser && $location.path() !== '/registration') {
                $location.path('/login');
            }
        });
    });