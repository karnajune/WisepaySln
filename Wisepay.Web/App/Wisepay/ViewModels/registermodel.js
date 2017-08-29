wisepaymodule.controller("registermodel", ['$scope', '$routeParams', 'viewModelHelper', '$filter', 'Auth', '$location', function ($scope, $routeParams, viewModelHelper, $filter, Auth, $location) {
    var today = new Date();
    var getinstitutesregistered;

    $scope.viewModelHelper = viewModelHelper;
    var initialize = function () {
        $scope.pageheading = "Welcome to Registration Page";
    };


    $scope.$watch(Auth.isLoggedIn, function (value, oldValue) {

        if (!value && oldValue) {
            console.log("Disconnect");
            $location.path('/login');
            viewModelHelper.navigateTo('login');
        }

        if (value) {
            console.log("Connect");
            //Do something when the user is connected
        }

    }, true);


    $('#memberexpirydate')
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

    $('#instituteexpirydate')
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
                  $scope.instituteexpirydate = selectedStartDate;
              });

    var validateDataEntered = function () {
        if ($scope.institutename == undefined || $scope.institutename.length == 0) {
            swal("", "'Please enter Institute Name!", "warning");
            return false;
        }
        if ($scope.instituteaddress == undefined || $scope.instituteaddress.length == 0) {
            swal("", "'Please enter Address!", "warning");
            return false;
        }

        if ($scope.institutenumber == undefined || $scope.institutenumber.length == 0) {
            swal("", "'Please enter Phone Number!", "warning");
            return false;
        }

        if ($scope.institutecategory == undefined || $scope.institutecategory.length == 0) {
            swal("", "'Please enter Institute Category!", "warning");
            return false;
        }

        if ($scope.instituteexpirydate == undefined || $scope.instituteexpirydate.length == 0) {
            swal("", "'Please enter Date!", "warning");
            return false;
        }
        if ($scope.institutecommentsentered == undefined || $scope.institutecommentsentered.length == 0) {
            $scope.institutecommentsentered = "No Comments added";
        }

        return true;
    };
    var validateFieldsEntered=function() {
        if ($scope.dropdowninstitutename == undefined || $scope.dropdowninstitutename.length == 0) {
            swal("", "'Please select Institute Name!", "warning");
            return false;
        }
        if ($scope.memberfirstname == undefined || $scope.memberfirstname.length == 0) {
            swal("", "'Please enter FirstName!", "warning");
            return false;
        }

        if ($scope.memberlastname == undefined || $scope.memberlastname.length == 0) {
            swal("", "'Please enter LastName!", "warning");
            return false;
        }

        if ($scope.memberusername == undefined || $scope.memberusername.length == 0) {
            swal("", "'Please enter Username!", "warning");
            return false;
        }

        if ($scope.memberpassword == undefined || $scope.memberpassword.length == 0) {
            swal("", "'Please enter Password!", "warning");
            return false;
        }
        if ($scope.memberexpirydate == undefined || $scope.memberexpirydate.length == 0) {
            swal("", "'Please select Date!", "warning");
            return false;
        }
        if ($scope.memberCommentsEntered == undefined || $scope.memberCommentsEntered.length == 0) {
            $scope.memberCommentsEntered = "No Comments added";
        }

        return true;
    }

    var resetinstitutevalues = function () {
        $scope.institutename = '';
        $scope.instituteaddress = '';
        $scope.institutenumber = '';
        $scope.institutecategory = '';
        $scope.instituteexpirydate = '';
        $scope.institutecommentsentered = '';
        
    }
    var resetcandidatevalues = function () {
        $scope.myinstituteslist = '';
        $scope.memberfirstname = '';
        $scope.memberlastname = '';
        $scope.memberusername = '';
        $scope.memberpassword = '';
        $scope.memberCommentsEntered = '';
        $scope.memberexpirydate = '';
    }
    $scope.registercandidate = function () {
        getinstitutesregistered();
        $('#register-user-entry').modal('show');
    };

    $scope.registerinstitute = function () {
        $('#register-institute-entry').modal('show');
        resetinstitutevalues();
    };
    $scope.savememberentry=function() {
        if (validateFieldsEntered) {
            $scope.memberexpirydate = $('#memberexpirydate').data('daterangepicker').startDate.format('YYYY-MM-DD');

            var memberentrymodel = {
                instituteId: $scope.dropdowninstitutename.id,
                FirstName: $scope.memberfirstname,
                LastName: $scope.memberlastname,
                UserName: $scope.memberusername,
                Password: $scope.memberpassword,
                Comments: $scope.memberCommentsEntered,
                Registereddate: $filter('date')(new Date(), 'yyyy-MM-dd'),
                MembershipExpirtyDate: $scope.memberexpirydate,
                IsActive: true
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(memberentrymodel),
                url: "api/members/add",
                contentType: "application/json",
                success: function (data) {
                    if (data.indexOf('Failed') != -1) {
                        swal("!", data, "error");
                        $('#register-user-entry').modal('hide');
                        resetcandidatevalues();
                    }
                    swal("Success", data, "success");
                    $('#register-user-entry').modal('hide');
                    resetcandidatevalues();
                }

            });
            resetcandidatevalues();
        }
    }
    $scope.saveinstituteentry = function () {
        if (validateDataEntered()) {
            $scope.instituteexpirydate = $('#instituteexpirydate').data('daterangepicker').startDate.format('YYYY-MM-DD');

            var addinstitutemodel = {
                Name: $scope.dropdowninstitutename,
                Address: $scope.instituteaddress,
                PhoneNumber: $scope.institutenumber,
                Category: $scope.institutecategory,
                Comments: $scope.institutecommentsentered,
                Registereddate: $filter('date')(new Date(), 'yyyy-MM-dd'),
                MembershipExpirtyDate: $scope.instituteexpirydate,
                IsActive: true
            };

            $.ajax({
                type: "POST",
                data: JSON.stringify(addinstitutemodel),
                url: "api/institute/add",
                contentType: "application/json",
                success: function (data) {
                    if (data.indexOf('Failed') != -1) {
                        swal("!", data, "error");
                        $('#register-institute-entry').modal('hide');
                        resetinstitutevalues();
                    }
                    swal("Success", data, "success");
                    $('#register-institute-entry').modal('hide');
                    resetinstitutevalues();
                }
            });
            resetinstitutevalues();
        };

    }
    getinstitutesregistered=function() {
        viewModelHelper.apiGet('api/institutes/get', null, function (result) {
            if (result.data == undefined || result.data.length == 0) {
                swal("Oops!!", "something went wrong with data from DB. No institutes returned" + result.statusText, "info");
            } else {
                $scope.myinstituteslist = result.data;
            }
        });
    }
    initialize();

}]);