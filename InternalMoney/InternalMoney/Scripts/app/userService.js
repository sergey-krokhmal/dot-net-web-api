internalMoneyApp.factory('userService', function ($http, $q) {
    return {
        getData: function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/Users' }).
             success(function (data, status, headers, config) {
                 console.log(data);
                 deferred.resolve(data);
             }).
            error(function (data, status, headers, config) {
                console.log(status);
                deferred.reject(status);
            });

            return deferred.promise;
        }
    }
})