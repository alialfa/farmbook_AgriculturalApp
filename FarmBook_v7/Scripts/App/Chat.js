/// <reference path="..\typings\jquery\jquery.d.ts" />
/// <reference path="..\typings\underscore\underscore.d.ts" />
/// <reference path="..\typings\SignalRExtensions.ts" />

var Chat;
(function (Chat) {
    var ChatController = (function () {
        function ChatController() {
            var _this = this;
            this.altRow = false;
            $(".chatWindow").hide();

            $(".signinButton").click(function () {
                _this.chatConnection = $.connection.chatHub;

                $.connection.hub.start().done(function () {
                    $(".signin").hide();
                    $(".chatWindow").show();

                    _this.chatConnection.server.registerChatClient($("#userNameTextbox").val()).done(function () {
                        $('.chatContents > div:not(.chatHeader)').remove();
                        $.ajax({ url: "api/messages" }).done(function (data) {
                            for (var i = data.Messages.length - 1; i >= 0; i--) {
                                _this.PaintMsg(data.Messages[i]);
                            }

                            $.each(data.UsersSigned, function (idx, value) {
                                _this.AddUser(value);
                            });
                        })
                            //.fail(function (x, y, z) {
                            //alert('something went wrong retrieving older messages');
                        //});
                    });
                }).fail(function () {
                    alert('something went wrong connecting');
                });

                _this.chatConnection.client.messageSent = _this.PaintMsg;

                _this.chatConnection.client.userSignedIn = _this.AddUser;

                _this.chatConnection.client.userSignedOut = _this.RemoveUser;
            });

            $(".sendmessageButton").click(function () {
                _this.chatConnection.server.sendText($("#userNameTextbox").val(), $("#chatMessageTextbox").val());
            });

            $(".signoutButton").click(function () {
                $.connection.hub.stop();
                $(".signin").show();
                $(".chatWindow").hide();
            });
        }
        ChatController.prototype.PaintMsg = function (msg) {
            var self = this;

            var tm2 = new Date(Date.parse(msg.TimeSent));
            var altStyle = 'chatRow';
            if (self.altRow) {
                altStyle = 'altChatRow';
            }
            var msgHtml = "<div class='row-fluid " + altStyle + "'>";
            msgHtml += "<div class='span1'>";
            msgHtml += msg.Username;
            msgHtml += "</div>";
            msgHtml += "<div class='span7'>";
            msgHtml += msg.MessageText;
            msgHtml += "</div>";
            msgHtml += "<div class='span2'>";
            msgHtml += tm2.toLocaleTimeString();
            msgHtml += "</div>";
            msgHtml += "</div>";

            $(".chatHeader").after(msgHtml);
            self.altRow = !self.altRow;
        };

        ChatController.prototype.AddUser = function (user) {
            var self = this;

            if ($(".usersContainer > div:contains('" + user.Username + "')").length == 0) {
                var newuserHtml;
                newuserHtml = "<div>" + user.Username + "</div>";
                $(".usersContainer").append(newuserHtml);
            }
        };

        ChatController.prototype.RemoveUser = function (userName) {
            $.each($(".usersContainer > div"), function (idx, userDiv) {
                var jDiv = $(userDiv);

                if (jDiv.text() == userName) {
                    jDiv.fadeOut(500, function () {
                        jDiv.remove();
                    });
                }
            });
        };
        return ChatController;
    })();
    Chat.ChatController = ChatController;
})(Chat || (Chat = {}));
//# sourceMappingURL=Chat.js.map
