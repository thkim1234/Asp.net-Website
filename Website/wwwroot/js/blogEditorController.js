// blogEditorController.js

(function() {
    "use strict";

    angular.module("app-blogs")
        .controller("blogEditorController", blogEditorController);

    function blogEditorController($routeParams, $http) {
        var vm = this;

        vm.blogTitle = $routeParams.blogTitle;
        vm.comments = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/blogs/" + vm.blogTitle + "/comments")
            .then(function(response) {
                    //success
                    angular.copy(response.data, vm.comments);
                },
                function(err) {
                    vm.errorMessage = "Failed to load comments";
                })
            .finally(function() {
                vm.isBusy = false;
            });
    }

})();