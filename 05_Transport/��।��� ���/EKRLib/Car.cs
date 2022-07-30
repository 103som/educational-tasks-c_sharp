using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class Car : Transport
    {
        public Car(string Model, uint Power) : base(Model, Power) { }

        public override string StartEngine() => $"{this.Model}: Vroom";

        public override string ToString() => ($"Car. {base.ToString()}");
    }
}
