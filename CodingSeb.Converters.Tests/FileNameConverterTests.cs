using NUnit.Framework;
using Shouldly;
using System;
using System.IO;
using System.Reflection;

namespace CodingSeb.Converters.Tests
{
    [TestFixture]
    public class FileNameConverterTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            /* Preparing test start */
            //Assembly assembly = Assembly.GetCallingAssembly();

            ////AppDomainManager manager = new AppDomainManager();
            //FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            //entryAssemblyfield.SetValue(manager, assembly);

            //AppDomain domain = AppDomain.CurrentDomain;
            //FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            //domainManagerField.SetValue(domain, manager);
            /* Preparing test end */

        }

        [Test]
        public void AbsolutePath()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.AbsolutePath,
                Directory = @"C:\MyDirectory",
            };

            converter.Convert("Test", null, null, null).ShouldBe(@"C:\MyDirectory\Test.png");
        }

        [Test]
        public void AbsolutePathWithPrefix()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.AbsolutePath,
                Directory = @"C:\MyDirectory",
                FileNamePrefix = "prefix"
            };

            converter.Convert("FileName", null, null, null).ShouldBe(@"C:\MyDirectory\prefixFileName.png");
        }

        [Test]
        public void AbsolutePathWithCustomExtension()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.AbsolutePath,
                Directory = @"C:\MyDirectory",
                Extension = ".txt"
            };

            converter.Convert("Test", null, null, null).ShouldBe(@"C:\MyDirectory\Test.txt");
        }

        [Test]
        public void ExecutingAssembly()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.ExecutingAssemblyDirectory,
            };

            converter.Convert("Test", null, null, null).ShouldBe(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Test.png"));
        }

        [Test]
        public void EntryAssembly()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.EntryAssemblyDirectory,
            };

            converter.Convert("Test", null, null, null).ShouldBe(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Test.png"));
        }

        [Test]
        public void WindowsDirectory()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.Windows,
                Directory = "SubDirectory",
            };

            converter.Convert("Test", null, null, null)
                .ToString()
                .ToLower()
                .ShouldBe(@"C:\Windows\SubDirectory\Test.png".ToLower());
        }

        [Test]
        public void WindowsDirectoryPrefix()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.Windows,
                Directory = "SubDirectory",
                FileNamePrefix = "prefix"
            };

            converter.Convert("FileName", null, null, null)
                .ToString()
                .ToLower()
                .ShouldBe(@"C:\Windows\SubDirectory\prefixFileName.png".ToLower());
        }

        [Test]
        public void WindowsDirectoryWithExtension()
        {
            FileNameConverter converter = new FileNameConverter()
            {
                DirectoryPathFrom = DirectoryPath.Windows,
                Extension = ".txt"
            };

            converter.Convert("Test", null, null, null)
                .ToString()
                .ToLower()
                .ShouldBe(@"C:\Windows\Test.txt".ToLower());
        }
    }
}
