// blogsController.js
(function() {

    "use strict";

    // Getting the existing module
    angular.module("app-blogs")
        .controller("blogsController", blogsController);

    function blogsController($http) {

        var vm = this;

        vm.blogs = [];

        //vm.newBlog = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/blogs")
            .then(function(response) {
                    // Success
                    angular.copy(response.data, vm.blogs);
                },
                function(error) {
                    // Failure
                    vm.errorMessage = "Failed to load data: " + error;
                })
            .finally(function() {
                vm.isBusy = false;
            });

        //vm.addBlog = function() {

        //    vm.isBusy = true;
        //    vm.errorMessage = "";

        //    $http.post("/api/blogs", vm.newBlog)
        //        .then(function (response) {
        //            // Success
        //            vm.blogs.push(response.data);
        //            vm.newBlog = {};
        //        },
        //        function() {
        //            // Failure
        //            vm.errorMessage = "Failed to save a new blog";
        //        })
        //        .finally(function() {
        //            vm.isBusy = false;
        //        });
        //};
    }

})();