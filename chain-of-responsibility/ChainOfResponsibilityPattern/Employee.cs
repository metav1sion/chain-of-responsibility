using chain_of_responsibility.Models;

namespace chain_of_responsibility.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover; //o sınıftan ve o sınıfı miras alan sınıflardan erişilebiliyor. Bu bir field ve metotun içinde tanımlandığında değişken oluyor sadece.

        public void SetNextApprover(Employee employee)
        {
            this.NextApprover = employee;
        }

        public abstract void ProcessRequest(CustomerViewModel customerViewModel);


    }
}
