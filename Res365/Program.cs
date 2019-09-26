using CommonServiceLocator;
using Res365.BusinessLogic;
using Res365.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.ServiceLocation;

namespace Res365
{
    class Program
    {
        protected static IStringIntegerCalculator _IStringIntegerCalculator;
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            InitializeIoC();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Enter input:"); // Prompt
                    string input = Console.ReadLine(); // Get string from user

                    _IStringIntegerCalculator = Res365Container.Instance.Resolve<IStringIntegerCalculator>();

                    int result = _IStringIntegerCalculator.CalculatorString(input, upBound: 2000, allowNegative: true);

                    Console.WriteLine($"Fomural: {_IStringIntegerCalculator.Formular}");
                    Console.WriteLine($"Result: {result}");
                }
            });
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();
        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            _closing.Set();
        }

        public static void InitializeIoC()
        {
            try
            {
                IUnityContainer Container = Res365Container.Instance;
                UnityServiceLocator locator = new UnityServiceLocator(Container);
                ServiceLocator.SetLocatorProvider(() => locator);
                Container.AddNewExtension<Res365BusinessLogicExtension>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error encountered initializing IOC container. {ex.Message}");
            }
        }
    }
}
