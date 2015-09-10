//Devuelve la latitud y logitud apartir de una direccion 
//
//
function getLL( place) {
   
    var data = "";
    geocoder = new GClientGeocoder();
    geocoder.getLatLng(place, function (point) {
        if (!point) {
            alert(place + " not found");
        } else {
            var marker = new GMarker(point);
            var info = "<h3>" + place + "</h3>Latitude: " + point.lat() + "  Longitude:" + point.lng();
            alert(info);

            data =  info;
            
            //alert(info);
        }
    });

    return data;

}

