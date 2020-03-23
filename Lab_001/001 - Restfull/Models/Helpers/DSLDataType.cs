using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _001___Restfull.Models.Helpers
{
    public class DSLDataType
    {
        public bool BoolValue { get; set; }
        public object Value { get; set; }

        public DSLDataType()
        {
            this.BoolValue = false;
            this.Value = "did not run";
        }
    }
}