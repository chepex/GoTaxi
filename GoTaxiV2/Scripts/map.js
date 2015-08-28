
var gdir;
var geocoder = null;
var direccion1Lat;
var direccion1Long;
var direccion2Lat;
var direccion2Long;

var directionsService = new google.maps.DirectionsService();
   var directionsDisplay = new google.maps.DirectionsRenderer();
    var map ;
   directionsDisplay.setMap(map);



var mapOptions =
        {
            
            zoom: 17, //zoom level, 0 = earth view to higher value
            panControl: true, //enable pan Control
            zoomControl: true, //enable zoom control
            zoomControlOptions: {
            style: google.maps.ZoomControlStyle.SMALL //zoom control size
        },
            scaleControl: true, // enable scale control
            mapTypeId: google.maps.MapTypeId.ROADMAP // google map type
        };
        

   function load() {
      if (GBrowserIsCompatible()) {
         map = new google.maps.Map(document.getElementById('map'), mapOptions);
         // directionsDisplay.setMap(map);

          /*
var contentwindow = '<div>your point</div>'
infowindow = new google.maps.InfoWindow({
    content: contentwindow
 });
          */
          /*
         google.maps.event.addListener(map, 'rightclick', function(event) {
          alert("aaa")
          placeMarker(event.latLng);
          });*/

        gdir = new GDirections(map);
         //GEvent.addListener(gdir, "load", onGDirectionsLoad);
         //GEvent.addListener(gdir, "error", mostrarError);   
         obtenerRuta("Mejicanos, El Salvador", "Metrocentro, El Salvador");   

       //  CalculaDistancia("Mejicanos, El Salvador", "Metrocentro, El Salvador");
       calculateDistances();
      }


   }


 function placeMarker(location) {
if (marker) {
  marker.setPosition(location);
} else {
 marker = new google.maps.Marker({
      position: location,
      map: map,
      title: 'My point',
      draggable: true,
     });
   // IF I REMOVE THIS PART -> IT WORKS, BUT WITHOUT INFOWINDOW
   google.maps.event.addListener(marker, 'click', function(){
       infowindow.open(map, marker);
   });
 }
}

function calculateDistances(desde, hasta) {
  var service = new google.maps.DistanceMatrixService();
  service.getDistanceMatrix(
    {
      origins: [desde],
      destinations: [ hasta],
      travelMode: google.maps.TravelMode.DRIVING,
      unitSystem: google.maps.UnitSystem.METRIC,
      avoidHighways: false,
      avoidTolls: false
    }, callback);
}

function callback(response, status) {
  if (status != google.maps.DistanceMatrixStatus.OK) {
    alert('Error was: ' + status);
  } else {
    var origins = response.originAddresses;
    var destinations = response.destinationAddresses;
    //var outputDiv = document.getElementById('outputDiv');
    //outputDiv.innerHTML = '';
    //deleteOverlays();

    for (var i = 0; i < origins.length; i++) {
      var results = response.rows[i].elements;
     // addMarker(origins[i], false);
      for (var j = 0; j < results.length; j++) {
          // addMarker(destinations[j], true);
          $("#distancia").val("");
          $("#distancia").val(results[j].distance.text);
          //alert(results[j].distance.text);
        //  $("#distancia2").html("<p>"+esults[j].distance.text+"</p>");
       //alert("Distancia2:"+);
        
      }
    }
  }
}

   

      
      
function obtenerRuta(desde, hasta) {
    //obtenerLL();
    /*  var i;
      var tipo;
      //comprobar tipo trayecto seleccionado
   for (i=0;i<document.form_ruta.tipo.length;i++){
      if (document.form_ruta.tipo[i].checked){
      break;
         }
   }
   tipo = document.form_ruta.tipo[i].value;
      if(tipo==1){
         //a pie
            gdir.load("from: " + desde + " to: " + hasta,{ "locale": "sv", "travelMode" : G_TRAVEL_MODE_WALKING });
      }else{
         //conduccion
          gdir.load("from: " + desde + " to: " + hasta, { "locale": "sv", "travelMode": G_TRAVEL_MODE_DRIVING });
      }*/
    calculateDistances(desde, hasta);
    gdir.load("from: " + desde + " to: " + hasta, { "locale": "sv", "travelMode": G_TRAVEL_MODE_DRIVING });
    var address =desde;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address}, geocodeResult);

    var address2 =hasta;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address2}, geocodeResult2);

   
}
   
   function geocodeResult(results, status) {
      if (status == 'OK') {
    //  map.setCenter(results[0].geometry.location);
        direccion1Lat = results[0].geometry.location.lat();
        direccion1Long = results[0].geometry.location.lng();
        
        $("#olatitud").val(direccion1Lat);
        $("#olongitud").val(direccion1Long);
      //    map.fitBounds(results[0].geometry.viewport);
        //  marker.setPosition(results[0].geometry.location);
      } else {
          alert("Geocoding no tuvo éxito debido a: " + status);
      }
  }

     function geocodeResult2(results, status) {
      if (status == 'OK') {
    //  map.setCenter(results[0].geometry.location);
        direccion2Lat = results[0].geometry.location.lat();
        direccion2Long = results[0].geometry.location.lng();
      //    map.fitBounds(results[0].geometry.viewport);
        //  marker.setPosition(results[0].geometry.location);
      } else {
          alert("Geocoding no tuvo éxito debido a: " + status);
      }
  }

 



   function onGDirectionsLoad(){
      //resumen de tiempo y distancia
      document.getElementById("getDistance").innerHTML =gdir.getSummaryHtml();
   }
   
   function mostrarError(){
       if (gdir.getStatus().code == G_GEO_UNKNOWN_ADDRESS)
       alert("No se ha encontrado una ubicación geográfica que se corresponda con la dirección especificada.");
       else if (gdir.getStatus().code == G_GEO_SERVER_ERROR)
       alert("No se ha podido procesar correctamente la solicitud de ruta o de códigos geográficos, sin saberse el motivo exacto del fallo.");
       else if (gdir.getStatus().code == G_GEO_MISSING_QUERY)
       alert("Falta el parámetro HTTP q o no tiene valor alguno. En las solicitudes de códigos geográficos, esto significa que se ha especificado una dirección vacía.");
      else if (gdir.getStatus().code == G_GEO_BAD_KEY)
       alert("La clave proporcionada no es válida o no coincide con el dominio para el cual se ha indicado.");
       else if (gdir.getStatus().code == G_GEO_BAD_REQUEST)
       alert("No se ha podido analizar correctamente la solicitud de ruta.");
       else alert("Error desconocido.");
   
   }

   function obtenerLL() {
       
         var content = document.getElementById("desde");

         if (navigator.geolocation) {
             navigator.geolocation.getCurrentPosition(function (objPosition) {
                 var lon = objPosition.coords.longitude;
                 var lat = objPosition.coords.latitude;
                 

                 
       
                 content.innerHTML = "<p><strong>Latitud:</strong> " + lat + "</p><p><strong>Longitud:</strong> " + lon + "</p>";

             }, function (objPositionError) {
                 switch (objPositionError.code) {
                     case objPositionError.PERMISSION_DENIED:
                         content.innerHTML = "No se ha permitido el acceso a la posición del usuario.";
                         break;
                     case objPositionError.POSITION_UNAVAILABLE:
                         content.innerHTML = "No se ha podido acceder a la información de su posición.";
                         break;
                     case objPositionError.TIMEOUT:
                         content.innerHTML = "El servicio ha tardado demasiado tiempo en responder.";
                         break;
                     default:
                         content.innerHTML = "Error desconocido.";
                 }
             }, {
                 maximumAge: 75000,
                 timeout: 15000
             });
         }
         else {
             content.innerHTML = "Su navegador no soporta la API de geolocalización.";
         }
     
   
   }
   