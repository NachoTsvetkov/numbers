$(document).ready(function () {
    let renderData = function () {
        $.ajax({
            method: "GET",
            url: "https://localhost:44369/api/numbers",
        }).done(function (data) {
            console.log(data);

            let container = $("#numbers-container");
            container.empty()

            for (var number of data) {
                container.append($("<span>", { "class": "number" }).html(number));
            }

            $("#count-field").html(data.length);
        });
    };

    $("#clear").click(function () {
        $.ajax({
            method: "DELETE",
            url: "https://localhost:44369/api/numbers",
        }).done(function () {
            $("#sum-field").html("Not summed");
            renderData();
        });
    });

    $("#add").click(function () {
        $.ajax({
            method: "PUT",
            url: "https://localhost:44369/api/numbers",
        }).done(function () {
            renderData();
        });
    });

    $("#sum").click(function () {
        $.ajax({
            method: "GET",
            url: "https://localhost:44369/api/numbers/sum",
        }).done(function (data) {
            $("#sum-field").html(data);
        });
    });

    renderData();
});