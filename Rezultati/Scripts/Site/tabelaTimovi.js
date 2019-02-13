$(function () {
    $(document).ready(function () {
        $.get("/Tim/GetTeams", "", function (result) {
            $('#content').append(result);
        });
    });

    $('#btn-dodaj').click(function () {
        var data = {
            Naziv : $("#naziv").val(),
            Grad : $("#grad").val(),
            Trener : $("#trener").val(),
            Stadion : $("#stadion").val(),
            Konferencija: $("input[name='konferencija']:checked").val()
        }
        $.get("/Tim/AddTeam", data, function (result) {
            $('#content').empty();
            $('#content').append(result);
        });
    });
});