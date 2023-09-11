// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


// сгененрируем массив двухзначных чисел
int[] GetNumbers()
{
    int length = 90; // 100 - 10 = 90, общее число двухзначных чисел
    int[] numbersList = new int[length];
    for (int i = 10; i < 100; i++)
    {
        numbersList[i - 10] = i;
    }
    return numbersList;
}

// перемешиваем сгенерированный массив
int[] mixArray(int[] array)
{
    Random rnd = new Random();
    int temp = 0;
    for (int i = array.Length - 1; i >= 1; i--)
    {
        int j = rnd.Next(i + 1);
        // меняем array[j] и array[i]
        temp = array[j];
        array[j] = array[i];
        array[i] = temp;
    }
    return array;
}

// заполняем новый трехмерный массив 2 X 2 X 2

int[,,] Fill3DArray(int[] array)
{
    int[,,] new3DMatrix = new int[2, 2, 2];
    int index = 0;
    for (int i = 0; i < new3DMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < new3DMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < new3DMatrix.GetLength(2); k++)
            {
                new3DMatrix[i, j, k] = array[index];
                index++;
            }
        }
    }
    return new3DMatrix;
}

void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k})\t");
            }
            Console.WriteLine();
        }
    }
}

Console.Clear();
int[] newRandomNums = mixArray(GetNumbers());
Print3DArray(Fill3DArray(newRandomNums));

