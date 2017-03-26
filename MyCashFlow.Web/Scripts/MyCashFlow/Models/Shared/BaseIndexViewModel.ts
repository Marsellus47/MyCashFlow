class BaseIndexViewModel {
	btnCreateLabel: string;
	btnEditLabel: string;
	btnDetailsLabel: string;
	btnDeleteLabel: string;
	deleteConfirmationMessage: string;
	btnYesLabel: string;
	btnNoLabel: string;

	constructor(public header: string) {
		this.btnCreateLabel = "Create";
		this.btnEditLabel = "Edit";
		this.btnDetailsLabel = "Details";
		this.btnDeleteLabel = "Delete";
		this.deleteConfirmationMessage = "Delete confirmation message";
		this.btnYesLabel = "Yes";
		this.btnNoLabel = "No";
	}
}