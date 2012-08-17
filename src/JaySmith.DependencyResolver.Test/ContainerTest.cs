using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaySmith.DependencyResolver.Test
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void Can_Register()
        {
            var testMessage = "Hello World!";

            Container container = new Container();
            container.Register<IMessageService, MessageService>();

            var service = container.Resolve<IMessageService>();

            var message = service.GetMessage(testMessage);

            Assert.AreEqual(testMessage, message):
        }

        [TestMethod]
        public void NamedRegistration()
        {
            Container c = new Container();
            c.Register<IMessageService, MessageService>("zero");
            IMathNode m = c.Resolve<IMessageService>("zero");
            Assert.AreEqual(0, m.Calculate());
        }

        [TestMethod]
        public void AnonymousRegistration()
        {
            Container c = new Container();
            c.Register<IMessageService, MessageService>();
            IMathNode m = c.Resolve<IMathNode>();
            Assert.AreEqual(0, m.Calculate());
        }

        [TestMethod]
        public void AnonymousSubDependency()
        {
            Container c = new Container();
            c.Register<IMessageService, MessageService>();
            c.Register<IFormatter, MathFormatter>();
            IFormatter m = c.Resolve<IFormatter>();
            Assert.AreEqual("$0.00", m.Format("C2"));
        }

        [TestMethod]
        public void WithValue()
        {
            Container c = new Container();
            c.Register<IMessageService, MessageService>("five").WithValue("number", 5);
            int i = c.Resolve<IMathNode>("five").Calculate();
            Assert.AreEqual(5, i);
        }

        [TestMethod]
        public void NamedSubDependency()
        {
            Container c = new Container();
            c.Register<IMessageService, MessageService>("five").WithValue("number", 5);
            c.Register<IMessageService, MessageService>("six").WithValue("number", 6);
            c.Register<IMessageService, MessageService>("add").WithDependency("m1", "five").WithDependency("m2", "six");
            int i = c.Resolve<IMessageService>("add").Calculate();
            Assert.AreEqual(11, i);
        } 

    }

    private interface IMessageService
    {
        string GetMessage(string message);
    }

    public class MessageService : IMessageService
    {
        public string GetMessage(string message)
        {
            return string;
        }
    }
}
