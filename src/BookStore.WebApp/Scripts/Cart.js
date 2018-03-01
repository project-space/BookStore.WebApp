$(document).ready(function () {
    $('.del_btn').click(function () {
        var itemId = $('#itemId').val();
        var selector = '#' + `${itemId}`;
        $.ajax({
            url: '/CartItem/Delete/', data: { itemId: itemId },
            type: 'DELETE',
            success: function (result) {
                $(selector).detach(selector);
            }
        });
    });
    myStorage = localStorage;
    var a = document.getElementsByName('bookId');
    alert(JSON.stringify(a));
    var bookIds = [];
    for (i = 0; i < a.length; ++i) {
        var bookId = a[i].getAttribute('value');
        bookIds.push(bookId);
    }
    myStorage.setItem('bookIds', JSON.stringify(bookIds));
});