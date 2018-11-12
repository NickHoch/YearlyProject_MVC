$(function () {
    let basis = parseFloat($('#basis').find(':selected').val());
    let size = parseInt($('#size').find(':selected').val());
    let sauce = parseInt($('#sauce').find(':selected').val());
    let price = Math.round(basis * size + sauce);
    let weight = size * 10;

    $('#price').html(price + ' uah');
    $('#weight').html(weight);

    $('#availableIngrid > div').click(function () {
        let ingrid = $(this);
        if(ingrid.is('#availableIngrid > div')) {
            $(ingrid).appendTo('#selectedIngrid');
            price += parseFloat($(this).data('price'));
            weight += parseInt($(this).data('weight'));
        } else {
            $(ingrid).appendTo('#availableIngrid');
            price -= parseFloat($(this).data('price'));
            weight -= parseInt($(this).data('weight'));
        }
        $('#price').html(Math.round(price * 10) / 10 + ' uah');
        $('#weight').html(weight);
    });

    function CountSum() {
        price = basis * size + sauce;
        $('#selectedIngrid > div').each(function() {
            price += parseFloat($(this).data('price'));
        });
        $('#price').html(Math.round(price * 10) / 10 + ' uah');
    }

    $('#basis').change( function() {
        basis = parseFloat($('#basis').find(':selected').val());
        CountSum();
    });
    $('#size').change(function () {
        size = parseInt($('#size').find(':selected').val());
        CountSum();
        weight = size * 10;
        $('#selectedIngrid > div').each(function () {
            weight += parseFloat($(this).data('weight'));
        });
        $('#weight').html(weight);
    });
    $('#sauce').change(function () {
        sauce = parseInt($('#sauce').find(':selected').val());
        CountSum();
    });   
    $('#addToBucket').click(function () {
        let basisId = $('#basis').find(':selected').attr('id');
        let sizeId = $('#size').find(':selected').attr('id');
        let sauceId = $('#sauce').find(':selected').attr('id');
        let quantity = $('#quantity').val();

        let ingridId = '';
        $('#selectedIngrid > div').each(function () {
            ingridId += $(this).attr('id') + ',';
        });

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