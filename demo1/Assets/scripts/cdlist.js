!function ($) {
    $(document).ready(function () {
        $('#cdjb').on('change', function () {
            window.location.href = '/Cd/List?cdjb=' + $(this).val();
        });
    })
}(jQuery);