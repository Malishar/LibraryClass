using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    // Дебетовая карта
    public class DebitCard : BankCard, IInit, IComparable
    {
        // Поля
        protected double balance;

        // Свойство с проверкой ограничений
        public double Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Баланс не может быть < 0");
            }
        }

        // Конструктор без параметров
        public DebitCard() 
        {
            balance = 0;
        }

        // Конструктор с параметрами
        public DebitCard(string number, string owner, int date, int num, double balance) : base(number, owner, date, num)
        {
            this.balance = balance;
        }

        // Переопределение виртуального метода Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Баланс: {balance}");
        }

        //Переопределение обычного (не виртуального) метода Show()
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void ShowUsual()
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        {
            base.ShowUsual();
            Console.WriteLine($"Баланс: {balance}");
        }

        // Переопределение метода Init 
        public override void Init()
        {
            base.Init(); // Вызов базовой реализации Init
            Console.Write("Введите баланс: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            Balance = double.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        }

        // Переопределение метода RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();// Вызов базовой реализации RandomInit
            Random rnd = new Random();
            balance = rnd.Next(1, 10000);
        }          
    }
}
