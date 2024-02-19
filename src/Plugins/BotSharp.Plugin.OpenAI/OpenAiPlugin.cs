using BotSharp.Abstraction.MLTasks;
using BotSharp.Abstraction.Plugins;
using BotSharp.Abstraction.Settings;
using BotSharp.Plugin.OpenAI.Providers;
using BotSharp.Plugin.OpenAI.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotSharp.Plugin.OpenAI
{
    /// <summary>
    /// Azure OpenAI Service
    /// </summary>
    public class OpenAiPlugin : IBotSharpPlugin
    {
        public string Id => "eb279804-e7a6-40a3-8669-ba53c280bdb9";
        public string Name => "OpenAI";
        public string Description => "OpenAI Service including text generation, text to image and other AI services.";
        public string IconUrl => "https://openai.com/favicon.ico";

        public void RegisterDI(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(provider =>
            {
                var settingService = provider.GetRequiredService<ISettingService>();
                return settingService.Bind<OpenAiSettings>("OpenAi");
            });

            services.AddScoped<ITextCompletion, TextCompletionProvider>();
            services.AddScoped<IChatCompletion, ChatCompletionProvider>();
        }
    }
}

