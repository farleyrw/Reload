'use strict';

$.ajaxSetup({
	cache: false
});

$(document).ajaxError(function (e, response) {
	if (response.status == 401) {
		alert("Your session has expired. Please login again to continue.");
		//window.location = "/account/logon";
	}
});