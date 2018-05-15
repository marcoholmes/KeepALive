//<a href="/Index/Stuff" id="action">show stuff</a>

//$(function () {
//    $('#userRecovery').click(function () {
//        alert("preso!");
//        //$.ajax({
//        //    url: "userRecovery/account",
//        //    type: "get",
//        //    async: true,
//        //    success: function (html) {
//        //        $('#recovery').html(html);
//        //    }
//        //    })
//    });
//});

$(function () {
    $(document).on("click", "#userRecovery", function () {
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

//$(function () {
//    $('#user-recovery').click(function (e) {
//        e.preventDefault();
//        var url = $(this).attr('href');
//        $.ajax({
//            url: "user-recovery",
//            //beforeSend: OnBeginWork,
//            //complete: OnCompleteWork,
//            success: function (html) {
//                $('#recovery').html(html);
//            }
//        });
//    });
//});