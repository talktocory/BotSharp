using BotSharp.Abstraction.Users.Models;
using BotSharp.Abstraction.Wiki.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BotSharp.Core.Repository
{
    public partial class FileRepository
    {
        /// <summary>
        /// Creates or updates a wiki page in the local file system repository.
        /// </summary>
        /// <param name="wikiPage"></param>
        public void UpsertPage(WikiPage wikiPage)
        {
            // Determine the directory to save the wiki page in.
            var dir = Path.Combine(_dbSettings.FileRepository, "conversations", wikiPage.ConversationId, "wiki");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // Remove any reserved characters from the file name.
            var fileName = wikiPage.Title
                .Replace(":", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("?", "")
                .Replace("*", "")
                .Replace("\"", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "")
                .Replace(" ", "-");
            var path = Path.Combine(dir, fileName + ".md");

            // Create or replace the wiki page file.
            File.WriteAllText(path, wikiPage.Content);
        }

        public WikiPage? GetWikiPage (string conversationId, string title)
        {
            // Determine the directory to read the wiki page from.
            var dir = Path.Combine(_dbSettings.FileRepository, "conversations", conversationId, "wiki");
                       if (!Directory.Exists(dir))
                       {
                           return null;
                       }

            // Remove any reserved characters from the file name.
           var fileName = title
               .Replace(":", "")
               .Replace("/", "")
               .Replace("\\", "")
               .Replace("?", "")
               .Replace("*", "")
               .Replace("\"", "")
               .Replace("<", "")
               .Replace(">", "")
               .Replace("|", "")
               .Replace(" ", "-");
            var path = Path.Combine(dir, fileName + ".md");

            // Read the wiki page file.
            if (File.Exists(path))
            {
                return new WikiPage
                {
                    Title = title,
                    ConversationId = conversationId,
                    Path = new string[] { title },
                    Summary = "",
                    Content = File.ReadAllText(path)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
