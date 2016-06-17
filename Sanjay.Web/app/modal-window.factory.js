sanjaytestModule.factory('modal_MY_Fac', function ($modal) {

    var modal_MY_Controller = _modal_MY_Cont;

    return {

        // Show a modal window with the specified title and msg
        show: function (title, msg, confirmCallback, cancelCallback) {

            // Show window
            var modalInstance = $modal.open({
                templateUrl: 'app/templates/modal-window.view.html',
                controller: modal_MY_Controller,
                size: 'sm',
                resolve: {
                    title: function () {
                        return title;
                    },
                    body: function () {
                        return msg;
                    }
                }
            });

            // Register confirm and cancel callbacks
            modalInstance.result.then(
                // if any, execute confirm callback
                function() {
                    if (confirmCallback != undefined) {
                        confirmCallback();
                    }
                },
                // if any, execute cancel callback
                function () {
                    if (cancelCallback != undefined) {
                        cancelCallback();
                    }
                });
        }
    };


    // Internal controller used by the modal window
    function _modal_MY_Cont($scope, $MY_modalInstance, title, body) {
        $scope.title = "";
        $scope.body = "";

        // If specified, fill window title and message with parameters
        if (title) {
            $scope.title = title;
        }
        if (body) {
            $scope.body = body;
        }

        $scope.confirm = function () {
            $MY_modalInstance.close();
        };

        $scope.cancel = function () {
            $MY_modalInstance.dismiss();
        };
    };


});
