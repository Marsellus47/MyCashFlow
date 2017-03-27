var TransactionIndexItem = (function () {
    function TransactionIndexItem(transactionID, date, amount, income, transactionType, paymentMethod) {
        this.transactionID = ko.observable(transactionID);
        this.date = ko.observable(date);
        this.amount = ko.observable(amount);
        this.income = ko.observable(income);
        this.transactionType = ko.observable(transactionType);
        this.paymentMethod = ko.observable(paymentMethod);
    }
    return TransactionIndexItem;
}());
//# sourceMappingURL=TransactionIndexItem.js.map