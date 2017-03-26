class BaseIndexViewModel {
	btnCreateLabel: string;
	btnEditLabel: string;
	btnDetailsLabel: string;
	btnDeleteLabel: string;

	constructor(public header: string) {
		this.btnCreateLabel = "Create";
		this.btnEditLabel = "Edit";
		this.btnDetailsLabel = "Details";
		this.btnDeleteLabel = "Delete";
	}
}