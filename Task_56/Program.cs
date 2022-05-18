// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
//            находить строку с наименьшей суммой элементов.
// Уточнение задания:
// 1. Количество строк и столбцов массива задаётся пользователем.
// 2. Значения элементов - целые числа.
// 3. Значения элементов массива задаются рандомно из диапазона от -999 до 999.
// 4. Номера строк для вывода на экран нумеруются начиная с "1". 
// 5. Вывод на экран массива  и номера искомой строки производится автоматически.


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
            createArray[i, j] = new Random().Next(-999, 1000);
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j], 4} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

int row, column;
string text1 = string.Empty, text2 = string.Empty, text3 = string.Empty;
text1 = "количество"; text2 = "строк"; text3 = "массива";
row = EnterIntegerNumber(text1, text2, text3);
text2 = "столбцов";
column = EnterIntegerNumber(text1, text2, text3); 
int[,] array = new int[row, column];
FillArrayRandom(array);
PrintArray(array);
int rowMinSum =0, sumElements = 0;
for (int i = 0; i < array.GetLength(0); i++)
{
    int sumCurrentRow = 0;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        sumCurrentRow = sumCurrentRow + array[i, j];
    }
    if(i == 0) sumElements = sumCurrentRow;
    else 
    {
        if(sumElements > sumCurrentRow) 
        {
            sumElements = sumCurrentRow;
            rowMinSum = i;
        }
    }
}

Console.Write($"Наименьшая сумма элементов {sumElements} в строке {rowMinSum + 1}.");

