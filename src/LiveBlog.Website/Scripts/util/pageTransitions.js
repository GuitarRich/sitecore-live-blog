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
				html: "html",
				body: "body",
				transitionDelay: 250
			};

			PrivatePageTransitions.prototype.additionalSelectors = function () {
				this.options.$pageHeader = $(this.options.pageHeader);
				this.options.$mainContainer = $(this.options.mainContainer);
				this.options.$html = $(this.options.html);
				this.options.$body = $(this.options.body);
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
				this.modifyResponse();
				$("#mainContent").remove();
				this.options.$mainContainer.append(this.modifiedResponse);
				return this.additionalSelectors();
			};

			PrivatePageTransitions.prototype.updateHeaderTags = function () {
				var oldMeta = $("meta");
				var oldTitle = $("title");
				var head = $("head");
				oldMeta.remove();
				head.prepend(this.newMeta);
				oldTitle.remove();
				return head.prepend(this.newTitle);
			};

			PrivatePageTransitions.prototype.updateLargeDropin = function () {
				var _ref, _template;
				_template = (_ref = this.options.$largeDropinTemplate) != null ? _ref.html() : void 0;
				if (_template) {
					if (!this.options.$largeDropin.length) {
						this.options.$wrapper.prepend(_template);
					} else {
						this.options.$largeDropin[0].outerHTML = _template;
					}
					return new LargeDropinAd({
						openAdTimeout: 2000
					});
				}
			};

			PrivatePageTransitions.prototype.updateSubNavigation = function (timeOut) {
				return setTimeout((function (_this) {
					return function () {
						var _ref, _template;
						_this.additionalSelectors();
						_template = (_ref = _this.options.$subNavigationTemplate) != null ? _ref.html() : void 0;
						if (_template) {
							_this.options.$subNavigation.remove();
							$(_template).insertAfter(_this.options.mainHeader);
							if (_this.options.$body.hasClass("is-mobile")) {
								return new SubNavigation();
							}
						} else {
							return _this.options.$subNavigation.remove();
						}
					};
				})(this), timeOut || this.options.transitionDelay * 2.1);
			};

			PrivatePageTransitions.prototype.updateHeaderCallouts = function () {
				var _ref, _template;
				_template = (_ref = this.options.$headerCalloutsTemplate) != null ? _ref.html() : void 0;
				if (_template) {
					if (!this.options.$headerCallouts.length) {
						return $(_template).insertAfter(this.options.mainHeader);
					} else {
						return this.options.$headerCallouts[0].outerHTML = _template;
					}
				} else {
					return this.options.$headerCallouts.remove();
				}
			};

			PrivatePageTransitions.prototype.updateLongForm = function () {
				var _ref, _template;
				_template = (_ref = this.options.$longFormTemplate) != null ? _ref.html() : void 0;
				if (_template) {
					if (!this.options.$longForm.length) {
						this.options.$body.append(_template);
					} else {
						this.options.$longForm[0].outerHTML = _template;
					}
					return setTimeout((function (_this) {
						return function () {
							return new LongForm();
						};
					})(this), this.options.transitionDelay);
				} else {
					return setTimeout((function (_this) {
						return function () {
							var _ref1;
							return (_ref1 = _this.options.$longForm) != null ? _ref1.remove() : void 0;
						};
					})(this), this.options.transitionDelay);
				}
			};

			PrivatePageTransitions.prototype.updateStickyNav = function () { };

			PrivatePageTransitions.prototype.updateOutsideElements = function (timeOut) {
				this.additionalSelectors();
				this.updateSubNavigation(timeOut);
				this.updateHeaderCallouts();
				this.updatePageHeader();
				this.updateLargeDropin();
				this.updateLongForm();
				return this.updateStickyNav();
			};

			return PrivatePageTransitions;

		})();

		return PageTransitions;

	})();
});
