using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestWebApi.Models;

public class Student:BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    //public List<Class>? Classes { get; set; } = default!;
    public Address Address { get; set; } = default!;
}
