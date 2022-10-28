using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    enum AccountType
    {
        Текущий,
        Сберегательный
    }
    class Bank
    {
        public Bank(string accountNumber, double balans, AccountType type)
        {
            AccountNumber = accountNumber;
            Balans = balans;
            Type = type;
        }
        private string AccountNumber { get; set; }
        public double Balans { get; set; }
        public AccountType Type { get; set; }
        public override string ToString() => $"Номер счета - {AccountNumber}, Баланс - {Balans}, Тип банковского счета - {Type}";

        public double PutOnAccount(double Balans)
        {
            Console.Write("Введите сумму для пополнения ");
            double temp = Convert.ToDouble(Console.ReadLine());
            return Balans + temp;
        }
        public double WithdrawFromAccount(double Balans)
        {
            Console.Write("Введите сумму для снятия ");
            double temp = Convert.ToDouble(Console.ReadLine());
            if (Balans >= temp)
            {
                return Balans - temp;
            }
            else
            {
                Console.WriteLine("На вашем счёте недостаточно средств!");
                return Balans;
            }
        }

    }
    class Building
    {
        private int numb;
        public int Numb
        {
            get => numb;
            set => numb = value;
        }
        private ushort height;
        public ushort Height
        {
            get => height;
            set => height = value;
        }
        private byte numberOfFloors;
        public byte Floors
        {
            get => numberOfFloors;
            set => numberOfFloors = value;
        }
        private ushort numberOfFlats;
        public ushort Flats
        {
            get => numberOfFlats;
            set => numberOfFlats = value;
        }
        private byte numberOfEntrance;
        public byte Entrance
        {
            get => numberOfEntrance;
            set => numberOfEntrance = value;
        }
        static Random r = new Random();
        public static int generic_number = r.Next(1000);
        public Building(int n, ushort h, byte floors, ushort flats, byte entrances)
        {
            this.numb = n;
            this.height = h;
            this.numberOfFloors = floors;
            this.numberOfFlats = flats;
            this.numberOfEntrance = entrances;
        }
        public int FloorHeight(ushort h, byte f)
        {
            int temp = h / f;
            return temp;
        }
        public int FlatsInEntrance(ushort f, byte e)
        {
            int temp = f / e;
            return temp;
        }
        public int FlatsOnFloor(ushort flats, byte e, byte floors)
        {
            int temp = (flats / e) / (floors - 1);
            return temp;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание 7.1");
            AccountType accountType = AccountType.Текущий;
            Console.WriteLine(accountType);
            Bank bank = new Bank("13154678", 100000, AccountType.Сберегательный);
            Console.WriteLine(bank);

            Console.WriteLine("Задание 7.2");
            AccountType accountType1 = AccountType.Сберегательный;
            Console.WriteLine(accountType1);
            Random rnd = new Random();
            int AccountNumber1 = rnd.Next(1000, 100000);
            string AccountNumber11 = AccountNumber1.ToString();
            Bank bank1 = new Bank(AccountNumber11, 108800, AccountType.Сберегательный);
            Console.WriteLine(bank1);

            Console.WriteLine("Задание 7.3");
            Random rnd1 = new Random();
            int AccountNumber2 = rnd1.Next(1000, 100000);
            string AccountNumber12 = AccountNumber2.ToString();
            Bank bank2 = new Bank(AccountNumber12, 108800, AccountType.Текущий);
            Console.WriteLine("Что хотите сделать со своим балансом?");
            Console.WriteLine("1: Снять");
            Console.WriteLine("2: Пополнить");
            int userChoose;
            if (!int.TryParse(Console.ReadLine(), out userChoose))
            {
                Console.WriteLine("Операция некорректна");
            }
            if (userChoose == 1)
            {
                bank2.Balans = bank2.WithdrawFromAccount(bank2.Balans);
                Console.WriteLine(bank2);
            }
            else
            {
                bank2.Balans = bank2.PutOnAccount(bank2.Balans);
                Console.WriteLine(bank2);
            }

            Console.WriteLine("Домашнее задание");
            Building building = new Building(1, 45, 18, 120, 7);
            Console.WriteLine($"Высота одного этажа {building.FloorHeight(building.Height, building.Floors)} метра, количество квартир в подъезде: {building.FlatsInEntrance(building.Flats, building.Entrance)}, количество квартир на этаже: {building.FlatsOnFloor(building.Flats, building.Entrance, building.Floors)}");
        }
    }
}