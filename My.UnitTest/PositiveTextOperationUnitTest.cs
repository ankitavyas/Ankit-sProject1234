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
    public class PositiveTextOperationUnitTest
    {

        #region "Declaration"
        static UnityContainer container = new UnityContainer();


        private List<string> inputStringList;
        private List<Customer> expectedCustomerList;
        #endregion
        

        [TestMethod]
        public void PositiveTest_InputDataValid()
        {
            Assert.IsNotNull(inputStringList, "Input data is null");
        }

        [TestMethod]
        public void PositiveTest_InputAndOutputHaveSameNumbers()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            Assert.IsNotNull(inputClassList, "Processed data output is null");
            Assert.IsTrue(inputClassList != null && inputClassList.Count == inputStringList.Count, "Less number of records extracted from input file");
        }

        [TestMethod]
        public void PositiveTest_SortedOutputHaveSameNumbers()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            // Business Logic to sort data via common class
            inputClassList = textOperation.SortData(inputClassList);

            Assert.IsNotNull(inputClassList, "Processed Sorted data output is null");
            Assert.IsTrue(inputClassList!= null && inputClassList.Count == inputStringList.Count, "Sorted data has Less number of records than input data");
        }

        [TestMethod]
        public void PositiveTest_SortedSequence()
        {
            // Objects from DI
            var textOperation = container.Resolve<ITextOperation>();

            // Business Logic to process data via common class
            var inputClassList = textOperation.ProcessData(inputStringList);

            // Business Logic to sort data via common class
            inputClassList = textOperation.SortData(inputClassList);

            Assert.IsNotNull(inputClassList, "Processed Sorted data output is null");
            Assert.IsTrue(inputClassList != null && inputClassList.Count == inputStringList.Count, "Sorted data has Less number of records than input data");

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
            
            inputStringList = new List<string> {"BAKER, THEODORE", "SMITH, ANDREW", "KENT, MADISON", "SMITH, FREDRICK"};

            expectedCustomerList = new List<Customer>();
            expectedCustomerList.Add(new Customer() { LastName = "BAKER", FirstName = "THEODORE" });
            expectedCustomerList.Add(new Customer() { LastName = "KENT", FirstName = "MADISON" });
            expectedCustomerList.Add(new Customer() { LastName = "SMITH", FirstName = "ANDREW" });
            expectedCustomerList.Add(new Customer() { LastName = "SMITH", FirstName = "FREDRICK" });
        }

        [TestCleanup()]
        public void Cleanup()
        {
            inputStringList = null;
        }

        #endregion
    }
}
