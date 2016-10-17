!function ($) {
    $(document).ready(function () {
        //修改基本信息
        $('#btnSave').on('click', function () {
            var form = document.getElementById('editForm');
            var para = { jsid:form.js_jsid.value,jsmc: form.js_jsmc.value, jssm: form.jssm.value, islock: form['js.islock'][0].value };
            $.ajax({
                url: '/Js/Edit',
                type: 'POST',
                dataType: 'json',
                data: para,
                success: function (json) {
                    if (json.sno == 1) {
                        alert('保存成功');
                    } else {
                        alert('修改角色基本信息失败:' + json.msg);
                    }
                }
            });
        });

        //修改角色权限信息
        $('#btnJsgn').on('click', function () {
            var $form = $('#jsgnForm');
            var checkeds = $form.find('input:checked');
            var gnids = [];
            var jsid = $('#editForm').find('#js_jsid').val();
            if (checkeds.length > 0) {
                for (var i = 0; i < checkeds.length; i++) {
                    var gnid = checkeds[i].value;
                    gnids.push(gnid);
                }
            } else {
                alert('未设置权限');
            }
            if (gnids.length > 0) {
                $.ajax({
                    url: '/Js/JsgnEdit',
                    type: 'POST',
                    data: { jsid: jsid, gnids: gnids.join('#') }
                }).success(function (json) {
                    if (json.sno == 1) {
                        alert('修改成功');
                    } else {
                        alert('修改失败：' + json.msg);
                    }
                }).error(function () {
                    alert('服务器错误');
                })
            }

        });

    });
}(jQuery);