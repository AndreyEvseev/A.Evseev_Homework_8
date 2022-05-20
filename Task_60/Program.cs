// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите 
//            программу, которая будет построчно выводить массив, добавляя индексы каждого 
//            элемента.
// Уточнение задания:
// 1. Размерность вводится пользователем. Минимальная длина каждой координаты равна 2, 
//    максимальная рассчитывается исходя из максимально возможного количества не повторяющихся
//    двузначных чисел и заданных значений элементов по другим координатам. Проводится 
//    проверка на соответствие заданного значения диапазону допустимых.
// 2. Массив заполняется целыми значениями от 10 до 99 по модулю с шагом 7 или -7. 
//    Начальный элемент и знак шага генерируются рандомно. 


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

void OutRangeErrorMessage(string userNumber, int minValue, int maxValue)
{
    TitleInputErrorMessage();
    Console.Write($"Введённое Вами значение: {userNumber},");
    Console.WriteLine($" выходит за допустимый диапазон от {minValue} до {maxValue}.");
}

int CheckNaturalNumbersFromRange (string messageForUser, int minValue, int maxValue)
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
            if(number >= minValue && number <= maxValue) i = 1;
            else OutRangeErrorMessage(userNumber, minValue, maxValue); 
        }
        else 
        {
            NumberInputErrorMessage(userNumber, definitionNumber);
        } 
        Console.WriteLine();
    }
    return number;
}

int InputIntFromRange(string text1, string text2, string text3, int minValue, int maxValue)
{
    string messegeForUser = string.Empty;
    messegeForUser = $"Введите {text1} {text2} {text3} из диапазона " +
                    $"от {minValue} до {maxValue}: ";
    int result = CheckNaturalNumbersFromRange(messegeForUser, minValue, maxValue); 
    return result; 
}

void FillArray(int[,,] createArray)
{
    int signDirection, sign, elementValue;
    if(new Random().Next(0, 2) == 0) signDirection = -1;
    else signDirection = 1;
    if(new Random().Next(0, 2) == 0) sign = -1;
    else sign = 1;
    elementValue = new Random().Next(10, 100) * sign;
    int step = 7 * signDirection; // допустимые значения для расчёта шага: 7, 11, 13, 17 
    for (int i = 0; i < createArray.GetLength(0); i++)
    {
        for (int j = 0; j < createArray.GetLength(1); j++)
        {
            for (int k = 0; k < createArray.GetLength(2); k++)
            {
                if(Math.Abs(elementValue + step) < 10) 
                {
                    elementValue = elementValue + step + 19 * signDirection;
                }
                else
                {
                    if (Math.Abs(elementValue + step) > 99)
                    {
                        int help = 99 - Math.Abs(elementValue);
                        elementValue = (elementValue + help * signDirection) * -1 
                                        + (Math.Abs(step) - 1 - help) 
                                        * signDirection;
                    }
                    else
                    {
                        elementValue = elementValue + step;
                    }
                }
                createArray[i, j, k] = elementValue;
            }
        }
    }
            
}

void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"a({i},{j},{k}):{array[i, j, k], 3}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.WriteLine("Формируем трёхмерный массив из неповторяющихся двузначных целых чисел.");
Console.WriteLine("Минимальное количество элементов по каждой координате равно 2.");
Console.WriteLine("Максимальное количество неповторяющихся двузначных целых чисел равно 180.");
Console.WriteLine("Максимальное количество элементов по каждой координате рассчитывается.");
int x = 2, y = 2, z = 2;
int coordinateMin =2, maxNumberElements = 180;
int xMax, yMax, zMax;
string text1 = string.Empty, text2 = string.Empty, text3 = string.Empty;
xMax = maxNumberElements / (y * z);
text1 = "количество"; text2 = "элементов"; text3 = "по координате x";
x = InputIntFromRange(text1, text2, text3, coordinateMin, xMax);
yMax = maxNumberElements / (x * z);
if(yMax == coordinateMin)
{
    Console.WriteLine($"При заданном значении x = {x}, координаты y и z равны 2. ");
}
else
{
    text1 = "количество"; text2 = "элементов"; text3 = "по координате y";
    y = InputIntFromRange(text1, text2, text3, coordinateMin, yMax);
}
zMax = maxNumberElements / (x * y);
if(zMax == coordinateMin)
{
    Console.WriteLine($"При заданных значениях x = {x} и y = {y}, координата z равна 2. ");
}
else
{
    text1 = "количество"; text2 = "элементов"; text3 = "по координате z";
    z = InputIntFromRange(text1, text2, text3, coordinateMin, zMax);
}
Console.WriteLine($"Трёхмерный массив [{x}, {y}, {z}]:");
Console.WriteLine();
int[,,] array = new int[x, y, z];
FillArray(array);
PrintArray(array);
