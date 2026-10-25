using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1
{
    internal class Program
    {
        class Reagent
        {
            public string name;
            public sbyte oxidationNumber;
            public int count;
        }
        static void Main(string[] args)
        {
            Console.Clear();


            string result = "";
            Reagent firstReagent = new Reagent();
            Console.Write("Название первого вещества: ");
            firstReagent.name = Console.ReadLine();
            Console.Write("Введите степень окисления первого вещества: ");
            if (sbyte.TryParse(Console.ReadLine(), out firstReagent.oxidationNumber)) { }
            char[] firstNameArray = firstReagent.name.ToCharArray();

            Reagent secondReagent = new Reagent();
            Console.Write("Название второго вещества: ");
            secondReagent.name = Console.ReadLine();
            Console.Write("Введите степень окисления второго вещества: ");
            if (sbyte.TryParse(Console.ReadLine(), out secondReagent.oxidationNumber)) { }
            char[] secondNameArray = secondReagent.name.ToCharArray();
            firstReagent.name = "";
            secondReagent.name = "";
            firstReagent.count = 0;
            secondReagent.count = 0;

            for (int i = 0; i < firstNameArray.Length; i++)
            {
                if (char.IsDigit(firstNameArray[i]))
                {
                    firstReagent.count += Int32.Parse(firstNameArray[i].ToString());
                }
                else
                {
                    firstReagent.name += firstNameArray[i];
                }
            }
            for (int i = 0; i < secondNameArray.Length; i++)
            {
                if (char.IsDigit(secondNameArray[i]))
                {
                    secondReagent.count += Int32.Parse(secondNameArray[i].ToString());
                }
                else
                {
                    secondReagent.name += secondNameArray[i];
                }
            }


            //Console.WriteLine($"Первое вещество: {firstReagent.name}");
            //Console.WriteLine($"Количество атомов в первом веществе: {firstReagent.count}");

            //Console.WriteLine($"Второе вещество: {secondReagent.name}");
            //Console.WriteLine($"Количество атомов во втором веществе: {secondReagent.count}");


            if (Math.Sign(firstReagent.oxidationNumber) == Math.Sign(secondReagent.oxidationNumber))
            {
                Console.WriteLine("Невозможно провести реакцию!");
            }
            else
            {
                sbyte tempFirstOxNum = Math.Abs(firstReagent.oxidationNumber);
                sbyte tempSecondOxNum = Math.Abs(secondReagent.oxidationNumber);
                while (tempSecondOxNum != 0)
                {
                    sbyte temp = tempSecondOxNum;
                    tempSecondOxNum = (sbyte)(tempFirstOxNum % tempSecondOxNum);
                    tempFirstOxNum = temp;
                }
                sbyte nod = tempFirstOxNum;
                sbyte nok = (sbyte)((Math.Abs(firstReagent.oxidationNumber * secondReagent.oxidationNumber) / nod));
                firstReagent.count = nok / Math.Abs(firstReagent.oxidationNumber);
                secondReagent.count = nok / Math.Abs(secondReagent.oxidationNumber);
                //Console.WriteLine($"Nod: {nod}     Nok: {nok}");
                if ((firstReagent.count == 1) && (secondReagent.count == 1)) result = firstReagent.name + secondReagent.name;
                else if (firstReagent.count == 1) result = firstReagent.name + secondReagent.name + secondReagent.count;
                else if (secondReagent.count == 1) result = firstReagent.name + firstReagent.count + secondReagent.name;
                else result = firstReagent.name + firstReagent.count + secondReagent.name + secondReagent.count;

                Console.WriteLine($"Результат: {result}");
            }
            Console.ReadKey();
        }
    }
}
