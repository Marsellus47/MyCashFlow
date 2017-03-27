class TransactionViewModel extends BaseViewModel {
	transactions: KnockoutObservableArray<TransactionIndexItem>;
	transaction: KnockoutObservable<Transaction>;

	constructor() {
		super();
		this.transactions = ko.observableArray([]);
		this.transaction = ko.observable(null);
		this.index();
		this.getTransactions();
	}

	index = () => {
		this.header("List of transactions");
		this.view("Index");
	}

	getTransactions = () => {
		$.getJSON("/api/apiTransaction", (data) => {
			$.each(data.$values, (key, value) => {
				this.transactions.push(new TransactionIndexItem(value.transactionID,
					value.date,
					value.amount,
					value.income,
					value.transactionType,
					value.paymentMethod));
			});
		});
	}

	createTransaction = () => {
		this.header("Create transaction");
		this.view("Modify");
		this.modifyActionCreate(true);
		this.transaction(new Transaction(null, null, null, false, "Test note", null, null, null));
	}

	deleteTransaction = (transaction) => {
		let dialogElement = $("#delete-dialog-confirm");
		let dialogOptions = {
			autoopen: false,
			resizable: false,
			height: 140,
			width: 580,
			modal: true,
			buttons: [{
				text: this.btnYesLabel,
				click: () => {
					$.ajax({
						url: "/api/apiTransaction/" + transaction.transactionID(),
						type: "delete",
						contentType: "application/json",
						success: () => {
							this.transactions.remove(transaction);
							this.showDeletePopup(false);
						}
					});
					dialogElement.dialog("close");
				}
			},
			{
				text: this.btnNoLabel,
				click: () => {
					dialogElement.dialog("close");
				}
			}]
		};
		dialogElement.dialog(dialogOptions);
		dialogElement.dialog("option", "title", this.deletePopupTitle);
		dialogElement.dialog("open").show();
	}
}

$(document).ready(() => {
	let viewModel = new TransactionViewModel();
	ko.applyBindings(viewModel);
	$(".datepicker").datepicker();
});