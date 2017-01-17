internalMoneyApp.controller('RegistrationController',
    function RegistrationController($scope, $route, $http) {
        var vm = this;

        vm.registration = registration;

        vm.error = false;
        
        function registration() {
            //vm.dataLoading = true;
            if (vm.email != '' && vm.email != '' && vm.password != '') {
                console.log(vm.user.username);
                $http({
                    url: "/api/Account/Register",
                    method: "POST",
                    data: 
                        {
                            UserName: vm.user.username,
                            Email: vm.user.email,
                            Password: vm.user.password,
                            ConfirmPassword: vm.user.password
                        },
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


var vm = this;

vm.register = register;

function register() {
    vm.dataLoading = true;
    UserService.Create(vm.user)
        .then(function (response) {
            if (response.success) {
                FlashService.Success('Registration successful', true);
                $location.path('/login');
            } else {
                FlashService.Error(response.message);
                vm.dataLoading = false;
            }
        });
}