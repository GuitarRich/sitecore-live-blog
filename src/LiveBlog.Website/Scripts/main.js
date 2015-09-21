require.config({
	baseUrl: "/scripts",
	paths: {
		"jquery": "//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min",
		"jquery-private": "modules/jquery.no-conflict",
		"backbone": "//cdnjs.cloudflare.com/ajax/libs/backbone.js/1.2.3/backbone-min",
		"bootstrap": "//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min",
		"underscore": "//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.8.3/underscore-min"
	},
	shim: {
		"bootstrap": {
			"deps": ["jquery"]
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