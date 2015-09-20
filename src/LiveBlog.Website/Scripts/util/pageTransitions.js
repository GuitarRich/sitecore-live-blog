var __bind = function (fn, me) { return function () { return fn.apply(me, arguments); }; };

define(["jquery"], function ($) {
	var PageTransitions;
	return PageTransitions = (function () {
		var PrivatePageTransitions, instance;

		function PageTransitions() { }

		instance = null;

		PageTransitions.get = function (options) {
			this.options = options;
			return instance != null ? instance : instance = new PrivatePageTransitions(this.options);
		};

		PrivatePageTransitions = (function () {
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
				var _ref, _ref1, _ref2, _ref3, _ref4, _ref5, _ref6, _ref7, _ref8, _ref9;
				if ((_ref = this.options.$filterHolder) != null) {
					_ref.removeClass("expand");
				}
				if ((_ref1 = this.options.$largeDropin) != null) {
					_ref1.removeClass("expand");
				}
				this.options.$navigation.removeClass("expand");
				this.options.$html.removeClass("full-nav");
				if ((_ref2 = this.options.$html) != null) {
					_ref2.removeClass("long-form-on");
				}
				$("html").removeClass("modal-carousel-on");
				$(".modal-carousel-wrapper").remove();
				$(".atp-touch-hover").removeClass("atp-touch-hover");
				if ((_ref3 = this.options.$mainNav) != null) {
					_ref3.removeClass("expand");
				}
				if ((_ref4 = this.options.$subNav) != null) {
					_ref4.removeClass("expand");
				}
				if ((_ref5 = this.options.$subNavLink) != null) {
					_ref5.removeClass("expand");
				}
				if ((_ref6 = this.options.$menuToggle) != null) {
					_ref6.removeClass("expand");
				}
				if ((_ref7 = this.options.$mainHeader) != null) {
					_ref7.removeClass("expand");
				}
				if ((_ref8 = this.options.$navigation) != null) {
					_ref8.removeClass("expand");
				}
				if ((_ref9 = this.options.$html) != null) {
					_ref9.removeClass("full-nav");
				}
				$("#mainNav, .nav-push, #controlMenu").removeClass("expand");
				return $("#closeSearch").trigger("click");
			};

			PrivatePageTransitions.prototype.scrollToTop = function () {
				return $("html, body").stop().animate({
					scrollTop: 0
				});
			};

			PrivatePageTransitions.prototype.modal = new Modal();

			PrivatePageTransitions.prototype.updateFilteredModules = function () {
				var $response, that;
				$response = $(this.response);
				$("[data-filtered-module]").each(function () {
					var _html, _module;
					_module = "[data-filtered-module='" + ($(this).data("filtered-module")) + "']";
					_html = $response.find(_module).html() || $response.filter(_module).html();
					return $(this).html(_html);
				});
				that = $(this);
				return $response.filter("[data-filtered-module-forced]").each(function () {
					var _element, _module;
					_module = "[data-filtered-module='" + ($(this).data("filtered-module")) + "']";
					_element = that.find(_module) || that.filter(_module);
					if (_element.length) {
						return _element.html($(this).html());
					} else {
						return $("#mainContent").append(this.outerHTML);
					}
				});
			};

			PrivatePageTransitions.prototype.updatePageHeader = function () {
				var $template, defaultPageHeader, trimmedPageHeader, _currentItemTransform, _currentTitle, _filterScript, _previousItemTransform, _previousTitle, _strippedFilterTemplate, _template;
				defaultPageHeader = '<div class="page-header-holder"></div>';
				if (this.pageHeaderHtml !== null && this.pageHeaderHtml !== void 0) {
					trimmedPageHeader = this.pageHeaderHtml.trim();
					if (trimmedPageHeader !== "") {
						_template = this.pageHeaderHtml;
					} else {
						_template = defaultPageHeader;
					}
				} else {
					_template = defaultPageHeader;
				}
				$template = $(_template);
				_previousTitle = (this.options.$pageHeader.find(".page-title").text()).trim() || this.options.$pageHeader.find(".page-title img").attr("src");
				_currentTitle = ($template.filter(".page-title").text()).trim() || this.options.$pageHeader.find(".page-title img").attr("src");
				_filterScript = $template.filter("#filterScript");
				_strippedFilterTemplate = $template.not(_filterScript);
				if (_previousTitle === _currentTitle && (_strippedFilterTemplate != null) && _strippedFilterTemplate !== "") {
					this.options.$pageHeader.find(".page-header-holder").html(_strippedFilterTemplate);
					if (_filterScript.length) {
						this.options.$pageHeader.find(".page-header-holder").append(_filterScript);
					}
					Util.checkPageHeader($(_template));
					return this.moreLinkInit();
				} else {
					if (!_strippedFilterTemplate) {
						return this.options.$pageHeader.find(".page-header-holder").empty();
					} else {
						_strippedFilterTemplate = _strippedFilterTemplate.wrapAll("<div class='page-header-holder'></div>").parent();
						this.options.$pageHeader.append(_strippedFilterTemplate || defaultPageHeader);
						_previousItemTransform = "translateY(110px)";
						_currentItemTransform = "translateY(0)";
						this.options.$html.addClass("transition-header-on");
						setTimeout((function (_this) {
							return function () {
								return _this.options.$pageHeader.find(".page-header-holder").eq(0).css({
									"-webkit-transform": _previousItemTransform,
									"-moz-transform": _previousItemTransform,
									"-ms-transform": _previousItemTransform,
									"transform": _previousItemTransform,
									"opacity": 0,
									"position": "absolute",
									"top": 0,
									"left": 0,
									"z-index": 1
								});
							};
						})(this), this.options.transitionDelay / 2);
						setTimeout((function (_this) {
							return function () {
								return _this.options.$pageHeader.find(".page-header-holder").eq(1).css({
									"-webkit-transform": _currentItemTransform,
									"-moz-transform": _currentItemTransform,
									"-ms-transform": _currentItemTransform,
									"transform": _currentItemTransform,
									"opacity": 1
								}, setTimeout(function () {
									_this.options.$pageHeader.find(".page-header-holder").eq(0).remove();
									Util.checkPageHeader($(_template));
									if (_filterScript.length) {
										_this.options.$pageHeader.find(".page-header-holder").append(_filterScript);
									}
									_this.options.$html.removeClass("transition-header-on");
									return _this.options.$pageHeader.find(".page-header-holder").eq(0).removeAttr("style");
								}, _this.options.transitionDelay));
							};
						})(this), this.options.transitionDelay);
						return this.moreLinkInit();
					}
				}
			};

			PrivatePageTransitions.prototype.moreLinkInit = function () {
				return setTimeout(function () {
					new MoreLink({
						element: "#subNavigation",
						navWrap: ".header-sub-navigation-list-wrap",
						navList: ".header-sub-navigation-list",
						wrapperInner: ".container",
						wrapperInnerPadding: 31
					});
					new MoreLink({
						wrapperInnerPadding: 16
					});
					return $(window).trigger("resize");
				}, 500);
			};

			PrivatePageTransitions.prototype.updatePage = function () {
				this.modifyResponse();
				$("#mainContent").remove();
				this.options.$mainContainer.append(this.modifiedResponse);
				this.additionalSelectors();
				this.updateOutsideElements(1000);
				Util.setModalContainer();
				return Util.setSponsoredBackground();
			};

			PrivatePageTransitions.prototype.modifyResponse = function () {
				var $outsideElements, $response, _self;
				_self = this;
				$response = $(this.response);
				$outsideElements = $response.filter("[data-outside-element]");
				this.newMeta = $response.filter("meta");
				this.newTitle = $response.filter("title");
				this.modifiedResponse = $response.not($outsideElements);
				this.modifiedResponse = this.modifiedResponse.not(this.newMeta);
				this.modifiedResponse = this.modifiedResponse.not(this.newTitle);
				$outsideElements.each(function () {
					var $this, _outsideHtml, _outsideLabel;
					$this = $(this);
					_outsideLabel = $this.data("outside-element");
					_outsideHtml = $this.html();
					if (_outsideLabel === "pageHeader") {
						return _self.pageHeaderHtml = _outsideHtml;
					} else {
						return $("[data-outside-element='" + _outsideLabel + "']").html(_outsideHtml);
					}
				});
				return this.updateHeaderTags();
			};

			PrivatePageTransitions.prototype.updateHeaderTags = function () {
				var head, oldMeta, oldTitle;
				oldMeta = $('meta');
				oldTitle = $('title');
				head = $('head');
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
