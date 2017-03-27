class BaseViewModel {
	header: KnockoutObservable<string>;
	view: KnockoutObservable<string>;
	modifyActionCreate: KnockoutObservable<boolean>;
	showDeletePopup: KnockoutObservable<boolean>;
	btnCreateLabel: string;
	btnEditLabel: string;
	btnDetailsLabel: string;
	btnDeleteLabel: string;
	deleteConfirmationMessage: string;
	deletePopupTitle: string;
	btnYesLabel: string;
	btnNoLabel: string;
	btnBackLabel: string;
	btnSaveLabel: string;

	constructor() {
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
}