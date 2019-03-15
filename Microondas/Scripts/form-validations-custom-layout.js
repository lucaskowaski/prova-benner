(function ($) {
    $.validator.setDefaults({
        errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group').find('input').after(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {

            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        }
    });
})(jQuery);