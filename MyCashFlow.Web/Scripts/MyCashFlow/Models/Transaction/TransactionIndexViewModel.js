var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var TransactionIndexViewModel = (function (_super) {
    __extends(TransactionIndexViewModel, _super);
    function TransactionIndexViewModel(header) {
        var _this = _super.call(this, header) || this;
        _this.transactions = ko.observableArray([]);
        _this.showDialog = ko.observable(false);
        _this.getTransaction = function () {
            $.getJSON("/api/apiTransaction", function (data) {
                $.each(data.$values, function (key, value) {
                    _this.transactions.push(new TransactionIdexItemViewModel(value.transactionID, value.date, value.amount, value.income, value.transactionType, value.paymentMethod));
                });
            });
        };
        _this.deleteTransaction = function (transaction) {
            var dialogElement = $("#delete-dialog-confirm");
            var dialogOptions = {
                autoopen: false,
                resizable: false,
                height: 140,
                modal: true,
                buttons: [{
                        text: _this.btnYesLabel,
                        click: function () {
                            $.ajax({
                                url: "/api/apiTransaction/" + transaction.transactionID(),
                                type: "delete",
                                contentType: "application/json",
                                success: function () {
                                    _this.transactions.remove(transaction);
                                    _this.showDialog(false);
                                }
                            });
                            dialogElement.dialog("close");
                        }
                    },
                    {
                        text: _this.btnNoLabel,
                        click: function () {
                            dialogElement.dialog("close");
                        }
                    }]
            };
            dialogElement.dialog(dialogOptions);
            //dialogElement.dialog("option", "title", this.deleteConfirmationMessage);
            dialogElement.dialog("open");
        };
        _this.getTransaction();
        return _this;
    }
    return TransactionIndexViewModel;
}(BaseIndexViewModel));
var TransactionIdexItemViewModel = (function () {
    function TransactionIdexItemViewModel(transactionID, date, amount, income, transactionType, paymentMethod) {
        this.transactionID = ko.observable(transactionID);
        this.date = ko.observable(date);
        this.amount = ko.observable(amount);
        this.income = ko.observable(income);
        this.transactionType = ko.observable(transactionType);
        this.paymentMethod = ko.observable(paymentMethod);
    }
    return TransactionIdexItemViewModel;
}());
//# sourceMappingURL=TransactionIndexViewModel.js.map