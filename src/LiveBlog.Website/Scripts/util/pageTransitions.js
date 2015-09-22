var __bind = function (fn, me) { return function () { return fn.apply(me, arguments); }; };

define(["jquery"], function ($) {
	var PageTransitions;
	return PageTransitions = (function () {
		var privatePageTransitions, instance;

		function PageTransitions() { }

		instance = null;

		PageTransitions.get = function (options) {
			this.options = options;
			return instance != null ? instance : instance = new privatePageTransitions(this.options);
		};

		privatePageTransitions = (function () {
			function PrivatePageTransitions(options) {
				this.options = options;
				this.transitionUpdatePage = __bind(this.transitionUpdatePage, this);
				this.options = $.extend({}, this.defaults, this.options);
				this.additionalSelectors();
			}

			PrivatePageTransitions.prototype.defaults = {
				pageHeader: "#pageHeader",
				mainContainer: "#mainContainer",
				navbar: "#navbar",
				html: "html",
				body: "body",
				transitionDelay: 250
			};

			PrivatePageTransitions.prototype.additionalSelectors = function () {
				this.options.$pageHeader = $(this.options.pageHeader);
				this.options.$mainContainer = $(this.options.mainContainer);
				this.options.$html = $(this.options.html);
				this.options.$body = $(this.options.body);
				this.options.$navbar = $(this.options.navbar);
			};

			PrivatePageTransitions.prototype.transitionStart = function () {
				this.additionalSelectors();
				this.closeExpandedItems();
				this.scrollToTop();
			};

			PrivatePageTransitions.prototype.transitionEnd = function () {
				var responseModal;
				var $response = $(this.response);

				return this.transitionUpdatePage();
			};

			PrivatePageTransitions.prototype.transitionUpdatePage = function () {
				return setTimeout((function (_this) {
					return function () {
						_this.updatePage();
						return setTimeout(function () {
							return _this.options.$html.removeClass("transition-content-on");
						}, _this.options.transitionDelay);
					};
				})(this), this.options.transitionDelay);
			};

			PrivatePageTransitions.prototype.closeExpandedItems = function () {
				this.options.$html.removeClass("full-nav");
			};

			PrivatePageTransitions.prototype.scrollToTop = function () {
				return $("html, body").stop().animate({
					scrollTop: 0
				});
			};

			PrivatePageTransitions.prototype.updatePage = function () {
				$("#mainContent").remove();
				this.options.$mainContainer.html(this.response);
				this.additionalSelectors();
				this.updateNavigation();
			};

			PrivatePageTransitions.prototype.updateNavigation = function () {
				var shortId = $("#mainContent").data().currentId;
				this.options.$navbar.find("li").removeClass("active");
				this.options.$navbar.find("li[data-id='" + shortId + "']").addClass("active");
			};

			return PrivatePageTransitions;

		})();

		return PageTransitions;

	})();
});
