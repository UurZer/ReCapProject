using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Tynamix.ObjectFiller;

namespace ReCapProject.xUnit.Tests.Business.ServiceTests
{
    public partial class CarManagerTests
    {

        private int CreateRandomInteger()=>
                new IntRange(min:11, max:12).GetValue();

        private Car CreateRandomCar() =>
                new Filler<Car>().Create();
    }
}
