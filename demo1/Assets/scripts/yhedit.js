!function ($) {
    var formValidate = function () {
        //添加联系电话自定义校验方法
        $.validator.addMethod("isLxdh", function (value, element) {
            var lxdhReg = /^1[0-9]{10}$/;
            return lxdhReg.test(value);
        }, '请填写手机号码');
        $('#editForm').validate({
            rules: {
                yhmm: {
                    required: true,
                    minlength: 6
                },
                qryhmm: {
                    equalTo: yhmm
                },
                email:{
                    email:true
                },
                lxdh: {
                    required: true,
                    isLxdh: true
                }
            },
            messages: {
                yhmm: {
                    required: '请设置密码',
                    minlength: '密码要求最少6位'
                },
                qryhmm: {
                    equalTo: '两次输入的密码不一致'
                },
                email:{
                    email:'请输入正确的邮箱地址'
                },
                lxdh: {
                    required: "请填写手机号码",
                    isLxdh: '联系电话必须为手机号码'
                }

            },
            errorPlacement: function (error, element) {
                //定义错误信息显示位置
                error.appendTo(element.next('span'));
            }
        });
    };

    $(document).ready(function () {
        //基本信息保存
        //初始化验证
        formValidate();
        $('#btnSave').on('click', function () {
            var validateState = $('#editForm').valid();

            if (!validateState) {
                return false;
            }
            var form = document.getElementById('editForm');
            var para = { yhid:form.yh_yhid.value,yhmc: form.yh_yhmc.value, yhmm: form.yhmm.value, email: form.email.value, qq: form.qq.value, lxdh: form.lxdh.value, zsxm: form.zsxm.value, islock: form['yh.islock'][0].value };
            $.ajax({
                url: '/Yh/Edit',
                type: 'POST',
                dataType: 'json',
                data: para,
                success: function (json) {
                    if (json.sno == 1) {
                        alert('保存成功');
                        location.href = '/Yh/List';
                    } else {
                        alert('添加用户失败:' + json.msg);
                    }
                }
            });
        });

        //用户功能权限信息保存
        $('#btnYhgn').on('click', function () {
            var $form = $('#yhgnForm');
            var checkeds = $form.find('input:checked');
            var gnids = [];
            var yhid = $('#editForm').find('#yh_yhid').val();
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
                    url: '/Yh/YhgnEdit',
                    type: 'POST',
                    data: { yhid: yhid, gnids: gnids.join('#') }
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
        //用户所属角色信息修改
        $('#btnYhjs').on('click', function () {
            var $form = $('#yhjsForm');
            var checkeds = $form.find('input:checked');
            var jsids = [];
            var yhid = $('#editForm').find('#yh_yhid').val();
            if (checkeds.length > 0) {
                for (var i = 0; i < checkeds.length; i++) {
                    var jsid = checkeds[i].value;
                    jsids.push(jsid);
                }
            } else {
                alert('未设置角色');
            }
            if (jsids.length > 0) {
                $.ajax({
                    url: '/Yh/YhjsEdit',
                    type: 'POST',
                    data: { yhid: yhid, jsids: jsids.join('#') }
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
        })
        //
    });
}(jQuery);