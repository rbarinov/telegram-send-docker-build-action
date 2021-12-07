using CommandLine;

namespace TelegramSendDockerBuildAction
{
    public class Options
    {
        [Option("bot-key", Required = true)]
        public string BotKey { get; set; }

        [Option("chat-id", Required = true)]
        public string ChatId { get; set; }

        [Option('s', "source", Required = true)]
        public string Source { get; set; }

        [Option('e', "event", Required = true)]
        public string Event { get; set; }

        [Option('r', "ref", Required = true)]
        public string Ref { get; set; }

        [Option('h', "commit-hash", Required = true)]
        public string CommitHash { get; set; }

        [Option('m', "commit-message", Required = false)]
        public string CommitMessage { get; set; }

        [Option('i', "docker-image", Required = true)]
        public string DockerImage { get; set; }
    }
}
