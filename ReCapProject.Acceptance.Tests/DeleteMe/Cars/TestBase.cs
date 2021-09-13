using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bussines.Abstract;
using Bussines.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace ReCapProject.Acceptance.Tests.APIs.Cars
{
    public class TestBase
    {
        private IContainer _autofacContainer;
        protected IContainer AutofacContainer {
            get {
                if (_autofacContainer == null)
                {
                    var builder = new ContainerBuilder();

                    // Repositories
                    builder.RegisterType<CarManager>().As<ICarService>().InstancePerLifetimeScope();

                    // Register the CompanyDataRepository for property injection not constructor allowing circular references
                    builder.RegisterType<EfCarDal>().As<ICarDal>()
                           .InstancePerLifetimeScope()
                           .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

                    // Other wireups....

                    var container = builder.Build();

                    _autofacContainer = container;
                }

                return _autofacContainer;
            }
        }

        protected ICarDal EfCarDal {
            get {
                return AutofacContainer.Resolve<EfCarDal>();
            }
        }

        protected ICarService CarManager {
            get {
                return AutofacContainer.Resolve<CarManager>();
            }
        }
    }
}
