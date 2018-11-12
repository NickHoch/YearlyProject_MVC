$(function () {
    var x = document.getElementById('Email');
    x.addEventListener('input', Modified, true);

    function Modified() {
        let newEmail = $('#Email').val();
        let oldEmail = $(this).data('oldemail');
        if (newEmail === oldEmail) {
            $('#msg').text('')
                .removeClass('field-validation-error');
            $('#Email').removeClass('input-validation-error');
        }
        let data = JSON.stringify({
            'email': email
        });
        let url = $(this).data('url');

        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: 'application/json',
            success: function (isExists) {
                if (isExists === 'True') {
                    $('#msg').text('Please enter another email')
                        .addClass('field-validation-error');
                    $('#Email').addClass('input-validation-error');
                }
                else {
                    $('#msg').text('')
                        .removeClass('field-validation-error');
                    $('#Email').removeClass('input-validation-error');
                }
            }
        });
    }
});