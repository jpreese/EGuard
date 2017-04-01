﻿using System;
using System.Collections.Generic;

namespace EGuard.Data
{
    public interface ILog<T>
    {
        IEnumerable<T> GetByDate(DateTime date);

        void Log(T data);
    }
}