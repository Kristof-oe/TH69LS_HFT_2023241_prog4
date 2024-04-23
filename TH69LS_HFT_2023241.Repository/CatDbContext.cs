using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using TH69LS_HFT_2023241.Models;


namespace TH69LS_HFT_2023241.Repository
{
    public class CatDbContext:DbContext
    {        
        public  DbSet<Cat> Cats {  get; set; }
        public DbSet<Cat_Owner> Cat_Owners { get; set; }
        public DbSet<Cat_Sitter> Cat_Sitters { get; set; }
         

        public CatDbContext()
        {
                this.Database.EnsureCreated(); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                
                    builder.UseLazyLoadingProxies()
                    .UseInMemoryDatabase("cat");
                
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity
                .HasOne(x => x.Cat_Owner)
                .WithMany(x => x.Cats)
                .HasForeignKey(x => x.OID)
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasMany(x => x.Cat_Sitter)
                    .WithOne(x => x.Cat)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Cat_Owner>(entity =>
            {
             entity
            .HasMany(owners => owners.Cats)
            .WithOne(cat => cat.Cat_Owner)
            .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Cat_Sitter>(entity =>
            {
                entity
            .HasOne(sitter => sitter.Cat)
              .WithMany(cat => cat.Cat_Sitter)
              .HasForeignKey(cardealership => cardealership.CID)
                .OnDelete(DeleteBehavior.Cascade);
            });


            //Cat_Owner

            Cat_Owner ToniKukoc = new Cat_Owner() { OID = 1, Owner_Name = "ToniKukoc", Owner_Age = 21, Is_Married = true, Nationality = "Hungarian" };
            Cat_Owner LucLongley = new Cat_Owner() { OID = 2, Owner_Name = "LucLongley", Owner_Age = 35, Is_Married = false, Nationality = "Afghan" };
            Cat_Owner DennisRodman = new Cat_Owner() { OID = 3, Owner_Name = "DennisRodman", Owner_Age = 47, Is_Married = true, Nationality = "Australian" };
            Cat_Owner MichaelJordan = new Cat_Owner() { OID = 4, Owner_Name = "MichaelJordan", Owner_Age = 52, Is_Married = false, Nationality = "Haitian" };
            Cat_Owner ScottiePippen = new Cat_Owner() { OID = 5, Owner_Name = "ScottiePippen", Owner_Age = 98, Is_Married = true, Nationality = "Iraqi" };
            Cat_Owner RonHarper = new Cat_Owner() { OID = 6, Owner_Name = "RonHarper", Owner_Age = 65, Is_Married = false, Nationality = "Irish" };
            /*Cat_Owner SteveKerr = new Cat_Owner() { OID = 7, Owner_Name = "SteveKerr", Owner_Age = 27, Is_Married = true, Nationality = "Irish" };
            Cat_Owner MuggsyBogues = new Cat_Owner() { OID = 8, Owner_Name = "MuggsyBogues", Owner_Age = 52, Is_Married = false, Nationality = "Australian" };
            Cat_Owner ScottBurrell = new Cat_Owner() { OID = 9, Owner_Name = "ScottBurrell", Owner_Age = 48, Is_Married = true, Nationality = "Haitian" };
            Cat_Owner TomChambers = new Cat_Owner() { OID = 10, Owner_Name = "TomChambers", Owner_Age = 36, Is_Married = false, Nationality = "Irish" };
            Cat_Owner DellCurry = new Cat_Owner() { OID = 11, Owner_Name = "DellCurry", Owner_Age = 22, Is_Married = true, Nationality = "Indonesian" };*/

            //modelBuilder.Entity<Cat_Owner>().HasData(ToniKukoc, LucLongley, DennisRodman, MichaelJordan, ScottiePippen, RonHarper, SteveKerr, MuggsyBogues, ScottBurrell, TomChambers, DellCurry);



            Cat Abyssinian = new Cat() { CID = 1, Breed = "Abyssinian", Cat_Name = "Cirmi", Is_Mixed = false, OID = ToniKukoc.OID };
            Cat British_Shorthair = new Cat() { CID = 2, Breed = "British_Shorthair", Cat_Name = "Gallus", Is_Mixed = false, OID = LucLongley.OID };
            Cat Burmese = new Cat() { CID = 3, Breed = "Burmese", Cat_Name = "Bajusz", Is_Mixed = true, OID = DennisRodman.OID };
            Cat Persian = new Cat() { CID = 4, Breed = "Persian", Cat_Name = "Lola", Is_Mixed = false, OID = MichaelJordan.OID };
            Cat Cornish_Rex = new Cat() { CID = 5, Breed = "Cornish_Rex", Cat_Name = "Grácia", Is_Mixed = true, OID = ScottiePippen.OID };
            Cat Devon_Rex = new Cat() { CID = 6, Breed = "Devon_Rex", Cat_Name = "Nyau", Is_Mixed = true, OID = RonHarper.OID };

            //Cat_sitter

            Cat_Sitter AllanHouston = new Cat_Sitter() { SID = 1, Sitter_Name = "AllanHouston", Sitter_Age = 21, Its_salary_month = 156000, Is_professional = true, CID= Abyssinian.CID};
            Cat_Sitter ChrisJent = new Cat_Sitter() { SID = 2, Sitter_Name = "ChrisJent", Sitter_Age = 39, Its_salary_month = 210000, Is_professional = true, CID = British_Shorthair.CID };
            Cat_Sitter LarryJohnson = new Cat_Sitter() { SID = 3, Sitter_Name = "LarryJohnson", Sitter_Age = 43, Its_salary_month = 300000, Is_professional = false, CID = Burmese.CID };
            Cat_Sitter PatrickEwing = new Cat_Sitter() { SID = 4, Sitter_Name = "PatrickEwing", Sitter_Age = 31, Its_salary_month = 430000, Is_professional = false, CID = Persian.CID };
            Cat_Sitter WalterMcCarty = new Cat_Sitter() { SID = 5, Sitter_Name = "WalterMcCarty", Sitter_Age = 29, Its_salary_month = 390000, Is_professional = true, CID = Cornish_Rex.CID };
            Cat_Sitter WalterMcCarty2 = new Cat_Sitter() { SID = 5, Sitter_Name = "WalterMcCarty2", Sitter_Age = 29, Its_salary_month = 390000, Is_professional = true, CID = Devon_Rex.CID };


            //modelBuilder.Entity<Cat_Sitter>().HasData(AllanHouston, ChrisJent, PatrickEwing, LarryJohnson, WalterMcCarty);

            //modelBuilder.Entity<Cat>().HasData({ };


            /*Cat Himalayan = new Cat() { CID = 7, Breed = "Himalayan", Cat_Name = "Tappancs", Is_Mixed = false, OID = SteveKerr.OID };
            Cat Maine_Coon = new Cat() { CID = 8, Breed = "Maine_Coon", Cat_Name = "Tik-Tak", Is_Mixed = true, OID = MuggsyBogues.OID };
            Cat Manx = new Cat() { CID = 9, Breed = "Manx", Cat_Name = "Vörös", Is_Mixed = false, OID = ScottBurrell.OID };
            Cat Russian_Blue = new Cat() { CID = 10, Breed = "Russian_Blue", Cat_Name = "Ringó", Is_Mixed = false, OID = TomChambers.OID };
            Cat Scottish_Fold = new Cat() { CID = 11, Breed = "Scottish_Fold", Cat_Name = "Rúfusz", Is_Mixed = false, OID = DellCurry.OID };
            Cat Siamese = new Cat() { CID = 12, Breed = "Siamese", Cat_Name = "Parádé", Is_Mixed = true, OID = SteveKerr.OID };
            Cat Sphynx = new Cat() { CID = 13, Breed = "Sphynx", Cat_Name = "Mendi", Is_Mixed = true, OID = RonHarper.OID };
            Cat Turkish_Angora = new Cat() { CID = 14, Breed = "Turkish_Angora", Cat_Name = "Taréj", Is_Mixed = false, OID = DennisRodman.OID };
            Cat Turkish_Van = new Cat() { CID = 15, Breed = "Turkish_Van", Cat_Name = "Robin", Is_Mixed = true, OID = ScottiePippen.OID };*/

            List<Cat_Owner> owners = new List<Cat_Owner>() { };
            owners.Add(ToniKukoc);
            owners.Add(LucLongley);
            owners.Add(DennisRodman);
            owners.Add(MichaelJordan);
            owners.Add(ScottiePippen);
            owners.Add(RonHarper);
            /*owners.Add(SteveKerr);
            owners.Add(MuggsyBogues);
            owners.Add(ScottBurrell);
            owners.Add(TomChambers);
            owners.Add(DellCurry);*/
            List<Cat_Sitter> sitter = new List<Cat_Sitter>();
            sitter.Add(AllanHouston);
            sitter.Add(ChrisJent);
            sitter.Add(LarryJohnson);
            sitter.Add(PatrickEwing);
            sitter.Add(WalterMcCarty);
            List<Cat> cat = new List<Cat>();
            cat.Add(Abyssinian);
            cat.Add(British_Shorthair);
            cat.Add(Burmese);
            cat.Add(Persian);
            cat.Add(Cornish_Rex);
            cat.Add(Devon_Rex);
            /*cat.Add(Himalayan);
            cat.Add(Maine_Coon);
            cat.Add(Manx);
            cat.Add(Russian_Blue);
            cat.Add(Scottish_Fold);
            cat.Add(Siamese);
            cat.Add(Sphynx);
            cat.Add(Turkish_Angora);
            cat.Add(Turkish_Van);*/
            modelBuilder.Entity<Cat>().HasData(cat);
            modelBuilder.Entity<Cat_Owner>().HasData(owners);
            modelBuilder.Entity<Cat_Sitter>().HasData(sitter);

        }
     }
}
