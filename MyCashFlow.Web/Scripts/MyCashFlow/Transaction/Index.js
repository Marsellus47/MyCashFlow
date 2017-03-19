var model = {
    transactions: ko.observableArray(),
    view: ko.observable("index"),
    insert: {
        Date: ko.observable(),
        Amount: ko.observable(),
        Note: ko.observable(),
        Income: ko.observable(),
        ProjectID: ko.observable(),
        Projects: ko.observableArray(),
        TransactionTypeID: ko.observable(),
        TransactionTypes: ko.observableArray(),
        PaymentMethodID: ko.observable(),
        PaymentMethods: ko.observableArray()
    }
};
function sendAjaxRequest(httpMethod, callback, url, reqData) {
    if (url === void 0) { url = null; }
    if (reqData === void 0) { reqData = null; }
    $.ajax("api/ApiTransaction" + (url ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: reqData
    });
}
function getAllItems() {
    sendAjaxRequest("GET", function (data) {
        model.transactions.removeAll();
        for (var _i = 0, _a = data.$values; _i < _a.length; _i++) {
            var item = _a[_i];
            model.transactions.push(item);
        }
    });
}
function removeItem(item) {
    sendAjaxRequest("DELETE", function () {
        getAllItems();
    }, item.TransactionId);
}
$(document).ready(function () {
    getAllItems();
    ko.applyBindings(model);
});
//# sourceMappingURL=Index.js.map