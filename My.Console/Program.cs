using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using My.Business;
using My.Business.Interface;

namespace My.Console
{
    class Program
    {

        #region "Declaration"
        static UnityContainer container = new UnityContainer();
        #endregion 

        static void Main(string[] args)
        {
            Registration();
            ExecuteFileOperation();
        }

        private static void ExecuteFileOperation()
        {
            try
            {
                // Objects from DI
                var textOperation = container.Resolve<ITextOperation>();
                var consoleOperation = container.Resolve<IConsoleOperation>();

                // Console Specific operation of reading (Text file)
                var inputStringList = consoleOperation.ReadData();

                // Business Logic to process data via common class
                var inputClassList = textOperation.ProcessData(inputStringList);

                // Business Logic to sort data via common class
                inputClassList = textOperation.SortData(inputClassList);

                // Console Specific operation to show data in console
                consoleOperation.OutputData(inputClassList);

                // Also writing to text file
                consoleOperation.OutputDataToFile(inputClassList);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error found : " + ex.Message);
            }
        }

        private static void Registration()
        {
            container.RegisterType<ITextOperation, TextOperation>();
            container.RegisterType<IConsoleOperation, FileHelper>();
        }
    }
}
