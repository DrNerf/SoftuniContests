using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniContests.BusinessObjects.Models
{
    public class PictureModel
    {
        public int PictureID { get; set; }
        public int ContestID { get; set; }
        public string Url { get; set; }
    }
}
