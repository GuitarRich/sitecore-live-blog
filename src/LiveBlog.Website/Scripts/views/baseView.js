define(["jquery", "backbone", "underscore"], function ($, Backbone, _) {
	var BaseView;
	return BaseView = {
		View: Backbone.View.extend({
			initialize: function () {
				return this.router = new app.Router();
			},
			render: function (options) {
				options = options || {};
				return this;
			}
		})
	};
});
