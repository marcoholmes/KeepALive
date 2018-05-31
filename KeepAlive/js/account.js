
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



    //$container.on("click", "#register", function () {
    //    $.ajax({
    //        url: "register2/account",
    //        type: "get",
    //        async: true,
    //        success: function (html) {
    //            $('#account').html(html);
    //        }
    //    })
    //});
});
