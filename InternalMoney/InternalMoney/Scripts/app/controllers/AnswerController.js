internalMoneyApp.controller('AnswerController',
    function AnswerController($scope, $http){
		
        $scope.$on('$routeChangeStart', function (event, next, current) {
            if (typeof (current) !== 'undefined') {
                $templateCache.remove(next.templateUrl);
                console.log("Remove cache");
                console.log(next);
                console.log(current);
                console.log("------------");
            }
        });
        $scope.save = function (answer, answerForm){
            if(answerForm.$valid){
                console.log("Form is valid");
                console.log(answer);
                console.log(answerForm);
                console.log("-------------");
				/*$http.post("postAnswer.php", answer).success(function (answ) {
					$scope.response=answ;
				});*/
            }
        };
    }
)