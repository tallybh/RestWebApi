using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWebApi.Models;

public class Class : BaseEntity
{
    public string Title { get; set; } = default!;
    public List<Student> Students { get; set; } = default!;
    //public Professor Professor { get; set; } = default!;
}
