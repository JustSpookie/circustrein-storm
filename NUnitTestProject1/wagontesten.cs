using NUnit.Framework;
using circustrein;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        [Test]
        public void Testcarnivoor1()
        {
            dier dier1 = new dier(1, 1, false);
            dier dier2 = new dier(2, 3, true);
            dier dier3 = new dier(3, 3, false);
            dier dier4 = new dier(4, 5, true);
            dier dier5 = new dier(5, 3, true);
            wagon wagon1 = new wagon();
            wagon1.kan_toevoegen(dier2);

            Assert.IsFalse(wagon1.kan_toevoegen(dier1));
            Assert.IsFalse(wagon1.kan_toevoegen(dier3));
            Assert.IsFalse(wagon1.kan_toevoegen(dier4));
            Assert.IsFalse(wagon1.kan_toevoegen(dier5));

            Assert.Pass();
        }

        [Test]
        public void Testcarnivoor2()
        {
            dier dier1 = new dier(1, 1, false);
            dier dier2 = new dier(2, 3, true);
            dier dier3 = new dier(3, 3, false);
            dier dier4 = new dier(4, 5, true);

            Assert.IsFalse(dier1.carnivoor);
            Assert.IsTrue(dier2.carnivoor);
            Assert.IsFalse(dier3.carnivoor);
            Assert.IsTrue(dier4.carnivoor);

            Assert.Pass();
        }



        [Test]
        public void Testruimte1()
        {
            dier dier1 = new dier(1, 5, false);
            dier dier2 = new dier(2, 5, false);
            dier dier3 = new dier(3, 1, false);

            wagon wagon1 = new wagon();
            wagon1.kan_toevoegen(dier1);
            Assert.IsTrue(wagon1.kan_toevoegen(dier2));
            Assert.IsFalse(wagon1.kan_toevoegen(dier3));

            Assert.Pass();
        }

        [Test]
        public void Testruimte2()
        {
            wagon wagon1 = new wagon();

            wagon1.kan_toevoegen(new dier(1, 3, false));
            
            Assert.IsTrue(wagon1.animalweightcount() == 3);

            wagon1.kan_toevoegen(new dier(2, 1, false));

            Assert.IsTrue(wagon1.animalweightcount() == 4);

            wagon1.kan_toevoegen(new dier(3, 5, false));

            Assert.IsTrue(wagon1.animalweightcount() == 9);

            Assert.Pass();
        }

        [Test]
        public void GetAllAnimals()
        {
            dier dier1 = new dier(1, 5, false);
            dier dier2 = new dier(2, 3, false);
            dier dier3 = new dier(3, 1, false);

            List<dier> listdieren1 = new List<dier>();
            listdieren1.Add(dier1);
            listdieren1.Add(dier2);
            listdieren1.Add(dier3);


            List<dier> listdieren2 = new List<dier>();

            wagon wagon1 = new wagon();

            wagon1.kan_toevoegen(dier1);
            wagon1.kan_toevoegen(dier2);
            wagon1.kan_toevoegen(dier3);

            listdieren2 = wagon1.getdieren();

            Assert.IsTrue(listdieren2.Count == listdieren1.Count);

            foreach(dier dier in listdieren1)
            {
                Assert.IsTrue(listdieren2.Contains(dier));
            }
            
            Assert.Pass();
        }

        [Test]
        public void carnivoorcheck()
        {
            dier dier1 = new dier(1, 5, false);
            dier dier2 = new dier(2, 3, false);
            dier dier3 = new dier(3, 1, false);
            dier diertest = new dier(4, 1, true);

            List<dier> listdieren1 = new List<dier>();
            listdieren1.Add(dier1);
            listdieren1.Add(dier2);
            listdieren1.Add(dier3);

            Assert.IsFalse(diertest.carnivoorcheck(listdieren1));

            diertest.carnivoor = false;

            Assert.IsTrue(diertest.carnivoorcheck(listdieren1));

            listdieren1[1].carnivoor = true;

            Assert.IsFalse(diertest.carnivoorcheck(listdieren1));
        }
    }
}