using Microsoft.AspNetCore.Mvc;

namespace BookSellerAPI.Controllers
{
    public class LoggerCls : ControllerBase
    {
        string _Path = @"C:\Users\isil.guler\source\repos\BookSellerAPI\BookSellerAPI\Log\";
        string _FileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

        public void CreateLog(string message)
        {
            FileStream fs = new FileStream(_Path + _FileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            //Log dosyasının içinde bulunan yazıyı formatlamak için kullanılır.
            sw.Write(DateTime.Now.ToString() + ":" + message);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
    }
}
