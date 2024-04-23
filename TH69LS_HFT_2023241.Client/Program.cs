using NuGet.Packaging.Signing;
using System;
using System.Linq;
using TH69LS_HFT_2023241.Logic;
using TH69LS_HFT_2023241.Models;
using TH69LS_HFT_2023241.Repository;
using TH69LS_HFT_2023241.Repository.Repository;
using ConsoleTools;

namespace TH69LS_HFT_2023241.Client
{
    internal class Program
    {
        static CatLogic catlogic;
        static Cat_SitterLogic cat_SitterLogic;
        static Cat_OwnerLogic cat_OwnerLogic;
        static CatDbContext ctx;

        static ConsoleMenu cownermenu;
        static ConsoleMenu catmenu;
        static ConsoleMenu catsittermenu;
        static ConsoleMenu menu;
        static void Main(string[] args)
        {
            ctx = new CatDbContext();

            IRepository<Cat> carR = new CatRepository(ctx);
            IRepository<Cat_Sitter> cat_sittterR = new Cat_SitterRepository(ctx);
            IRepository<Cat_Owner> cat_ownerR = new Cat_OwnerRepository(ctx);

            catlogic = new CatLogic(carR);
            cat_SitterLogic = new Cat_SitterLogic(cat_sittterR);
            cat_OwnerLogic = new Cat_OwnerLogic(cat_ownerR);
            ;
            static void List(string entity)
            {
                if (entity == "Cat_Owner")
                {
                    var helper = cat_OwnerLogic.ReadAll();
                    foreach (var owner in helper)
                    {
                        Console.WriteLine(owner.OID + "\t" + owner.Owner_Name);
                    }
                }
                if (entity == "Cat")
                {
                    var helper = catlogic.ReadAll();
                    foreach (var cat in helper)
                    {
                        Console.WriteLine(cat.CID + "\t" + cat.Cat_Name);
                    }
                }
                if (entity == "Cat_Sitter")
                {
                    var helper = cat_SitterLogic.ReadAll();
                    foreach (var sitter in helper)
                    {
                        Console.WriteLine(sitter.SID + "\t" + sitter.Sitter_Name);
                    }
                }
                Console.ReadLine();
            }
            static void Delete(string entity)
            {
                if (entity == "Cat_Owner")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat Owner that you want to delete");
                    int ID = int.Parse(Console.ReadLine());
                    try
                    {
                        cat_OwnerLogic.Delete(ID);
                        Console.WriteLine($"Item with {ID} is deleted from the database");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (entity == "Cat")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat that you want to delete");
                    int ID = int.Parse(Console.ReadLine());
                    try
                    {
                        catlogic.Delete(ID);
                        Console.WriteLine($"Item with {ID} is deleted from the database");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (entity == "Cat_Sitter")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat Sitter that you want to delete");
                    int ID = int.Parse(Console.ReadLine());
                    try
                    {
                        cat_SitterLogic.Delete(ID);
                        Console.WriteLine($"Item with {ID}  is deleted from the database");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.ReadLine();
            }
            static void Read(string entity)
            {
                if (entity == "Ca_Owner")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat Owner that you want to display");
                    int ID = int.Parse(Console.ReadLine());
                    try
                    {
                        var helper = cat_OwnerLogic.Read(ID);
                        Console.WriteLine($"ID: {helper.OID}" + $"\nName: {helper.Owner_Name}" + $"\nAge: {helper.Owner_Age}" +$"\nIs_Married:{helper.Is_Married} "+ $"\nNationality: {helper.Nationality}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (entity == "Cat")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat that you want to display");
                    int id = int.Parse(Console.ReadLine());
                    try
                    {
                        var helper = catlogic.Read(id);
                        Console.WriteLine($"Id: {helper.CID}" + $"\nName: {helper.Cat_Name}" + $"\nBreed: {helper.Breed}" + $"\nIs_Mixed: {helper.Is_Mixed}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (entity == "Cat_Sitter")
                {
                    Console.WriteLine("\n Please give me the ID of the Cat Sitter that you want to display");
                    int ID = int.Parse(Console.ReadLine());
                    try
                    {
                        var helper = cat_SitterLogic.Read(ID);
                        Console.WriteLine($"Id: {helper.SID}" + $"\nName: {helper.Sitter_Name}" + $"\nAge: {helper.Sitter_Age}" + $"\nSalaryperMonth: {helper.Its_salary_month}" + $"\nIsProfessional?: {helper.Is_professional}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.ReadLine();
            }
            static void Create(string entity)
            {
                if (entity == "Cat_Owner")
                {
                    Cat_Owner cowner = new Cat_Owner();
                    var cownerprops = cowner.GetType().GetProperties();
                    foreach (var prop in cownerprops)
                    {
                        if (prop.Name == "Owner_Name")
                        {
                            Console.WriteLine("Owner_Name: ");
                            cowner.Owner_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Owner_Age")
                        {
                            Console.WriteLine("Owner_Age: ");
                            cowner.Owner_Age = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Is_Married")
                        {
                            Console.WriteLine("Is Married?  [true/false]: ");
                            cowner.Is_Married = bool.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Nationality")
                        {
                            Console.WriteLine("Nationality:  ");
                            cowner.Nationality = Console.ReadLine();
                        }
                    }
                    try
                    {
                        cat_OwnerLogic.Create(cowner);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                if (entity == "Cat")
                {
                    Cat cat = new Cat();
                    var catprops = cat.GetType().GetProperties();
                    foreach (var prop in catprops)
                    {
                        if (prop.Name == "Breed")
                        {
                            Console.WriteLine("Breed: ");
                            cat.Breed = Console.ReadLine();
                        }
                        else if (prop.Name == "Cat_Name")
                        {
                            Console.WriteLine("Name: ");
                            cat.Cat_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Is_Mixed")
                        {
                            Console.WriteLine("Is the cat mixed breed? [true/false]: ");
                            cat.Is_Mixed = bool.Parse(Console.ReadLine());
                        }
                    }
                    try
                    {
                        catlogic.Create(cat);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                if (entity == "Cat_Sitter")
                {
                    Cat_Sitter cat_sitter = new Cat_Sitter();
                    var citterprops = cat_sitter.GetType().GetProperties();
                    foreach (var prop in citterprops)
                    {
                        if (prop.Name == "Sitter_Name")
                        {
                            Console.WriteLine("Sitter_Name: ");
                            cat_sitter.Sitter_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Sitter_Age")
                        {
                            Console.WriteLine("Sitter_Age: ");
                            cat_sitter.Sitter_Age = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Its_salary_month")
                        {
                            Console.WriteLine("CostperMonth: ");
                            cat_sitter.Its_salary_month = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Is_professional")
                        {
                            Console.WriteLine("Is it Professional? [true/false]: ");
                            cat_sitter.Is_professional = bool.Parse(Console.ReadLine());
                        }
                    }
                    try
                    {
                        cat_SitterLogic.Create(cat_sitter);
                    }
                    catch (ArgumentException e) { Console.WriteLine(e.Message); }
                }
                Console.ReadLine();
            }
            static void Update(string entity)
            {
                if (entity == "Cat_Owner")
                {
                    Cat_Owner cowner = new Cat_Owner();
                    var cownerprops = cowner.GetType().GetProperties();
                    foreach (var prop in cownerprops)
                    {
                        if (prop.Name == "ID")
                        {
                            Console.WriteLine("ID: ");
                            cowner.OID = int.Parse(Console.ReadLine());
                        }
                        if (prop.Name == "Owner_Name")
                        {
                            Console.WriteLine("Owner Name: ");
                            cowner.Owner_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Owner_Age")
                        {
                            Console.WriteLine("Owner Age: ");
                            cowner.Owner_Age = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Is_Married")
                        {
                            Console.WriteLine("Is Married?  [true/false]: ");
                            cowner.Is_Married = bool.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Nationality")
                        {
                            Console.WriteLine("Nationality:  ");
                            cowner.Nationality = Console.ReadLine();
                        }
                       
                    }
                    try
                    {
                        cat_OwnerLogic.Update(cowner);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                }
                if (entity == "Cat")
                {
                    Cat cat = new Cat();
                    var catprops = cat.GetType().GetProperties();
                    foreach (var prop in catprops)
                    {
                        if (prop.Name == "ID")
                        {
                            Console.WriteLine("ID: ");
                            cat.CID = int.Parse(Console.ReadLine());
                        }
                        if (prop.Name == "Breed")
                        {
                            Console.WriteLine("Cat Breed: ");
                            cat.Breed = Console.ReadLine();
                        }
                        else if (prop.Name == "Cat_Name")
                        {
                            Console.WriteLine("Cat Name: ");
                            cat.Cat_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Is_Mixed")
                        {
                            Console.WriteLine("Is the cat mixed breed? [true/false]: ");
                            cat.Is_Mixed = bool.Parse(Console.ReadLine());
                        }
                    }
                    try
                    {
                        catlogic.Update(cat);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                }
                if (entity == "Cat_Sitter")
                {
                    Cat_Sitter cat_sitter = new Cat_Sitter();
                    var citterprops = cat_sitter.GetType().GetProperties();
                    foreach (var prop in citterprops)
                    {
                        if (prop.Name == "ID")
                        {
                            Console.WriteLine("ID: ");
                            cat_sitter.SID = int.Parse(Console.ReadLine());
                        }
                        if (prop.Name == "Siter_Name")
                        {
                            Console.WriteLine("Sitter Name: ");
                            cat_sitter.Sitter_Name = Console.ReadLine();
                        }
                        else if (prop.Name == "Sitter_Age")
                        {
                            Console.WriteLine("Age: ");
                            cat_sitter.Sitter_Age = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Its_salary_month")
                        {
                            Console.WriteLine("CostPerMonth: ");
                            cat_sitter.Its_salary_month = int.Parse(Console.ReadLine());
                        }
                        else if (prop.Name == "Is_professional")
                        {
                            Console.WriteLine("Is it Professional? [true/false]: ");
                            cat_sitter.Is_professional = bool.Parse(Console.ReadLine());
                        }
                    }
                    try
                    {
                        cat_SitterLogic.Update(cat_sitter);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadLine();
                }
            }
            static void NonCrudCat1()
            {
                foreach (var cat in catlogic.Mixed())
                {
                    Console.WriteLine(cat.Cat_Name);
                }
                Console.ReadLine();
            }
            static void NonCrudCat2()
            {
                foreach (TopBreed item in catlogic.Top2Breed())
                {
                    Console.WriteLine(item.Breed);
                }
                Console.ReadLine();
            }
            static void NonCrudCat_Sitter1()
            {
                Console.WriteLine("Sitter ID?");
                int sitter_ID = int.Parse(Console.ReadLine());
                try
                {
                    foreach (var item in cat_SitterLogic.CatHere(sitter_ID))
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }
            static void NonCrudCat_Owner1()
            {
                Console.WriteLine("Cat Owner Id? ");
                int cat_owner_ID = int.Parse(Console.ReadLine());
                try
                {
                    int price = cat_OwnerLogic.CatPricePerMonth(cat_owner_ID);
                    Console.WriteLine($"Cat Owner's price of cat: {price}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }
            static void NonCrudCat_Owner2()
            {

                var q = cat_OwnerLogic.RetiredPerson();
                Console.WriteLine("Cat ownner over 64: ");
                foreach (Cat_Owner item in q)
                {
                    Console.WriteLine(item.Owner_Name + " " + item.Owner_Age);
                }
                Console.ReadLine();
            }
            static void NonCrudCat_Owner3()
            {
                var q = cat_OwnerLogic.MarriedOwner();
                foreach (Cat_Owner item in q)
                {
                    Console.WriteLine(item.Owner_Name + ": " + item.Owner_Age);
                }
                Console.ReadLine();
            }

            cownermenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Cat_Owner"))
               .Add("Create", () => Create("Cat_Owner"))
               .Add("Delete", () => Delete("Cat_Owner"))
               .Add("Update", () => Update("Cat_Owner"))
               .Add("Read", () => Read("Cat_Owner"))
               .Add("Cat price for owner?", () => NonCrudCat_Owner1())
               .Add("Cat owner over 65", () => NonCrudCat_Owner2())
               .Add("Married cat owner", () => NonCrudCat_Owner3())
               .Add("Exit", ConsoleMenu.Close);

            catmenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Cat"))
               .Add("Create", () => Create("Cat"))
               .Add("Delete", () => Delete("Cat"))
               .Add("Update", () => Update("Cat"))
               .Add("Read", () => Read("Cat"))
               .Add("Mixed cat", () => NonCrudCat1())
               .Add("Top 2 cat", () => NonCrudCat2())
               .Add("Exit", ConsoleMenu.Close);

            catsittermenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Cat_Sitter"))
               .Add("Create", () => Create("Cat_Sitter"))
               .Add("Delete", () => Delete("Cat_Sitter"))
               .Add("Update", () => Update("Cat_Sitter"))
               .Add("Read", () => Read("Cat_Sitter"))
               .Add("Cat here", () => NonCrudCat_Sitter1())
               .Add("Exit", ConsoleMenu.Close);

            menu = new ConsoleMenu(args, level: 0)
              .Add("Cat", () => catmenu.Show())
              .Add("Cat_Owner", () => cownermenu.Show())
              .Add("Cat_Sitter", () => catsittermenu.Show())
              .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
    }

