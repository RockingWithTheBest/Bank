using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankAccount
    {
        private double interestRate;
        private string owner;
        private decimal balance;
        private decimal dep;
        private long accountNumber;

        private static long nextAccountNumber = 0;
        private static ArrayList account = new ArrayList();

        public BankAccount(string owner)
        {
            nextAccountNumber++;
            account.Add(this);
            this.accountNumber = nextAccountNumber;
            this.owner = owner;
            this.interestRate = 0;
            this.balance = 0M;

        }
        public BankAccount(string owner, double interestRate)
        {
            nextAccountNumber++;
            account.Add(this);
            this.accountNumber = nextAccountNumber;
            this.interestRate = interestRate;
            this.owner = owner;
            this.balance = 0.0M;
        }
        public static long NumberofAccount()
        {
            return nextAccountNumber;
        }
        public static BankAccount GetAccount(long accoutNumber)
        {
            foreach(BankAccount ba in account)
                if (ba.accountNumber == accoutNumber)
                    return ba;
            return null;
        }
        public BankAccount( string owner, double interestRate, decimal balance) 
        {
            this.interestRate = interestRate;
            this.owner = owner;
            this.balance = balance;
        }
        public decimal Deposit(decimal amount)
        {
            this.dep = amount;
            this.balance = amount;
            return amount;
        }
        public decimal AddInterest()
        {
            decimal interest = Convert.ToDecimal(this.interestRate);
            decimal otherDep = Deposit(dep);
            return otherDep + (otherDep * interest);
        }
        public override string ToString()
        {
            this.balance = balance;
            return owner + "'s account, no." + accountNumber + " holds " + balance + " kroner ";
        }

    }
    //public class BankAccountClient
    //{
    //    static void (string[] args)
    //    {
    //        BankAccount a1 = new BankAccount("Kurt", 0.02),
    //                    a2 = new BankAccount("Bent", 0.03),
    //                    a3 = new BankAccount("Thomas", 0.02);
    //        a1.Deposit(100.0M);
    //        a2.Deposit(1000.0M);
    //        a3.Deposit(3000.0M);
    //        decimal a1Int = a1.AddInterest();
    //        decimal a2Int = a2.AddInterest();
    //        decimal a3Int = a3.AddInterest();
    //        //Console.WriteLine($"Kurt:{a1Int}\n Bent:{a2Int}\n Thomas:{a3Int}");
    //        //Console.WriteLine(a1);
    //        //Console.WriteLine(a2);
    //        //Console.WriteLine(a3);
    //        BankAccount a = BankAccount.GetAccount(2);
    //        if (a != null)
    //            Console.WriteLine(a);
    //        else
    //            Console.WriteLine("Cannot find account 2");

    //    }
    //}
    class ConstDemo
    {
        const double ca = 5,
            cb = ca + 1;
        private readonly double roa = 7,
            rob = Math.Log(Math.E);
        private readonly BankAccount roba = new BankAccount("Anders");
        public ConstDemo()
        {
            roa = 8;
            roba = new BankAccount("Tim");
        }
        public void Go()
        {
            roba.Deposit(100.0M);
        }
        public static void Main(string[] args)
        {
            ConstDemo self = new ConstDemo();
            self.Go();
        }
    }
}
