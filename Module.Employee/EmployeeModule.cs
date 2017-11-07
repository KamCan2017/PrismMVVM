using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Module.Employee.ViewModels;
using Module.Employee.Views;
using Prism.Modularity;

namespace Module.Employee
{
    public class EmployeeModule : IModule
    {
        private readonly IUnityContainer _container;

        public EmployeeModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<object, EmployeeEditor>("EmployeeEditor");

            _container.RegisterType<EmployeeEditorViewModel>(
                 new Interceptor<VirtualMethodInterceptor>()
                );
        }
    }
}
