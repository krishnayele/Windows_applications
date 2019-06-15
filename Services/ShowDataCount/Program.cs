using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CheckMyDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x => {
                x.Service<ShowData>(s => {
                    s.ConstructUsing(showDataObj =>new ShowData());
                    s.WhenStarted(showDataObj => showDataObj.Start());
                    s.WhenStopped(showDataObj => showDataObj.Stop());

                });

                x.RunAsLocalSystem();
                x.SetServiceName("ShowDbData");
                x.SetDisplayName("Show DB Data");
                x.SetDescription("This service will in 100 sec interval retrieve the info from database and store the number of Items in a File");

            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
