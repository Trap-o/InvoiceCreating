using System;

namespace InvoiceCreating
{
    class InvoiceRow
    {
        public InvoiceRow() { }

        public InvoiceRow(string description, decimal quantity, decimal price) =>
           (Description, Quantity, Price) = (description, quantity, price);

        public int SequentialNumber { get; set; } = 0;
        public string? Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount => Quantity * Price;
    }
}
