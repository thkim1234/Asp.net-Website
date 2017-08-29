// newBlogController.js

(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-blogs")
        .controller("newBlogController", newBlogController);

    function newBlogController($http) {

        var vm = this;

        vm.blogs = [];

        vm.newBlog = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        vm.addBlog = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/blogs", vm.newBlog)
                .then(function (response) {
                        // Success
                        vm.blogs.push(response.data);
                        vm.newBlog = {};
                    },
                    function () {
                        // Failure
                        vm.errorMessage = "Failed to save a new blog";
                    })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }

})();