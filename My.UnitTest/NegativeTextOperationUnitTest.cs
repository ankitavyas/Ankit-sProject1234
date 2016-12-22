using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using My.Business;
using My.Business.Interface;
using My.Model;

namespace My.UnitTest
{
    [TestClass]
    public class NegativeTextOperationUnitTest
    {

        #region "Declaration"
        static UnityContainer container = new UnityContainer();

        private List<string> inputStringList;
        private List<Customer> expectedCustomerList;
        #endregion

        

        [TestMethod]
        public void Test_InputDataValid()
        {
            Assert.IsNotNull(inputStringList, "Input data is null");
        }

        [TestMethod]
        public void Test_InputAndOutputHaveNotSameNumbers()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            Assert.IsNotNull(inputClassList, "Processed data output is null");
            Assert.IsFalse(inputClassList != null && inputClassList.Count == inputStringList.Count, "Same number of records extracted from input file - Expected less");
        }

        [TestMethod]
        public void Test_SortedOutputHaveNotSameNumbers()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            // Business Logic to sort data via common class
            inputClassList = textOperation.SortData(inputClassList);

            Assert.IsNotNull(inputClassList, "Processed Sorted data output is null");
            Assert.IsFalse(inputClassList!= null && inputClassList.Count == inputStringList.Count, "Sorted data has same number of records - Expected less");
        }

        [TestMethod]
        public void Test_SortedSequence()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            // Business Logic to sort data via common class
            inputClassList = textOperation.SortData(inputClassList);

            var ctr = 0;
            foreach (var aCustomer in inputClassList)
            {
                Assert.IsTrue(inputClassList[ctr].LastName == aCustomer.LastName &&
                            inputClassList[ctr].FirstName == aCustomer.FirstName, "Unexpected customer sorted - Position " + ctr+1);

                ctr += 1;
            }
        }

        #region "Initialization"

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            container.RegisterType<ITextOperation, TextOperation>();
        }

        [TestInitialize()]
        public void Initialize()
        {
            
            inputStringList = new List<string> {"BAKER, THEODORE", "SMITH, ANDREW", "KENT, MADISON, abc", ""};

            expectedCustomerList = new List<Customer>();
            expectedCustomerList.Add(new Customer() { LastName = "BAKER", FirstName = "THEODORE" });
            expectedCustomerList.Add(new Customer() { LastName = "SMITH", FirstName = "ANDREW" });
        }

        [TestCleanup()]
        public void Cleanup()
        {
            inputStringList = null;
        }

        #endregion
    }
}
