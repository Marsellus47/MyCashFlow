class TransactionViewModel extends BaseViewModel {
	transactionIndexViewModel = new TransactionIndexViewModel("List of transactions");
	view: KnockoutObservable<string>;

	constructor(view: string) {
		super("Transactions");
		this.view = ko.observable(view);
	}
}

$(document).ready(() => {
	let viewModel = new TransactionViewModel("Index");
	ko.applyBindings(viewModel);
});