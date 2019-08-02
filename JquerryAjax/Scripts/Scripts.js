function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);

    }
}


function jQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if ($(form).isValid()) {

        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            sucess: function (response) {
                $("Fdiv").html(response);
            }
        }

        if ($(form).attr('enctype') == "multipart/form-data") {

            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;


        }
        $.ajax(ajaxConfig);
    }
    return false;  
}