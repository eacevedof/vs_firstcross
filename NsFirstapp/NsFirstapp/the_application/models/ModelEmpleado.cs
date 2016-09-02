/**
* @file:\NsFirstapp\NsFirstapp\models\ModelEmpleado.cs 1.0.3
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;


namespace NSTheapplication.Models
{
    [Table("app_emloyee")]
    public class ModelEmpleado
    {
        [PrimaryKey, AutoIncrement] 
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public decimal salary { get; set; }
        public string birth_date { get; set; }
        public bool is_enabled { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}"
                ,this.id,this.first_name,this.last_name,this.birth_date,this.salary,this.is_enabled);
        }//ToString

    }//ModelEmpleado
}//NsFirstapp.models
