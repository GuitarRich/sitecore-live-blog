/*
 * Main router for the Sitecore backbone application
 */
define(["jquery", "backbone"], function ($, Backbone) {
	var Router;
	return Router = Backbone.Router.extend({
		routes: {
			"*actions": "defaultAction"
		},
		defaultAction: function () {
			var view;
			view = new app.Views.DefaultAction();
			return app.instance.navigateTo(view);
		},
		trackPageView: function () {
			var url;
			url = "/" + Backbone.history.getFragment();
			//return app.Analytics.trackPageView(url, document.title);
		}
	});
});
