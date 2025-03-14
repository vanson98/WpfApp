using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Models
{
    public class Photo
    {
        public string Source { get; }
        public override string ToString()
        {
            return Source;
        }

        public Photo(string path)
        {
            Source = path;
        }
    }
}
