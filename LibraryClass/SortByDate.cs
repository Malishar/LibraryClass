using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass
{
    public class SortByDate : IComparer
    {
        public int Compare(object? x, object? y)
        {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            BankCard b1 = (BankCard)x;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            BankCard b2 = (BankCard)y;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            if (b1.Date < b2.Date) return -1;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            else
                if (b1.Date == b2.Date) return 0;
            else
                return 1;
        }
    }
}
