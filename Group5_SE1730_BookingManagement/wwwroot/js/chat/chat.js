"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("NeedUpdateInboxHistory", function (userId) {
    console.log("Need");
    connection.invoke("SendUpdateInboxHistory", userId).catch(function (err) {
            return console.error(err.toString());
        });
    
});

connection.on("ReceiveUpdateInboxHistory", function (inboxList) {
    console.log("test1");
    document.getElementById("inboxListHistory").appendChild(li);
    console.log("test");
    inboxList.forEach(inbox => {
        const li = document.createElement("li");
        li.className = 'clearfix';
        if (inbox.FromUserId === "dfs") {
            li.innerHTML = `
            <img src="https://bootdey.com/img/Content/avatar/avatar3.png" alt="avatar">
            <div class="about">
                <div class="name">${inbox.FromUser.UserName}</div>
                <div class="status"><i class="fa fa-circle online"></i> online</div>
            </div>
        `;
        } else {
            li.innerHTML = `
            <img src="https://bootdey.com/img/Content/avatar/avatar3.png" alt="avatar">
            <div class="about">
                <div class="name">${inbox.ToUser.UserName}</div>
                <div class="status"><i class="fa fa-circle online"></i> online</div>
            </div>
        `;
        }

       
        messagesList.appendChild(li);
    });

});



connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});