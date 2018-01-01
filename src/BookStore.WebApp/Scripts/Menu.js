$(document).ready(function () {
    if ($.cookie('cart') == null) {
        $.get('/Cart/Get', function (data) {
            $.cookie('cart', JSON.stringify(data));
            $('<a>', { href: '/Cart/Index/' + data.Id, text: 'Корзина' }).appendTo('#cart');
        });
    } else {
        var cart = JSON.parse($.cookie('cart'));
        $('<a>', { href: '/Cart/Index/' + cart.Id, text: 'Корзина' }).appendTo('#cart');
    }
});