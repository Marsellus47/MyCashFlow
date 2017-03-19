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
    },
    showView: function (viewName) {
        return viewName == model.view();
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
        for (var _i = 0, _a = model.transactions(); _i < _a.length; _i++) {
            var transaction = _a[_i];
            if (transaction.TransactionID == item.TransactionID) {
                model.transactions.remove(transaction);
                break;
            }
        }
    }, item.TransactionID.toString());
}
function handleEditorClick() {
    sendAjaxRequest("POST", function (newItem) {
        model.transactions.push(newItem);
    }, null, {
        Date: model.insert.Date,
        Amount: model.insert.Amount,
        Note: model.insert.Note,
        Income: model.insert.Income,
        ProjectID: model.insert.ProjectID,
        TransactionTypeID: model.insert.TransactionTypeID,
        PaymentMethodID: model.insert.PaymentMethodID
    });
}
$(document).ready(function () {
    getAllItems();
    ko.applyBindings(model);
});
//# sourceMappingURL=Index.js.map