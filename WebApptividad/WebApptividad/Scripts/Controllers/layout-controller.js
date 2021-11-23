angular.module('appTividadApp', []).
    controller('LayoutController', function ($scope) {
        $scope.cust = {};
        $scope.message = 'Hola mundo';
       
    }).config(function ($locationProvider) {
        //default = 'false'  
        $locationProvider.html5Mode(true);
    });