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
var TransactionViewModel = (function (_super) {
    __extends(TransactionViewModel, _super);
    function TransactionViewModel() {
        var _this = _super.call(this) || this;
        _this.index = function () {
            _this.header("List of transactions");
            _this.view("Index");
        };
        _this.getTransactions = function () {
            $.getJSON("/api/apiTransaction", function (data) {
                $.each(data.$values, function (key, value) {
                    _this.transactions.push(new TransactionIndexItem(value.transactionID, value.date, value.amount, value.income, value.transactionType, value.paymentMethod));
                });
            });
        };
        _this.createTransaction = function () {
            _this.header("Create transaction");
            _this.view("Modify");
            _this.modifyActionCreate(true);
            _this.transaction(new Transaction(null, null, null, false, "Test note", null, null, null));
        };
        _this.deleteTransaction = function (transaction) {
            var dialogElement = $("#delete-dialog-confirm");
            var dialogOptions = {
                autoopen: false,
                resizable: false,
                height: 140,
                width: 580,
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
                                    _this.showDeletePopup(false);
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
            dialogElement.dialog("option", "title", _this.deletePopupTitle);
            dialogElement.dialog("open").show();
        };
        _this.transactions = ko.observableArray([]);
        _this.transaction = ko.observable(null);
        _this.index();
        _this.getTransactions();
        return _this;
    }
    return TransactionViewModel;
}(BaseViewModel));
$(document).ready(function () {
    var viewModel = new TransactionViewModel();
    ko.applyBindings(viewModel);
    $(".datepicker").datepicker();
});
//# sourceMappingURL=TransactionViewModel.js.map