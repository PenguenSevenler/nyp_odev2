using System;

internal class inVoice
{
    internal string number { get; set; }
    internal string description { get; set; }
    internal int quantity;
    internal int Quantity 
    {
        get { return quantity;} //checking negative value
        set 
        { 
            if(value>=0)
            {
                quantity=value;
            }
            else
            {
                Console.WriteLine("\nQuantity can't be negative!!");
            }
        }
    }
    internal decimal price;
    internal decimal Price
    {
        get { return price; } //checking negative value
        set 
        { 
            if(value>=0)
            {
                price=value;
            }
            else
            {
                Console.WriteLine("\nPrice can't be negative!!");
            }
        }
    }
    
    internal inVoice(string Number, string Description, int Quantity, decimal Price) //constructor
    {
    	this.number= Number;
        this.description= Description;
        this.Quantity= Quantity;
        this.Price= Price;
    }
    
    internal decimal getInVoiceAmount(int Quantity, decimal Price)//calculating invoice amount
    {
    	return Quantity*Price;
    }
    
    internal void writeInVoiceAmount(inVoice item1,inVoice item2,inVoice item3,inVoice item4)//writing invoice amount
    {
        Console.WriteLine ($"\nInvoice amount of item number {item1.number}: {item1.getInVoiceAmount(item1.quantity,item1.price)}$");
        Console.WriteLine ($"\nInvoice amount of item number {item2.number}: {item2.getInVoiceAmount(item2.quantity,item2.price)}$");
        Console.WriteLine ($"\nInvoice amount of item number {item3.number}: {item3.getInVoiceAmount(item3.quantity,item3.price)}$");
        Console.WriteLine ($"\nInvoice amount of item number {item4.number}: {item4.getInVoiceAmount(item4.quantity,item4.price)}$");
    }
    
    internal void writeItem(inVoice item)//writing items infos
    {
    	Console.WriteLine ($"\nITEM INFO\nItem number:{item.number}\t\t\t\tItem description:{item.description}\nPurchased item quantity:{item.Quantity}\t\tItem price:{item.Price}$");
    }
    
    internal void changeQuantity_Price(inVoice item1,inVoice item2,inVoice item3,inVoice item4)//asking user to make a change 
    {
        string checkItem;
        Console.WriteLine("\nEnter item number you want to make change:");
        checkItem= Convert.ToString(Console.ReadLine());
        Console.WriteLine("\nEnter new purchased quantity and new price:");
        if(checkItem==item1.number)
        {
            item1.Quantity=Convert.ToInt32(Console.ReadLine());
            item1.Price=Convert.ToDecimal(Console.ReadLine());
        }
        else if(checkItem==item2.number)
        {
            item2.Quantity=Convert.ToInt32(Console.ReadLine());
            item2.Price=Convert.ToDecimal(Console.ReadLine());
        }
        else if(checkItem==item3.number)
        {
            item3.Quantity=Convert.ToInt32(Console.ReadLine());
            item3.Price=Convert.ToDecimal(Console.ReadLine());
        }
        else if(checkItem==item4.number)
        {
            item4.Quantity=Convert.ToInt32(Console.ReadLine());
            item4.Price=Convert.ToDecimal(Console.ReadLine());
        }
    }
}

public class InvoiceTest
{
    public static void Main(string[] args)
    {
    	inVoice item1 = new inVoice("01","Mouse",120,390); //creats items
        inVoice item2 = new inVoice("02","USB-A cable",43,59);
        inVoice item3 = new inVoice("04","Graphics Card",560,830);
        inVoice item4 = new inVoice("12","Laptop",1322,3190);
        
        item1.writeItem(item1); //writes items initial infos
        item2.writeItem(item2);
        item3.writeItem(item3);
        item4.writeItem(item4);
        
        item1.changeQuantity_Price(item1,item2,item3,item4);//changes quantity or price
        
        item1.writeItem(item1); //writes items new infos
        item2.writeItem(item2);
        item3.writeItem(item3);
        item4.writeItem(item4);
        
        item1.writeInVoiceAmount(item1,item2,item3,item4);//calculates and writes invoice amount for each item 
    }
}
