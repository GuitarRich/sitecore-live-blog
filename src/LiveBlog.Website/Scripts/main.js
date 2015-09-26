require.config({
	baseUrl: "/scripts",
	paths: {
		"jquery": "//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min",
		"jquery-private": "modules/jquery.no-conflict",
		"backbone": "//cdnjs.cloudflare.com/ajax/libs/backbone.js/1.2.3/backbone-min",
		"bootstrap": "//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min",
		"underscore": "//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.8.3/underscore-min",
		//"signalr": "//ajax.aspnetcdn.com/ajax/signalr/jquery.signalr-2.2.0.min",
		"signalr": "sc.liveblog/jquery.signalR-2.2.0",
		"hub": "sc.liveblog/hubs",
		"liveblog": "Sc.LiveBlog/sc.liveblog"
	},
	shim: {
		"bootstrap": {
			"deps": ["jquery"]
		},
		"signalr": {
			"deps": ["jquery"]
		},
		"hub": {
			"deps": ["jquery", "signalr"]
		},
		"liveblog": {
			"deps": ["jquery", "signalr", "hub"]
		}
	},
	map: {
		'*': "jquery",
		'jquery-private': "jquery-private",
		'jquery': "jquery"
	}
});

// require these files
require(["modules/init"]);