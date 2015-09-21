define(["jquery", "backbone"], function ($, Backbone) {
	/*
	   * Create the main backbone application object
	   * This is here and not in a require module as it has to be added as a global variable
	   * for all other backbone objects to reference
	 */
	var isPageEditor;
	isPageEditor = $('body').hasClass("is-page-editor");

	window.app = {
		BackboneEnabled: true,
		BackboneUtil: null,
		Views: {},
		Extensions: {},
		Router: null,
		MainNavigation: null,
		FilteredModules: false,
		OverrideTransition: false,
		ModalContainerCookie: 'atpModalContainer',
		init: function () {
			this.instance = new app.Views.App();
			if (typeof history.pushState === "undefined" || isPageEditor) {
				app.BackboneEnabled = false;
				return false;
			}
			return Backbone.history.start({
				pushState: true,
				silent: true
			});
		}
	};

	if (typeof history.pushState === "undefined" || isPageEditor) {
		app.BackboneEnabled = false;
	}

	return require(["router", "views/app", "views/default/view", "util/backboneUtil"], function (Router, AppView, DefaultAction, BackboneUtil) {
		app.Router = Router;
		app.Views.App = AppView;
		app.Views.DefaultAction = DefaultAction;
		$(function () {
			window.app.init();
			window.app.BackboneUtil = BackboneUtil.get();
			return window.app.BackboneUtil.initializeEvents($(document));
		});
	});
});
