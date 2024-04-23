using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;
using NuGet.ContentModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TH69LS_HFT_2023241.Logic;
using TH69LS_HFT_2023241.Models;
using TH69LS_HFT_2023241.Repository;

namespace TH69LS_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        CatLogic catLogic;
        Cat_SitterLogic cat_SitterLogic;
        Cat_OwnerLogic cat_OwnerLogic;

        public Tester()
        {
            var MockCatRepo = new Mock<IRepository<Cat>>();
            catLogic = new CatLogic(MockCatRepo.Object);
            var MockSitterlRepo = new Mock<IRepository<Cat_Sitter>>();
            cat_SitterLogic = new Cat_SitterLogic(MockSitterlRepo.Object);
            var MockCat_OwnerRepo = new Mock<IRepository<Cat_Owner>>();
            cat_OwnerLogic = new Cat_OwnerLogic(MockCat_OwnerRepo.Object);

            List<Cat_Owner> cowners = new List<Cat_Owner>()
            {
                new Cat_Owner()
                 {
                OID = 1,
                Owner_Name = "Eva",
                Owner_Age = 70,
                Is_Married = false,
                Nationality="Urugvay"

                 },
                new Cat_Owner()
                {
                 OID = 2,
                Owner_Name = "Johhny",
                Owner_Age = 54,
                Is_Married = false,
                Nationality="Hungary"
                },
                new Cat_Owner()
                {
                OID = 3,
                Owner_Name = "Adam",
                Owner_Age = 23,
                Is_Married = true,
                Nationality="German"
                }
            };


            List<Cat_Sitter> catsitters = new List<Cat_Sitter>()
            {
                new Cat_Sitter()
                {
                SID = 1,
                Sitter_Name = "Károly",
                Sitter_Age =35,
                Its_salary_month = 190000,
                Is_professional=true,
                },
                new Cat_Sitter()
                {
                 SID = 2,
                Sitter_Name = "Áron",
                Sitter_Age =20,
                Its_salary_month = 310000,
                Is_professional=false,
                }
            };

            List<Cat> cats = new List<Cat>()
            {
                new Cat()
                {
                 CID=1,
                 Cat_Owner_ID=1,
                 Cat_Sitter_ID=1,
                 Cat_Name="Cirmos",
                 Is_Mixed=true,
                 Breed="Siamese"
                },
                new Cat()
                {
                 CID=2,
                 Cat_Owner_ID=2,
                 Cat_Sitter_ID=1,
                 Cat_Name="Kázmér",
                 Is_Mixed=false,
                 Breed="Burmese"
                },
                new Cat()
                {
                 CID=3,
                 Cat_Owner_ID=2,
                 Cat_Sitter_ID=2,
                 Cat_Name="Pötyi",
                 Is_Mixed=true,
                 Breed="Sphynx"
                },
                new Cat()
                {
                CID=4,
                 Cat_Owner_ID=2,
                 Cat_Sitter_ID=2,
                 Cat_Name="Álmos",
                 Is_Mixed=false,
                 Breed="Persian"
                }
            };

           MockCatRepo.Setup((t) => t.ReadAll()).Returns(cats.AsQueryable());
           MockSitterlRepo.Setup((t) => t.ReadAll()).Returns(catsitters.AsQueryable());
           MockCat_OwnerRepo.Setup((t) => t.ReadAll()).Returns(cowners.AsQueryable());


        }
        [Test]
        public void CreateCatTest()
        {
            Assert.That(() => catLogic.Create(new Cat()
            {
                Cat_Name = null

            }), Throws.Nothing);

        }
        [Test]
        public void DeleteCatTest()
        {
            Assert.That(() => catLogic.Delete(52), Throws.Exception);
        }
        [Test]
        public void CreateCat_OwnerTest()
        {
            Assert.That(()=>cat_OwnerLogic.Create(new Cat_Owner()
            {
                Owner_Name=null
            }),Throws.Nothing);
        }

        public void DeleteCat_OwnerTest()
        {
            Assert.That(() => catLogic.Delete(52), Throws.Exception);
        }

        [Test]
        public void ReadCat_OwnerTest()
        {
            Assert.That(() => cat_OwnerLogic.Read(0), Throws.Exception);
        }
        [Test]
        public void RetiredPerson()
        {
            var r = cat_OwnerLogic.RetiredPerson().ToArray();
            Assert.That(r[0].Owner_Name, Is.EqualTo("Eva"));
        }

        [Test]
        public void MarriedOwner()
        {
            var r = cat_OwnerLogic.MarriedOwner().ToArray();
            Assert.That(r[0].Owner_Name, Is.EqualTo("Adam"));
        }
        [Test]
         public void Mixed()
        {
            var r= catLogic.Mixed().ToArray();
            Assert.That(r[0].Cat_Name, Is.EqualTo("Cirmos"));
        }
        [Test]
        public void Salary()
        {
            var r = cat_SitterLogic.Salary().ToArray();
            Assert.That(r[0].Sitter_Name, Is.EqualTo("Áron"));
        }
        [Test]
        public void ReadCatTest()
        {
            Assert.That(() => catLogic.Read(0), Throws.Exception);
        }
        [Test]
        public void Cat_sitterCreated()
        {
            Assert.That(() => cat_SitterLogic.Delete(0), Throws.Exception);
        }
    }
}
