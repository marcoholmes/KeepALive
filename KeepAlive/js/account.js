
$(function () {

    var $container = $('#account');

    $container.on("click", "#userRecovery", function () {
        $.ajax({
            url: "userRecovery/account",
            type: "get",
            async: true,
            success: function (html) {
                $('#account').html(html);
            }
        })
        });
});
