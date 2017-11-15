'use strict';
app.controller('homeController', ['$scope', 'camlogService', function ($scope,$camlogservice) {
   
    $scope.message = "";
    $scope.expenses = [];
    $camlogservice.getCamLogs().then(function (results) {

        console.log(results.data);
        $scope.camlogs = results.data;

        //chartlib


        $scope.myChartObject = {};

        $scope.myChartObject.type = "ColumnChart";

        

        $scope.myChartObject.data = {
            "cols": [
                { id: "t", label: "time", type: "string" },
                { id: "s", label: "eventhit", type: "number" }
            ], "rows": [
                {
                    c: [
                        { v: "Mushrooms" },
                        { v: 3 },
                    ]
                },
                {
                    c: [
                        { v: "Olives" },
                        { v: 31 }
                    ]
                },
                {
                    c: [
                        { v: "Zucchini" },
                        { v: 1 },
                    ]
                },
                {
                    c: [
                        { v: "Pepperoni" },
                        { v: 2 },
                    ]
                }
            ]
        };

        $scope.myChartObject.options = {
            'title': 'How Much Pizza I Ate Last Night'
        };

    }, function (error) {
        //alert(error.data.message);
    });


   
}]);