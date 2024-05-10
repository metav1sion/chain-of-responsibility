using chain_of_responsibility.DAL;
using chain_of_responsibility.Models;

namespace chain_of_responsibility.ChainOfResponsibilityPattern
{
    public class Treasurer : Employee
    {
        private readonly Context context;

        public Treasurer(Context context)
        {
            this.context = context;
        }

        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();

                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Metehan Sözen";
                customerProcess.Description = "Talep edilen tutar veznedar tarafından ödendi";

                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Metehan Sözen";
                customerProcess.Description = "Talep edilen tutar karşılanamadı bir üst kişiye yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(customerViewModel);
            }
        }
    }
}
