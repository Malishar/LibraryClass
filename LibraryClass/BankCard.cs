using System.Collections.Generic;

namespace LibraryClass
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class IdNumber
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public int num;

        // Конструктор класса IdNumber, инициализирующий числовое значение идентификационного номера
        public IdNumber(int num)
        {
            this.num = num;
        }
        public override string ToString()
        {
            return num.ToString();
        }

        // Переопределение метода Equals для сравнения объектов типа IdNumber
        public override bool Equals(object? obj)
        {
            // Проверка, является ли переданный объект экземпляром класса IdNumber
            if (obj is IdNumber n)
                return this.num == n.num;
            return false;
        }
    }
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class BankCard : IInit, IComparable, ICloneable
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        // Поля
        protected string number;
        protected string owner;
        protected int date;

        public IdNumber id { get; set; }
        // Свойства с проверкой ограничений
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public int Date
        {
            get { return date; }
            set
            {
                if (value >= 0)
                    date = value;
                else
                    Console.WriteLine("Год не может быть < 0");
            }
        }

        // Конструктор без парметров
        public BankCard()
        {
            number = "0";
            owner = "NoName";
            date = 0;
            id = new IdNumber(0);
        }

        // Конструктор с парметрами
        public BankCard(string number, string owner, int date, int num)
        {
            this.number = number;
            this.owner = owner;
            this.date = date;
            this.id = new IdNumber(num);
        }

        // Конструктор копирования
        public BankCard(BankCard other)
        {
            number = other.number;
            owner = other.owner;
            date = other.date;
            id = other.id;
        }

        // Виртуальный метод Show()
        public virtual void Show()
        {
            Console.WriteLine($"Айди: {id}, Номер: {number}, Владелец: {owner}, Срок действия: {date}");
        }

        //Обычный (не виртуальный) метод Show()
        public void ShowUsual()
        {
            Console.WriteLine($"Номер: {number}, Владелец: {owner}, Срок действия: {date}");
        }

        // Метод Init() для ввода вручную
        public virtual void Init()
        {
            Console.Write("Введите айди: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            id.num = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            Console.Write("Введите номер карты: ");
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            number = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            Console.Write("Введите имя владельца: ");
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            owner = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            Console.Write("Введите срок действия: ");
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            date = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
        }

        // Метод RandomInit() для генерации элементов/объктов с помощью ДСЧ
        public virtual void RandomInit()
        {
            Random rnd = new Random();
            number = rnd.Next(1000, 9999).ToString() + " " + rnd.Next(1000, 9999).ToString() + " " + rnd.Next(1000, 9999).ToString() + " " + rnd.Next(1000, 9999).ToString();
            string[] firstNames = { "Иван", "Пётр", "Артемий", "Владимир", "Никита", "Дмитрий", "Геннадий", "Алексей", "Борис", "Сергей" };
            string[] lastNames = { "Иванов", "Пётров", "Сидоров", "Смирнов", "Попов", "Лебедев", "Кузнецов", "Соколов", "Морозов", "Голубев" };
            string firstName = firstNames[rnd.Next(firstNames.Length)];
            string lastName = lastNames[rnd.Next(lastNames.Length)];
            owner = $"{firstName} {lastName}";
            date = rnd.Next(DateTime.Now.Year, DateTime.Now.Year + 5);
            id.num = rnd.Next(1, 100);
        }

        // Метод Equals
#pragma warning disable CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // Допустимость значений NULL для типа параметра не соответствует переопределенному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            BankCard other = (BankCard)obj;
            // Сравнение значений полей текущего объекта и другого объекта типа BankCard
            return number == other.number && owner == other.owner && date == other.date;
        }

        // Метод CompareTo для сравнения текущего объекта с другим объектом, реализуемый интерфейсом IComparable
        public int CompareTo(object? obj)
        {
            // Проверка, является ли переданный объект null
            if (obj == null) return -1;
            if (obj is not BankCard) return -1;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            BankCard bcard = obj as BankCard;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            // Сравнение номеров текущего и другого объектов типа BankCard
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            return String.Compare(this.Number, bcard.Number);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        // Метод Clone для создания копии текущего объекта, реализуемый интерфейсом ICloneable
        public object Clone()
        {
            // Создание нового объекта BankCard на основе значений полей текущего объекта
            return new BankCard(this.Number, this.Owner, this.Date, this.id.num);
        }

        // Метод ShallowCopy для создания поверхностной копии текущего объекта
        public object ShallowCopy()
        {
            // Возвращение поверхностной копии текущего объекта
            return this.MemberwiseClone();
        }  
    }
}