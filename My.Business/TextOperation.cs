using System.Collections.Generic;
using System.Linq;
using My.Business.Interface;
using My.Model;

namespace My.Business
{
    public class TextOperation : ITextOperation
    {
        /// <summary>
        /// This Function excepts a row string list and returns an equivalent list of class
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<Customer> ProcessData(List<string> inputList)
        {
            List<Customer> answerList = new List<Customer>();
            foreach (var anItem in inputList)
            {
                var splittedData = anItem.Split(',');
                if (splittedData.Length == 2)
                {
                    var aCustomer = new Customer() { LastName = splittedData[0].Trim(), FirstName = splittedData[1].Trim() };
                    answerList.Add(aCustomer);
                }
                else
                {
                    // This could have been logged
                    // OR exception handled at called end.
                    // For Now, not doing anything and ignoring that line
                }
            }

            return answerList;
        }

        /// <summary>
        /// This function holds current sorting logic
        /// In this instance, I have used LINQ - can be any other
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<Customer> SortData(List<Customer> inputList)
        {
            if (inputList!= null && inputList.Count > 0)
                return inputList.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

            return null;
        }
        
    }
}
