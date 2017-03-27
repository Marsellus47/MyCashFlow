class TransactionIndexItem {
	transactionID: KnockoutObservable<number>;
	date: KnockoutObservable<Date>;
	amount: KnockoutObservable<number>;
	income: KnockoutObservable<boolean>;
	transactionType: KnockoutObservable<string>;
	paymentMethod: KnockoutObservable<string>;

	constructor(
		transactionID: number,
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