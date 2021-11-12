using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContozooAPI.Models
{
    public class Animals
    {   
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Location { get; set; }
        public string ActiveHours { get; set; }
        public string Notes { get; set; }
    }
}
