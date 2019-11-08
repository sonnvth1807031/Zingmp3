using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Entity
{
    class Song
    {
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }
        public Dictionary<string, string> Validate()
        {
            bool a;
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("name", "Name is required!");
            }
            else if (name.Length < 5 || name.Length > 30)
            {
                errors.Add("name", "Name must be 5 to 30 characters!");
            }
            if (string.IsNullOrEmpty(singer))
            {
                errors.Add("single", "Please tell me who you are!");
            }
            else if (singer.Length < 5 || singer.Length > 30)
            {
                errors.Add("single", "Single must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(author))
            {
                errors.Add("author", "Avoid copyright infringement!");
            }
            else if (author.Length < 5 || author.Length > 30)
            {
                errors.Add("author", "Author must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(description))
            {
                errors.Add("description", "Avoid copyright infringement!");
            }

            if (string.IsNullOrEmpty(thumbnail))
            {
                errors.Add("thumbnail", "Thumbnail is required!");
            }
            else if (thumbnail.Length < 5 || thumbnail.Length > 30)
            {
                errors.Add("thumbnail", "Thumbnail must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(link))
            {
                errors.Add("link", "Link is required!");
            }
            else if (a = link.EndsWith(".mp3"))
            {
                var son = a.ToString();
                if (son.Equals("TRUE"))
                {
                    errors.Add("link", "Link phai ket thuc bang .mp3!");
                }
            }
            return errors;
        }
    }
}
