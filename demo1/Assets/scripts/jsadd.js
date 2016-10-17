!function ($) {
    var formValidate = function () {
        
        $('#addForm').validate({
            rules: {
                jsmc: {
                    required: true,
                    remote: '/Js/ValidateJsmc'
                }
            },
            messages: {
                jsmc: {
                    required: '请输入角色名称',
                    remote: '角色名已存在'
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
            var para = { jsmc: form.jsmc.value, jssm: form.jssm.value,islock: form.islock[0].value };
            $.ajax({
                url: '/Js/Add',
                type: 'POST',
                dataType: 'json',
                data: para,
                success: function (json) {
                    if (json.sno == 1) {
                        alert('添加成功');
                        location.href = '/Js/List';
                    } else if (json.sno == 2) {
                        //显示表单校验信息
                        $('#addForm').valid();
                    } else {
                        alert('添加角色失败:' + json.msg);
                    }
                }
            });
        });
    });
}(jQuery);