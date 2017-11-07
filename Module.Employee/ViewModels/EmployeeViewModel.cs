using Common;
using Module.Employee.Models;


namespace Module.Employee.ViewModels
{
    public class EmployeeEditorViewModel : BaseViewModel
    {
        private EmployeeModel _model;


        public EmployeeEditorViewModel()
        {
            Model = new EmployeeModel()
            { Name = "Paul", Company = "cellent"};
        }

        public EmployeeModel Model
        {
            get { return _model; }

            set
            {
                _model = value;
                NotifyPropertyChanged(nameof(Model));
            }
        }
    }
}
