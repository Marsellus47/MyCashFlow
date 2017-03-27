var BaseViewModel = (function () {
    function BaseViewModel() {
        this.header = ko.observable(null);
        this.view = ko.observable(null);
        this.modifyActionCreate = ko.observable(true);
        this.showDeletePopup = ko.observable(false);
        this.btnCreateLabel = "Create";
        this.btnEditLabel = "Edit";
        this.btnDetailsLabel = "Details";
        this.btnDeleteLabel = "Delete";
        this.deleteConfirmationMessage = "This item will be permanently deleted and cannot be recovered. Are you sure?";
        this.deletePopupTitle = "Delete this item?";
        this.btnYesLabel = "Yes";
        this.btnNoLabel = "No";
        this.btnBackLabel = "Back";
        this.btnSaveLabel = "Save";
    }
    return BaseViewModel;
}());
//# sourceMappingURL=BaseViewModel.js.map