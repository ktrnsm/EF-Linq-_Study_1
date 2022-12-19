using EF_Linq__Study_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Linq__Study_1.DesignPatterns.SingltonPattern
{
    public class DBTool
    {

        DBTool() { }
        static NorthwindEntities _dbInstance;

        public static NorthwindEntities DBInstance
        {
            get

            {
                if (_dbInstance == null) _dbInstance = new NorthwindEntities();
                return _dbInstance;
            }
        }
    }

}
