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
<div class="col">
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