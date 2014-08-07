using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using BankOCR;

namespace BankOCRTests
{
    [TestFixture]
    public class UseCase1
    {
        IngeniousMachine machine = new IngeniousMachine();

        [Test]
        public void CheckOneToNine() 
        {
            var sb = new StringBuilder();
            sb.Append("   ").Append(" _ ").Append(" _ ").Append("   ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("  |").Append(" _|").Append(" _|").Append("|_|").Append("|_ ").Append("|_ ").Append("  |").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("  |").Append("|_ ").Append(" _|").Append("  |").Append(" _|").Append("|_|").Append("  |").Append("|_|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("123456789");
        }

        [Test]
        public void CheckZeros()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("| |").Append("| |").Append("| |").Append("| |").Append("| |").Append("| |").Append("| |").Append("| |").Append("| |").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("000000000");
        }

        [Test]
        public void CheckOnes()
        {
            var sb = new StringBuilder();
            sb.Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("\r\n");
            sb.Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("\r\n");
            sb.Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("111111111");
        }

        [Test]
        public void CheckTwos()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("222222222");
        }

        [Test]
        public void CheckThrees()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("333333333");
        }

        [Test]
        public void CheckFours()
        {
            var sb = new StringBuilder();
            sb.Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("   ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("444444444");
        }

        [Test]
        public void CheckFives()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("555555555");
        }

        [Test]
        public void CheckSixes()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("|_ ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("666666666");
        }

        [Test]
        public void CheckSevens()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("\r\n");
            sb.Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("  |").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("777777777");
        }

        [Test]
        public void CheckEights()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("888888888");
        }

        [Test]
        public void CheckNines()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("999999999");
        }

        [Test]
        public void CheckTwoLines() 
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");
            sb.Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("|_|").Append("\r\n");
            sb.Append("\r\n");


            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(2);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("999999999");

            parsedAccount = result[1].Item2;
            parsedAccount.Should().Be("888888888");
        }

    }
}
