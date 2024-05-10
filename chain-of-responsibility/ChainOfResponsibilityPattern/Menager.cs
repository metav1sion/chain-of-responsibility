using chain_of_responsibility.DAL;
using chain_of_responsibility.Models;

namespace chain_of_responsibility.ChainOfResponsibilityPattern
{
    public class Menager : Employee
    {
        private readonly Context context;

        public Menager(Context context)
        {
            this.context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Zuhal Sözen";
                customerProcess.Description = "Talep edilen değer şube müdürü tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Zuhal Sözen";
                customerProcess.Description = "Talep edilen değer şube müdürü tarafından ödenemedi, bölge nüdürüne aktarıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }
    }
}
