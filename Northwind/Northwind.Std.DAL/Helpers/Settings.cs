using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.NET.DAL.Properties
{
    public partial class Settings
    {
        public class Default
        {
            public static string NorthwindConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=Northwind;Persist Security Info=True;User ID=YOUR_USERID;Password=YOUR_PASSWORD";
        }       
    }
}
