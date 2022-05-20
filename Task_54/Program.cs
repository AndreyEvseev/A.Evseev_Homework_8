// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
//            элементы каждой строки двумерного массива.
// Уточнение задания:
// 1. Количество строк и столбцов массива задаётся пользователем.
// 2. Значения элементов - целые числа.
// 3. Значения элементов массива задаются рандомно из диапазона от -999 до 999. 
// 4. Вывод на экран исходного и упорядоченного массива производится автоматически.
// 

void TitleInputErrorMessage()
{
    Console.WriteLine("Уважаемый пользователь, вы ошиблись при вводе! ");
}

void NumberInputErrorMessage (string userNumber, string definitionNumber)
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
            else NumberInputErrorMessage(userNumber, definitionNumber); 
        }
        else 
        {
            NumberInputErrorMessage(userNumber, definitionNumber);
        } 
        Console.WriteLine();
    }
    return number;
}

int InputIntegerNumber(string text1, string text2, string text3)
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
row = InputIntegerNumber(text1, text2, text3);
text2 = "столбцов";
column = InputIntegerNumber(text1, text2, text3); 
int[,] sourceArray = new int[row, column];
FillArrayRandom(sourceArray);
PrintArray(sourceArray);

for (int i = 0; i < sourceArray.GetLength(0); i++)
{
    for (int j = 0; j < sourceArray.GetLength(1); j++)
    {
        for (int k = 1; k < sourceArray.GetLength(1) - j; k++)
        {
            int help;
            if(sourceArray[i, k] > sourceArray[i, k-1]) 
            {
                help = sourceArray[i, k];
                sourceArray[i, k] = sourceArray[i, k-1];
                sourceArray[i, k-1] = help;
            }
        }
    }
}
PrintArray(sourceArray);


