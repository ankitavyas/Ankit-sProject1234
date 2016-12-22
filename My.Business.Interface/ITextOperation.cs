using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.Model;

namespace My.Business.Interface
{
    public interface ITextOperation
    {
        List<Customer> ProcessData(List<string> inputList);

        List<Customer> SortData(List<Customer> inputList);
    }
}
