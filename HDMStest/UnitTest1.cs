using Microsoft.EntityFrameworkCore;
using HDMS.Data;
using HDMS.Models;

namespace HDMStest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var person = new Patient();
            person.Name = "S";

            Assert.True(person.Name == "S", "is S!");
        }
    }
}