using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._3CS
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
