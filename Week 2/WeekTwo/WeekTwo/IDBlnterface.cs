using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeekTwo
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
