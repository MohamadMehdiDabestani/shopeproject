// When the window has finished loading create our google map below
const init = () => {
    // Basic options for a simple Google Map
    // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
    const mapOptions = {
        // How zoomed in you want the map to start at (always required)
        zoom: 12,
        scrollwheel: false,
        // The latitude and longitude to center the map (always required)
        center: new google.maps.LatLng(37.393322, -122.023780),
    };
    // Get the HTML DOM element that will contain your map
    // We are using a div with id="map" seen below in the <body>
    const mapElement = document.getElementById('map');
    // Create the Google Map using our element and options defined above
    const map = new google.maps.Map(mapElement, mapOptions);
    // Let's also add a marker while we're at it
    new google.maps.Marker({
        position: new google.maps.LatLng(37.393322, -122.023780),
        map: map,
    });
}
google.maps.event.addDomListener(window, 'load', init);