﻿/**
 * This file contains the JavaScript used by the XSS attack demo pages
 */

$(document).ready(function () {
    $("#xssSubmit").click(function () {
        $("#resultsHeader").html("Results");
        $("#results").html("<script>alert('test')</script>");
    });
});

