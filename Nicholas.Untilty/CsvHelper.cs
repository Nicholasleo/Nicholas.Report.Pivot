/*==============================================
*CLR版本：4.0.30319.36388
*名称：CsvHelper
*命名空间名称：Nicholas.Untilty
*文件名称：CsvHelper
*创建时间：2017/9/5 11:04:23
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System.IO;
using System.Data;

namespace Nicholas.Untilty
{
    public class CsvHelper
    {
        public MemoryStream ExportCsv(DataTable dt)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter write = new StreamWriter(ms, System.Text.Encoding.Default);
            {
                for (int i = 0; i < dt.Columns.Count; ++i)
                {
                    write.Write(dt.Columns[i].ColumnName + (i < dt.Columns.Count - 1 ? "," : ""));
                }
                write.WriteLine();

                foreach (DataRow dr in dt.Rows)
                {
                    write.WriteLine(string.Join(",", FilterSpecialSymbol(dr.ItemArray)));
                }
            }

            return ms;
        }

        public byte[] ExportCsvTo(DataTable dt)
        {
            byte[] buffer = null;
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter write = new StreamWriter(ms, System.Text.Encoding.Default))
            {
                for (int i = 0; i < dt.Columns.Count; ++i)
                {
                    write.Write(dt.Columns[i].ColumnName + (i < dt.Columns.Count - 1 ? "," : ""));
                }
                write.WriteLine();

                foreach (DataRow dr in dt.Rows)
                {
                    string item = string.Join(",", FilterSpecialSymbol(dr.ItemArray));
                    write.WriteLine(item);
                }
                write.Flush();
                buffer = ms.ToArray();
            }

            return buffer;
        }

        public bool ExportSvcToFile(DataTable dt, string saveFileName)
        {
            using (FileStream f = new FileStream(saveFileName, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(f))
                {
                    for (int i = 0; i < dt.Columns.Count; ++i)
                    {
                        write.Write(dt.Columns[i].ColumnName + (i < dt.Columns.Count - 1 ? "," : ""));
                    }
                    write.WriteLine();

                    foreach (DataRow dr in dt.Rows)
                    {
                        string item = string.Join(",", FilterSpecialSymbol(dr.ItemArray));
                        write.WriteLine(item);
                    }
                    write.Flush();
                    return true;
                }
            }
        }

        private string[] FilterSpecialSymbol(object[] array)
        {
            string[] rarray = new string[array.Length];
            for (int i = 0; i < rarray.Length; ++i)
            {
                string itm = array[i].ToString().Replace("\"", "\"\"");
                if (itm.Contains(",") || itm.Contains("\"")
                || itm.Contains("\r") || itm.Contains("\n"))
                {
                    itm = string.Format("\"{0}\"", itm);
                }

                rarray[i] = itm;
            }
            return rarray;
        }
    }
}
