using chain_of_responsibility.DAL;
using chain_of_responsibility.Models;

namespace chain_of_responsibility.ChainOfResponsibilityPattern
{
    public class ManagerAssistant : Employee
    {
        private readonly Context context;

        public ManagerAssistant(Context context)
        {
            this.context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Yiğit Emre Sözen";
                customerProcess.Description = "Talep edilen değer şube müdürü yardımcısı tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Yiğit Emre Sözen";
                customerProcess.Description = "Talep edilen değer şube müdürü yardımcısı tarafından ödenemedi, şube nüdürüne aktarıldı.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }
    }
}
