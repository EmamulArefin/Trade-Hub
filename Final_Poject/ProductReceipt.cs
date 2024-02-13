using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Poject
{
    public class ProductReceipt
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }


        public String TotalPrice { get { return string.Format("(0)$", ProductPrice * ProductQuantity); } }

    }
}
