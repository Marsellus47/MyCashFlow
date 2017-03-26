class BaseModifyActionViewModel {
	btnBackLabel: string;
	btnSaveLabel: string;

	constructor(public header: string) {
		this.btnBackLabel = "Back";
		this.btnSaveLabel = "Save";
	}
}