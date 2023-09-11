// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int InputNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] Create2DArray(int rows, int columns)
{
    return new int[rows, columns];
}

void Fill2DArray(int[,] array, int minValue, int maxValue)
{
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(minValue, maxValue + 1);
}

int[] SumRowArray(int[,] array)
{
    int[] rowSumArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            rowSumArray[i] += array[i, j];
        }
    }
    return rowSumArray;
}

int MinimalRow(int[] array)
{
    int min = array[0];
    int indexMinRow = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
            indexMinRow = i + 1;
        }
    }
    return indexMinRow;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]}\t");
        Console.WriteLine();
    }
}

bool taskTest(int num1, int num2)
{
    return num1 != num2;
}

Console.Clear();

Console.WriteLine("Для корректоной работы введите значения строк и столбцов прямоугольного массива");

int rows = InputNum("Введите количество строк: ");
int cols = InputNum("Введите количество столбцов: ");

if (taskTest(rows,cols)) 
{
    int min = InputNum("Введите минимальное значение диапазона: ");
    int max = InputNum("Введите максимальное значение диапазона: ");
    Console.WriteLine();

    int[,] rectangularArray = Create2DArray(rows, cols);

    Fill2DArray(rectangularArray, min, max);
    Print2DArray(rectangularArray);
    Console.WriteLine();
    int[] sumRowList = SumRowArray(rectangularArray);
    Console.WriteLine($"Номер строки с минимальной суммой значений равняется {MinimalRow(sumRowList)}");

}
else
Console.WriteLine("Заданный массив будет квадратным и не соответсвует условиям задачи. Запустите программу заново и введите корректные значения строк и столбцов");


