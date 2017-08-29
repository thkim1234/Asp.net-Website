//// readerBlogsController.js
//(function () {

//    "use strict";

//    // Getting the existing module
//    angular.module("app-blogs")
//        .controller("readerBlogsController", readerBlogsController);

//    function readerBlogsController($http) {

//        var vm = this;

//        vm.blogs = [];

//        vm.errorMessage = "";
//        vm.isBusy = true;

//        $http.get("/api/blogs")
//            .then(function (response) {
//                    // Success
//                    angular.copy(response.data, vm.blogs);
//                },
//                function (error) {
//                    // Failure
//                    vm.errorMessage = "Failed to load data: " + error;
//                })
//            .finally(function () {
//                vm.isBusy = false;
//            });
//    }

//})();