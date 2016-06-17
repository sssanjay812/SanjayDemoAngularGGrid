'use strict';
(function () {
    sanjaytestModule.controller("Add_Controller", Add_Controller);

    function Add_Controller(modal_MY_Fac) {

        var self = this;

        //// ---------------- PUBLIC ----------------
        //// PUBLIC fields
        self.gridController = {};

        //// PUBLIC Methods
        // Method executed when a button inside the grid is clicked
        self.gridOnButtonClick = _gridOnButtonClick;

        // Method executed when the grid is initialized
        self.gridOnInitialized = _gridOnInitialized;
        
        // API URL
        self.serverUrl = "/api/Items";

        //// ---------------- CODE TO RUN -----------

        //// ---------------- PRIVATE ---------------
        //// PRIVATE fields

        //// PRIVATE Functions - Public Methods Implementation	
        function _gridOnInitialized(controller) {
            self.gridController = controller;
        }

        function _gridOnButtonClick(sender, args) {
            console.log("button click" + args.button + " " + args.item.id);

            if (args.button == 'plus') {
                modal_MY_Fac.show(args.item.name, "Custom button click = +");
            }
            else if (args.button == 'minus') {
                modal_MY_Fac.show(args.item.name, "Custom button click = -");
            }
        }
  
    };
})();