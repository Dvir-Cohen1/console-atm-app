using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
     
    //Constructor
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // getters
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    // setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        void printObtions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1 Deposite");
            Console.WriteLine("2 Withdraw");
            Console.WriteLine("3 Show balance");
            Console.WriteLine("4 Exit");
        }

        void deposite(cardHolder currentUser)
        {
            Console.WriteLine("How mush $$ would you like to deposite?");
            double deposite = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposite);
            Console.WriteLine("Thank you for your $$. Your new balance is:" + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How mush $$ would you like to withdraw:");
            double withdrawal = Double.Parse(Console.ReadLine());

            // Check if the user has enough money

            if (currentUser.getBalance()<withdrawal)
            {
                Console.WriteLine("insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance:" + currentUser.getBalance());
        }


        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123135564545442", 123, "John", "Griffin", 150.32));
        cardHolders.Add(new cardHolder("987622434937816", 123, "Ashley", "Tahthem", 74310.74));
        cardHolders.Add(new cardHolder("746109471084654", 123, "Frida", "Jones", 15450.46));
        cardHolders.Add(new cardHolder("987622465542781", 123, "Jane", "Harding", 1801.82));
        cardHolders.Add(new cardHolder("234798734961956", 123, "Dawn", "Smith", 153.26));


        //Promet user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please write your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;


        while (true)
        {
            try 
            {
                debitCardNum = Console.ReadLine();
                //checked against db
                currentUser = cardHolders.FirstOrDefault(a=> a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognize please try again!"); }
            }
            catch{Console.WriteLine("Card not recognize please try again!"); }
        }


        Console.WriteLine("Please eneter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //checked against db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin please try again!"); }
            }
            catch { Console.WriteLine("Incorrect pin please try again!"); }
        }


        Console.WriteLine("Welcome" + currentUser.getFirstName() + " ):");
        int option = 0;
        do
        {
            printObtions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch{}
            if(option == 1) { deposite(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you have a nice day!");
    }






}

