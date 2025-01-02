using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public bool Married { get; set; }
    public string Phone { get; set; }
    [Column(TypeName = "decimal(6,6)")]
    public decimal Salary { get; set; }
}
