require.config = {
	baseUrl: "/scripts/",
	paths: {
		"jquery": "//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min",
		"jquery-private": "modules/jquery.no-conflict",
		"backbone": "vendor/backbone-min"
	},
	map: {
		'*': 'jquery',
		'jquery-private': 'jquery-private',
		'jquery': 'jquery'
	}
}

// require these files
require(["modules/init"]);