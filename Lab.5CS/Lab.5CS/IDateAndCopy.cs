﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._5CS
{
    interface IDateAndCopy
    {

        object DeepCopy();
        DateTime Date { get; set; }
    }
}
