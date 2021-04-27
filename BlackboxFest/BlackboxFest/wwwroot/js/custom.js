
//Tonen foto voor het uploaden
function previewFile() {
    // Where you will display your image
    var preview = document.querySelector('img');
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