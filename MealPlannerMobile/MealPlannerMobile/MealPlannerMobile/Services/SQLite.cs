using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace MealPlannerMobile
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
