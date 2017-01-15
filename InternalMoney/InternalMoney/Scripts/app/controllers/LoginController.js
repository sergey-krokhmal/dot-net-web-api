internalMoneyApp.controller('LoginController',
    function TestController($scope, $route, $http) {
        var vm = this;

        vm.login = login;

        function login() {
            //vm.dataLoading = true;
            if (vm.email != '' && vm.password != '') {
                console.log('wrong');
                $http({
                    url: "api/Login",
                    method: "POST",
                    data: {"Login": vm.email, "Password": vm.password},
                    headers: {
                        "Content-Type": "application/json"
                    }
                })
                .then(function successCallback(response) {
                    console.log(response.data);
                    console.log(response.status);
                    $scope.data = response.data;
                }, function errorCallback(response) {
                    $scope.status = response.status;
                    console.log(response.data);
                    console.log(response.status);
                });
            } else {
                console.log('work');
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
        console.log("It is work");
    }
)