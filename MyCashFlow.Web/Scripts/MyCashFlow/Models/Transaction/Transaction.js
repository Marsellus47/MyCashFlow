var Transaction = (function () {
    function Transaction(transactionID, date, amount, income, note, projectID, transactionTypeID, paymentMethodID) {
        this.transactionID = ko.observable(transactionID);
        this.date = ko.observable(date);
        this.amount = ko.observable(amount);
        this.income = ko.observable(income);
        this.note = ko.observable(note);
        this.projectID = ko.observable(projectID);
        this.projects = ko.observableArray([]);
        this.transactionTypeID = ko.observable(transactionTypeID);
        this.transactionTypes = ko.observableArray([]);
        this.paymentMethodID = ko.observable(paymentMethodID);
        this.paymentMethods = ko.observableArray([]);
    }
    return Transaction;
}());
//# sourceMappingURL=Transaction.js.map