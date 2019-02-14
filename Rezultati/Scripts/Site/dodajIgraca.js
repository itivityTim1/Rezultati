
    $('#dodaj-igraca').click(function () {
        var data = {
            Ime: $("#ime").val(),
            Prezime: $("#prezime").val(),
            DatumRodjenja: $("#datum-rodjenja").val(),
            MjestoRodjenja: $("#mjesto-rodjenja").val(),
            BrojDresa: $("#broj-dresa").val(),
            Tim: $("#tim").val(),
            Pozicija: $("input[name='pozicija']:checked").val()
        }
        $.get("/Igrac/AddPlayer", data, function (result) {
            $('#content').empty();
            $('#content').append(result);
        });
    });
