using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    // Молодежная карта
    public class YouthCard : BankCard, IInit, IComparable
    {
        // Поля
        protected double cashback;

        // Свойство с проверкой ограничений
        public double Cashback
        {
            get { return cashback; }
            set
            {
                if (value >= 0 && value <= 100)
                    cashback = value;
                else
                    Console.WriteLine("Кэшбек должен быть от 0 до 100");
            }
        }

        // Конструктор без параметров
        public YouthCard() 
        {
            cashback = 0;
        }

        // Конструктор с параметрами
        public YouthCard(string number, string owner, int date, int num, double cashback) : base(number, owner, date, num)
        {
            this.cashback = cashback;
        }

        // Переопределение виртуального метода Show()
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Кэшбек: {cashback}%");
        }

        //Переопределение обычного (не виртуального) метода Show()
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void ShowUsual()
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        {
            base.ShowUsual();
            Console.WriteLine($"Кэшбек: {cashback}%");
        }

        // Переопределение метода Init()
        public override void Init()
        {
            base.Init(); // Вызов базовой реализации Init
            Console.Write("Введите кэшбек: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            Cashback = double.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        }

        // Переопределение метода RandomInit()
        public override void RandomInit()
        {
            base.RandomInit();// Вызов базовой реализации RandomInit
            Random rnd = new Random();
            cashback = rnd.Next(0, 100); // Устанавливаем случайный кэшбек от 0% до 100%
        }
    }
}