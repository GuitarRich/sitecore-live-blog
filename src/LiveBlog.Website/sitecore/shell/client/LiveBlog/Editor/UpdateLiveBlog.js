define(["sitecore", "jquery", "/-/speak/v1/signalr/hubs.js"], function (Sitecore, $) {
	var model = Sitecore.Definitions.Models.ControlModel.extend({
		initialize: function (options) {
			this._super();
		}
	});

	var view = Sitecore.Definitions.Views.ControlView.extend({
		initialize: function (options) {
			this.bindEvents();
			this._super();
		},
		bindEvents: function () {
			var liveBlogHub = $.connection.liveBlogHub;

			liveBlogHub.client.blogPosted = function (text, type) {

				var encodedText = $('<div />').text(text).html();
				var encodedType = $('<div />').text(type).html();

				$('#discussion').append('<li><strong>' + text + '</strong>:&nbsp;&nbsp;' + encodedType + '</li>');
			};

			$.connection.hub.start().done(function () {
				$('#sendmessage').on('click', function () {
					liveBlogHub.server.postBlogEntry($('#message').val(), "FROM SPEAK");
					$('#message').val('').focus();
				});
			});
		}


	});

	Sitecore.Factories.createComponent("UpdateLiveBlog", model, view, ".sc-UpdateLiveBlog");
});
