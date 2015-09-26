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

			liveBlogHub.client.blogPosted = function (text, type, timestamp) {

				var encodedType = $('<div />').text(type).html();

				$('#discussion').append('<li>' + text + '<div>:&nbsp;&nbsp;' + encodedType + '</div></li>');
			};

			$.connection.hub.start().done(function() {
				$('#sendmessage').on('click', function() {
					liveBlogHub.server.postBlogEntry($('#message').val(), "FROM CLIENT");
					$('#message').val('').focus();
				});
			});
		}

		return LiveBlog;
	}());
});