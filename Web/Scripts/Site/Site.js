'use strict';

$.ajaxSetup({
	cache: false
});

$(document).ajaxError(
	function (e, request) {
		if (request.status == 401) {
			alert("Your session has expired. Please login again to continue.");
			//window.location = "/account/logon";
		}
	}
);