$(document).ready(function () {
    $('#cart-btn').click(function () {
        var cart = JSON.parse($.cookie('cart'));
        var bookId = $('#bookId').val();

       //* $.post('/CartItem/Add', { bookId: bookId, cartId: cart.Id }, "json", error:(error) => {
       //*     console.log(JSON.stringify(error));
   //* });

        $.ajax(
            {
                type: "post",
                url: "/CartItem/Add",
                data: JSON.stringify({ bookId: bookId, cartId: cart.Id }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert(data.d);
                },
                error: (error) => {
                    console.log(JSON.stringify(error));
                }
            });
    });
});