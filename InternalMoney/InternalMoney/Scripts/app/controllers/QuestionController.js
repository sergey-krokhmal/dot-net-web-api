internalMoneyApp.controller('QuestionController',
    function QuestionController($scope, dataService){
     
        /*var promiseObj=dataService.getData();
        promiseObj.then(function(value) { $scope.question=value; });*/
        $scope.question = {
            "question": {
                "text": "����� js-��������� ����� ������������?",
                "author": "���� ������",
                "date": "20/10/2013",
                "answers":
                [{
                    "text": "AngularJS!",
                    "author": "���� �������",
                    "date": "20/10/2013",
                    "rate": 2
                }, {
                    "text": "AngularJS ����� ����",
                    "author": "���� ��������",
                    "date": "21/10/2013",
                    "rate": 3
                }]
            }
        };
         
        $scope.voteUp = function (answer){
            answer.rate++;
        };
        $scope.voteDown = function (answer){
            answer.rate--;
        };
    }
)