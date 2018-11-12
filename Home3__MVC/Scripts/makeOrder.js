$(function () {
    $('#makeOrder').click(function () {
        let clientName = $('clientName').text();
        let clientNumber = $('clientNumber').text();
        let clientAddress = $('clientAddress').text();
        let data = JSON.stringify({
            'clientName': clientName,
            'clientNumber': clientNumber,
            'clientAddress': clientAddress
        });
        var url = $(this).data('url');
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: 'application/json',
            success: function () { }
        });
        $('#totalSum').empty();
        $('#orderList').empty();
        $('#clientName').val('');
        $('#clientNumber').val('');
        $('#clientAddress').val('');
    });
});