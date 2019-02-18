$('.tim-stat').click(function () {
    var data = {
        TimId: $(this).attr('data-id')
    };
    window.location.href = '/Ucinak/TeamDetails' + data
    //$.get('/Ucinak/TeamDetails', data);
});