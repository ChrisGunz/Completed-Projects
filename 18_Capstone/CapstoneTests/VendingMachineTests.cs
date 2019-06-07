using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Assert.AreEqual(vendingMachine.Balance, 0.0M);
        }

        [TestMethod]
        public void TestFeedMoney()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(5.0M);
            Assert.AreEqual(5.0m, vendingMachine.Balance);

            vendingMachine.FeedMoney(3.0M);
            Assert.AreEqual(8.0m, vendingMachine.Balance);

            vendingMachine.FeedMoney(3.0M);
            Assert.AreEqual(11.0m, vendingMachine.Balance);
        }

        [TestMethod]
        public void TestPurchase()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FeedMoney(100.0m);

            vendingMachine.Purchase(10.0M);
            Assert.AreEqual(90.0M, vendingMachine.Balance);

            vendingMachine.Purchase(20.0M);
            Assert.AreEqual(70.0M, vendingMachine.Balance);
        }
    }
}