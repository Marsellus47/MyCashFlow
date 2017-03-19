let model = {
	transactions: ko.observableArray(),
	view: ko.observable("index"),
	insert: {
		Date: ko.observable<Date>(),
		Amount: ko.observable<number>(),
		Note: ko.observable<string>(),
		Income: ko.observable<boolean>(),
		ProjectID: ko.observable<number>(),
		Projects: ko.observableArray(),
		TransactionTypeID: ko.observable<number>(),
		TransactionTypes: ko.observableArray(),
		PaymentMethodID: ko.observable<number>(),
		PaymentMethods: ko.observableArray()
	}
};

function sendAjaxRequest(httpMethod: string, callback, url:string = null, reqData = null) {
	$.ajax("api/ApiTransaction" + (url ? "/" + url : ""), {
		type: httpMethod,
		success: callback,
		data: reqData
	});
}

function getAllItems() {
	sendAjaxRequest("GET", function (data) {
		model.transactions.removeAll();
		for(let item of data.$values) {
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