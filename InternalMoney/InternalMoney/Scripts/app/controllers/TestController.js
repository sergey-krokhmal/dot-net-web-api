internalMoneyApp.controller('TestController',
    function TestController($scope, $route) {
        var p = $route.current.params;

        $scope.path = '/';
        if (p.p1) $scope.path += p.p1;
        if (p.p2) $scope.path += '/' + p.p2;
        if (p.p3) $scope.path += '/' + p.p3;

        console.log("It is work");
        $scope.testt = {"tt":"2"};
    }
)