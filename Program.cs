using InvoiceCreating;
using InvoiceModeling;
using System;
using System.Text;

namespace InvoiceModeling
{
    class Program
    {
        private static InvoiceRow row;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Invoice invoice = new Invoice();
            Console.Write($"Введіть дату: ");
            invoice.DateOfInspection = DateTime.Parse(Console.ReadLine());
            Console.Write($"Введіть номер накладої: ");
            invoice.RowNumber = Console.ReadLine();
            Console.Write($"Від кого: ");
            invoice.Recipient = Console.ReadLine();
            Console.Write($"Кому: ");
            invoice.Sender = Console.ReadLine();

            Console.Write($"\nСкільки товарів буде додано: ");
            int quantityOfGoods = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantityOfGoods; i++)
            {
                InvoiceRow row = new();
                Console.WriteLine($"\nВведіть опис товару №{i + 1}: ");
                row.Description = Console.ReadLine();
                Console.WriteLine($"Введіть кількість товару №{i + 1}: ");
                row.Quantity = decimal.Parse(Console.ReadLine());
                Console.WriteLine($"Введіть ціну товару №{i + 1}: ");
                row.Price = decimal.Parse(Console.ReadLine());

                invoice[i] = row;
            }

            Console.Write($"\nКомірник: ");
            invoice.StorekeeperSurname = Console.ReadLine();
            Console.Write($"Експедитор: ");
            invoice.ForwarderSurname = Console.ReadLine();

            Console.WriteLine("____________________________________________________");
            Console.WriteLine($"\nДата: {invoice.DateOfInspection.ToShortDateString()}" +
                $"\nНакладна №{invoice.RowNumber}" +
                $"\nВід кого: {invoice.Recipient}" +
                $"\nКому: {invoice.Sender}\n");

            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10} {4,-15}\n", "№ товару", "Опис товару", "Кількість, шт", "Ціна", "Вартість");
            for (int i = 0; i < invoice.Table.Size; i++)
            {
                row = invoice[i];
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10:C} {4,-15:C}", row.SequentialNumber, row.Description, row.Quantity, row.Price, row.Amount);
            }
            Console.WriteLine($"\nВсього: {invoice.Table.Total}грн");

            Console.WriteLine($"\nКомірник: {invoice.StorekeeperSurname}" +
               $"\nЕкспедитор: {invoice.ForwarderSurname}");
        }
    }
}
