var sanjaytestModule = angular.module('sanjaytestModule', [
    'ui.router',
    'ui.bootstrap',
    'ngResource'
]);

sanjaytestModule.
    config(function ($stateProvider, $urlRouterProvider) {

        // For any unmatched URL redirect to dashboard URL
        $urlRouterProvider.otherwise("/items");

        $stateProvider
            // Known items
            .state('items', {
                url: "/items",
                views: {
                    'main': {
                        templateUrl: "app/items/items.view.html",
                        controller: "Add_Controller as SanjayCtrl"
                    }
                },
            });

    });


