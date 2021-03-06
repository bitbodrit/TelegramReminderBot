﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ReminderTelegramBot.Model.Interfaces;

namespace ReminderTelegramBot.Model
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, ITelegramBotClient client, IReminderStore reminderStore, CallbackQuery callbackQuery = null);

        public bool Contains(Message message)
        {
            if (message == null || message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public bool Contains(CallbackQuery callbackQuery)
        {
            if (callbackQuery == null || !Name.Equals("удалить все"))
                return false;

            return true;
        }
    }
}
