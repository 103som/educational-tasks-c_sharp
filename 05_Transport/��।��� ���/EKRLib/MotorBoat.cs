using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class MotorBoat : Transport
    {
        public MotorBoat(string Model, uint Power) : base(Model, Power) { }

        public override string StartEngine() => $"{this.Model}: Brrrbrr";

        public override string ToString() => ($"MotorBoat. {base.ToString()}");
    }
}
