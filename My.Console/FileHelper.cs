using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using My.Business.Interface;
using My.Model;

namespace My.Console
{
    /// <summary>
    /// Console based helper class
    /// </summary>
    internal class FileHelper : IConsoleOperation
    {

        #region "Declaration"
        readonly string INPUTFILENAME = "MyInput.txt";
        readonly string OUTPUTFILENAME = "MyInput-sorted.txt";
        #endregion  

        public void OutputData(List<Customer> customerList)
        {
            foreach (var aCustomer in customerList)
            {
                System.Console.WriteLine(string.Format("{0}, {1}", aCustomer.LastName, aCustomer.FirstName));
            }
        }

        public void OutputDataToFile(List<Customer> customerList)
        {
            using (StreamWriter output = new StreamWriter(OUTPUTFILENAME, false))
            {
                foreach (var aCustomer in customerList)
                {
                    output.WriteLine(string.Format("{0}, {1}", aCustomer.LastName, aCustomer.FirstName));
                    output.Flush();
                }
            }
        }

        /// <summary>
        /// Reading Data (For Console : It's from text file)
        /// </summary>
        /// <returns></returns>
        public List<string> ReadData()
        {
            List<string> inputList = new List<string>();

            StreamReader sr = new StreamReader(INPUTFILENAME);
            try
            {
                string line;
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    inputList.Add(line);
                }
            }
            finally
            {
                if (sr != null)
                {
                    ((IDisposable)sr).Dispose();
                }
            }

            return inputList;
        }
    }
}
