$(function () {
    $('#addToBucket').click(function () {
        //let basis = $('#basis').find(':selected').text();
        let basisId = $('#basis').find(':selected').attr('id');
        //let size = $('#size').find(':selected').text();
        let sizeId = $('#size').find(':selected').attr('id');
        //let sauce = $('#sauce').find(':selected').text();
        let sauceId = $('#sauce').find(':selected').attr('id');
        let quantity = $('#quantity').val();

        //let ingrid = '';
        let ingridId = '';
        $('#selectedIngrid > div').each(function () {
            //ingrid += '\t' + $(this).data('name') + ' - ';
            //ingrid += parseFloat($(this).data('weight')) + 'g - ';
            //ingrid += parseFloat($(this).data('price')) / 100 + 'uah' + '\n';
            ingridId += $(this).attr('id') + ',';
        });

        //////
        confirm('Cheque: \n' + 'Size - ' + size + ';\n' + 'Sauce - ' + sauce + ';\n' + 'Basis - ' + basis + ';\n' + 'Ingridients: \n' + ingrid + 'Total weight - ' + weight + 'g;\n' + 'Price - ' + price + 'uah.');

        var data = JSON.stringify({
            'basisId': basisId,
            'sizeId': sizeId,
            'sauceId': sauceId,
            'ingridId': ingridId,
            'quantity': quantity,
            'weight': weight,
            'price': price
        });
        var url = $(this).data('url');
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            contentType: 'application/json',
            success: function () { }
        });
    });
});