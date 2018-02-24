$(document).ready(function () {
    if ($.cookie('cart') == null) {
        $.get('/Cart/Get', function (data) {
            $.cookie('cart', JSON.stringify(data));

            var link = $('<a>', { href: '/Cart/Index/' + data.Id });
            $('<span>', { class: 'glyphicon glyphicon-shopping-cart' }).appendTo(link);
            link.appendTo('#cart');        });
    } else {
        var cart = JSON.parse($.cookie('cart'));

        var link = $('<a>', { href: '/Cart/Index/' + cart.Id });
        $('<span>', { class: 'glyphicon glyphicon-shopping-cart' }).appendTo(link);
        link.appendTo('#cart');
    }
});