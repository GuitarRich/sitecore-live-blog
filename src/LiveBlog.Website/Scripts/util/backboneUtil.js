/*
 *	A utiliy file for backbone compatability functions
 */
define(["jquery", "backbone", "underscore"], function ($, Backbone, _) {
	var BackboneUtil;
	return BackboneUtil = (function () {
		var PrivateClass, instance;

		function BackboneUtil() { }

		instance = null;

		BackboneUtil.get = function (options) {
			this.options = options;
			return instance != null ? instance : instance = new PrivateClass(this.options);
		};

		PrivateClass = (function () {
			function PrivateClass(options) {
				this.options = options;
				this.options = $.extend({}, this.defaults, this.options);
			}

			PrivateClass.prototype.isAttribute = function (attr) {
				if (attr !== typeof void 0 && attr !== false) {
					return true;
				}
				return false;
			};

			PrivateClass.prototype.shouldBypassLink = function ($link, linkData) {
				if (app.BackboneEnabled === false) {
					return false;
				}
				if (linkData.bypass) {
					return false;
				}
				if (this.isAttribute($this.attr('download'))) {
					return false;
				}
			};

			PrivateClass.prototype.initializeEvents = function ($rootEl) {
				var self = this;
				/*
				 * This sets up all the pages links to run through backbone
				 */
				var notList = ["[data-bypass]", "[download]", "[href*='.pdf']", "[href*='.doc']", "[target='_blank']"];
				var notListSelector = notList.join(',');

				if (app.BackboneEnabled) {
					$rootEl.off("click", "a[href]:not(" + notListSelector + ")", function (evt) { });
					return $rootEl.on("click", "a[href]:not(" + notListSelector + ")", function (evt) {
						var anchorLink, href, match, root, enterBackboneFunk;
						var $this = $(this);
						enterBackboneFunk = true;
						if ($this.hasClass("nav-push")) {
							if (!$this.hasClass("expand")) {
								enterBackboneFunk = false;
							}
						}
						if (enterBackboneFunk) {
							window.app.FilteredModules = false;
							href = {
								prop: $this.prop("href"),
								attr: $this.attr("href"),
								filteredModules: $this.attr("data-filter-modules"),
								overrideTransition: $this.attr("data-override-transition")
							};
							if (href.filteredModules !== void 0) {
								window.app.FilteredModules = true;
							}
							if (href.overrideTransition !== void 0) {
								window.app.OverrideTransition = true;
							}
							match = href.prop.indexOf("#") === -1;
							anchorLink = href.prop.indexOf("#") < href.prop.length - 1 && href.attr.indexOf("#") !== 0;
							root = "" + location.protocol + "//" + location.host;
							if (href.prop.slice(0, root.length) === root && match) {
								evt.preventDefault();
								Backbone.history.navigate(href.attr, true);
							} else if (href.prop.slice(0, root.length) === root && !match && anchorLink) {
								evt.preventDefault();
								Backbone.history.navigate(href.attr, true);
							}
						}
					});
				}
			};

			PrivateClass.prototype.defaults = {
				$el: $(document)
			};

			return PrivateClass;

		})();

		return BackboneUtil;

	})();
});
