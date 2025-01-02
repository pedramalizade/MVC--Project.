using Microsoft.IdentityModel.Tokens;
using Quiz_Maktab.APPDbContext;
using Quiz_Maktab.Entities;
using Quiz_Maktab.Interface.Repository;
using Quiz_Maktab.Interface.Service;
using Quiz_Maktab.Repository;
using Quiz_Maktab.Service;
using System;
using System.Transactions;

ICardService cardService = new CardService();
ITransactionService transactionService = new TransactionService();
Dictionary<int, DateTime> codes = new Dictionary<int, DateTime>();
IUserService userService = new UserService();
AppDbContext appDbContext = new AppDbContext();

Login();
void Login()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("**** WELLCOME ****");
        Console.WriteLine("1. Login ");
        Console.WriteLine("2. Register ");
        Console.Write("Choice an option: ");
        int Choice = int.Parse(Console.ReadLine());
        CheckOption(Choice);
    }
    void CheckOption(int Choice)
    {
        switch (Choice)
        {
            case 1:
                Console.Clear();
                Console.Write("Enter UserName: ");
                var username = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var password = Console.ReadLine();
                var user = userService.Login(username, password);
                if (user != null)
                {
                    UserMenu();
                }
                else
                {
                    Login();
                }
                break;
            case 2:
                Console.Clear();
                Console.Write("Enter UserName: ");
                var userName = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var Password = Console.ReadLine();
                Console.Write("Enter Name: ");
                var name = Console.ReadLine();

                var registerUser = new User
                {
                    Username = userName,
                    Password = Password,
                    Name = name
                };
                var isRegister = userService.Register(registerUser);
                if (registerUser != null)
                {
                    UserMenu();
                }
                else
                {
                    Login();
                }
                break;
        }
    }
}

void UserMenu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("1. Show All Cards ");
        Console.WriteLine("2. Change Card Password ");
        Console.WriteLine("3. Transaction ");
        Console.WriteLine("4. Add Card");
        Console.WriteLine("5. Remove Card");
        Console.WriteLine("6. Exit");
        Console.Write("Choice An Option: ");
        var option = int.Parse(Console.ReadLine());
        Check(option);
        Console.ReadKey();
    }

    void Check(int option)
    {
        switch (option)
        {
            case 1:
                Console.Clear();
                var userid = InMemoryDb.OnlineUser.Id;
                userService.ShowCardBalance(userid);
                Console.ReadKey();
                break;
            case 2:
                Console.Write("Enter card number: ");
                var cardNumber = Console.ReadLine();
                Console.Write("Enter old password: ");
                var password = Console.ReadLine();
                Console.Write("Enter new password: ");
                var newPassword = Console.ReadLine();
                cardService.ChangePassword(cardNumber, password, newPassword);
                break;
            case 3:
                Wellcome();
                break;
            case 4:
                var userId = InMemoryDb.OnlineUser.Id;
                Console.WriteLine("Enter Card Number: ");
                var carNumber = Console.ReadLine();
                Console.Write("Enter Passsword: ");
                var cardPassword = Console.ReadLine();
                Console.Write("Enter card Name: ");
                var cardName = Console.ReadLine();
                Console.Write("Enter a Balance: ");
                var balance = int.Parse(Console.ReadLine());
                var AddCard = new Card
                {
                    CardNumber = carNumber,
                    Password = cardPassword,
                    HolderName = cardName,
                    Balance = balance,
                    IsActive = true,
                    FailedAttempts = 0

                };
                userService.AddCard(userId, AddCard);
                break;
            case 5:
                Console.Write("Enter a card Number: ");
                var cardNumbers = Console.ReadLine();
                userService.RemoveCard(cardNumbers);
                break;
            case 6:
                Login();
                break;
            default:
                Console.WriteLine("Wrong option.");
                break;
        }
    }
}

void Wellcome()
{
    Console.Clear();
    Console.Write("Enter Your Card Number: ");
    string cardNumber = Console.ReadLine();

    Console.Write("Enter Your Password: ");
    string password = Console.ReadLine();

    string result = cardService.CheckCard(cardNumber, password);
    if (result != "Check Successful.")
    {
        Console.WriteLine(result);
        return;
    }

    bool IsCodeValid(int code)
    {
        if (codes.ContainsKey(code) && codes[code] > DateTime.Now)
        {
            return true;
        }
        if (codes.ContainsKey(code) && codes[code] < DateTime.Now)
        {
            codes.Remove(code);
            Console.WriteLine("The code Has Expired.");
            return false;
        }
        Console.WriteLine("The Entered code is wrong.");
        return false;
    }

    while (true)
    {
        Console.Clear();
        Console.WriteLine("****WELCOME****");
        Console.WriteLine("1: transaction");
        Console.WriteLine("2: view Transaction");
        Console.WriteLine("3: Exit");
        Console.Write("Please Choice an Option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Clear();
                Console.Write("Enter Amount: ");
                var amount = float.Parse(Console.ReadLine());
                Console.Write("Enter the Destination Card Number: ");
                var destinationCardNumber = Console.ReadLine();
                Console.Write("The random Code: ");
                var randomeCode = userService.GenerateRandomeCode();
                Console.WriteLine(randomeCode);
                codes[randomeCode] = DateTime.Now.AddMinutes(5);
                var holdername = cardService.GetHolderNameCard(destinationCardNumber);
                if (holdername)
                {
                    Console.WriteLine($"from: {cardNumber}");
                    Console.WriteLine($"To: {destinationCardNumber} ");
                    Console.WriteLine($"Amount: {amount}");
                    Console.WriteLine("1: continue");
                    Console.WriteLine("2: Back");
                    Console.Write("Choice an option: ");
                    var choicee = int.Parse(Console.ReadLine());
                    switch (choicee)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Enter the code: ");
                            var ccode = int.Parse(Console.ReadLine());
                            var isCodeValid = IsCodeValid(ccode);
                            if (isCodeValid)
                            {
                                var transactions = transactionService.Transfer(cardNumber, destinationCardNumber, amount);
                                Console.WriteLine(transactions);
                            }
                            else
                            {
                                Console.WriteLine($"invalid code: {isCodeValid}");
                            }
                            break;
                    }
                }

                Console.ReadKey();
                break;
            case "2":
                Console.Clear();
                var transactionList = transactionService.GetTransactions(cardNumber);
                foreach (var transaction in transactionService.GetTransactions(cardNumber))
                {
                    Console.WriteLine($"Date : {transaction.TranceactionTime}, Amount : {transaction.Amount}, Success: {transaction.IsSuccessful}");
                }
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("thanks");
                Login();
                return;
            default:
                Console.WriteLine("Wrong option.");
                break;
        }
    }
}
