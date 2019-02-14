$(function () {
    $(document).ready(function () {
        $.get("/Igrac/GetPlayers", "", function (result) {
            $('#content').append(result);
        });
    });
    
});
const fp = flatpickr("#datum-rodjenja", {
    onChange: function (selectedDates, dateStr, instance) {

        var podaci = {

            pocetniDatum: dateStr.substr(0, 10),
            krajDatum: dateStr.substr(14, 10)

        };
    }
});