using System;

namespace InvoiceCreating
{
    class Table
    {
        InvoiceRow[] rows = new InvoiceRow[0];

        public InvoiceRow this[int index]
        {
            get => rows[index];
            set
            {
                bool arrayNeedsToBeIncreased = rows.Length == index,
                    tryingModifyExistingItem = index < rows.Length && index >= 0;

                if (arrayNeedsToBeIncreased)
                    AddRow(value);
                else if (tryingModifyExistingItem)
                {
                    rows[index] = value;
                    rows[index].SequentialNumber = index;
                }
                else
                    rows[index] = value;
            }
        }

        public int Size => rows.Length;
        public decimal Total { get; private set; }

        public void AddRow(InvoiceRow row)
        {
            Array.Resize(ref rows, rows.Length + 1);
            rows[rows.Length - 1] = row;
            row.SequentialNumber = rows.Length;
            Total += row.Amount;
        }

        public InvoiceRow GetRow(int index) => rows[index];
    }
}
