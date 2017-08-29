wisepaymodule.controller("detailsmodel", ['$scope', '$routeParams', 'viewModelHelper', 'Auth', '$location', 'mysharedservice', function ($scope, $routeParams, viewModelHelper, Auth, $location, mysharedservice) {

    var getinstitutesregistered;
    var gettransactiondetails;

    $scope.viewModelHelper = viewModelHelper;
    var initialize = function () {
        $scope.pageheading = "Wisepay Insitute Details Page";
        getinstitutesregistered();
        $('#searchresults').hide();
        $('#transactiondetailsDiv').hide();
        $('#institutesDropDown').show();
        $('#candidatesdropdown').show();

    };
    var validate=function() {
        if ($scope.institutename == undefined || $scope.institutename == null) {
            swal("", "'Please select an institute!", "warning");
            return false;
        }
        if ($scope.candidatename == undefined || $scope.candidatename == null) {
            swal("", "'Please select a candidate!", "warning");
            return false;
        }
        return true;
    }
     getinstitutesregistered= function() {
         viewModelHelper.apiGet('api/institutes/get', null, function(result) {
             if(result.data == undefined || result.data.length == 0) {
                    swal("Oops!!",
                        "something went wrong with data from DB. No institutes returned. Contact Admin / Go to Home " + result.statusText,
                        "info");
                    $('#institutesDropDown').hide();
                    $('#candidatesdropdown').hide();
                } else {
                    $scope.myinstituteslist = result.data;
                }
            });
     }

     $scope.instituteselecteditemchanged = function () {
         $('#searchresults').hide();
         $('#transactiondetailsDiv').hide();
        viewModelHelper.apiGet('api/members/get/' + $scope.institutename.id,
            null,
            function(result) {
                if (result.data == undefined || result.data.length == 0) {
                    swal("Oops!!",
                        "something went wrong with data from DB. No candidates returned " + result.statusText,
                        "info");
                    $('#candidatesdropdown').hide();
                } else {
                    $scope.mycandidateslist = result.data;
                    $('#candidatesdropdown').show();
                }
            });
    }

     $scope.candidateselecteditemchanged = function () {
         $('#searchresults').hide();
         $('#transactiondetailsDiv').hide();
         viewModelHelper.apiGet('api/member/getdetails/' + $scope.candidatename.id, null,
              function(result) {
                  if (result.data == undefined || result.data.length == 0) {
                      swal("Oops!!",
                          "something went wrong with data from DB. No candidate details returned " + result.statusText,
                          "info");
                      $('#searchresults').hide();
                  } else {
                      $scope.candidatedetails = result.data;
                      $('#searchresults').show();
                      gettransactiondetails($scope.candidatename.id);
                  }
                  //initialize();
              });
    }
    gettransactiondetails = function (memberId) {
        viewModelHelper.apiGet('api/transactions/getbymember/' +memberId, null,
              function(result) {
                  if (result.data == undefined || result.data.length == 0) {
                      //swal("Oops!!",
                      //    "something went wrong with data from DB. No transaction details returned" + result.statusText,
                      //    "info");
                      $('#transactiondetailsDiv').hide();
                      $('#transactionhistorymessage').show();
                      $scope.transactionhistorymessage = "There are no transactions to display for this candidate";

                  } else {
                      $scope.transactionslist = result.data;
                      $('#transactionhistorymessage').hide();
                      $('#transactiondetailsDiv').show();
                  }
                  //initialize();
              });
        
    }
    $scope.proceedtopayment = function () {
        if (validate()) {
            mysharedservice.setinstituteDetails($scope.institutename.id,
                $scope.institutename.name,
                $scope.institutename.address);
            mysharedservice.setcandidatedetails($scope.candidatename.id,
                $scope.candidatename.firstName + '  ' + $scope.candidatename.lastName,
                $scope.candidatename.comments);
            viewModelHelper.navigateTo('payment');
        }
    }

    initialize();
}]);