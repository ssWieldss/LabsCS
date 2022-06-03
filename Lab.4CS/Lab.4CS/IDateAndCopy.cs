using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._4CS
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
