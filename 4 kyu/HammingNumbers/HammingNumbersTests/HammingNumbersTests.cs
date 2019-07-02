﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HammingNumbers;

namespace HammingNumbersTests
{
    [TestClass]
    public class HammingNumbersTests
    {
        [TestMethod]
        public void Test1() =>
            Assert.AreEqual(1, Hamming.hamming(1), "hamming(1) should be 1");
        [TestMethod]
        public void Test2() =>
            Assert.AreEqual(2, Hamming.hamming(2), "hamming(2) should be 2");
        [TestMethod]
        public void Test3() =>
            Assert.AreEqual(3, Hamming.hamming(3), "hamming(3) should be 3");
        [TestMethod]
        public void Test4() =>
            Assert.AreEqual(4, Hamming.hamming(4), "hamming(4) should be 4");
        [TestMethod]
        public void Test5() =>
            Assert.AreEqual(5, Hamming.hamming(5), "hamming(5) should be 5");
        [TestMethod]
        public void Test6() =>
            Assert.AreEqual(6, Hamming.hamming(6), "hamming(6) should be 6");
        [TestMethod]
        public void Test8() =>
            Assert.AreEqual(8, Hamming.hamming(7), "hamming(7) should be 8");
        [TestMethod]
        public void Test9() =>
            Assert.AreEqual(9, Hamming.hamming(8), "hamming(8) should be 9");
        [TestMethod]
        public void Test10() =>
            Assert.AreEqual(10, Hamming.hamming(9), "hamming(9) should be 10");
        [TestMethod]
        public void Test12() =>
            Assert.AreEqual(12, Hamming.hamming(10), "hamming(10) should be 12");
        [TestMethod]
        public void Test15() =>
            Assert.AreEqual(15, Hamming.hamming(11), "hamming(11) should be 15");
        [TestMethod]
        public void Test16() =>
            Assert.AreEqual(16, Hamming.hamming(12), "hamming(12) should be 16");
        [TestMethod]
        public void Test18() =>
            Assert.AreEqual(18, Hamming.hamming(13), "hamming(13) should be 18");
        [TestMethod]
        public void Test20() =>
            Assert.AreEqual(20, Hamming.hamming(14), "hamming(14) should be 20");
        [TestMethod]
        public void Test24() =>
            Assert.AreEqual(24, Hamming.hamming(15), "hamming(15) should be 24");
        [TestMethod]
        public void Test25() =>
            Assert.AreEqual(25, Hamming.hamming(16), "hamming(16) should be 25");
        [TestMethod]
        public void Test27() =>
            Assert.AreEqual(27, Hamming.hamming(17), "hamming(17) should be 27");
        [TestMethod]
        public void Test30() =>
            Assert.AreEqual(30, Hamming.hamming(18), "hamming(18) should be 30");
        [TestMethod]
        public void Test32() =>
            Assert.AreEqual(32, Hamming.hamming(19), "hamming(19) should be 32");
               
    }
}
