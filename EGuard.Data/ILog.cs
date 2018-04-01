using System;
using System.Collections.Generic;

namespace EGuard.Data
{
    public interface ILog<T>
    {
        IEnumerable<T> GetLogs();

        void Log(T data);
    }
}
