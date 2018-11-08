var apiActions = {
    fetch: "GET",
    create: "POST",
    update: "PUT",
    delete: "DELETE"
};

function StandarAjaxCall(urlAction, parameters, apiAction, successCallBackFunction) {
    $.ajax({
        url: urlAction,
        method: apiAction,
        cache: false,
        traditional: true,
        contentType: "application/json; charset=utf-8",        
        data: parameters,
        beforeSend: function () {
            $(".loading__container").fadeIn();
        },
        success: function (data) {
            successCallBackFunction(data);
            $(".loading__container").fadeOut();
        },
        error: function (xhr) {
            alert('Error Ajax: ' + xhr.statusText);
        }              
    });
}

function StringifyAjaxCall(urlAction, parameters, apiAction, successCallBackFunction) {
    $.ajax({
        url: urlAction,
        method: apiAction,        
        traditional: true,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parameters),
        dataType: "json",
        cache: true, // sólo para Internet Explorer 8
        beforeSend: function () {
            $(".loading__container").fadeIn();
        },
        success: function (data) {
            successCallBackFunction(data);
            $(".loading__container").fadeOut();
        },
        error: function (xhr) {
            alert('Error Ajax: ' + xhr.statusText);
        }
    });
}