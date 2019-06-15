using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ICanDoIt>(s =>
                {
                    s.ConstructUsing(iCan => new ICanDoIt());
                    s.WhenStarted(iCan => iCan.start());
                    s.WhenStopped(iCan => iCan.Stop());
                });
                x.RunAsLocalSystem();

                x.SetServiceName("ICanDoIt");
                x.SetDisplayName("I Can Do It");
                x.SetDescription("It is a demo service that will run in background");
            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
