var urlPrincipal = "http://localhost/joindernote/";


var ajaxCall = function (metodo, url, data, success) {

    //dataType : "json",
    //contentType: "application/json; charset=utf-8",
    // data : JSON.stringify(data),

    $.ajax({
        type: metodo,
        url: url,
        data: data,
        success: success,
        dataType: "text"
    });

};
