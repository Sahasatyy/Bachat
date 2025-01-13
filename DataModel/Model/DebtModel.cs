using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model
{
    public class DebtModel
    {

        public Guid DebtId { get; set; }

        public string DebtAmount { get; set; }

        public string DebtNotes { get; set; }

        public DateTime DebtDueDate { get; set; }

        public DateTime DebtStartDate { get; set; }

        public string DebtSource { get; set; }

        public bool IsCleared { get; set; } = false;



    }
}
