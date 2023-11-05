﻿using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Reflection;
using System.Globalization;

public class Invoice    // we created a class for Invoice elements
{
    public string PartNumber { get; set; }
    public string PartDescription { get; set; }
    public double PricePerItem { get; set; }
    public double Quantity { get; set; }

    public Invoice(string PartNumber, string PartDescription, double PricePerItem, int Quantity)
    {

        this.PartNumber = PartNumber;
        this.PartDescription = PartDescription;
        this.PricePerItem = PricePerItem;
        this.Quantity = Quantity;
    }

    public double PriceOfTotalItem() // we created a method to calculate the price for each item sold
    {
        return this.PricePerItem * this.Quantity;
    }

    public void ItemShow() // we created a method to show the item informations
    {
        Console.WriteLine("" + this.PartNumber + " - " + this.PartDescription + " - " + this.PricePerItem + " USD");
    }


    public string TotalPriceShow() // we created a method to
                                   // return item informations , quantity and total price of each items sold.
                                   // we can use these to create a database or txt or pdf file.
                                   // or we will just write these to console at the end of program
    {
        return ("" + this.PartNumber + "  -  " + this.PricePerItem + " USD  -  " + this.Quantity + " pcs" + "  -  " + this.PartDescription + " = " + Math.Round(this.PriceOfTotalItem(), 4) + " USD");
    }


}


public class Program
{
    public static void Main()
    {
        Invoice product001 = new Invoice("P001", "Aluminium Carabiner", 0.40, 0);
        Invoice product002 = new Invoice("P002", "Stainless Steel Corner Bracket", 0.12, 0);
        Invoice product003 = new Invoice("P003", "Work Gloves", 0.45, 0);
        Invoice product004 = new Invoice("P004", "Plastic Chain", 0.20, 0);
        Invoice product005 = new Invoice("P005", "Stainless Steel Spring", 0.30, 0);
        Invoice product006 = new Invoice("P006", "PTFE Seal Thread Tape", 0.16, 0);
        Invoice product007 = new Invoice("P007", "Silver Door Handle", 0.21, 0);
        Invoice product008 = new Invoice("P008", "Mini Tool Kit", 3.25, 0);
        Invoice product009 = new Invoice("P009", "Middle Tool Kit", 21.40, 0);
        Invoice product010 = new Invoice("P010", "Professional Tool Kit", 149.99, 0);

        Console.WriteLine("- - - OUR PRODUCT LIST - - -\n");
        Console.WriteLine("\n PN - NAME - PRICE");

        // ONCELIKLE URUN LISTEMIZI BASALIM


        product001.ItemShow();
        product002.ItemShow();
        product003.ItemShow();
        product004.ItemShow();
        product005.ItemShow();
        product006.ItemShow();
        product007.ItemShow();
        product008.ItemShow();
        product009.ItemShow();
        product010.ItemShow();

        Console.WriteLine("\n");

        // we created a string to create a new file name.


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
                        product001.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product001.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P002":
                        Console.Write("How many Stainless Steel Corner Brackets do you want? : ");
                        product002.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product002.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P003":
                        Console.Write("How many Work Gloves do you want? : ");
                        product003.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product003.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P004":
                        Console.Write("How many Plastic Chains do you want? : ");
                        product004.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product004.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P005":
                        Console.Write("How many Stainless Steel Springs do you want? : ");
                        product005.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product005.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P006":
                        Console.Write("How many PTFE Seal Thread Tape do you want? : ");
                        product006.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product006.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P007":
                        Console.Write("How many Silver Door Handles do you want? : ");
                        product007.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product007.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P008":
                        Console.Write("How many Mini Tool Kits do you want? : ");
                        product008.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product008.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P009":
                        Console.Write("How many Middle Tool Kits do you want? : ");
                        product009.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product009.Quantity > 0)
                        {
                            didBuy = 1;

                        }
                        break;

                    case "P010":
                        Console.Write("How many Professional Tool Kits do you want? : ");
                        product010.Quantity += Convert.ToInt32(Console.ReadLine());
                        if (product010.Quantity > 0)
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


                    iTextSharp.text.Paragraph headParagraph = new Paragraph("Penguin Lovers Hardware");

                    headParagraph.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
               
                    theReport.Add(new Paragraph(headParagraph));
                    theReport.Add(new Paragraph(" "));

                    theReport.Add(new Paragraph());



                    // SADECE SATILAN URUNLER FATURADA OLACAK


                    if (product001.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product001.TotalPriceShow()));
                    }

                    if (product002.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product002.TotalPriceShow()));
                    }

                    if (product003.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product003.TotalPriceShow()));
                    }

                    if (product004.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product004.TotalPriceShow()));
                    }

                    if (product005.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product005.TotalPriceShow()));
                    }

                    if (product006.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product006.TotalPriceShow()));
                    }

                    if (product007.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product007.TotalPriceShow()));
                    }
                    
                    if (product008.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product008.TotalPriceShow()));
                    }

                    if (product009.Quantity > 0)
                    {
                        theReport.Add(new Paragraph(product009.TotalPriceShow()));
                    }

                    if (product010.Quantity > 0) 
                    {
                        theReport.Add(new Paragraph(product010.TotalPriceShow()));
                    }




             double InvoiceTotal = product001.PriceOfTotalItem();
                    InvoiceTotal += product002.PriceOfTotalItem();
                    InvoiceTotal += product003.PriceOfTotalItem();
                    InvoiceTotal += product004.PriceOfTotalItem();
                    InvoiceTotal += product005.PriceOfTotalItem();
                    InvoiceTotal += product006.PriceOfTotalItem();
                    InvoiceTotal += product007.PriceOfTotalItem();
                    InvoiceTotal += product008.PriceOfTotalItem();
                    InvoiceTotal += product009.PriceOfTotalItem();
                    InvoiceTotal += product010.PriceOfTotalItem();

                    InvoiceTotal = Math.Round(InvoiceTotal, 6);

                    iTextSharp.text.Paragraph theTotaL = new Paragraph("Total Price : " + InvoiceTotal.ToString() + " USD");
                    theTotaL.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
                    theReport.Add(new Paragraph(" "));
                    theReport.Add(new Paragraph(" "));
                    theReport.Add(new Paragraph(theTotaL));
                    



                    theReport.Close();                

                }

            }
            else if (choose == "no" || choose == "nO" || choose == "No" || choose == "NO")
            {

                Console.WriteLine("\nSee You Again :)");

                if (didBuy == 1)
                    Console.WriteLine("Your invoice is here -> " + invoicePath);


                break;
            }
            else
                Console.WriteLine("\nYou wrote wrong your answer, please try again...");
        }

    }
}