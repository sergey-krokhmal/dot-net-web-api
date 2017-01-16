internalMoneyApp.controller('LoginController',
    function TestController($scope, $route, $http) {
        var vm = this;

        vm.login = login;

        vm.error = false;

        function login() {
            //vm.dataLoading = true;
            if (vm.email != '' && vm.password != '') {
                $http({
                    url: "api/Login",
                    method: "POST",
                    data: {"Login": vm.email, "Password": vm.password},
                    headers: {
                        "Content-Type": "application/json"
                    }
                })
                .then(function successCallback(response) {
                    if (response.data.Message !== undefined) {
                        vm.error = true;
                        vm.errorMsg = response.data.Message;
                    } else {
                        vm.error = false;
                    }
                    console.log(response.data);
                    console.log(response.status);
                    $scope.data = response.data;
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