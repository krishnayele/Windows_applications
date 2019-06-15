using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CheckMyDatabase
{
    public class ShowData
    {
        private readonly Timer _timer;
        

        public ShowData()
        {
            _timer = new Timer(100000) { AutoReset = true };
            _timer.Elapsed += timer_Elapsed;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Inventory"].ConnectionString;
            string query = "Select Count(*) from Item;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
               var result =  "\n The number of Items Present is "+cmd.ExecuteScalar();
                File.AppendAllText(@"E:\practice\C#\services\showData.txt", result.ToString());
                conn.Close();
            }catch(Exception ex)
            {
                var result = "\n" + ex.Message + "\n";
                File.AppendAllText(@"E:\practice\C#\services\showData.txt", result.ToString());
            }
        }
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
