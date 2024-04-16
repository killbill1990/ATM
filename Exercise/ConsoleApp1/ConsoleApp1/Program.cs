using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Data.SqlClient;


using Microsoft.SqlServer.Dts.Runtime;

namespace ConsoleApp1
{
    internal class Program
    {
       

        static void Main(string[] args)
        {






            //Here is the path of the folder where there are the files
            string path = @"D:\SoftwareDeveloperExercise\";

             //Unzip the zip file with the text files
             using (ZipFile archive = new ZipFile(@"D:\SoftwareDeveloperExercise\Files.zip"))
             {
                 archive.Password = "FirstCall13";
                 archive.Encryption = EncryptionAlgorithm.WinZipAes256;
                 archive.StatusMessageTextWriter = Console.Out;

                 archive.ExtractAll(@"D:\SoftwareDeveloper", ExtractExistingFileAction.Throw);
             }


            var application = new Application();
            using (var package = application.LoadPackage(@"C:\Users\Vasilis\source\repos\SsisLoadData\SsisLoadData\Package.dtsx", null))
            {
                var execResult = package.Execute();
                Console.WriteLine(execResult.ToString());
            }
            Console.ReadKey();



        }
    }


}