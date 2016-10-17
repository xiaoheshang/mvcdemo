!function ($) {
    $(document).ready(function () {
        var yhtable = $('#yhtable');
        yhtable.on('click', '.btnDel', function (e) {

            var yh = $(this).data('yh');
            if (window.confirm("是否删除用户：" + yh.yhmc)) {
                $.ajax({
                    type: 'POST',
                    url: '/Yh/Delete',
                    data: { yhid: yh.yhid }
                }).success(function (json) {
                    if (json.sno == 1) {
                        alert('删除成功');
                        window.location.href = '/Yh/List';
                    } else {
                        alert('删除失败：' + json.msg);
                    }
                });
            }
        });
    });
}(jQuery);