﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} - {Id}";
        }
    }
}
