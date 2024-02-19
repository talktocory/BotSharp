namespace BotSharp.Abstraction.Wiki.Models
{
    /// <summary>
    /// A model class for a wiki page.
    /// </summary>
    public class WikiPage
    {
        /// <summary>
        /// Gets or sets the title of the wiki page.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the conversation ID for the wiki page.
        /// </summary>
        public string ConversationId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the path for the wiki page.
        /// </summary>
        public string[] Path { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the summary of the wiki page.
        /// </summary>
        public string Summary { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the content of the wiki page.
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}
