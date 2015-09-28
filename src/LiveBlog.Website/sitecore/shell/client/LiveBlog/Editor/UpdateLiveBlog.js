define(["sitecore", "jquery", "/-/speak/v1/signalr/hubs.js"], function (Sitecore, $) {
	var model = Sitecore.Definitions.Models.ControlModel.extend({
		initialize: function (options) {
			this._super();

			this.set("itemId", null);
			this.set("blogTitle", null);
			this.set("blogEntries", null);

			this.on("change:itemId", this.updateBlogEntries, this);
		},
		updateBlogEntries: function () {
			var itemId = this.get("itemId");
			var item = this;

			$.ajax({
				url: "/sitecore/api/liveblogservices/getitem/" + itemId,
				type: "GET",
				success: function(data) {

					item.set("blogTitle", data.blogTitle);
					item.set("blogEntries", data.entries);
				}
			});
		}
	});

	var view = Sitecore.Definitions.Views.ControlView.extend({
		initialize: function (options) {
			this.bindEvents();
			this._super();
		},
		bindEvents: function () {
			var liveBlogHub = $.connection.liveBlogHub;
			var itemId = this.getParameterByName("id");

			this.model.viewModel.itemId(itemId);

			liveBlogHub.client.blogPosted = function (data) {
				var json = JSON.parse(data);
				$("#discussion").prepend("<div>" + json.text + "</div>");
			};

			$.connection.hub.start().done(function () {
				$("#sendmessage").on("click", function () {
					liveBlogHub.server.postBlogEntry(itemId, $("#message").val());
					$("#message").val("").focus();
				});
			});
		},
		getParameterByName: function (name) {
			name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
			var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
				results = regex.exec(location.search);
			return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
		}
	});

	Sitecore.Factories.createComponent("UpdateLiveBlog", model, view, ".sc-UpdateLiveBlog");
});
