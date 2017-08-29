wisepaymodule.controller("aboutusmodel", ['$scope', '$routeParams', 'viewModelHelper', function ($scope, $routeParams, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    var initialize = function() {
        $scope.pageheading = "Welcome to About Us Page";
    };
    initialize();
}]);