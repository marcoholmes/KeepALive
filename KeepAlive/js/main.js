var App = function () {

    // Update dynamic content validation.
    function updateDynamicContent(selector) {
        var $elem = $(selector);

        // remove validation data
        $elem.find('form').each(function (index, element) {
            $(this).removeData("validator"); /* added by the raw jquery.validate plugin */
            $(this).removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin */
        });

        // set validation
        $.validator.unobtrusive.parse($elem);

        $(":input").inputmask();

        $('.input-validation-error').parents('.form-group')
            .addClass('has-validation-error');
    }

    return {
        // Update dynamic content validation.
        updateValidation: function (selector) {
            var $elem = $(selector);

            // remove validation data
            $elem.find('form').each(function (index, element) {
                $(this).removeData("validator"); /* added by the raw jquery.validate plugin */
                $(this).removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin */
            });

            // set validation
            $.validator.unobtrusive.parse($elem);

            $('.input-validation-error').parents('.form-group')
                .addClass('has-validation-error');
        }
    };
}();