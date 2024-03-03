using LibraryClass;
namespace la_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankCard[] cards = new BankCard[20];
            GenerateCards(cards);
            while (true)
            {
                Console.WriteLine("Выберите часть программы для выполнения:");
                Console.WriteLine("1. Виртуальные и невиртуальные функции");
                Console.WriteLine("2. Выполнение запросов");
                Console.WriteLine("3. Печать объектов и подсчет их количества, сортировка и клонирование");
                Console.WriteLine("4. Выход");

                string choice = Console.ReadLine();

                switch (choice)//Меню для выбора выполения частей лабораторной работы
                {
                    case "1":
                        VirtualAndNonVirtualFunctions(cards);
                        break;
                    case "2":
                        ExecuteQueries(cards);
                        break;
                    case "3":
                        PrintObjectsAndOperations(cards);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите существующий пункт меню.");
                        break;
                }
            }
        }
        static void GenerateCards(BankCard[] cards)//Метод для формирования массива из карт разного вида
        {
            // Добавление 5 банковских карт
            for (int i = 0; i < 5; i++)
            {
                BankCard bcard = new BankCard();
                bcard.RandomInit();
                cards[i] = bcard;
            }

            // Добавление 5 дебетовых карт
            for (int i = 5; i < 10; i++)
            {
                DebitCard dcard = new DebitCard();
                dcard.RandomInit();
                cards[i] = dcard;
            }

            // Добавление 5 молодёжных карт
            for (int i = 10; i < 15; i++)
            {
                YouthCard ycard = new YouthCard();
                ycard.RandomInit();
                cards[i] = ycard;
            }

            // Добавление 5 кредитных карт
            for (int i = 15; i < 20; i++)
            {
                CreditCard ccard = new CreditCard();
                ccard.RandomInit();
                cards[i] = ccard;
            }
        }

        static void VirtualAndNonVirtualFunctions(BankCard[] cards)//Метод для демонстрации разницы между виртуальными и невиртуальными функциями
        {
            Console.WriteLine("\nВы выбрали выполнение виртуальных и невиртуальных функций.");

            Console.WriteLine("\nВыполнение виртуальной функции ShowUsual для каждой карты:");
            foreach (var card in cards)
            {
                card.ShowUsual();//печать всех элементов массива с помощью обычной функции ShowUsual
            }

            Console.WriteLine("\nВыполнение невиртуальной функции Show для каждой карты:");
            foreach (var card in cards)
            {
                card.Show();//печать всех элементов массива с помощью виртуально функции Show, которая позволяет просматривать добавленные поля в базовому классу
            }
        }

        static void ExecuteQueries(BankCard[] cards)//выполнение функций-запросов по варианту
        {
            Console.WriteLine("\nВы выбрали выполнение запросов:");

            // Получаем общий баланс всех дебетовых карт
            double totalDebitBalance = GetTotalDebitBalance(cards);
            Console.WriteLine($"Общий баланс всех дебетовых карт: {totalDebitBalance}");

            // Получаем среднюю сумму ежемесячных возвратов по доступным лимитам всех кредитных карт
            double averageMonthlyRepayments = GetAverageMonthlyRepayments(cards);
            Console.WriteLine($"Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт: {averageMonthlyRepayments}");

            //Получаем общую сумму возможного кэшбека по всем действующим молодёжным картам
            double totalYouthCashback = GetTotalYouthCashback(cards);
            Console.WriteLine($"Общая сумма возможного кэшбека по всем действующим молодёжным картам: {totalYouthCashback}%");
        }

        static void PrintObjectsAndOperations(BankCard[] cards)
        {
            Console.WriteLine("\nВы выбрали печать объектов и подсчет их количества, сортировка и клонирование:");
            // Инициализация счётчиков количества объектов разных типов
            int bankCardCount = 0;
            int debitCardCount = 0;
            int youthCardCount = 0;
            int creditCardCount = 0;
            int coordinatesCount = 0;

            // Создание массива для хранения всех объектов, включая карты и координаты
            IInit[] allcards = new IInit[25];
            for (int i = 0; i < 5; i++)
            {
                BankCard bcard = new BankCard();
                bcard.RandomInit();
                allcards[i] = bcard;
                bankCardCount++;
            }

            // Добавление 5 дебетовых карт
            for (int i = 5; i < 10; i++)
            {
                DebitCard dcard = new DebitCard();
                dcard.RandomInit();
                allcards[i] = dcard;
                debitCardCount++;
            }

            // Добавление 5 молодёжных карт
            for (int i = 10; i < 15; i++)
            {
                YouthCard ycard = new YouthCard();
                ycard.RandomInit();
                allcards[i] = ycard;
                youthCardCount++;
            }

            // Добавление 5 кредитных карт
            for (int i = 15; i < 20; i++)
            {
                CreditCard ccard = new CreditCard();
                ccard.RandomInit();
                allcards[i] = ccard;
                creditCardCount++;
            }

            // Добавление 5 кординат
            for (int i = 20; i < 25; i++)
            {
                GeoCoordinates сoord = new GeoCoordinates();
                сoord.RandomInit();
                allcards[i] = сoord;
                coordinatesCount++;
            }
            // Вывод всех объектов из массива, а также подсчёт количества объектов разных типов
            Console.WriteLine("\nМассив из карт и координат\n");
            foreach (var card in allcards)
            {
                if (card is BankCard)
                {
                    BankCard bankCard = (BankCard)card;
                    bankCard.Show();
                }
                else if (card is GeoCoordinates)
                {
                    GeoCoordinates coordinates = (GeoCoordinates)card;
                    coordinates.Show();
                }
            }
            // Вывод количества объектов разных типов
            Console.WriteLine("\nПодсчёт количества разных объектов");
            Console.WriteLine($"Всего банковских карт: {bankCardCount}");
            Console.WriteLine($"Всего дебетовых карт: {debitCardCount}");
            Console.WriteLine($"Всего молодёжных карт: {youthCardCount}");
            Console.WriteLine($"Всего кредитных карт: {creditCardCount}");
            Console.WriteLine($"Всего координатных точек: {coordinatesCount}\n");

            // Операции сортировки и клонирования
            Console.WriteLine("Сортировка и поиск");
            BankCard[] sortcards = new BankCard[20];
            GenerateCards(sortcards);//массив из сгенерированных рандомно элементов библиотеки класса

            Console.WriteLine("\nИсходный массив");
            foreach (BankCard b in sortcards)
            {
                b.Show();
            }

            // Сортировка массива по номеру карты
            Console.WriteLine("\nСортировка по номеру карты");
            Array.Sort(sortcards);
            foreach (BankCard b in sortcards)
            {
                b.Show();
            }

            // Поиск карты по номеру
            Console.WriteLine("\nВведите номер для поиска");
            string findNumber = Console.ReadLine();
            int pos = Array.BinarySearch(sortcards, new BankCard(findNumber, "", 0, 0));
            if (pos < 0) Console.WriteLine("Не найден");
            else
                Console.WriteLine($"Позиция: {pos + 1}");

            // Сортировка массива по сроку действия карты
            Console.WriteLine("\nСортировка по сроку действия карты");
            Array.Sort(sortcards, new SortByDate());
            foreach (BankCard b in sortcards)
            {
                b.Show();
            }
            // Поиск карты по году
            Console.WriteLine("\nВведите год для поиска");
            if (!int.TryParse(Console.ReadLine(), out int findYear))
            {
                Console.WriteLine("Неверный формат числа. Пожалуйста, введите целое число.");
                return;
            }

            int index = Array.BinarySearch(sortcards, new BankCard("", "", findYear, 0), new SortByDate());
            if (index < 0)
            {
                Console.WriteLine("Не найден");
            }
            else
            {
                Console.WriteLine($"Позиция: {index + 1}");
            }

            // Клонирование и копирование объектов
            Console.WriteLine("\nКлонирование и копирование");
            BankCard bacard = new BankCard();
            bacard.RandomInit();//создание рандомного объекта
            bacard.Show();
            BankCard copy = (BankCard)bacard.ShallowCopy();//моздание его копии
            copy.Show();
            BankCard clon = (BankCard)bacard.Clone();//создание его клона
            clon.Show();
            copy.id.num = 200;
            copy.Number = "copy" + bacard.Number;
            clon.id.num = 200;
            clon.Number = "clon" + bacard.Number;
            Console.WriteLine("\nПосле изменения");
            Console.WriteLine("\nИзначальный объект");
            bacard.Show();
            Console.WriteLine("\nКопирование");
            copy.Show();
            Console.WriteLine("\nКлонирование");
            clon.Show();
        }

        // 18. Общий баланс всех дебетовых карт.
        public static double GetTotalDebitBalance(BankCard[] cards)
        {
            double totalDebitBalance = 0;//присваивание сумме 0
            foreach (var card in cards)
            {
                if (card is DebitCard debitCard)
                {
                    totalDebitBalance += debitCard.Balance;//просматриваем весь массив и складываем баланс всех дебетовых карт
                }
            }
            return totalDebitBalance;
        }

        // 19. Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
        public static double GetAverageMonthlyRepayments(BankCard[] cards)
        {
            int count = 0;
            double sum = 0;

            foreach (var card in cards)
            {
                if (card is CreditCard creditCard && creditCard.RepaymentTerm > 0)
                {
                    sum += creditCard.Limit / creditCard.RepaymentTerm;
                    count++;
                }
            }
            return count > 0 ? sum / count : 0; // Избегаем деления на ноль
        }

        // 21. Общая сумма возможного кешбека по всем действующим молодёжным картам.
        public static double GetTotalYouthCashback(BankCard[] cards)
        {
            double totalYouthCashback = 0;//присваивание сумме 0
            foreach (var card in cards)
            {
                if (card is YouthCard youthCard)
                {
                    totalYouthCashback += youthCard.Cashback;//просматриваем весь массив и складываем кэшбек по всем молодёжным картам  
                }
            }
            return totalYouthCashback;
        }
    }
}