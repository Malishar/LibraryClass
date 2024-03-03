using LibraryClass;
using la_10;
using System.Runtime.InteropServices;

namespace TestCsrd
{
    [TestClass]

    //Тестирование BankCard
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            int num = 123;

            // Act
            IdNumber idNumber = new IdNumber(num);

            // Assert
            Assert.AreEqual(num, idNumber.num);
        }

        [TestMethod]
        public void TestToString()
        {
            // Arrange
            int num = 456;
            IdNumber idNumber = new IdNumber(num);
            string expected = num.ToString();

            // Act
            string actual = idNumber.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParametrNull()
        {
            // Arrange
            BankCard original = new BankCard("0", "NoName", 0, 0);

            // Act
            BankCard card = new BankCard();
            // Assert
            Assert.AreEqual(original, card);
        }

        [TestMethod]
        public void ParametrCopy()
        {
            // Arrange
            BankCard originalCard = new BankCard("123456789", "John Doe", 2024, 100);

            // Act
            BankCard copiedCard = new BankCard(originalCard);

            // Assert
            Assert.AreEqual(originalCard, copiedCard);
        }

        [TestMethod]
        public void NumberProperty()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Number = "1000 0000 0000 0000";

            // Assert
            Assert.AreEqual("1000 0000 0000 0000", card.Number);
        }

        [TestMethod]
        public void OwnerProperty()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Owner = "Иван Морозов";

            // Assert
            Assert.AreEqual("Иван Морозов", card.Owner);
        }

        [TestMethod]
        public void DatePropertyCorrectly()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Date = 2024;

            // Assert
            Assert.AreEqual(2024, card.Date);
        }

        [TestMethod]
        public void DatePropertyWrong()
        {
            // Arrange
            BankCard card = new BankCard();

            // Act
            card.Date = -2024;

            // Assert
            Assert.AreEqual(0, card.Date); // Убедимся, что значение не изменилось
        }






        [TestMethod]
        public void CloneEqualOriginal()
        {
            // Arrange
            BankCard original = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1001);

            // Act
            BankCard cloned = (BankCard)original.Clone();

            // Assert
            Assert.AreEqual(original, cloned);
        }

        [TestMethod]
        public void CopyEqualOriginal()
        {
            // Arrange
            BankCard original = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1001);

            // Act
            BankCard copied = (BankCard)original.ShallowCopy();

            // Assert
            Assert.AreEqual(original, copied);
        }

        [TestMethod]
        public void EqualsObjects()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 100);
            BankCard card2 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 100);

            // Act
            bool result = card1.Equals(card2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Not_EqualsObjects()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 100);
            BankCard card2 = new BankCard("1000 0000 0000 1000", "Пётр Морозов", 2022, 101);

            // Act
            bool result = card1.Equals(card2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_ReturnsFalseForNullObject()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1001);

            // Act
            bool result = card1.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CompareTo_ForNullObject()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 101);

            // Act
            int result = card1.CompareTo(null);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareTo_ForNonBankCard()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 101);
            object obj = new object();

            // Act
            int result = card1.CompareTo(obj);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareTo_ZeroForEqualObjects()
        {
            // Arrange
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 101);
            BankCard card2 = new BankCard("1000 0000 0000 0000", "Пётр Морозов", 2023, 102);

            // Act
            int result = card1.CompareTo(card2);

            // Assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void Equals_ReturnsTrueForEqualIdNumbers()
        {
            // Arrange
            IdNumber id1 = new IdNumber(101);
            IdNumber id2 = new IdNumber(101);

            // Act
            bool result = id1.Equals(id2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentIdNumbers()
        {
            // Arrange
            IdNumber id1 = new IdNumber(101);
            IdNumber id2 = new IdNumber(102);

            // Act
            bool result = id1.Equals(id2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_FalseForNullObject()
        {
            // Arrange
            IdNumber id = new IdNumber(1001);

            // Act
            bool result = id.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_FalseForDifferentObject()
        {
            // Arrange
            IdNumber id = new IdNumber(1001);
            object obj = new object();

            // Act
            bool result = id.Equals(obj);

            // Assert
            Assert.IsFalse(result);
        }


        //Тестирование CreditCard

        [TestMethod]
        public void LimitPropertyCorrectly()
        {
            // Arrange
            CreditCard card = new CreditCard();

            // Act
            card.Limit = 5000;

            // Assert
            Assert.AreEqual(5000, card.Limit);
        }

        [TestMethod]
        public void LimitPropertyWrong()
        {
            // Arrange
            CreditCard card = new CreditCard();
            card.Limit = 5000; 

            // Act
            card.Limit = -2000;

            // Assert
            Assert.AreEqual(5000, card.Limit); 
        }

        [TestMethod]
        public void RepaymentTermPropertyCorrectly()
        {
            // Arrange
            CreditCard card = new CreditCard();

            // Act
            card.RepaymentTerm = 12;

            // Assert
            Assert.AreEqual(12, card.RepaymentTerm);
        }

        [TestMethod]
        public void RepaymentTermPropertyWrong()
        {
            // Arrange
            CreditCard card = new CreditCard();
            card.RepaymentTerm = 12; 

            // Act
            card.RepaymentTerm = 0;

            // Assert
            Assert.AreEqual(12, card.RepaymentTerm); 
        }

        [TestMethod]
        public void CreditCardConstructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            string number = "1000 0000 0000 0000";
            string owner = "Иван Морозов";
            int date = 2024;
            int idNumber = 1;
            double limit = 5000;
            int repaymentTerm = 12;

            // Act
            CreditCard card = new CreditCard(number, owner, date, idNumber, limit, repaymentTerm);

            // Assert
            Assert.AreEqual(number, card.Number);
            Assert.AreEqual(owner, card.Owner);
            Assert.AreEqual(date, card.Date);
            Assert.AreEqual(idNumber, card.id.num);
            Assert.AreEqual(limit, card.Limit);
            Assert.AreEqual(repaymentTerm, card.RepaymentTerm);
        }

        //Тестирование DebitCard

        [TestMethod]
        public void NullConstructor()
        {
            // Arrange & Act
            DebitCard card = new DebitCard();

            // Assert
            Assert.AreEqual(0, card.Balance);
        }

        [TestMethod]
        public void ParameterizedConstructor()
        {
            // Arrange
            string number = "1000 0000 0000 0000";
            string owner = "Иван Морозов";
            int date = 2024;
            int idNumber = 1;
            double balance = 1000;

            // Act
            DebitCard card = new DebitCard(number, owner, date, idNumber, balance);

            // Assert
            Assert.AreEqual(number, card.Number);
            Assert.AreEqual(owner, card.Owner);
            Assert.AreEqual(date, card.Date);
            Assert.AreEqual(idNumber, card.id.num);
            Assert.AreEqual(balance, card.Balance);
        }

        [TestMethod]
        public void BalanceNegative()
        {
            // Arrange
            DebitCard card = new DebitCard();

            // Act
            card.Balance = -100;

            // Assert
            Assert.AreEqual(0, card.Balance); 
        }


        [TestMethod]
        public void BalancePositive()
        {
            // Arrange
            DebitCard card = new DebitCard();

            // Act
            card.Balance = 100;

            // Assert
            Assert.AreEqual(100, card.Balance);
        }


        //Тестирование YouthCard
        [TestMethod]
        public void CashbackPositive()
        {
            // Arrange
            YouthCard card = new YouthCard();

            // Act
            card.Cashback = 10;

            // Assert
            Assert.AreEqual(10, card.Cashback);
        }

        [TestMethod]
        public void CashbackNegative()
        {
            // Arrange
            YouthCard card = new YouthCard();

            // Act
            card.Cashback = -5;

            // Assert
            Assert.AreEqual(0, card.Cashback); 
        }

        [TestMethod]
        public void CashbackBiggerThan100()
        {
            // Arrange
            YouthCard card = new YouthCard();

            // Act
            card.Cashback = 150;

            // Assert
            Assert.AreEqual(0, card.Cashback); 
        }

        [TestMethod]
        public void YouthCard_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string number = "1000 0000 0000 0000";
            string owner = "Иван Морозов";
            int date = 2024;
            int num = 1001;
            double cashback = 5.0;

            // Act
            YouthCard card = new YouthCard(number, owner, date, num, cashback);

            // Assert
            Assert.AreEqual(number, card.Number);
            Assert.AreEqual(owner, card.Owner);
            Assert.AreEqual(date, card.Date);
            Assert.AreEqual(num, card.id.num);
            Assert.AreEqual(cashback, card.Cashback);
        }


        [TestMethod]
        public void SortByDateSameDate()
        {
            // Arrange
            SortByDate comparer = new SortByDate();
            BankCard card1 = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1);
            BankCard card2 = new BankCard("2000 0000 0000 0000", "Пётр Морозов", 2023, 2);

            // Act
            int result = comparer.Compare(card1, card2);

            // Assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void SortByDate_EarlierDate()
        {
            // Arrange
            SortByDate comparer = new SortByDate();
            BankCard earlierDateCard = new BankCard("1000 0000 0000 0000", "Иван Морозов", 2022, 1);
            BankCard laterDateCard = new BankCard("1000 0000 0000 0000", "Пётр Морозов", 2024, 2);

            // Act
            int result = comparer.Compare(earlierDateCard, laterDateCard);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Compare_ReturnsOne_WhenFirstDateIsLater()
        {
            // Arrange
            var comparer = new SortByDate();
            var card1 = new BankCard("", "", 2023, 1);
            var card2 = new BankCard("", "", 2022, 2);

            // Act
            int result = comparer.Compare(card1, card2);

            // Assert
            Assert.AreEqual(1, result);
        }

        //тестирование класса Program
        [TestMethod]
        public void DebitBalance_AllCards()
        {
            // Arrange
            BankCard[] cards = new BankCard[0];

            // Act
            double totalDebitBalance = Program.GetTotalDebitBalance(cards);

            // Assert
            Assert.AreEqual(0, totalDebitBalance);
        }

        [TestMethod]
        public void DebitBalance_NonDebitCards()
        {
            // Arrange
            BankCard[] cards = new BankCard[]
            {
                new BankCard("1000 0000 0000 0000", "Иван Морозов", 2022, 1),
                new CreditCard("2000 0000 0000 0000", "Алексей Смирнов", 2024, 2, 5000, 12),
                new YouthCard("3000 0000 0000 0000", "Пётр Сидоров", 2023, 3, 5)
            };

            // Act
            double totalDebitBalance = Program.GetTotalDebitBalance(cards);

            // Assert
            Assert.AreEqual(0, totalDebitBalance);
        }

        [TestMethod]
        public void DebitBalance()
        {
            // Arrange
            BankCard[] cards = new BankCard[]
            {
                new DebitCard("1000 0000 0000 0000", "Иван Морозов", 2022, 1, 1000),
                new DebitCard("2000 0000 0000 0000", "Алексей Смирнов", 2024, 2, 2000),
                new DebitCard("3000 0000 0000 0000", "Пётр Сидоров", 2023, 3, 1500)
            };

            // Act
            double totalDebitBalance = Program.GetTotalDebitBalance(cards);

            // Assert
            Assert.AreEqual(1000 + 2000 + 1500, totalDebitBalance);
        }

        [TestMethod]
        public void GetAverageMonthlyRepayments_NoCreditCards()
        {
            // Arrange
            BankCard[] cards = new BankCard[]
            {
                new BankCard("1000 0000 0000 0000", "Иван Морозов", 2024, 1),
                new BankCard("2000 0000 0000 0000", "Алексей Морозов", 2025, 2)
            };

            // Act
            double averageRepayment = Program.GetAverageMonthlyRepayments(cards);

            // Assert
            Assert.AreEqual(0, averageRepayment);
        }

        [TestMethod]
        public void GetCashback_NoYouthCards()
        {
            // Arrange
            BankCard[] cards = new BankCard[]
            {
            new BankCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1),
            new BankCard("2000 0000 0000 0000", "Алексей Морозов", 2024, 2),
            new BankCard("3000 0000 0000 0000", "Пётр Морозов", 2025, 3),
            };

            // Act
            double totalCashback = Program.GetTotalYouthCashback(cards);

            // Assert
            Assert.AreEqual(0, totalCashback);
        }

        [TestMethod]
        public void GetCashback_YouthCardsExist()
        {
            // Arrange
            BankCard[] cards = new BankCard[]
            {
            new YouthCard("1000 0000 0000 0000", "Иван Морозов", 2023, 1, 10.0),
            new BankCard("2000 0000 0000 0000", "Алексей Морозов", 2024, 2),
            new YouthCard("3000 0000 0000 0000", "Пётр Морозов", 2025, 3, 15.0),
            };

            // Act
            double totalCashback = Program.GetTotalYouthCashback(cards);

            // Assert
            Assert.AreEqual(25.0, totalCashback);
        }
    }
}