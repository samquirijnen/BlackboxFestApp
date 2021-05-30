
//Tonen foto voor het uploaden
function previewFile() {
    // Where you will display your image
    var preview = document.querySelector('.fotoAanpassen');
    // The button where the user chooses the local image to display
    var file = document.querySelector('input[type=file]').files[0];
    // FileReader instance
    var reader = new FileReader();

    // When the image is loaded we will set it as source of
    // our img tag
    reader.onloadend = function () {
        preview.src = reader.result;
    }


    if (file) {
        // Load image as a base64 encoded URI
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}


/* Set the width of the sidebar to 250px and the left margin of the page content to 250px */
function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}

