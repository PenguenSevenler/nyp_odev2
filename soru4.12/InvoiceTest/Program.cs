using System;
using iTextSharp.text;
using iTextSharp.text.pdf;

internal class Invoice    // we created a class for Invoice elements
{
    internal string PartNumber { get; set; }
    internal string PartDescription { get; set; }
    internal decimal PricePerItem { get; set; }
    internal int Quantity { get; set; }

    internal Invoice(string PartNumber, string PartDescription, double PricePerItem, int Quantity)
    {

        this.PartNumber = PartNumber;
        this.PartDescription = PartDescription;
        this.PricePerItem = Convert.ToDecimal(PricePerItem);
        this.Quantity = Quantity;
    }

    protected internal decimal TotalPriceofItem() // we created a method to calculate the price for each item sold
    {
        return this.PricePerItem * (decimal)this.Quantity;
    }

    protected internal void PrintItemInfo() // we created a method to show the item informations
    {
        Console.WriteLine(this.PartNumber + " - " + this.PartDescription + " - " + this.PricePerItem + " USD");
    }

    public override string ToString()
    {
        return $"{this.PartNumber} - {this.PartDescription} - {this.Quantity} pcs * {this.PricePerItem} USD" +
                 $"= {this.TotalPriceofItem()} USD";
    }
}


public class Program
{
    public static void Main()
    {
        Invoice[] products = new Invoice[10];
        products[0] = new Invoice("P001", "Aluminium Carabiner", 0.40, 0);
        products[1] = new Invoice("P002", "Stainless Steel Corner Bracket", 0.12, 0);
        products[2] = new Invoice("P003", "Work Gloves", 0.45, 0);
        products[3] = new Invoice("P004", "Plastic Chain", 0.20, 0);
        products[4] = new Invoice("P005", "Stainless Steel Spring", 0.30, 0);
        products[5] = new Invoice("P006", "PTFE Seal Thread Tape", 0.16, 0);
        products[6] = new Invoice("P007", "Silver Door Handle", 0.21, 0);
        products[7] = new Invoice("P008", "Mini Tool Kit", 3.25, 0);
        products[8] = new Invoice("P009", "Middle Tool Kit", 21.40, 0);
        products[9] = new Invoice("P010", "Professional Tool Kit", 149.99, 0);

        // ONCELIKLE URUN LISTEMIZI BASALIM
        Console.WriteLine("- - - OUR PRODUCT LIST - - -");
        Console.WriteLine("\n PN - NAME - PRICE");

        for (int i = 0; i < 10; i++)
        {
            products[i].PrintItemInfo();
        }
        Console.WriteLine("\n");

        // We create a new file name for invoice PDF
        string invoiceID = "invoice" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string invoicePath = invoiceID + ".pdf";

        int didBuy = 0;

        while (true)
        {
            Console.Write("Do you want to buy anything ? (y/n) : ");
            string choice = Console.ReadLine();

            if (choice == "y" || choice == "Y")
            {
                
                Console.Write("What do you want to buy? Only use PN : ");
                string PN = Console.ReadLine();

                switch (PN)  // PN PRODUCT NUMBER HANGI URUNU SECECEKSİN...
                {
                    case "P001":
                        Console.Write("How many ALuminium Carabiners do you want? : ");
                        products[0].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[0].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P002":
                        Console.Write("How many Stainless Steel Corner Brackets do you want? : ");
                        products[1].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[1].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P003":
                        Console.Write("How many Work Gloves do you want? : ");
                        products[2].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[2].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P004":
                        Console.Write("How many Plastic Chains do you want? : ");
                        products[3].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[3].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P005":
                        Console.Write("How many Stainless Steel Springs do you want? : ");
                        products[4].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[4].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P006":
                        Console.Write("How many PTFE Seal Thread Tape do you want? : ");
                        products[5].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[5].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P007":
                        Console.Write("How many Silver Door Handles do you want? : ");
                        products[6].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[6].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P008":
                        Console.Write("How many Mini Tool Kits do you want? : ");
                        products[7].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[7].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P009":
                        Console.Write("How many Middle Tool Kits do you want? : ");
                        products[8].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[8].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P010":
                        Console.Write("How many Professional Tool Kits do you want? : ");
                        products[9].Quantity += Convert.ToInt32(Console.ReadLine());
                        if (products[9].Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;
                    default:
                        Console.WriteLine("Sorry, could not understand.");
                        break;
                }



                if (didBuy == 1) // EGER SATIS YAPILDIYSA FATURA OLUSTURULACAK
                { 
                    iTextSharp.text.Document theReport = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(theReport, new FileStream(invoicePath, FileMode.Create));
                    theReport.AddAuthor("Group 2");
                    theReport.AddCreationDate();
                    theReport.AddCreator("Group 2");
                    theReport.AddSubject("Group 2 - Homework 2");

                    if (theReport.IsOpen() == false)
                        theReport.Open();


                    iTextSharp.text.Paragraph headParagraph = new Paragraph("Hardware Store");

                    headParagraph.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
               
                    theReport.Add(new Paragraph(headParagraph));
                    theReport.Add(new Paragraph(" "));

                    theReport.Add(new Paragraph());


                    // SADECE SATILAN URUNLER FATURADA OLACAK
                    decimal total_price = 0;
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i].Quantity > 0)
                        {
                            theReport.Add(new Paragraph(products[i].ToString()));
                            total_price += products[i].TotalPriceofItem();
                        }
                    }
                    
                    iTextSharp.text.Paragraph theTotaL = new Paragraph("Total Price : " + total_price.ToString() + " USD");
                    theTotaL.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
                    theReport.Add(new Paragraph(" "));
                    theReport.Add(new Paragraph(" "));
                    theReport.Add(new Paragraph(theTotaL));
                    
                    theReport.Close();
                }

            }
            else
            {
                Console.WriteLine("\nSee You Again");

                if (didBuy == 1)
                    Console.WriteLine("Your invoice is here -> " + invoicePath);


                break;
            }
        }

    }
}