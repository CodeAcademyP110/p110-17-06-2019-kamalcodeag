using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    //public delegate void TestDelegate(int number);
    class Program
    {
        static void Main(string[] args)
        {
            #region Practice Delegate
            //Testing testing = new Testing();

            //1st way
            //TestDelegate del1 = new TestDelegate(testing.ShowNumber);
            //del1(7); //7
            //TestDelegate del2 = new TestDelegate(testing.GetSum);
            //del2(8); //16

            //2nd way
            //TestDelegate del3 = testing.ShowNumber;
            //del3 += testing.GetSum;
            //del3(7);
            //del3(8);
            #endregion

            #region HomeTask
            ATM atm = new ATM();

            atm.OnBalanceLow += BalanceChangedAfterWithdraw;
            atm.OnBalanceUp += BalanceChangedAfterDeposit;
            atm.OnBalanceFinished += BalanceFinished;

            ATM.Withdraw(50);
            ATM.Deposit(200);
            ATM.Withdraw(1150);
            #endregion
        }

        public static void BalanceChangedAfterWithdraw(object sender, EventArgs e)
        {
            Console.WriteLine("Withdraw process occured");
        }
        public static void BalanceChangedAfterDeposit(object sender, EventArgs e)
        {
            Console.WriteLine("Deposit process occured");
        }
        public static void BalanceFinished(object sender, EventArgs e)
        {
            Console.WriteLine("You do not have sufficient money in your balance");
        }
    }

    #region Practice Delegate
    //public class Testing
    //{
    //    public void ShowNumber(int number)
    //    {
    //        Console.WriteLine(number);
    //    }

    //    public void GetSum(int number)
    //    {
    //        Console.WriteLine(number + number);
    //    }
    //}
    #endregion

    #region HomeTask
    public class ATM
    {
        public static decimal Balance { get; private set; } = 1000; // 1000 AZN
        public delegate void MainDelegate(object sender, EventArgs e);
        public event MainDelegate OnBalanceLow;
        public event MainDelegate OnBalanceUp;
        public event MainDelegate OnBalanceFinished;

        public static void Withdraw(decimal money)
        {
            if (money > 0 && Balance >= money)
            {
                Balance -= money;
                Console.WriteLine(Balance);
            }
        }
        public static void Deposit(decimal money)
        {
            if (money > 0)
            {
                Balance += money;
                Console.WriteLine(Balance);
            }
        }
    }
    #endregion
}
