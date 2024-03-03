using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    // Кредитная карта
    public class CreditCard : BankCard, IInit, IComparable
    {
        // Поля
        protected double limit;
        protected int repaymentTerm;

        // Свойства с проверкой ограничений
        public double Limit
        {
            get { return limit; }
            set
            {
                if (value >= 0)
                    limit = value;
                else
                    Console.WriteLine("Лимит не может быть < 0");
            }
        }

        public int RepaymentTerm
        {
            get { return repaymentTerm; }
            set
            {
                if (value > 0)
                    repaymentTerm = value;
                else
                    Console.WriteLine("Срок погашения должен быть положительным числом");
            }
        }

        // Конструктор без параметров
        public CreditCard() 
        {
            limit = 0;
            repaymentTerm = 0;
        }

        // Конструктор с параметрами
        public CreditCard(string number, string owner, int date, int num, double limit, int repaymentTerm) : base(number, owner, date, num)
        {
            this.limit = limit;
            this.repaymentTerm = repaymentTerm;
        }

        // Переопределение виртуального метода Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Лимит: {limit}; Срок погашения: {repaymentTerm} месяцев");
        }

        //Переопределение обычного (не виртуального) метода Show()
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void ShowUsual()
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        {
            base.ShowUsual();
            Console.WriteLine($"Лимит: {limit}; Срок погашения: {repaymentTerm} месяцев");
        }

        // Переопределение метода Init()
        public override void Init()
        {
            base.Init(); // Вызов базовой реализации Init
            Console.Write("Введите лимит: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            Limit = double.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            Console.Write("Введите срок погашения: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            RepaymentTerm = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        }

        // Переопределение метода RandomInit()
        public override void RandomInit()
        {
            base.RandomInit(); // Вызов базовой реализации RandomInit
            Random rnd = new Random();
            limit = rnd.Next(1000, 100000);
            repaymentTerm = rnd.Next(1, 120);
        }
    }
}

