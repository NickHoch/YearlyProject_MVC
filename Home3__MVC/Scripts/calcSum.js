$(function () {
    let sum = 0;
    $('#ordItemBd td:nth-last-of-type(2)').each(function () {
        sum += parseFloat($(this).html());
    });
    $('#sumBucket').html("Total sum: " + sum + "uah");
    $('#discount').html("Discount: " + 5 + "%");
    $('#sumWithDisc').html("Sum with discount: " + Math.round(sum * 0.95 * 100) / 100 + "uah");
});