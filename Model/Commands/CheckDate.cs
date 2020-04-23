﻿using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReminderTelegramBot.Commands
{
    public class CheckDate : TelegramCommand
    {
        public override string Name => "/date";

        public override async Task Execute(Message message, ITelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var keyBoard = new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("/help")
                    }
                },
            };
            var now = DateTime.Now;

            await client.SendTextMessageAsync(chatId, $"{now.ToString("F")}", 
                                                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);

        }
    }
}
