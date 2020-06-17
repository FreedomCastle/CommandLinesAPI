using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommandAPI.Controllers;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        DbContextOptionsBuilder<CommandContext> optionsBuilder;
        CommandContext dbContext;
        CommandsController controller;

        public CommandsControllerTests()
        {
            optionsBuilder = new DbContextOptionsBuilder<CommandContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestInMemDB");
            dbContext = new CommandContext(optionsBuilder.Options);

            controller = new CommandsController(dbContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var cmd in dbContext.CommandItems)
            {
                dbContext.CommandItems.Remove(cmd);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            controller = null;
        }

        //Test 1.1 Request objects when none exist - return "nothing"
        [Fact]
        public void GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
        {
            //Act
            var result = controller.GetCommandItems();

            //Assert
            Assert.Empty(result.Value);
        }
        
        [Fact]
        public void GetCommandItemsReturnsOneItemWhenDBHasOneObject()
        {
            //Arrange
            var command = new Command
            {
                HowTo = "Do Somethting", 
                Platform = "Some Platform", 
                CommandLine = "Some Command"
            };
            dbContext.CommandItems.Add(command); 
            dbContext.SaveChanges();

            //Act
            var result = controller.GetCommandItems();
            //Assert 
            Assert.Single(result.Value);
            // Or
            //Assert.Equal(1, result.Value.Count()); Then xUnit will complain
        }
        [Fact]
        public void GetCommandItemsReturnNItemsWhenDBHasNoObjects()
        {
            //Arrange
            var command = new Command
            {
                HowTo = "Do Something",
                Platform = "Some Platform",
                CommandLine = "Some Command"
            };
            var command2 = new Command
            {
                HowTo = "Do Something",
                Platform = "Some Platform",
                CommandLine = "Some Command"               
            };
            dbContext.CommandItems.Add(command);
            dbContext.CommandItems.Add(command2);
            dbContext.SaveChanges();

            //Act
            var result = controller.GetCommandItems();

            //Assert
            Assert.Equal(2, result.Value.Count());
        }
        [Fact]
        public void GetCommandItemsReturnsTheCorrectType()
        {
            //Arrange
            //Act
            var result = controller.GetCommandItems();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<Command>>>(result);
        }
        [Fact]
        public void GetCommandItemsReturnNItemsWhenDBHasNObjects()
        {
            //Arrange
            var command = new Command
            {
                HowTo = "Do Something",
                Platform = "Some Platform",
                CommandLine = "Some Command"
            };
            var command2 = new Command
            {
                HowTo = "Do Something",
                Platform = "Some Platform",
                CommandLine = "Some Command"               
            };
            dbContext.CommandItems.Add(command);
            dbContext.CommandItems.Add(command2);
            dbContext.SaveChanges();

            //Act
            var result = controller.GetCommandItems();

            //Assert
            Assert.Equal(2, result.Value.Count());
        }
    }
}