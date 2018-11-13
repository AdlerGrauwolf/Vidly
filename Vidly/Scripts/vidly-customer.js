$(document).ready(function () {
    LoadCustomersTable();
    BindDeleteCustomerEvent();
});

function LoadCustomersTable() {
    StandarAjaxCall(_customerApiRouteURI, apiMethods.fetch, "", BuildCustomerTable);
}

function BuildCustomerTable(jsonData) {    
    if (jsonData == undefined || Object.keys(jsonData).length == 0) {
        $("#tbl-customers").DataTable();
        return false;
    }    

    var tableRows = "";
    for (var index in jsonData) {
        var customer = jsonData[index];

        var columns = "<td><a href='" + _customerEditAction + "/" + customer.id + "'>" + customer.name + "</a></td>";
        columns += "<td>" + customer.membershipType.name + "</td>";
        columns += "<td><button type='button' data-customer-id='" + customer.id + "' class='js-customer-delete glyphicon glyphicon-trash button button-red'></button></td>";

        var row = "<tr>";
        row += columns;
        row += "</tr>";

        tableRows += row;
    }

    $("#tbl-customers > tbody").append(tableRows);
    $("#tbl-customers").DataTable();
}

function BindDeleteCustomerEvent() {
    $("#tbl-customers").on("click", ".js-customer-delete", function () {
        DeleteCustomer($(this));
    });
}

function DeleteCustomer(element) {
    bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
        if (result) {
            var deleteRequest = apiMethods.delete;
            var customerId = element.attr("data-customer-id");
            StandarAjaxCall(_customerApiRouteURI + "/" + customerId, deleteRequest, "", function (data) {
                element.parents("tr").remove();
            });
        }
    });
}