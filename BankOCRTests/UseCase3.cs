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
    public class UseCase3
    {
        IngeniousMachine machine = new IngeniousMachine();

        [Test]
        public void IlleligibleAccount()
        {
            var sb = new StringBuilder();
            sb.Append(" _ ").Append("   ").Append("   ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append(" _ ").Append("\r\n");
            sb.Append(" _|").Append("| |").Append("|_ ").Append("|_|").Append("|_|").Append(" _|").Append("|_|").Append("|_ ").Append("|_ ").Append("\r\n");
            sb.Append("|_|").Append("  |").Append(" _|").Append("|_|").Append("|_|").Append("|_ ").Append("|_|").Append("|_|").Append(" _|").Append("\r\n");
            sb.Append("\r\n");

            var result = machine.Translate(new StringReader(sb.ToString())).ToArray();

            result.Count().Should().Be(1);

            var parsedAccount = result[0].Item2;
            parsedAccount.Should().Be("???882865");

            result[0].Item3.Should().Be("ILL");
        }
    }
}
