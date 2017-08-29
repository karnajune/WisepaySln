wisepaymodule.controller("loginmodel", ['$scope', '$routeParams', 'viewModelHelper', 'Auth', function ($scope, $routeParams, viewModelHelper, Auth) {

    $scope.viewModelHelper = viewModelHelper;
    var initialize = function () {
        $scope.pageheading = "Wisepay Login Page";
    };

    $scope.redirecttoregister = function () {
        viewModelHelper.navigateTo('registeradminuser');
    }
    var validateDataEntered = function () {
        if ($scope.username == undefined || $scope.username.length == 0) {
            swal("", "'Please enter UserName!", "warning");
            return false;
        }

        if ($scope.password == undefined || $scope.password.length == 0) {
            swal("", "'Please enter Password!", "warning");
            return false;
        }
        return true;
    };
    $scope.letmein = function() {
        if (validateDataEntered()) {
            Auth.Login($scope.username, $scope.password).then(function (loginstatus) {
                if (loginstatus==undefined || loginstatus == null || loginstatus.data == null) {
                    swal("", "Login Failed!!!", "error");
                } else {
                    Auth.SetCredentials($scope.username, $scope.password, loginstatus.data.isCustomer, loginstatus.data.isCallCenterUSer);
                    window.location.pathname = 'home/wisepaylanding';
                }
            });
        };
    };
    initialize();
}]);