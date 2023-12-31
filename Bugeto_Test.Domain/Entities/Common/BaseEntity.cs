﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Domain.Entities.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey ID { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }

        public DateTime? RemoveTime { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<long> { }

}
