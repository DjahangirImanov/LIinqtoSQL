using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp46
{
    internal class Operations
    {
        public static Table<USER> Doldur()
        {
            AccauntDataContext data = new AccauntDataContext();
            return data.USERs;
        }
    }
}
