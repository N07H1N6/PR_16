//********************************************************************************************
//*Практическая работа №16                                                                   *   
//* Выполнил: Кондаков.П.А.,группа 2ИСП                                                      *
//* Задание: Изучить приемы работы с файлами и способы создания файлов.                      *
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PR_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath;//строка для хранения файла
            int n = 0;//n - количество чисел

            Console.WriteLine("Практаческая работа №16.");
            Console.WriteLine("Введите путь к сохраненному файлу и укажите имя файла,\n\tнапример:D:\\MyProgram\\PR_16.txt");
            filepath = Console.ReadLine();
            try
            {
                //создание нового экземпляра объекта StreamReader и передача пути к файлу в конструктор
                FileStream F = File.Create(filepath);
                StreamWriter writer = new StreamWriter(F);//создание файловой переменнойбпоток для записи в файл
                Console.Write("Введите количество чисел,n = ");
                n = Convert.ToInt32(Console.ReadLine());
                Random rnd = new Random();
                int m = 11;
                int[] nums = new int[n];
                for (int i = 0; i < n; i++)//цикл для перебора нужного количества строк
                {
                    int a = rnd.Next((int)-5.00, (int)10.11);
                    nums[i] = a;
                    writer.Write(a + " ");//запись значения в поток
                    if (a < m && a % 2 == 0)//вычисление наименьшего четного значения m
                    {
                        m = a;
                    }
                    
                }
                writer.Close();//закрытие потока 
                
                if (m == 11)//проверка на четность числа
                {
                    throw new Exception("Минимальное четное число не найдено");
                }
                Console.WriteLine("Наименьший четный элемент m:"+ m);

                Console.WriteLine("Увеличенные значения на m :");
                for (int i = 0; i < nums.Length; i++)//увеличение значения на m
                {
                    nums[i] += m;
                    Console.Write(String.Format("{0}", nums[i]+" "));
                }
                
            }
            catch (IOException e)//обработка исключений типа IOException
            {
                Console.WriteLine("Ошибка открытия файла для записи.Проверьте местоположения файла!\n");
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка:{0}", e.Message);
            }
            int[] mas = new int[n];//массив для считывания данных            
            try
            {                
                Console.WriteLine("\nСодержимое файла {0}: ", filepath);
                FileStream F1 = File.OpenRead(filepath);
                StreamReader reader = new StreamReader(F1);//создание файловой переменнойбпоток для чтение данных         
                string s = reader.ReadLine();
                s = s.TrimEnd(' ');//удаление пробела в конце строки
                string[] text = s.Split(' ');//разбиение строки на подстроки
                for (int j = 0; j < text.Length; j++)
                {
                    mas[j] = Convert.ToInt32(text[j]);//заполнение массива данниых из потока
                }                   
                F1.Close();
            }
            catch (IOException e)//обработка исключений типа IOException
            {
                Console.WriteLine("Ошибка открытия файла для записи.Проверьте местоположения файла!\n");
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка:{0}", e.Message);
            }
            foreach (int element in mas)//вывод массива на экран
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
    }
}



