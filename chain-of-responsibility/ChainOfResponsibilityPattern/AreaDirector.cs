using chain_of_responsibility.DAL;
using chain_of_responsibility.Models;

namespace chain_of_responsibility.ChainOfResponsibilityPattern
{
    public class AreaDirector : Employee
    {
        private readonly Context context;

        public AreaDirector(Context context)
        {
            this.context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 360000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Süleyman Sözen";
                customerProcess.Description = "Talep edilen değer Bölge müdürü tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Süleyman Sözen";
                customerProcess.Description = "Talep edilen değer şube müdürü tarafından ödenemedi, işlem geçersiz";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }
    }
}
