using BotSharp.Abstraction.Plugins.Models;
using BotSharp.Abstraction.Settings;
using Microsoft.Extensions.Configuration;

namespace BotSharp.Plugin.Wiki;

public class WikiPlugin : IBotSharpPlugin
{
    public string Id => "4893add4-9dd2-4266-85a4-d1d10b9842b2";
    public string Name => "Wiki";
    public string Description => "Manages upserts to a wiki file structure.";
    public string IconUrl => "https://en.wikipedia.org/favicon.ico";
    public string[] AgentIds => new[] { "41af73f9-295b-4ec2-8b30-745dfc7eb9e1" };

    public void RegisterDI(IServiceCollection services, IConfiguration config)
    {
        var a = config["Wiki"];
    }

}
