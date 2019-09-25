using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Res365.Global
{   
    public class Res365Container
    {
        protected static UnityContainer MyUnityContainer;

        public Res365Container()
        {
        }

        public static UnityContainer Instance
        {
            get
            {
                if (MyUnityContainer == null)
                {
                    MyUnityContainer = new UnityContainer();
                }

                return MyUnityContainer;
            }
            set { }
        }       
    }
}
