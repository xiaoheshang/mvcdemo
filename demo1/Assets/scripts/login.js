!function ($) {

    var $yhmc = $('#yhmc');
    var $yhmm = $('#yhmm');
    var $btnLogin = $('#btnLogin');
    var $loginform = $('#loginform');

    var $feedback = $('#feedback');


    var formValidate = function () {

    

        $loginform.validate({
        rules: {
            yhmc: {
                required: true,
                minlength: 4,
                maxlength: 10
            },
            yhmm: {
                required: true,
                minlength: 6
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
                required: '请输入密码',
                minlength: '密码要求最少6位'
            }
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.next('span'));
        }
        });
    }

    $(document).ready(function () {
        formValidate();

        $yhmc.on('mousedown', function () {
            $feedback.hide();
        });

        $yhmm.on('mousedown', function () {
            $feedback.hide();
        });

        $btnLogin.on('click', function () {
            var form = document.getElementById('loginform');
            var validateState = $loginform.valid();
            if (!validateState) {
                return false;
            }

            var para = { yhmc: form.yhmc.value, yhmm: form.yhmm.value }
            $.ajax({
                url: '/PLogin/Login',
                type: 'POST',
                data: para
            }).success(function (json) {
                if (json.sno == 1) {
                    location.href = '/Yh/Index';
                } else {
                    $feedback.show('normal', function () {
                        $(this).find('p').text(json.msg);
                    });
                }
            }).error(function () {
                aler('出错了');
            });
        });
    });

    


}(jQuery);