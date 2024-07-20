"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();
connection.on("LoadFoods", function () {
    location.href = '/homepage'
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});