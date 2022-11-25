using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_ornek_calisma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int sayi1 = 10;
            int sayi2 = 20;
            sayi1 = sayi2;
            sayi2 = 100;

            int[] sayilar1 = new[] { 1, 2, 3 };
            int[] sayilar2 = new[] { 10, 20, 30 };
            sayilar1= sayilar2; //adres ataması yapıyoruz, değer ataması değil.
            sayilar2[0] = 1000;

            Console.WriteLine(sayi1);
            Console.WriteLine(sayilar1[0]);*/

            /*CreditManager creditManager = new CreditManager();
            creditManager.Calculate();
            creditManager.Calculate();
            creditManager.Save();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.City = "İstanbul";

            CustomerManager customerManager = new CustomerManager(customer);
            customerManager.Save();
            customerManager.Delete();

            Company company = new Company();
            company.TaxNumber = "100000";
            company.CompanyName = "Arçelik";
            company.Id = 100;

            CustomerManager customerManager1 = new CustomerManager(new Person());


            Person person = new Person();
            person.NationalIdentity = "12345";

            Customer c1=new Customer();
            Customer c2 = new Person();
            Customer c3= new Company();*/

            CustomerManager customerManager = new CustomerManager(new Customer(), new MilitaryCreditManager());
            customerManager.GiveCredit();



            Console.ReadLine();
        }
    }

    class CreditManager : ICreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("Hesaplandı");
        }

        public void Save()
        {
            Console.WriteLine("Kredi verildi");
        }
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager: ICreditManager
    {
        public abstract void Calculate();
        public virtual void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }

    class TeacherCreditManager : BaseCreditManager,ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Öğretmen kredisi hesaplandı.");
        }

        public override void Save()
        {
            //virtual anahtar sözcüğü sayesinde istediğimiz kodu ekleyebiliyoruz.
            //istenilen kodlar..
            base.Save();
            //istenilen kodlar..
        }


    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandı.");
        }

        
    }

    class CarCreditManager : BaseCreditManager,ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araba kredisi hesaplandı.");
        }

    }

    class Customer
    {

        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }
        public string City { get; set; }


    }

    class Person : Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }

    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;  //customer'a ulaşmak için
            _creditManager = creditManager;
        }
        public void Save() { Console.WriteLine("Müşteri kaydedildi : " ); }
        public void Delete() { Console.WriteLine("Müşteri silindi : " ); }
        public void GiveCredit() 
        { 
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }
    }



}
