$(function () {
    $('#ordItemBd input').click(function () {
        let id = $(this).attr('id').replace('ordItm', '');
        let data = JSON.stringify({ "id": id });
        let url = $(this).data('url');
        let elem = $(this).parent().closest("tr");
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: 'application/json',
            success: function () {
                elem.remove();
                let sum = 0;
                $('#ordItemBd td:nth-last-of-type(2)').each(function () {
                    sum += parseFloat($(this).html());
                });
                $('#sumBucket').html("Total sum: " + sum + "uah");
                $('#sumWithDisc').html("Sum with discount: " + Math.round(sum * 0.95 * 100) / 100 + "uah");
            }
        });
    });
});