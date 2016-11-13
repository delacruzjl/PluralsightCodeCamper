(function () {
    "use strict";

    ko.bindingHandlers.executeOnEnter = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
            var value = valueAccessor();

            $(element).keypress(onKeyPress);

            function onKeyPress(event) {
                var keyCode = (event.which ? event.which : event.keyCode);
                if (keyCode === 13) {

                    //contextually set the "this" object
                    value.call(viewModel);
                    return false;
                }

                return true;
            }
        }
    }

})();