using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWebApi.Models;

public class Address : BaseEntity
{
    public string City { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public string Street { get; set; } = default!;
    public int HouseNumber { get; set; }
}
