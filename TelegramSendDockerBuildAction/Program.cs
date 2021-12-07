using System;
using System.Threading.Tasks;
using CommandLine;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace TelegramSendDockerBuildAction
{
    public static class Program
    {
        private static async Task Job(Options options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var bot = new TelegramBotClient(options.BotKey);
            await bot.SetWebhookAsync(string.Empty);

            var commitMessage = string.IsNullOrWhiteSpace(options.CommitMessage)
                ? ""
                : $@"
<code>{options.CommitMessage}</code>
";

            var message = $@"
{IconHelper.GetRandomIcon()}  <b>{options.Event}</b>

<b>{options.Source}</b>
{options.Ref}

<code>{options.DockerImage}</code>

{options.CommitHash}
" + commitMessage;

            await bot.SendTextMessageAsync(
                options.ChatId,
                message,
                ParseMode.Html
            );
        }

        private static async Task Main(string[] args)
        {
            var parse = Parser.Default.ParseArguments<Options>(args);

            parse.WithNotParsed(e => { });
            await parse.WithParsedAsync(Job);
        }
    }
}
