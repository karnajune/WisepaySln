wisepaymodule.controller("registeradminusermodel", ['$scope', '$routeParams', 'viewModelHelper', '$filter', function ($scope, $routeParams, viewModelHelper, $filter) {
    var today = new Date();

    $scope.viewModelHelper = viewModelHelper;
    var initialize = function () {
        $scope.pageheading = "Welcome to Register Admin User Page";
        resetPage();
    };

    var resetPage = function () {
        $scope.userfirstname = '';
        $scope.lastname = '';
        $scope.username = '';
        $scope.userpassword = '';
        $scope.expirydate = '';
        $scope.userCommentsEntered = '';
        $scope.adminUserslist = '';
        $('#adminUserListDiv').hide();
    };


    $('#expirydate')
          .daterangepicker({
              startDate: today,
              singleDatePicker: true,
              showDropdowns: true,
              minDate: today,
              locale: {
                  format: 'DD/MM/YYYY'
              }
          },
              function (start, end, label) {
                  var selectedStartDate = $filter('date')(new Date(start), "dd/MM/yyyy");
                  $scope.expirydate = selectedStartDate;
              });


    var validateDataEntered = function () {
        if ($scope.userfirstname == undefined || $scope.userfirstname.length == 0) {
            swal("", "'Please enter First Name!", "warning");
            return false;
        }
        if ($scope.lastname == undefined || $scope.lastname.length == 0) {
            swal("", "'Please enter Last Name!", "warning");
            return false;
        }

        if ($scope.username == undefined || $scope.username.length == 0) {
            swal("", "'Please enter UserName!", "warning");
            return false;
        }

        if ($scope.userpassword == undefined || $scope.userpassword.length == 0) {
            swal("", "'Please enter Password!", "warning");
            return false;
        }

        if ($scope.expirydate == undefined || $scope.expirydate.length == 0) {
            swal("", "'Please enter Date!", "warning");
            return false;
        }
        if ($scope.userCommentsEntered == undefined) {
            $scope.userCommentsEntered = "No Comments added";
        }

        return true;
    };

    $scope.saveadminuserentry = function () {
        if (validateDataEntered()) {
            var selectedDate = $('#expirydate').data('daterangepicker').startDate.format('YYYY-MM-DD');

            var addadminusermodel = {
                FirstName: $scope.userfirstname,
                LastName: $scope.lastname,
                UserName: $scope.username,
                Password: $scope.userpassword,
                Comments: $scope.userCommentsEntered,
                Registereddate: $filter('date')(new Date(), 'yyyy-MM-dd'),
                RoleExpirtyDate: selectedDate,
                IsActive: true,
                IsCustomer: true,
                IsCallCenterUSer:true
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(addadminusermodel),
                url: "api/adminuser",
                contentType: "application/json",
                success: function (data) {
                    if (data.indexOf('Failed') != -1) {
                        swal("!", data, "error");
                        initialize();
                    }
                    swal("Success", data, "success");
                    initialize();
                }
            });
            //resetPage();
        };
    }
    $scope.listadminusers = function() {

        viewModelHelper.apiGet("api/adminusers/get",null,function (result) {
            if (result.data == undefined || result.data == null || result.data.length == 0) {
                swal("", "Failed to load any Admin Users or No users to be listed", "error");
            } else {
                $('#adminUserListDiv').show();
                $scope.adminUserslist = result.data;
            }
        });
    };
    $scope.hidelist = function() {
        $('#adminUserListDiv').hide();
    };
    initialize();

}]);