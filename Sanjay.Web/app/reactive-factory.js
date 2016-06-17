(function () {
    'use strict';

    
    sanjaytestModule.factory("MY_Fac", function MY_Fac() {
        return {
             getThrottle: _createThrottle
        };

        function _createThrottle(delay) {
            var throttleTimer = 2000;
            var throttleDelay = delay;

            if (!throttleDelay) {
                throttleDelay = 2500;
            }

            return {
                run: function(action) {
                    return function() {
                        clearTimeout(throttleTimer);

                        throttleTimer = setTimeout(function() {
                            action.apply();
                            throttleTimer = null;
                        }, throttleDelay);
                    }();
                }
            };
        }

    });
})();


