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

			liveBlogHub.client.blogPosted = function (text, type) {

				var encodedText = $('<div />').text(text).html();
				var encodedType = $('<div />').text(type).html();

				$('#discussion').append('<li><strong>' + encodedText + '</strong>:&nbsp;&nbsp;' + encodedType + '</li>');
			};

			$.connection.hub.start().done(function() {
				$('#sendmessage').on('click', function() {
					liveBlogHub.server.postBlogEntry($('#displayname').val(), $('#message').val());
					$('#message').val('').focus();
				});
			});
		}

		return LiveBlog;
	}());
});