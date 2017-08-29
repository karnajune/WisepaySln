wisepaymodule.controller("rootviewmodel", ['$scope', 'viewModelHelper', '$rootScope','Auth', function ($scope, viewModelHelper, $rootScope,Auth) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.currentloggedinuser = '';
    $scope.iscustomer = false;
    $scope.iscallcenteruser = false;


    var initialize = function () {
        $scope.pageHeading = "Wisepay Section";
        //|| $rootScope.globals.currentUser != null || $rootScope.globals.currentUser != ""
        if ($rootScope.globals.currentUser != undefined || $rootScope.globals.currentUser !=null) {
            $scope.currentloggedinuser = $rootScope.globals.currentUser.username;
            $scope.iscustomer = $rootScope.globals.currentUser.IsCustomer;
            $scope.iscallcenteruser = $rootScope.globals.currentUser.IsCallCenterUSer;
            $scope.showlogin = false;
            $scope.showsignout = true;
        } else {
            $scope.showlogin = true;
            $scope.showsignout = false;
        }

    }
    $scope.goHome = function () {
        viewModelHelper.navigateTo('home');
    };
    $scope.gotoregisternewclient = function () {
        viewModelHelper.navigateTo('register');
    };
    $scope.gotoregisteradminuser=function() {
        viewModelHelper.navigateTo('registeradminuser');
    }
    $scope.gotoaboutus = function () {
        viewModelHelper.navigateTo('aboutus');
    };
    $scope.gotologin = function () {
        viewModelHelper.navigateTo('login');
    };
    $scope.gotosearch = function () {
        viewModelHelper.navigateTo('details');
    };
    $scope.gotoprocesspayment = function () {
        viewModelHelper.navigateTo('payment');
    };
    $scope.signout=function() {
        Auth.ClearCredentials();
        window.location.pathname = 'home/wisepaylanding';
    }
    initialize();
}]);