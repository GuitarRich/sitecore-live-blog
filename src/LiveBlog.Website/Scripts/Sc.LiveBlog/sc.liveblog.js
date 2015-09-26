// ReSharper disable InconsistentNaming
define(["jquery", "signalr", "hub"], function ($) {
	var LiveBlog;
	return LiveBlog = (function() {
		
		function LiveBlog(options) {
			this.options = options;
			this.options = $.extend({}, this.defaults, this.options);
		}

		LiveBlog.prototype.defaults = {
			element: "#discussion"
		}

		LiveBlog.prototype.init = function() {
			var liveBlogHub = $.connection.liveBlogHub;

			liveBlogHub.client.blogPosted = function (data) {
				var json = JSON.parse(data);
				var templateHtml = $("#" + json.type + "Template").html();
				var template = _.template(templateHtml);
				var html = _.unescape(template(json));
				$('#discussion').prepend(html);
			};

			$.connection.hub.start();
		}

		return LiveBlog;
	}());
});