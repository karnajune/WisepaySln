wisepaymodule.controller("paymentmodel", ['$scope', '$routeParams', 'viewModelHelper', 'mysharedservice', '$location', '$rootScope', '$filter',
    function ($scope, $routeParams, viewModelHelper, mysharedservice, $location, $rootScope, $filter) {

        $scope.viewModelHelper = viewModelHelper;
        $scope.IsRedirectionVisible = true;
        $scope.IspaymentDivVisible = false;
        var filldetailsofpage;
        var redirecttohome;


        var initialize = function () {
            $scope.pageheading = "Wisepay Insitute Details Page";
            if (($rootScope.currentcandidateDetails != null || $rootScope.currentcandidateDetails != undefined) &&
            ($rootScope.currentinstituteDetails != null || $rootScope.currentinstituteDetails != undefined)) {
                $scope.IsRedirectionVisible = false;
                $scope.IspaymentDivVisible = true;

                filldetailsofpage();
            }
        };
        filldetailsofpage = function () {
            $scope.candidatenumber = $rootScope.currentcandidateDetails.id;
            $scope.candidatename = $rootScope.currentcandidateDetails.candidatename;
            $scope.candidateaddress = $rootScope.currentcandidateDetails.candidatecomments;


            $scope.institutenumber = $rootScope.currentinstituteDetails.id;
            $scope.institutename = $rootScope.currentinstituteDetails.institutename;
            $scope.instituteaddress = $rootScope.currentinstituteDetails.instituteaddress;
        };
        var resetpaymentdetails = function () {
            $scope.paymentamount = '';
            $scope.paymentrelatedcomments = '';
            $scope.cardnumber = '';
            $scope.cardexpirydatemonth = '';
            $scope.cardexpirydateyear = '';
            $scope.cardcvv = '';

        }

        var validateDataEntered = function () {
            if ($scope.paymentamount == undefined || $scope.paymentamount.length === 0) {
                swal("", "'Please enter valid payment amount!", "warning");
                return false;
            }
            if ($scope.paymentrelatedcomments == undefined || $scope.paymentrelatedcomments.length === 0) {
                swal("", "'Please enter payment related comments!", "warning");
                return false;
            }
            if ($scope.cardnumber == undefined || $scope.cardnumber.toString().length === 0) {
                swal("", "'Please enter long card number!", "warning");
                return false;
            }
            if ($scope.cardexpirydatemonth == undefined || $scope.cardexpirydatemonth.toString().length === 0) {
                swal("", "'Please enter card expiry month!", "warning");
                return false;
            }
            if ($scope.cardexpirydateyear == undefined || $scope.cardexpirydateyear.toString().length === 0) {
                swal("", "'Please enter card expiry year!", "warning");
                return false;
            }
            if ($scope.cardcvv == undefined || $scope.cardcvv.toString().length === 0) {
                swal("", "'Please enter CVV code for card!", "warning");
                return false;
            }
            if ($scope.cardholdersname == undefined || $scope.cardholdersname.length === 0) {
                swal("", "'Please enter Card Holders Name!", "warning");
                return false;
            }
            if ($scope.paymentbillingaddress == undefined || $scope.paymentbillingaddress.length === 0) {
                swal("", "'Please enter Billing address!", "warning");
                return false;
            }
            return true;
        };
        $scope.pay = function () {
            if (validateDataEntered()) {
                // to call paymentgateway service

                var transactionmodel = {
                    id: $scope.candidatenumber,
                    MemberId:$scope.candidatenumber,
                    TransactionDoneBy: $rootScope.globals.currentUser.username,
                    TransactionDate: $filter('date')(new Date(), 'yyyy-MM-dd HH:mm:ss'),
                    Amount: $scope.paymentamount,
                    Comments: $scope.paymentrelatedcomments,
                    PaymentGuid: 'XXFGHDKHYS',
                    PaymentRef: 'THIRD TRANSACTION',
                    PaymentStatus: 'SUCCESS'

                };

                $.ajax({
                    type: "POST",
                    data: JSON.stringify(transactionmodel),
                    url: "api/transactions/add",
                    contentType: "application/json",
                    success: function (data) {
                        if (data.indexOf('Failed') != -1) {
                            swal("!", data, "error");
                            resetpaymentdetails();
                        }
                        swal("Success", 'Payment Successfull', 'success');
                        resetpaymentdetails();
                        mysharedservice.clearDetails();
                        redirecttohome();
                    }
                });
            };
        };

        $scope.cancel = function () {
            swal({
                title: "Are you sure you want to cancel payment now",
                text: "You can return and search for candidate to pay at a later date.",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Cancel Anyway!",
                closeOnConfirm: true
            },
             function () {
                 resetpaymentdetails();
                 redirecttohome();
                 mysharedservice.clearDetails();
             });
        };
        redirecttohome = function() {
            viewModelHelper.navigateTo('home');
            window.location.pathname = 'home/wisepaylanding';
        };
        initialize();
    }
]);