// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat:53.3243201, lng:- 6.2457041 },
        zoom: 12,
    });

    var markers = new google.maps.Marker({
        map: map

    });




    var markers = [{
        coords: { lat: 53.2947222, lng: - 6.3219444 },
        content: '<h1>Easy Garden</h1>'
    },
    {
        coords: { lat: 53.3368399, lng: - 6.2807545 },
        content: '<h1>Urban Plant Life</h1>'
    },

    {
        coords: { lat: 53.3393123, lng:- 6.273483 },
        content: '<h1>Hopeless Botanics</h1>'
    },
    {
        coords: { lat: 53.3619061, lng:- 6.3488689  },
        content: '<h1>Howbert & Mays Monkstown</h1>'
    },
    {
        coords: { lat: 53.3148522, lng:- 6.3917822 },
        content: '<h1>Newlands Home & Garden Centre</h1>'
    },
    {
        coords: { lat: 53.3685595, lng: - 6.3286569 },
        content: '<h1>Dublin Indoor Gardening</h1>'
    },
    {
        coords: { lat: 53.3681889, lng: - 6.3064643 },
        content: '<h1>Culture Indoor Dublin 1</h1>'
    },


    ]


    //loop through markers
    for (var i = 0; i < markers.length; i++) {
        addMarker(markers[i])
    }

    function addMarker(props) {
        var marker = new google.maps.Marker({
            position: props.coords,
            map: map,

            icon: 'http://maps.google.com/mapfiles/kml/pal4/icon39.png'
        });


        if (props.content) {
            var infoWindow = new google.maps.InfoWindow({
                content: props.content
            });

            marker.addListener('click', function () {
                infoWindow.open(map, marker);
            });
        }
    }






}

window.initMap = initMap;




