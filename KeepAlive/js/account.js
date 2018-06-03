
$(function () {

    var $container = $('#account');

    $container.on("click", "#user-recovery", function () {
        $.ajax({
            url: "userRecovery/account",
            type: "get",
            async: true,
            success: function (html) {
                $('#account').html(html);
                App.updateValidation($container);
            }
        })
    });

    $container.on("click", "#pwd-recovery", function () {
        $.ajax({
            url: "pwdRecovery/account",
            type: "get",
            async: true,
            success: function (html) {
                $('#account').html(html);
                App.updateValidation($container);
            }
        })
    });


});

var account = {

    success: function(data, status, xhr) {
        account.updateUI();
    },

    updateUI: function () {
        var $elem = $('#account');

        //App.updateUI($elem);
        App.updateValidation($elem);
    }


};

//var App = function () {

//    // Update dynamic content validation.
//    function updateDynamicContent(selector) {
//        var $elem = $(selector);

//        // remove validation data
//        $elem.find('form').each(function (index, element) {
//            $(this).removeData("validator"); /* added by the raw jquery.validate plugin */
//            $(this).removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin */
//        });

//        // set validation
//        $.validator.unobtrusive.parse($elem);

//        $(":input").inputmask();

//        $('.input-validation-error').parents('.form-group')
//            .addClass('has-validation-error');
//    }

//    return {
//        // Update dynamic content validation.
//        updateValidation: function (selector) {
//            var $elem = $(selector);

//            // remove validation data
//            $elem.find('form').each(function (index, element) {
//                $(this).removeData("validator"); /* added by the raw jquery.validate plugin */
//                $(this).removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin */
//            });

//            // set validation
//            $.validator.unobtrusive.parse($elem);

//            $('.input-validation-error').parents('.form-group')
//                .addClass('has-validation-error');
//        }
//    };
//}();