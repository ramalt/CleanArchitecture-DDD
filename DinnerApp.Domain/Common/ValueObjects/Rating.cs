using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinnerApp.Domain.Common.ValueObjects;

public record Rating
{
    public int Value { get; private set; }
    public Rating()
    {
        
    }   
}
