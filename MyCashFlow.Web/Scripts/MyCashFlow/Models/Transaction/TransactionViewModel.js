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
    function TransactionViewModel(view) {
        var _this = _super.call(this, "Transactions") || this;
        _this.transactionIndexViewModel = new TransactionIndexViewModel("List of transactions");
        _this.view = ko.observable(view);
        return _this;
    }
    return TransactionViewModel;
}(BaseViewModel));
$(document).ready(function () {
    var viewModel = new TransactionViewModel("Index");
    ko.applyBindings(viewModel);
});
//# sourceMappingURL=TransactionViewModel.js.map