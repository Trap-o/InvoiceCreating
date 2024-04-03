using System;

using InvoiceCreating;

namespace InvoiceModeling
{
    class Invoice
    {
        public Invoice() { }
        public Invoice(DateTime dateOfInspection, string rowNumber, string recipient, string sender, string storekeeperSurname, string forwarderSurname) =>
            (DateOfInspection, RowNumber, Recipient, Sender, StorekeeperSurname, ForwarderSurname) =
            (dateOfInspection, rowNumber, recipient, sender, storekeeperSurname, forwarderSurname);

        public DateTime DateOfInspection { get; set; }
        public string? RowNumber { get; set; }
        public string? Recipient { get; set; }
        public string? Sender { get; set; }

        public Table Table { get; } = new Table();

        public InvoiceRow this[int index] { get => Table[index]; set => Table[index] = value; }

        public decimal Total => Table.Total;
        public string? StorekeeperSurname { get; set; }
        public string? ForwarderSurname { get; set; }
    }
}