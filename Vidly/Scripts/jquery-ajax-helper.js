var apiMethods = {
    fetch: "GET",
    create: "POST",
    update: "PUT",
    delete: "DELETE"
};

function StandarAjaxCall(urlAction, apiMethod, parameters, successCallBackFunction) {

    if (!ContextValidation(urlAction, apiMethod, parameters))
        return false;

    $.ajax({
        url: urlAction,
        method: apiMethod,
        cache: false,
        traditional: true,
        contentType: "application/json; charset=utf-8",
        data: parameters,
        beforeSend: function () {
            $(".loading__container").fadeIn();
        },
        success: function (data) {
            if (typeof successCallBackFunction === "function")
                successCallBackFunction(data);

            $(".loading__container").fadeOut();
        },
        error: function (xhr) {
            $(".loading__container").fadeOut();
            alert('Error Ajax: ' + xhr.statusText);
        }
    });
}

function StringifyAjaxCall(urlAction, apiMethod, parameters, successCallBackFunction) {

    if (!ContextValidation(urlAction, apiMethod, parameters))
        return false;

    $.ajax({
        url: urlAction,
        method: apiMethod,
        traditional: true,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parameters),
        dataType: "json",
        cache: true, // sólo para Internet Explorer 8
        beforeSend: function () {
            $(".loading__container").fadeIn();
        },
        success: function (data) {
            if (typeof successCallBackFunction === "function")
                successCallBackFunction(data);

            $(".loading__container").fadeOut();
        },
        error: function (xhr) {
            $(".loading__container").fadeOut();
            alert('Error Ajax: ' + xhr.statusText);
        }
    });
}

function ContextValidation(urlAction, apiMethod, parameters) {

    if (urlAction == undefined || urlAction == null)
        return false;

    if (parameters == undefined || parameters == null)
        return false;

    if (apiMethod == undefined || apiMethod == null)
        return false;

    return true;
}