using Microsoft.EntityFrameworkCore;
using HDMS.Data;
using HDMS.Models;
using HDMS.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Moq;
using Newtonsoft.Json;

namespace HDMStest
{
    public class TestPatientsController()
    {
        [Fact]
        public void TestGetNewData()
        {
            //db connection
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-HDMS-48d40d55-8956-414c-91ce-39d2db00ba82;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            using var context = new ApplicationDbContext(contextOptions);
            //get a date for Patient 1
            DateTime date = context.PatientData
                .Where(b => b.PatientId == 1)
                .Select(b => new
                {
                    date = b.Date,
                }).First().date;

            //create input
            var dataInput = new Dataex();
            dataInput.Date = date;
            dataInput.PatientId = 1;
            //call controller function
            var controller = new PatientsController(context);
            var jsonString = controller.GetNewData(dataInput);
            //is the output not null?
            Assert.NotNull(jsonString);
        }
    }
}