using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MvvmCross_Application1.Core.Model
{
   [Table("Favor1")]
    public class Favor1
    {
        public int? Id { get; set; }

        public string VideoId { get; set; }
       
    }
}
