var datumi = []
$(document).ready(function () {
    $.get('/Utakmica/GetGames', '', function (result) {
        $('#tabela').append(result);
    });
    $.get('/Utakmica/GetDates', '', function (result) {
        datumi = result;
        var fpKalendar = flatpickr("#kalendar", {
            defaultDate: new Date(),
            onChange: function (selectedDates, dateStr, instance) {

                var podaci = {

                    pocetniDatum: dateStr.substr(0, 10),
                    krajDatum: dateStr.substr(14, 10),
                };
            },
            enable: datumi

        });
    });
});


