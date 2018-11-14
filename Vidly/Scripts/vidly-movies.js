$(document).ready(function () {
    LoadMoviesTable();
    BindNewMovieEvent();    
});

function BindNewMovieEvent() {
    $(".js-addMovie").on("click", function () {               
        window.location.href = _movieNewAction;
    });
}

function LoadMoviesTable() {
    StandarAjaxCall(_movieApiRouteURI, apiMethods.fetch, "", BuildMoviesTable);
}

function BuildMoviesTable(jsonData) {  
    var tableRows = "";
    for (var index in jsonData) {
        var movie = jsonData[index];

        var columns = "<td><a href='" + _movieEditAction + "/" + movie.id + "'>" + movie.name + "</a></td>";
        columns += "<td>" + movie.movieGenre.name + "</td>";
        columns += "<td><button type='button' data-movie-id='" + movie.id + "' class='js-movie-delete glyphicon glyphicon-trash button button-red'></button></td>";

        var row = "<tr>";
        row += columns;
        row += "</tr>";

        tableRows += row;
    }

    $("#tbl-movies > tbody").append(tableRows);
    var tableMovies = $("#tbl-movies").DataTable();
    BindDeleteMovieEvent(tableMovies);
}

function BindDeleteMovieEvent(tableMovies) {
    $("#tbl-movies").on("click", ".js-movie-delete", function () {
        var element = $(this);   
        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                var deleteRequest = apiMethods.delete;
                var movieId = element.attr("data-movie-id");
                StandarAjaxCall(_movieApiRouteURI + "/" + movieId, deleteRequest, "", function (data) {
                    tableMovies.row(element.parents("tr")).remove().draw();
                });
            }
        })
    });
}