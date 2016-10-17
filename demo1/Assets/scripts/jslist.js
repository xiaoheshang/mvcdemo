!function ($) {
    $(document).ready(function () {
        var jstable = $('#jstable');
        jstable.on('click', '.btnDel', function (e) {

            var js = $(this).data('js');
            if (window.confirm("是否删除角色：" + js.jsmc)) {
                $.ajax({
                    type: 'POST',
                    url: '/Js/Delete',
                    data: { jsid: js.jsid }
                }).success(function (json) {
                    if (json.sno == 1) {
                        alert('删除成功');
                        window.location.href = '/Js/List';
                    } else {
                        alert('删除失败：' + json.msg);
                    }
                });
            }
        });
    });
}(jQuery);