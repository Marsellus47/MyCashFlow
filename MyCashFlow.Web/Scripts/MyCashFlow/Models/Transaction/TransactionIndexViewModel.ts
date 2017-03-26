class TransactionIndexViewModel extends BaseIndexViewModel {
	transactions: KnockoutObservableArray<TransactionIdexItemViewModel> = ko.observableArray([]);
	showDialog: KnockoutObservable<boolean> = ko.observable(false);

	constructor(header: string) {
		super(header);
		this.getTransaction();
	}
	
	getTransaction = () => {
		$.getJSON("/api/apiTransaction", (data) => {
			$.each(data.$values, (key, value) => {
				this.transactions.push(new TransactionIdexItemViewModel(value.transactionID,
					value.date,
					value.amount,
					value.income,
					value.transactionType,
					value.paymentMethod));
			});
		});
	}

	deleteTransaction = (transaction) => {
		$.ajax({
			url: "/api/apiTransaction/" + transaction.transactionID(),
			type: "delete",
			contentType: "application/json",
			success: () => {
				this.transactions.remove(transaction);
				this.showDialog(false);
			},
			error: () => {
				alert("Error during delete");
			}
		});
	}
}

class TransactionIdexItemViewModel {
	transactionID: KnockoutObservable<number>;
	date: KnockoutObservable<Date>;
	amount: KnockoutObservable<number>;
	income: KnockoutObservable<boolean>;
	transactionType: KnockoutObservable<string>;
	paymentMethod: KnockoutObservable<string>;

	constructor(transactionID: number,
		date: Date,
		amount: number,
		income: boolean,
		transactionType: string,
		paymentMethod: string) {
		this.transactionID = ko.observable<number>(transactionID);
		this.date = ko.observable<Date>(date);
		this.amount = ko.observable<number>(amount);
		this.income = ko.observable<boolean>(income);
		this.transactionType = ko.observable<string>(transactionType);
		this.paymentMethod = ko.observable<string>(paymentMethod);
	}
}