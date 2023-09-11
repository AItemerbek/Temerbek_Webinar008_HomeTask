// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int InputNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] SpiralArray(int row, int column)
{
    int[,] newSpiralArray = new int[row, column];
    int rowIndex = 0;
    int columnIndex = 0;
    int rightBorder = 0;
    int leftBorder = 0;
    int downBorder = 0;
    int upBorder = 0;
    string direction = "right";

    for (int i = 1; i <= row*column; i++)
    {
        // двигаемся вправо
        if (direction == "right")
        {
            if (columnIndex < column - rightBorder)
            {
                newSpiralArray[rowIndex, columnIndex] = i;
                columnIndex++;
                continue;
            }
            else
            {
                columnIndex--;
                upBorder++;
                rowIndex++;
                direction = "down";
            }
        }
        // двигаемся вниз
        if (direction == "down")
        {
            if (rowIndex < row - downBorder)
            {
                newSpiralArray[rowIndex, columnIndex] = i;               
                rowIndex++;
                continue;
            }
            else
            {
                rowIndex--;
                rightBorder++;
                columnIndex--;
                direction = "left";
            }
        }
        // двигаемся влево
        if (direction == "left")
        {
            if (columnIndex >= 0 + leftBorder)
            {
                newSpiralArray[rowIndex, columnIndex] = i;
                columnIndex--;
                continue;
            }
            else
            {
                columnIndex++;
                downBorder++;
                rowIndex--;
                direction = "up";
            }
        }
        // двигаемся вверх
        if (direction == "up")
        {
            if (rowIndex >= 0 + upBorder)
            {
                newSpiralArray[rowIndex, columnIndex] = i;
                rowIndex--;
                continue;
            }
            else
            {
                rowIndex++;
                leftBorder++;
                columnIndex++;
                direction = "right";
                // уменьшаем счетчик циккла на 1, т.к это последнее условие цикла, и если он не выполнится, то массив пропустит одно значение.
                i--;
            }
        }

    }
    return newSpiralArray;
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

// проверка на ввод размерности матрицы для спирального заполнения

bool ChangeDefoults(int num)
{
    return num != 0;
}

Console.Clear();
int answerNum = InputNum("Ведите '0' для выполнения задачи с матрицей 4 Х 4 или любую цифру для выбора размера матрицы: ");

int rows = 4;
int columns = 4;

if (ChangeDefoults(answerNum))
{
    rows = InputNum("Введите количество строк:");
    columns = InputNum("Введите количество столбцов: ");
}

    int[,] newArray = SpiralArray(rows,columns);

    Print2DArray(newArray);


