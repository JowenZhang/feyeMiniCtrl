using System.Collections.Generic;
using System;

namespace DaliyLife.Dal
{
    public static class CodeDal
    {
        public static Dictionary<string, string> ConStr
        {
            get
            {
                Dictionary<string, string> conStr = new Dictionary<string, string>();
                conStr.Add("postgres", @"Server=47.94.151.185;Port=5432;Database=FeyeDb;uid=postgres;pwd=123456;");
                return conStr;
            }
        }

        public static Dictionary<string, string> QueryStr
        {
            get
            {
                Dictionary<string, string> queryStr = new Dictionary<string, string>();
                queryStr.Add("getCount", @"select count(*) from ctl_fly where id=1;");
                queryStr.Add("getSingle", @"select * from ctl_fly limit 1;");
                queryStr.Add("updateSingle", @"update ctl_fly set input_time=@input_time,fly_code=@fly_code where id=@id;");
                queryStr.Add("insertSingle", @"insert into ctl_fly(input_time,fly_code) values (@input_time,@fly_code);");
                return queryStr;
            }
        }
    }
}