// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getMovies(val) {
    let numberOfItems = 4;

    
    $.ajax({
        type: "POST",
        url: "MyList/GetMovies",
        data: { value: val, numberOfItems: numberOfItems },
        dataType: "json",
        success: function (msg) {
            $("#search_results").html("");
            msg.forEach((item, index) => {
                let listHTML = $("#search_results").html();
                let elementHTML = `
<div class="col-lg-3 d-flex align-items-stretch" style="margin-bottom: 15px;">
            <div class="card h-100" style="width: 15rem;">
                <img class="card-img-top"  src="${item.poster_path}" />
                <div class="card-body">
                    <h5 class="card-title text-center">${item.title}</h5>
                    <div class="card-text">Średnia ocen: ${item.vote_average}</div>
                    <br />
                    
                </div>
               <center> <div class="card-footer"><a href="/MyList/AddMovie/${item.id}"  class="btn btn-primary" style=" ">Dodaj</a></div> </center>
            </div>
</div>
`
                listHTML += elementHTML;
                $("#search_results").html(listHTML);
                console.log(index + ". " + item.title);
            })

        },
        error: function (req, status, error) {
            console.log(msg);
        }
    });


}

function addMovie() {
    alert("button clicked!" + this);
}

$(document).ready(function () {
    //$("#myInput").on("keyup", function () {
    //    var value = $(this).val().toLowerCase();
    //    $("#myTable div").filter(function () {
    //        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    //    });
    //});
    $("#myInput").on("change paste keyup input",function () {
        var value = $(this).val().toLowerCase();
        $("#myTable div").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

function changeMyInput(e) {
    if (!e)
        e = window.event;
    var sender = e.srcElement || e.target;

    //maybe some nested element.. find the actual table cell parent.
    while (sender && sender.nodeName.toLowerCase() != "div")
        sender = sender.parentNode;

    var genreName = sender.innerHTML;
    $("#myInput").attr("value",genreName);
    //document.getElementById("myInput").value = genreName;
}