// app-blogs.js
(function() {

    "use strict";

    // Creating the module
    angular.module("app-blogs", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/",
                {
                controller: "blogsController",
                controllerAs: "vm",
                templateUrl: "/views/blogsView.html"
                });

            $routeProvider.when("/editor/:blogTitle",
                {
                    controller: "blogEditorController",
                    controllerAs: "vm",
                    templateUrl: "/views/blogEditorView.html"
                });

            $routeProvider.when("/newBlog",
                {
                    controller: "newBlogController",
                    controllerAs: "vm",
                    templateUrl: "/views/newBlogView.html"
                });

            //$routeProvider.when("/readerBlogs",
            //    {
            //        controller: "readerBlogsController",
            //        controllerAs: "vm",
            //        templateUrl: "/views/readerBlogsView.html"
            //    });

            $routeProvider.otherwise({ redirectTo: "/" });

        });
})();