$(document).ready(function () {
    $('.del_btn').click(function () {
        var btn = $(this);
        var itemId = $(this).attr('data-itemId');
        var selector = '#' + `${itemId}`;
        $.ajax({
            url: '/CartItem/Delete/', data: { itemId: itemId },
            type: 'DELETE',
            success: function (result) {
                $(selector).detach(selector);
            }
        });
    });
    
    var a = document.getElementsByName('bookId');
    var bookIds = [];
    for (i = 0; i < a .length; ++i) {
        var bookId = a[i].getAttribute('value'); 
        bookIds.push(bookId); 
    } 
    localStorage.setItem('bookIds', JSON.stringify(bookIds));

});