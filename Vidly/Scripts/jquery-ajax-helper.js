var apiActions = {
    fetch: "GET",
    create: "POST",
    update: "PUT",
    delete: "DELETE"
};

function StandarAjaxCall(urlAction, parameters, apiAction, successCallBackFunction) {
    $.ajax({
        url: urlAction,
        cache: false,
        traditional: true,
        contentType: "application/json; charset=utf-8",        
        data: parameters,
        method: apiAction,
        success: function (data) {
            successCallBackFunction(data);            
        },
        error: function (xhr) {
            alert('Error Ajax: ' + xhr.statusText);
        }              
    });
}