// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение 
//            двух матриц.
// Уточнение задания:
// 1. Количество строк и столбцов матриц задаётся пользователем.
// 2. Значения элементов - целые числа.
// 3. Значения элементов матриц задаются рандомно из диапазона от -99 до 99.
// 4. Вывод на экран исходных матриц и их произведения производится автоматически. 


void TitleInputErrorMessage()
{
    Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! ");
}

void PrintErrorMessageEnterNumber (string userNumber, string definitionNumber)
{
    TitleInputErrorMessage();
    Console.Write($"Введённое Вами значение: {userNumber},");
    Console.WriteLine($" не является {definitionNumber} числом.");
}

int CheckNaturalNumbers (string messageForUser)
{
    int number = 0, i = 0;
    string userNumber = string.Empty;
    string definitionNumber = "натуральным";
    bool success = false;
    while(i == 0) 
    {
        Console.Write(messageForUser);
        userNumber = Console.ReadLine();
        success = int.TryParse(userNumber, out number);
        if(success)
        {
            number = int.Parse(userNumber);
            if(number > 0) i = 1;
            else PrintErrorMessageEnterNumber(userNumber, definitionNumber); 
        }
        else 
        {
            PrintErrorMessageEnterNumber(userNumber, definitionNumber);
        } 
        Console.WriteLine();
    }
    return number;
}

int EnterIntegerNumber(string text1, string text2, string text3)
{
    string messegeForUser = string.Empty;
    messegeForUser = $"Введите {text1} {text2} {text3}: ";
    int result = CheckNaturalNumbers(messegeForUser); 
    return result; 
}

void FillArrayRandom(int[,] createArray)
{
    for (int i = 0; i < createArray.GetLength(0); i++)
        for (int j = 0; j < createArray.GetLength(1); j++)
            createArray[i, j] = new Random().Next(-99, 100);
}

void FillMatrixProduct(int[,] createArray, int[,] firstArray, int[,] secondArray)
{
    for (int i = 0; i < createArray.GetLength(0); i++)
    {
        for (int j = 0; j < createArray.GetLength(1); j++)
        {
            int scalarProduct = 0;
            for (int k = 0; k < firstArray.GetLength(1); k++)
            {
                scalarProduct = scalarProduct + firstArray[i, k] * secondArray[k, j];
            } 
            createArray[i, j] = scalarProduct;
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j], 8} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.WriteLine("Программа умножения матриц.");
int rowA, columnA, rowB, columnB, rowC, columnC;
string text1 = string.Empty, text2 = string.Empty, text3 = string.Empty;
Console.WriteLine("Задайте количество строк и столбцов матрицы A.");
text1 = "количество"; text2 = "строк"; text3 = "матрицы A";
rowA = EnterIntegerNumber(text1, text2, text3);
text2 = "столбцов";
columnA = EnterIntegerNumber(text1, text2, text3); 
int[,] arrayA = new int[rowA, columnA];
Console.WriteLine($"Размерность матрицы A ({rowA} x {columnA}).");
Console.WriteLine("Умножение матриц возможно, если количество стролбцов " + 
                    "одной матрицы равно количеству строк другой матрицы.");
text1 = "количество"; text2 = "строк"; text3 = "матрицы B";
rowB = EnterIntegerNumber(text1, text2, text3);
if(rowB != columnA)
{
    Console.WriteLine("Количество строк матрицы B не равно количеству столбцов матрицы A.");
    Console.WriteLine("Для возможности умножения матриц, количество стролбцов матрицы B " + 
                    $"автоматически задаётся равным количеству строк матрицы A: {rowA}.");
    columnB = rowA;
    rowC = rowB; columnC = columnA;
}
else
{
    Console.WriteLine("Количество строк матрицы B равно количеству столбцов матрицы A.");
    text2 = "столбцов";
    columnB = EnterIntegerNumber(text1, text2, text3); 
    rowC = rowA; columnC = columnB;
}
int[,] arrayB = new int[rowB, columnB];
FillArrayRandom(arrayA);
Console.WriteLine($"Задана матрица A ({rowA} x {columnA}):");
PrintArray(arrayA);
FillArrayRandom(arrayB);
Console.WriteLine($"Задана матрица B ({rowB} x {columnB}):");
PrintArray(arrayB);
Console.WriteLine($"Произведение матриц A и B является матрицей ({rowC} x {columnC}):");
int[,] arrayC = new int[rowC, columnC];
if(columnB == rowA) 
{
    FillMatrixProduct(arrayC, arrayB, arrayA);
}
else 
{
    FillMatrixProduct(arrayC, arrayA, arrayB);
}
PrintArray(arrayC);
