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
            App.setCustomInvalidHandler();

        },

        setCustomInvalidHandler: function () {

            var $forms = $('form');
            $.each($forms, function (key, value) {
                $forms.off('invalid-form.validate')
                    .on('invalid-form.validate', newInvalidHandler);
                //$forms.bind('invalid-form.validate', newInvalidHandler);
            });
        }
    };
}();

function newInvalidHandler(event, validator) {
    var container = $($('form')).find("[data-valmsg-summary=true]"),
        list = container.find("ul");

    if (list && list.length && validator.errorList.length) {
        list.empty();
        container.addClass("validation-summary-errors").removeClass("validation-summary-valid");
        
        list.prepend('<i class="fas fa-exclamation-circle"></i>');

        $.each(validator.errorList, function () {
            $("<li />").html(this.message).appendTo(list);
        });

    }
}
