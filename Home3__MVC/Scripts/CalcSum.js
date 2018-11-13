$(function () {
    let sum = 0;
    $('#ordItemBd td:nth-last-of-type(2)').each(function () {
        sum += parseFloat($(this).html());
    });
    $('#sumBucket').html("Total sum: " + sum + "uah");
});