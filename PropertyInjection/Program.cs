using System;
using Unity;
using Unity.Attributes;

namespace PropertyInjection
{
    public interface IEmployee
    {
    }
    public class Employee : IEmployee
    {
        private ICompany _Company;
        [Dependency]
        public ICompany Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public void DisplaySalary()
        {
            _Company.ShowSalary();
        }
    }

    public interface ICompany
    {
        void ShowSalary();
    }
    public class Company : ICompany
    {
        public void ShowSalary()
        {
            Console.WriteLine("Your salary is 40 K");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<ICompany, Company>();

            Employee emp = unitycontainer.Resolve<Employee>();
            emp.DisplaySalary();


            Console.ReadLine();
        }
    }
}
