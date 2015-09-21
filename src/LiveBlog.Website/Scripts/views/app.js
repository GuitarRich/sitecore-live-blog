/*
 * Add header comments :)
 */
define(["jquery", "backbone", "views/baseView", "util/pageTransitions"], function ($, Backbone, BaseView, PageTransitions) {
	var AppView;
	return AppView = BaseView.View.extend({
		el: "#backbonePlaceholder",
		navigateTo: function (view) {
			var self;
			self = this;
			PageTransitions.get().transitionStart();
			return view.render({
				page: true
			});
		}
	});
});
