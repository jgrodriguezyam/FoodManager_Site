using System.Web;
using System.Web.Script.Serialization;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Models.Files;

namespace FoodManager.Models
{
    public class SaucerMultimedia: File
    {
        public SaucerMultimedia()
        {
            Id = 0;
            Path = "";
            Status = false;
            Saucer = new Saucer();
        }

        public int Id { get; set; }
        public bool Status { get; set; }
        public string Path
        {
            get { return Href; }
            set { ResolvePath(value); }
        }

        [ScriptIgnoreAttribute]
        public HttpPostedFileBase FileBase { get; set; }

        public Saucer Saucer { get; set; }
        public int SaucerId
        {
            get { return Saucer.IsNotNull() ? Saucer.Id : 0; }
            set
            {
                Saucer.Id = value;
                Saucer.Name = "OnlyId";
            }
        }
    }
}