class Transaction {
	transactionID: KnockoutObservable<number>;
	date: KnockoutObservable<Date>;
	amount: KnockoutObservable<number>;
	income: KnockoutObservable<boolean>;
	note: KnockoutObservable<string>;
	projectID: KnockoutObservable<number>;
	projects: KnockoutObservableArray<string>;
	transactionTypeID: KnockoutObservable<number>;
	transactionTypes: KnockoutObservableArray<string>;
	paymentMethodID: KnockoutObservable<number>;
	paymentMethods: KnockoutObservableArray<string>;

	constructor(
		transactionID: number,
		date: Date,
		amount: number,
		income: boolean,
		note: string,
		projectID: number,
		transactionTypeID: number,
		paymentMethodID: number) {
		this.transactionID = ko.observable<number>(transactionID);
		this.date = ko.observable<Date>(date);
		this.amount = ko.observable<number>(amount);
		this.income = ko.observable<boolean>(income);
		this.note = ko.observable<string>(note);
		this.projectID = ko.observable<number>(projectID);
		this.projects = ko.observableArray<string>([]);
		this.transactionTypeID = ko.observable<number>(transactionTypeID);
		this.transactionTypes = ko.observableArray<string>([]);
		this.paymentMethodID = ko.observable<number>(paymentMethodID);
		this.paymentMethods = ko.observableArray<string>([]);
	}
}