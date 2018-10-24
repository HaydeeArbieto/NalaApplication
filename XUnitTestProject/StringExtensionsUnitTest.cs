using NalaApplication.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class StringExtensionsUnitTest
    {
        [Fact]
        public void Return_First_Case_To_Upper()
        {
            var testString = "name";
            var result = testString.UppercaseFirst();
          
            Assert.Equal("Name", result);
        }
    }
}
