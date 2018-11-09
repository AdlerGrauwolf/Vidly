$(document).ready(function () {    
    DeleteCustomer();

});

function DeleteCustomer() {
    $(".js-customer-delete").on("click", function () {
        var element = $(this);        
        var deleteRequest = apiMethods.delete;
        var customerId = element.attr("data-customer-id");
        StandarAjaxCall(_apiRouteURI + "/" + customerId, deleteRequest, "", function (data) { return OnDeleteSuccess(element) });
    });
}


function OnDeleteSuccess(element) {
    element.parents("tr").remove();
}