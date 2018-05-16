
$(function () {

    var $container = $('#account');

    $container.on("click", "#user-recovery", function () {
        $.ajax({
            url: "userRecovery/account",
            type: "get",
            async: true,
            success: function (html) {
                $('#account').html(html);
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
            }
        })
    });
});
