using MvvmCross_Application1.Core.DataBase;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MvvmCross_Application1.Core.Model
{
   [Table("Favor12")]
    public class Favor12: BaseEntity
    {
        public int? Id { get; set; }

        public string VideoId { get; set; }
       
    }

   
}
