"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("HaveNewMessage", function (newMessage, createAt) {
    addNewMessage(newMessage, createAt);
    showNotification();
});

function addNewMessage(newMessage, createAt) {
    var messageList = document.getElementById("chat-list-history");

    var li = document.createElement("li");
    li.classList.add("clearfix");

    var messageData = document.createElement("div");
    messageData.classList.add("message-data", "text-left");
    messageData.innerHTML = `<span class="message-data-time">${createAt}</span>
                             <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="avatar">`;

    var messageContent = document.createElement("div");
    messageContent.classList.add("message", "other-message", "float-left");
    messageContent.textContent = newMessage;

    li.appendChild(messageData);
    li.appendChild(messageContent);
    messageList.appendChild(li);

    // Cuộn xuống cuối cùng khi có tin nhắn mới
    messageList.scrollTop = messageList.scrollHeight;
}

function showNotification() {
    var notificationBar = document.getElementById("notificationBar");
    notificationBar.style.display = 'block';

    // Hide the notification after 3 seconds
    setTimeout(function () {
        notificationBar.style.display = 'none';
    }, 3000);
}

function refreshPage() {
    location.reload();
}

connection.start().then(function () {
    console.log("SignalR connected.");
}).catch(function (err) {
    return console.error(err.toString());
});