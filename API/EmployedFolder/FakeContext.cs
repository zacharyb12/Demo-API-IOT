
namespace API.EmployedFolder
{
    public class FakeContext : IContext
    {
        private List<Employee> _employees;

        public FakeContext()
        {
            _employees = new List<Employee>()
            {
                new Employee { Id = 1, Firstname = "John", Lastname = "Doe" },
                new Employee { Id = 2, Firstname = "Jane", Lastname = "Smith" },
                new Employee { Id = 3, Firstname = "Alice", Lastname = "Johnson" }
            };
        }


        public List<Employee> Employees
        {
            get => this._employees;
            set => this._employees = value;
        }
    }
}
