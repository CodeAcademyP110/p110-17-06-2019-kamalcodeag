using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P110_ConsoleDemo
{
    class Program
    {
        public delegate bool IntCheckers(int item);
        public delegate void SendVerification(string verifyMessage);

        //enum Colors { red,black,yellow}

        static void Main(string[] args)
        {
            //foreach (var item in Enum.GetNames(typeof(Colors)))
            //{
            //    Console.WriteLine(item);
            //}

            #region delegate
            //Add(IsEven, 10, 15, 20, 35, 56, 89, 78);
            //Add(IsOlder, 25, 10, 45, 56, 98, 11);

            //SendVerification sendVerification = new SendVerification(WriteToConsole);
            //SendVerification sendVerification = SendSMS;
            //sendVerification += SendEmail;
            //sendVerification += SendSMS;
            //sendVerification += SendSMS;
            //sendVerification += WriteToConsole;

            //sendVerification -= WriteToConsole;
            //sendVerification -= WriteToConsole;
            //sendVerification -= WriteToConsole;
            //sendVerification -= WriteToConsole;
            //sendVerification -= WriteToConsole;

            //sendVerification("100 AZN deducted.");
            #endregion

            //ATM mainATM = new ATM();
            //ATM azadliqATM = new ATM();

            //mainATM.OnBalanceLow += SendSms;
            //mainATM.OnBalanceLow += Write;

            ////anonymous method
            //azadliqATM.OnBalanceLow += delegate (object sender, ATMEventArgs e)
            //{
            //    ATM atm = (ATM)sender;
            //    Console.WriteLine($"Balance is low on ATM №{atm.ID}. Current amount is {e.CurrentBalance} at {e.ActionTime.ToShortDateString()}");
            //};

            ////lambda expression
            //azadliqATM.OnBalanceLow += (sender, e) =>
            //{
            //    ATM atm = (ATM)sender;
            //    Console.WriteLine($"Caution. Balance azalir ATM №{atm.ID}. Faktiki balans: {e.CurrentBalance}, tarix: {e.ActionTime.ToLongDateString()}");
            //};

            //mainATM.TopUp(2000);
            //mainATM.Withdraw(700);
            //mainATM.Withdraw(500);

            //azadliqATM.TopUp(1300);
            //azadliqATM.Withdraw(550);
        }

        class ATM
        {
            private static int id_counter = 1;
            private int _id;

            public int ID
            {
                get { return _id; }
                private set { _id = value; }
            }

            public ATM()
            {
                _id = id_counter++;
            }

            public delegate void BalanceLow(object sender, ATMEventArgs e);

            public event BalanceLow OnBalanceLow;

            public decimal Balance { get; private set; }

            public void Withdraw(decimal amount)
            {
                if (Balance >= amount) Balance -= amount;
                Console.WriteLine($"Balans-dan {amount} azn pul cixidli. Balans: {Balance}");
                //else 

                //check whether balance is low
                if (Balance <= 1000)
                {
                    //if(OnBalanceLow != null)
                    //    OnBalanceLow();

                    OnBalanceLow?.Invoke(this, new ATMEventArgs
                    {
                        CurrentBalance = Balance,
                        ActionTime = DateTime.Now
                    });
                }
            }

            public void TopUp(decimal amount)
            {
                Balance += amount;
            }


        }

        class ATMEventArgs : EventArgs
        {
            public decimal CurrentBalance { get; set; }
            public DateTime ActionTime { get; set; }
        }



        static void SendSms(object sender, ATMEventArgs e)
        {
            ATM atm = (ATM)sender;
            Console.WriteLine($"ID-si {atm.ID} olan Atm-de faktiki balans {e.CurrentBalance} AZN. Bas verme tarixi: {e.ActionTime}");
        }

        static void Write(object sender, ATMEventArgs e)
        {
            ATM atm = (ATM)sender;
            Console.WriteLine($"ID-si {atm.ID} olan ATM-e balans azaldi. Balansin miqdari: {e.CurrentBalance}, Bas verme tarixi: {e.ActionTime}");
        }


        static void WriteToConsole(string sentence)
        {
            Console.WriteLine(sentence);
        }

        static void SendEmail(string sentence)
        {
            //email sending simulation
            Console.WriteLine("Email sent successfully");
        }

        static void SendSMS(string message)
        {
            //message sent simulation
            Console.WriteLine("SMS sent successfully");
        }





        static int Add(IntCheckers callBack, params int[] numbers)
        {
            int sum = 0;
            foreach (int item in numbers)
            {
                if (callBack(item))
                    sum += item;
            }
            return sum;
        }

        static bool IsEven(int number) => number % 2 == 0;

        static bool IsOlder(int age) => age > 18;
    }

   

}

