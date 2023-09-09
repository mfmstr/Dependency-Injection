using System;

namespace Injection
{
    internal class Program
    {

        public interface IService
        {
            void Serve();
        }

        public class Service1 : IService
        {
            public void Serve() { Console.WriteLine("Service1 Called"); }
        }

        public class Service2 : IService
        {
            public void Serve()
            {
                Console.WriteLine("Service2 Called");
                Console.WriteLine("Service2 Called");
                Console.WriteLine("Service2 Called");
                Console.WriteLine("Service2 Called");

            }
        }

        public class Client
        {
            private IService _service;
            public Client(IService service)
            {
                _service = service;
            }
            public void ServeMethod() { _service.Serve(); }
        }

        static void Main(string[] args)
        {

            Service1 s1 = new Service1();
            Service2 s2 = new Service2();

            Client c1 = new Client(s1);
            c1 = new Client(s1);
            c1.ServeMethod();


            Client c2 = new Client(s2);
            c1 = new Client(s2);
            c1.ServeMethod();

        }
    }
}
