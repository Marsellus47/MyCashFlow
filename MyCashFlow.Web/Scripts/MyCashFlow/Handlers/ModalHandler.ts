ko.bindingHandlers["modal"] = {
	init: (element, valueAccessor) => {
		$(element).modal({ show: false });

		let value = valueAccessor();
		if (typeof value === "function") {
			$(element).on("hide.bs.modal", () => value(false));
		}
		//ko.utils.domNodeDisposal.addDisposeCallback(element, () => $(element).modal("destroy"));
	},
	update: (element, valueAccessor) => {
		let value = valueAccessor();
		if (ko.utils.unwrapObservable(value)) {
			$(element).modal("show");
		} else {
			$(element).modal("hide");
		}
	}
}