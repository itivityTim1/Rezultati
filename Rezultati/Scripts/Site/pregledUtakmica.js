var fpDatumOdigravanja = flatpickr("#datum-odigravanja", {
    defaultDate: new Date(),
    onChange: function (selectedDates, dateStr, instance) {

        var podaci = {

            pocetniDatum: dateStr.substr(0, 10),
            krajDatum: dateStr.substr(14, 10),
        };
    }
});
$('#kalendar').change(function () {
    var data = {
        datum: $(this).val()
    };
    $.get('/Utakmica/ChangeDate', data, function (result) {
        $('#tabela').empty();
        $('#tabela').append(result);
    });
});

$(document).ready(function () {
    $.get('/Utakmica/ListaTimova', '', function (result) {
        var domaci = '';
        var gost = '';
        $.each(result, function (index, item) {
            domaci += '<option class="dom-opcija" value="' + item.Id + '">' + item.Naziv + '</option>';
            gost += '<option class="gost-opcija" value="' + item.Id + '">' + item.Naziv + '</option>';
        });
        domaci += '<option  disabled selected>Domaći tim</option>';
        gost += '<option " disabled selected>Gostujući tim</option>';
        $('#domaci-tim').html(domaci);
        $('#gostujuci-tim').html(gost);
        $('#lbl-datum-odig').addClass('active');
    });
});

$('#potvrdi').click(function () {
    var data = {
        datum: $('#datum-odigravanja').val(),
        kolo: $('#kolo').val(),
        domaciId: $('.dom-opcija:selected').val(),
        gostId: $('.gost-opcija:selected').val()
    };

    $('#datum-odigravanja').val('');
    $('#kolo').val('');
    $('#domaci-tim').val('');
    $('#gostujuci-tim').val('');
    $.get('/Utakmica/AddGame', data, function (result) {
        $('#tabela').empty();
        $('#tabela').append(result)
    });
});