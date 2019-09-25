using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace Res365.BusinessLogic
{
    public class Res365BusinessLogicExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {            
            if (!this.Container.IsRegistered<IStringIntegerParser>())
                this.Container.RegisterType<IStringIntegerParser, StringIntegerParser>();

            if (!this.Container.IsRegistered<StringIntegerCalculator>())
                this.Container.RegisterType<IStringIntegerCalculator, StringIntegerCalculator>();
        }
    }
}
