using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace Homework
{
    abstract class Profession
    {
        public string Name { get; }
        public Profession(string name)
        {
            Name = name;
        }
        public void level() => Console.WriteLine($"Ваша профессия - {Name}. Приступайте к ее обязанностям");

    }
    public class Person
    {
        public string name { get; set; }
        public short age { get; set; }


    }
    public class Emploee : Person
    {
        public long nomer { get; }
        public string education { get; }
        public Emploee(string name, short age, long nomer, string education)
        {
            this.name = name;
            this.age = age;
            this.nomer = nomer;
            this.education = education;
        }
        public Emploee(string name, long nomer)
        {
            this.name = name;
            this.nomer = nomer;
        }
    }
    public class Drinked : Person
    {
        private string about_family { get; set; }
        private string relationship_problems { get; set; }
        public Drinked(string name, short age)
        {
            this.name = name;
            this.age = age;
        }

        public Drinked(string name, short age, string about_family, string relationship_problems)
        {
            this.name = name;
            this.age = age;
            this.about_family = about_family;
            this.relationship_problems = relationship_problems;
        }
    }
    class Hostes : Profession
    {
        public Hostes(string name) : base(name) { }
        public void Get_Information(StreamReader sr, ref List<string> people)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                people.Add(line);
            }

        }
        public void New_visitor(ref List<string> people)
        {
            Console.WriteLine();
            Console.WriteLine("Вам нужно встретить посетителей. Ваша должность-хостес");
            Console.WriteLine($"Вы уже пропустили {people.Count} людей:");
            foreach (string person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("Примите новых посетителей");
            string answer = "да";
            while (answer == "да")
            {
                Console.WriteLine("Пожалуйста, назовите свое имя в формате Фамилия-Имя-Отчество");
                people.Add(Console.ReadLine());
                Console.WriteLine("Пожалуйста, проходите за столик");
                Console.WriteLine("Вы: Добро пожаловать в наш ресторан! Желаете пообедать(да/собеседование?)");
                answer = Console.ReadLine();
            }
            if (answer == "собеседование")
            {
                JobInterview();
            }
            else
            {
                Console.WriteLine("Гости в зале:");
                foreach (string person in people)
                {
                    Console.WriteLine(person);
                }

            }
        }
        public void JobInterview()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте! Добро пожаловать на собеседование");
            Console.WriteLine("Введите свое ФИО");
            string name = Console.ReadLine();
            Console.WriteLine("Введите свой возраст: ");
            short age = short.Parse(Console.ReadLine());
            Console.WriteLine("Введите свой номер телефона: ");
            long nomer = long.Parse(Console.ReadLine());
            Console.WriteLine("Какое у вас образование? ");
            string education = Console.ReadLine();
            Console.WriteLine("Проверим ваши знания тестом");
            Random random = new Random();
            int test;
            test = random.Next(0, 101);
            Console.WriteLine($"Результат вашего теста: {test}");
            if (test >= 80)
            {
                Console.WriteLine("Поздравляем, вы приняты на работу");
                Emploee emploeeYes = new Emploee(name, age, nomer, education);
                List<Emploee> emploeesYes = new List<Emploee>();
                emploeesYes.Add(emploeeYes);
            }
            else
            {
                Console.WriteLine("Мы вам перезвоним");
                Emploee emploeeNo = new Emploee(name, nomer);
                List<Emploee> emploeesNo = new List<Emploee>();
                emploeesNo.Add(emploeeNo);
            }
        }
        public void WorkHostesEnd()
        {
            Console.WriteLine();
            Console.WriteLine($"Поздравляем, вы справились с должностью хостес.\nПереходим к следующей профессии");
            Console.WriteLine("Чтобы изменить профессию, нажмите на любую клавишу");
            Console.ReadLine();
            Console.Clear();
        }
        public void EnterH()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\restaurant.txt");
            List<string> people = new List<string>();
            Get_Information(sr, ref people);
            New_visitor(ref people);
            WorkHostesEnd();

        }
    }
    class Waiter : Profession
    {
        public Waiter(string name) : base(name) { }
        public void RandomGuest(List<string> people)
        {
            Console.WriteLine("Вам нужно обслужить посетителя ресторана");
            Random rnd = new Random();
            int randIndex = rnd.Next(people.Count);
            string NewGuest = people[randIndex];
            Console.WriteLine($"Посетитель, которого нужно обслужить - {NewGuest}");
        }
        public void Menu(ref List<string> menu)
        {
            StreamReader list = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\menu.txt");
            string line;
            while ((line = list.ReadLine()) != null)
            {
                menu.Add(line);
            }

        }
        public void PrintMenu()
        {
            List<string> menu = new List<string>();
            Menu(ref menu);
            foreach (string item in menu)
                Console.WriteLine(item);
        }
        public void AcceptOrder(ref string dish)
        {
            Console.WriteLine("Вы: Добро пожаловать в наш ресторан! Пожалуйста выберите что-то из меню");
            Console.WriteLine();
            PrintMenu();
            Console.WriteLine();
            dish = Console.ReadLine();
            Console.WriteLine("Вы: Ваш заказ принят, ожидайте");
        }
        public void EnterW()
        {
            Console.WriteLine("Теперь вы официант");
            string name2 = "Waiter";
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\restaurant.txt");
            List<string> people = new List<string>();
            Hostes people_list = new Hostes(name2);
            people_list.Get_Information(sr, ref people);
            RandomGuest(people);
            string dish = "";
            AcceptOrder(ref dish);
            Console.WriteLine($"Поздравляем, вы справились с должностью официант.\nПереходим к следующей профессии");
            Console.WriteLine("Чтобы изменить профессию, нажмите на любую клавишу");
            Console.ReadLine();
            Console.Clear();
        }
    }
    class Cook : Profession
    {
        public Cook(string name) : base(name) { }
        public void Dish1()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\resipe1.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        public void Dish2()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\resipe2.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        public void Dish3()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\resipe3.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        public void Dish4()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\resipe4.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        public void Dish5()
        {
            StreamReader sr = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\resipe5.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        public void EnterC()
        {
            string namee = "Waiter";
            Waiter povar = new Waiter(namee);
            List<string> menuu = new List<string>();
            povar.Menu(ref menuu);
            Random rnd = new Random();
            int randIndex = rnd.Next(menuu.Count);
            string dish = menuu[randIndex];
            Console.WriteLine($"Теперь вы повар ресторана\nЗаказ, который нужно приготовить \n{dish}");
            Console.WriteLine("В вашем ресторане проверка. Расскажите комиссии, как вы готовите блюдо, чтобы они убедились в качестве вашего приготовдения");
            if (dish == menuu[0])
            {
                Console.Write("Вы: ");
                Dish1();
            }
            else if (dish == menuu[1])
            {
                Console.Write("Вы: ");
                Dish2();
            }
            else if (dish == menuu[2])
            {
                Console.Write("Вы: ");
                Dish3();
            }
            else if (dish == menuu[3])
            {
                Console.Write("Вы: ");
                Dish4();
            }
            else if (dish == menuu[4])
            {
                Console.Write("Вы: ");
                Dish5();
            }
            Console.WriteLine($"Поздравляем, вы справились с должностью повар.\nПереходим к следующей профессии");
            Console.WriteLine("Чтобы изменить профессию, нажмите на любую клавишу");
            Console.ReadLine();
            Console.Clear();
        }
    }
    class Barman : Profession
    {
        public Barman(string name) : base(name) { }

        public void Drinker()
        {
            Console.WriteLine("Вам нужно обслужить посетителя ресторана");
            StreamReader drink = new StreamReader(@"C:\Users\farra\OneDrive\Рабочий стол\Drinkers.txt");
            List<string> drinkers = new List<string>();
            string line;
            while ((line = drink.ReadLine()) != null)
            {
                drinkers.Add(line);
            }
            Random rnd = new Random();
            int randIndex = rnd.Next(drinkers.Count);
            string Drinker = drinkers[randIndex];
            Console.WriteLine($"Посетитель, которого нужно обслужить - {Drinker}");
        }
        public void Sober()
        {
            Console.WriteLine("Гость немного пьян. Он не очень хочет разговаривать");
            Console.WriteLine("Вы: Как вас зовут");
            string name = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            short age = short.Parse(Console.ReadLine());
            Drinked sober_person = new Drinked(name, age);
            List<Drinked> sobers = new List<Drinked>();
            sobers.Add(sober_person);
        }
        public void Drunk()
        {
            Console.WriteLine("Гость сильно пьян. Он очень хочет с вами поговорить");
            Console.WriteLine("Вы: Как вас зовут?");
            string name = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            short age = short.Parse(Console.ReadLine());
            Console.WriteLine("Можетe расскажете что-то о семье?");
            string about_family = Console.ReadLine();
            Console.WriteLine("Какие у вас отношения с семьей?");
            string relationship_problems = Console.ReadLine();
            Drinked drunk_person = new Drinked(name, age, about_family, relationship_problems);
            List<Drinked> drunk = new List<Drinked>();
            drunk.Add(drunk_person);
        }
        public void HowDrink()
        {
            Console.WriteLine("Введите, какое количество литров алкоголя выпил посетитель");
            short how_much_drink = short.Parse(Console.ReadLine());
            if (how_much_drink < 2)
            {
                Sober();
            }
            else
            {
                Drunk();
            }
        }
        public void EnterB()
        {
            Console.WriteLine("Теперь вы бармен");
            Drinker();
            HowDrink();
            Console.WriteLine($"Поздравляем, вы справились с должностью бармен");
            Console.WriteLine("Чтобы выйти, нажмите на любую клавишу");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Поздравляем! Вы прошли все профессии. Спасибо за участие в дне самоуправления!");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в ресторан сети KFU-restaurants!\nСегодня день самоуправления. Побудьте сотрудником нашего ресторана!");
            string name1 = "Hostes";
            Hostes op1 = new Hostes(name1);
            op1.EnterH();
            string name2 = "Waiter";
            Waiter op2 = new Waiter(name2);
            op2.EnterW();
            string name3 = "Cook";
            Cook op3 = new Cook(name3);
            op3.EnterC();
            string name4 = "Barman";
            Barman op4 = new Barman(name4);
            op4.EnterB();
        }
    }
}
