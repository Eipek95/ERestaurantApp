var connection = new signalR.HubConnectionBuilder()
    .withAutomaticReconnect()
    .withUrl("https://localhost:7146/SignalRHub").build();

document.getElementById("sendButton").disabled = true;
connection.on("RecieveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;

    li.appendChild(span);
    li.innerHTML += `:${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);
});


start();
function start() { //sayfa ilk açıldığında bağlantı koparsa tekrar bağlantı sağlamak amaçlı böyle bişey yazdık

    connection.start() // Bağlantıyı başlat
        .then(function () {
            
            document.getElementById("sendButton").disabled = false;
            $("#conStatus").text("Bağlantı Açık");

           

        })
        .catch(function (err) {
            console.error(err.toString());
            $("#conStatus").text("Bağlantı Hatası");
            setTimeout(() => start(), 2000)
        });
}

connection.on("RecieveClientCount", (count) => {
    $("#cliCount").text(count);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    
    event.preventDefault();
});