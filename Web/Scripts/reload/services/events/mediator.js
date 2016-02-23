
(function() {
	'use strict';

	Reload.DefineNamespace('Reload.Services.Events.Mediator', function () {
		var channels = {};

		this.Listen = function (channelName, callback) {
			channels[channelName] = channels[channelName] || [];

			channels[channelName].push(callback);
		};

		this.Fire = function (channelName, data) {
			channels[channelName].forEach(function(channel) {
				channel(data);
			});
		};
	});
})();