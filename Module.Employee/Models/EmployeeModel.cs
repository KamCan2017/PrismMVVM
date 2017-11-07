using Common;

namespace Module.Employee.Models
{
    public class EmployeeModel: BasePropertyChanged
    {
        private string _name;
        private string _company;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                NotifyPropertyChanged(nameof(Company));
            }
        }
    }
}
