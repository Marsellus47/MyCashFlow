interface Transaction {
	TransactionID: number,
	Date: Date,
	Amount: number,
	Income: boolean,
	TransactionType: string,
	PaymentMethod: string
}

let model = {
	transactions: ko.observableArray<Transaction>(),
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
	},
	showView: function (viewName) {
		return viewName == model.view();
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

function removeItem(item: Transaction) {
	sendAjaxRequest("DELETE", function () {
		for (let transaction of model.transactions()) {
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