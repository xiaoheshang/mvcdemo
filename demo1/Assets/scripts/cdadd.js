!function ($) {
    function init() {
        var $sjcd = $('#sjcd');
        var $controller = $('#controller');
        var $action = $('#action');

        $sjcd.html('<option value="">--无--</option>');
        $controller.html('<option value="">--无--</option>');
        $action.html('<option value="">--无--</option>');
    }
    $(document).ready(function () {
        var $sjcd = $('#sjcd');
        var $xtid = $('#xtid');
        $('#cdjb').on('change', function () {
            init();
            var index = this.selectedIndex;
            var value = this.options[index].value;
            //菜单或功能，有上级
            if (value=='2' || value == '3') {
                //获取系统列表
                $.ajax({
                    url: '/Cd/GetParentCds',
                    data: { cdjb: 2 }
                }).success(function (json) {
                    $xtid.removeAttr('disabled');
                    $xtid.html('<option>请选择</option>');
                    $.each(json, function (k, v) {
                        $xtid.append('<option value="' + v.key + '">' + v.value + '</option>');
                    });
                }).error(function () {
                    window.alert('出错了');
                });
                $xtid.removeAttr('disabled');

            } else {
                $xtid.attr('disabled', 'disabled');
            }

            var $controller = $('#controller');
            var $action = $('#action');
            //功能
            if (value == '3') {
                //绑定功能
                $controller.removeAttr('disabled');
                $action.removeAttr('disabled');
                $.ajax({
                    url: '/Gn/ControllerList'
                }).success(function (json) {
                    $controller.removeAttr('disabled')
                        .html('请选择');
                    $.each(json, function (k, v) {
                        $controller.append('<option value="' + v.key + '">' + v.value + '</option>');
                    });

                }).error(function () {
                    window.alert('error');
                });
            } else {
                $controller.attr('disabled', 'disabled');
                $action.attr('disabled', 'disabled');
            }

        });

        $xtid.on('change', function () {
            var xtid = $(this).val();
            //获取系统下菜单
            $.ajax({
                url: '/Cd/GetCdByXtid',
                data: { xtid: xtid }
            }).success(function (json) {
                $sjcd.removeAttr('disabled');
                $sjcd.html('<option>无</option>');
                $.each(json, function (k, v) {
                    $sjcd.append('<option value="' + v.key + '">' + v.value + '</option>');
                });
            }).error(function () {
                window.alert('出错了');
            });
        });



        $('#controller').on('change', function () {
            var controller = $(this).val();
            var $action = $('#action');
            //绑定action
            $.ajax({
                url: '/Gn/ActionList',
                data: { ctrl: controller }
            }).success(function (json) {
                $action.removeAttr('disabled')
                    .html('请选择');
                $.each(json, function (k, v) {
                    $action.append('<option value="' + v.key + '">' + v.value + '</option>');
                });

            });
        });

        //添加


        var formValidate = function () {
            $('#cdForm').validate({
                rules: {
                    cdjb: {
                        required: true
                    },
                    cdmc: {
                        required: true
                    }
                },
                messages: {
                    cdjb: {
                        required: '请选择菜单级别'
                    },
                    cdmc: {
                        required: '请输入菜单名称'
                    }
                },
                errorPlacement: function (error, element) {
                    error.appendTo(element.next('span'));
                }
            });
        };
        formValidate();
        $('#btnAdd').on('click', function () {
            var validateState = $('#cdForm').valid();
            if (!validateState) {
                return false;
            }
            var form = document.getElementById('cdForm');
            var para={cdjb:form.cdjb.value,xtid:form.xtid.value,sjcdid:form.sjcd.value,controller:form.controller.value,action:form.action.value,cdmc:form.cdmc.value,xsjb:form.xsjb.value,icon:form.icon.value,dkfs:form.dkfs.value}
            
            if (para.cdjb == '2') {
                para.sjcdid = para.xtid;
            }

            $.ajax({
                url: '/Cd/Add',
                type: 'POST',
                data: para
            }).success(function (json) {
                if (json.sno == 1) {
                    alert('添加成功');
                    location.href = '/Cd/List';
                } else {
                    alert('添加菜单失败:' + json.msg);
                }
            });

        });


    });
}(jQuery);
