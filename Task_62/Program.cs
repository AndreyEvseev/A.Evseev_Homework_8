// Задача 62: Заполните спирально массив 4 на 4.
// Уточнение задания:
// 1. Задача решена для общего случая размерности массива. Позволяет создать массив 4 на 4.
// 2. Количество строк и стоблцов задаётся потльзователем. 
// 3. Заполненный массив выводится на экран автоматически. 

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
int[,] spiralArray = new int[row, column];
int rowMin = 0, columnMin = 0, rowMax = row, columnMax = column;
int start, stop;
int direction =1;
int elementValue = 0;
while (rowMin != rowMax && columnMin != columnMax)
{
    if(direction == 1 || direction == 2) // от меньшего к большему
    {
        if(direction == 1) 
        {
            start = columnMin; stop = columnMax;
        }
        else 
        {
            start = rowMin; stop = rowMax;
        }
        for (int i = start; i < stop; i++)
        {
            elementValue++;
            if(direction == 1) spiralArray[rowMin, i] = elementValue;
            else spiralArray[i, columnMax -1 ] = elementValue;
        }
        if(direction == 1) rowMin++;
        else columnMax--;
        if(direction < 4) direction++;
        else direction = 1;
    }
    else // от большего к меньшему
    {
        if(direction == 3) 
        {
            start = columnMax - 1; stop = columnMin - 1;
        }
        else 
        {
            start = rowMax - 1; stop = rowMin -1;
 
        }
            for (int i = start; i > stop; i--)
            {
                elementValue = elementValue + 1;
                if(direction == 3) spiralArray[rowMax - 1, i] = elementValue;
                else spiralArray[i, columnMin] = elementValue;
            }
            if(direction == 3) rowMax--;
            else columnMin++;
            if(direction < 4) direction++;
            else direction = 1;
        }
}
    
PrintArray(spiralArray);


