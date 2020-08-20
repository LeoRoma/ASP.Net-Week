// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getData() {
    fetch('https://api.nytimes.com/svc/topstories/v2/arts.json?api-key=s3sidQNE043xhMtYMOTXG0E044n5RsFd')
        .then(response => {
            console.log(response)
            if (!response.ok) {
                thorw("Error");
            }
            return response.json()
        })
        .then(data => {
            console.log(data.results)
            const arts = data.results
            const html = arts.map(art => {
                return `<a href='${art.multimedia[0].url}'><img src='${art.multimedia[3].url}' width='450' height='250'></a>
                                    <a href='${art.url}'><h4>${art.title}</h4></a>
                                    <p>${art.abstract}</p>`
            }).join(" ");
            console.log(html);
            document.querySelector('.grid-item').innerHTML = html;
        }).catch(error => {
            console.log(error);
        })
};