
$(document).ready(function () {
    //your code here
    $("#btnPostUser").on("click", function () {
        var url = "http://localhost:57989/api/usuario";
        var data = {};

        data.Nombre = $("#inpName").val();
        //data.Email = $("#inpPassword").val();
        data.Password = $("#inpPassword").val();


        ajaxCall("POST", url, data,
            function (token) {
                
                window.location.assign(urlPrincipal)
            }); 
            
       
    });
    
});