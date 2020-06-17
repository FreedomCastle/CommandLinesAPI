using System;
using Xunit;
using CommandAPI.Tests;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;
        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }
        
        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Act
            testCommand.HowTo = "Execute Unit Tests";
            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }
        [Fact]
        public void CanChangePlatform()
        {
            //Act
            testCommand.Platform = "rPi 4B Kodi";
            //Assert
            Assert.Equal("rPi 4B Kodi", testCommand.Platform);
        }
        [Fact]
        public void CanChangeCommandLine()
        {
            //Act
            testCommand.CommandLine = "install raspbian";
            //Assert
            Assert.Equal("install raspbian", testCommand.CommandLine);
        }

    }
}