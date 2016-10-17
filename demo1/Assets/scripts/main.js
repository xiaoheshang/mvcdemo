$(function() {
    $('.sidebar [data-click]').on('click', function(e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('.section-' + id).toggleClass('active');
        $(this).find('i.icon-down').toggleClass('icon-rotate-180')
        return false;
    });

    $('.navbar-1 [data-click]').on('click', function(e) {
        var action = $(this).data('click');
        var id = $(this).data('id');
        if (action === 'toggle-search') {
            e.preventDefault();
            $('.navbar-form').toggleClass('active');
            return false;
        }
        // if (action === 'open-dropdown-menu') {
        //     e.preventDefault();
        //     if ($('#' + id)) {
        //         $('#' + id).toggleClass('active');
        //     }
        //     return false;
        // }
        if (action === 'toggle-layout') {
            e.preventDefault();
            var currentLayout = $('body').attr('data-layout');
            if (currentLayout === 'collapsed-sidebar') {
                $('body').attr('data-layout', 'default-sidebar');
            } else if (currentLayout === 'default-sidebar') {
                $('body').attr('data-layout', 'collapsed-sidebar');
            }
            return false;
        }
    });
})