!function($){
    var formValidate = function () {
        //添加联系电话自定义校验方法
        $.validator.addMethod("isLxdh", function (value, element) {
            var lxdhReg = /^1[0-9]{10}$/;
            return lxdhReg.test(value);
        }, '请填写手机号码');
        $('#addForm').validate({
            rules: {
                yhmc: {
                    required: true,
                    minlength: 4,
                    maxlength: 10,
                    remote: '/Yh/ValidateYhmc'
                },
                yhmm: {
                    required: true,
                    minlength: 6
                },
                qryhmm: {
                    equalTo: yhmm
                },
                email: {
                    email: true
                },
                lxdh: {
                    required:true,
                    isLxdh: true
                }
            },
            messages: {
                yhmc: {
                    required: '请输入用户名',
                    minlength: '最小4位，最多10位',
                    maxlength: '最小4位，最多10位',
                    remote: '用户名已存在'
                },
                yhmm: {
                    required: '请设置密码',
                    minlength: '密码要求最少6位'
                },
                qryhmm: {
                    equalTo: '两次输入的密码不一致'
                },
                email: {
                    email: '请输入正确的邮箱地址'
                },
                lxdh: {
                    required:"请填写手机号码",
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
        formValidate();
        $('#btnAdd').on('click', function () {
            var validateState = $('#addForm').valid();

            if (!validateState) {
                return false;
            }
            var form = document.getElementById('addForm');
            var para = { yhmc: form.yhmc.value, yhmm: form.yhmm.value, email: form.email.value, qq: form.qq.value, lxdh: form.lxdh.value, zsxm: form.zsxm.value, islock: form.islock[0].value };
            $.ajax({
                url: '/Yh/Add',
                type: 'POST',
                dataType: 'json',
                data: para,
                success: function (json) {
                    if (json.sno == 1) {
                        alert('添加成功');
                        location.href = '/Yh/List';
                    } else {
                        alert('添加用户失败:' + json.msg);
                    }
                }
            });
        });
    });
}(jQuery);