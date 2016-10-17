!function ($) {
    $(document).ready(function () {
        var btnInit = $('#btnInit');
        btnInit.on('click', function () {
            $.ajax({
                url: '/Gn/Init',
                type: 'POST'
            }).success(function (json) {
                if (json.sno == 1) {
                    window.alert('初始化成功');
                    window.location.href = '/Gn/List';
                } else {
                    window.alert('初始化失败');
                }
            });
            return false;
        });
    });
}(jQuery);