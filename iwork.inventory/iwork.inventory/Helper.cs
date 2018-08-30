using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  iwork.autobits.inventory.Model;
using System.Windows.Forms;

namespace  iwork.autobits.inventory
{
    public static class Helper
    {

        private static DatabaseDataContext Database = new DatabaseDataContext();

        public static long USERID = 0;
        public static long ROLEID = 0;
        public static string USERNAME = string.Empty;
        public static string FULLNAME = string.Empty;
        public static string ROLE_NAME = string.Empty;

        public static string PRICEOPTION = string.Empty;
        public static string MODEOPTION = string.Empty;

        public static bool isChanged = false;
        public static string isCopy = "no";
        public static string isSalesCopy = "no";

        public static bool IsPermitted(long FormID)
        {
            var data = Database.RolePermissions.Where(x => x.RoleID == ROLEID && x.SystemFormID == FormID);

            if (data.Count() <= 0)
            {
                return false;
            }

            return true;

        }



        public static String MessageBoxHeader
        {
            get
            {
                return "INVENTORY SYSTEM";
            }
            
        }
        public static ColumnHeader Header(string ColumnName, HorizontalAlignment align, int width)
        {
            ColumnHeader col = new ColumnHeader();
            col.TextAlign = align;
            col.Text = ColumnName;
            col.Width = width;
            return col;
        }

        public static string RemoveSpaceAfter(string inputString)
        {
            string fateh = string.Empty;
            try
            {


                string[] Split = inputString.Split(new Char[] { ' ' });
                //SHOW RESULT
                for (int i = 0; i < Split.Length; i++)
                {
                    fateh += Convert.ToString(Split[i]);
                }
                return fateh;
            }
            catch (Exception gg)
            {
                return fateh;
            }
        }

        public static bool CheckIfInterger(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsMoney(string value)
        {
            try
            {
                decimal.Parse(value);
                return true;

            }
            catch
            {

            }
            return false;
        }

        public static bool IsValidDate(string value)
        {
            try { DateTime.Parse(value); return true; }
            catch { }
            return false;
        }
        

    }
}
