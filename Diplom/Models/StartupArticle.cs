using System;

namespace Diplom.Models
{
    public class StartupArticle
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
