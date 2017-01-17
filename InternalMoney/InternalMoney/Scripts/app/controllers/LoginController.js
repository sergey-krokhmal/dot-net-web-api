internalMoneyApp.controller('LoginController',
    function LoginController($scope, $route, $http, $cookieStore, $rootScope, $location) {
        var vm = this;

        vm.login = login;

        vm.error = false;

        if ($cookieStore.get('globals') !== undefined){
            $http({
                url: "api/Account/Logout",
                method: "POST"
            })
            .then(function successCallback(response) {
                if (response.status == 200) {
                    $cookieStore.remove('globals');
                }
            });
        }

        function login() {
            //vm.dataLoading = true;
            if (vm.email != '' && vm.password != '') {
                $http({
                    url: "/Token",
                    method: "POST",
                    data: "grant_type=password&username="+vm.email+"&password="+vm.password,
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded"
                    }
                })
                .then(function successCallback(response) {
                    if (response.status == 200) {
                        token = response.data.access_token;
                        $rootScope.globals = {
                            currentUser: {
                                email: vm.email,
                                token: token
                            }
                        };
                        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;
                        $cookieStore.put('globals', $rootScope.globals);
                        $location.url('/home');
                    } else {
                        if (response.data.Message !== undefined) {
                            vm.error = true;
                            vm.errorMsg = response.data.Message;
                        } else {
                            vm.error = false;
                        }
                    }
                }, function errorCallback(response) {
                    
                    console.log(response.data);
                    console.log(response.status);
                });
            } else {
            
            }
            /*$http({
                url: "http://example.appspot.com/rest/app",
                method: "GET",
                data: { "foo": "bar" }
            }).success(function (data, status, headers, config) {
                $scope.data = data;
            }).error(function (data, status, headers, config) {
                $scope.status = status;
            });*/
        };
    }
)