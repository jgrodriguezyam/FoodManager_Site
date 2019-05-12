using System;
using System.IO;
using System.Web.Mvc;

namespace FoodManager.Infrastructure.Factories
{
    public class StreamFactory : Controller
    {
        public FileStreamResult Csv(Stream stream, string title)
        {
            return File(stream, "application/csv", title + " " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".csv");
        }
    }
}