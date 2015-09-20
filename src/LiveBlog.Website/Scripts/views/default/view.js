/*
 * This is the default view that most Sitecore pages will use for rendering through backbonejs
 */
define(["jquery", "backbone", "views/baseView", "util/pageTransitions", "util/backboneUtil"], function ($, Backbone, BaseView, PageTransitions, BackboneUtil) {
	var SitecorePage;
	return SitecorePage = BaseView.View.extend({
		className: "main-container",
		render: function () {
			var hashIndex, linkPart, url, ref;
			var self = this;
			var hrefLength = location.href.length;
			var deviceQueryString = "";
			linkPart = "?";
			if (location.search) {
				linkPart = "&";
			}

			if (location.hash) {
				hashIndex = location.href.indexOf("#");
				url = location.href.substring(0, hashIndex) + linkPart + "ajax=true" + deviceQueryString + location.href.substring(hashIndex, hrefLength);
			} else {
				if (location.href.indexOf('?') !== -1 && (location.search === void 0 || location.search === "")) {
					linkPart = "";
				}
				url = location.href + linkPart + "ajax=true" + deviceQueryString;
			}

			if ((ref = app.ajaxRequest) != null) {
				ref.abort();
			}

			app.ajaxRequest = $.get(url, function (data) {
				self.router.trackPageView();
				var pageTransitions = PageTransitions.get();
				pageTransitions.response = data;
				pageTransitions.transitionEnd();
				BackboneUtil.get().initializeEvents($('#mainContainer'));
				BackboneUtil.get().initializeEvents($('#pageHeader'));
				return BackboneUtil.get().initializeEvents($('#subNavigation'));
			});
			return BaseView.View.prototype.render.apply(self, arguments);
		}
	});
});
