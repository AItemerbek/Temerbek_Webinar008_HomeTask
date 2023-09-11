// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Две матрицы можно перемножить если количество столбцов первой матрицы равно количеству строк второй матрицы.

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

int[,] MultiplyMatrix(int[,] arrayA, int[,] arrayB)
{
    int[,] multiplyArray = new int[arrayA.GetLength(0), arrayB.GetLength(1)];

    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            for (int k = 0; k < arrayA.GetLength(1); k++)
            {
                multiplyArray[i, j] += arrayA[i, k] * arrayB[k, j];
            }
        }
    }
    return multiplyArray;
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

bool MatrixMultiplicationPossibility(int rows,int columns)
{
    return rows == columns;
} 

Console.Clear();

int rowFirstArray = InputNum("Введите количество строк первой матрицы: ");
int colsFirstArray = InputNum("Введите количество столбцов первой матрицы: ");
int rowSecondtArray = InputNum("Введите количество столбцов второй матрицы: ");
int colsSecondtArray = InputNum("Введите количество столбцов второй матрицы: ");

if (MatrixMultiplicationPossibility(colsFirstArray,rowSecondtArray)) 
{
int min = InputNum("Введите минимальное значение диапазона (одинаково для двух матриц): ");
int max = InputNum("Введите максимальное значение диапазона (одинаково для двух матриц): ");

int[,] firstArray = Create2DArray(rowFirstArray, colsFirstArray);
int[,] secondArray = Create2DArray(rowSecondtArray, colsSecondtArray);

Fill2DArray(firstArray, min, max);
Print2DArray(firstArray);
Console.WriteLine();
Fill2DArray(secondArray, min, max);
Print2DArray(secondArray);
Console.WriteLine();
Console.WriteLine("Произведением двух матриц A и B будет матрица AB следующего вида: ");

Print2DArray(MultiplyMatrix(firstArray, secondArray));
}
else
Console.WriteLine($"Матрица размером [{rowFirstArray},{colsFirstArray}] не может быть умножена на матрицу размером [{rowSecondtArray},{colsSecondtArray}], т.к. количество стролбцов первой матрицы не равно количеству строк второй матрицы");
