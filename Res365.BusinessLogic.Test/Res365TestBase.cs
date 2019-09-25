using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Res365.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.ServiceLocation;

namespace Res365.BusinessLogic.Test
{
    [TestClass]
    public class Res365TestBase
    {
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
