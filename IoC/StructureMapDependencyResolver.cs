using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace IoC
{
    public class StructureMapDependencyResolver : StructureMapScope, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this.container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }
    }
}
