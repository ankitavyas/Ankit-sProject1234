using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.Model;

namespace My.Business.Interface
{
    public interface IConsoleOperation
    {
        void OutputData(List<Customer> customerList);

        void OutputDataToFile(List<Customer> customerList);

        List<string> ReadData();
    }
}
