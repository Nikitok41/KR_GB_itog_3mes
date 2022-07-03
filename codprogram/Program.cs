// Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа.

string PrintArray(string[] array) // Метод , который создаёт печатную форму массива ( как в примере )
{
    string result = String.Empty;
    result += "[";
    for (int i = 0; i < array.Length; i++)
    {
        result += '"' + array[i] + '"';
        if (i < array.Length - 1) result += ',';
    }
    result += "]";
    return result;
}

string[] ArrayCreation()//Метод создания массива ( другой вариант был бы с разделителем, но с этим было мало практики - пока остановился на этом)
{
    Console.Clear();
    Console.WriteLine("Введите элементы массива - после каждого ввода - ESC закрывает создание массива, другая кнопка даёт возможность ввести следующий элемент");
    int index = 0;
    string text = String.Empty;
    List<string> arrayList = new List<string>();
    do
    {
        Console.Write($"Элемент {index} : ");
        text = Console.ReadLine();
        if (text == null) text = String.Empty; //Нужная такая проверка - для пустых значений
        arrayList.Add(text);
        index++;
        Console.WriteLine("\tДля выхода нажмите ESC, для продолжения любую другую кнопку");
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    string[] array = new string[arrayList.Count];

    for (int i = 0; i < array.Length; i++) array[i] = arrayList[i];

    return array;
}

int ConditionCheck() // Выбора условия 
{
    Console.WriteLine(//есть желание сюда подгрудать словать, но очень много меняется - по этому пока не могу придумать способ
        "Выберите условие по которому будет проводится отбор : " +
        "\n\t 1 - '=' ( равно числу )" +
        "\n\t 2 - '>' ( больше числа )" +
        "\n\t 3 - '>=' ( больше или равно )" +
        "\n\t 4 - '<' ( меньше )" +
        "\n\t 5 - '<=' ( меньше или равно )" +
        "\n\t 6 - '!=' ( не равно )" +
        "\n\t 7 - '' - пустой эллемент ( выведет кол-во пустых эллементов в массиве )");
    int result = NumberInput("цифру с выбором 1 - 7");
    return result;
}

int NumberInput(string text)//Метод ввода и проверки на число
{
    bool isInputInt = true;
    int number = 0;
    while (isInputInt)
    {
        Console.Write($"\nВведите {text} :");
        string numberSTR = Console.ReadLine();
        if (int.TryParse(numberSTR, out int numberInt))
        {
            if ((numberInt > 0) && (numberInt < 8))
            {
                number = numberInt;
                isInputInt = false;
            }
            else
                Console.WriteLine("Вне диапозона");
        }
        else
            Console.WriteLine("Ввели не число");
    }
    return number;
}

(int, string[]) SecondArrayCreationByCondition(string[] array, int condition, int conditionNumer)//Метод создания нового массива в зависимости от условия
{
    int count = 0;
    switch (condition)
    {
        case 1:
            for (int i = 0; i < array.Length; i++) if (array[i].Length == conditionNumer) count++;
            break;
        case 2:
            for (int i = 0; i < array.Length; i++) if (array[i].Length > conditionNumer) count++;
            break;
        case 3:
            for (int i = 0; i < array.Length; i++) if (array[i].Length >= conditionNumer) count++;
            break;
        case 4:
            for (int i = 0; i < array.Length; i++) if (array[i].Length < conditionNumer) count++;
            break;
        case 5:
            for (int i = 0; i < array.Length; i++) if (array[i].Length <= conditionNumer) count++;
            break;
        case 6:
            for (int i = 0; i < array.Length; i++) if (array[i].Length != conditionNumer) count++;
            break;
        case 7:
            for (int i = 0; i < array.Length; i++) if (array[i].Length == conditionNumer) count++;
            break;
    }
    string[] resultArray = new string[count];
    return (count, resultArray);
}

void ArrayFillingByCondition(string[] array, string[] fillArray, int condition, int conditionNumer)//Метод заполнения массива в зависимости от условия
{
    int index = 0;
    switch (condition)
    {
        case 1:
            for (int i = 0; i < array.Length; i++) if (array[i].Length == conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
        case 2:
            for (int i = 0; i < array.Length; i++) if (array[i].Length > conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
        case 3:
            for (int i = 0; i < array.Length; i++) if (array[i].Length >= conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
        case 4:
            for (int i = 0; i < array.Length; i++) if (array[i].Length < conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
        case 5:
            for (int i = 0; i < array.Length; i++) if (array[i].Length <= conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
        case 6:
            for (int i = 0; i < array.Length; i++) if (array[i].Length != conditionNumer)
                {
                    fillArray[index] = array[i];
                    index++;
                }
            break;
    }
}

System.Console.OutputEncoding = System.Text.Encoding.Unicode;// Не на всех компьютерах установлена Русская кодировка.
Console.Clear();

var action = new Dictionary<int, string>()
{
    { 1 , "="},
    { 2 , ">"},
    { 3 , ">="},
    { 4 , "<"},
    { 5 , "<="},
    { 6 , "!="},
    { 7 , "null"}
};

int conditionNumer = 0;
int condition = ConditionCheck();
if ((condition > 0) && (condition < 7))
    conditionNumer = NumberInput($"число ( от 1 до 7 ) для условия поиска кол-во символов {action[condition]}");

string[] array = ArrayCreation(); // Создаю изначальный массив
(int count, string[] secondArray) = SecondArrayCreationByCondition(array, condition, conditionNumer);

Console.Clear();

if (condition == 7)// если условие 7 ( кол-во пустых элементов ) нужно поменять схему вывода
{
    Console.WriteLine($" В изначальном массиве ищем кол-во пустых эллементов");
    Console.Write($"\n{PrintArray(array)} -> {count} кол-во пустых ячеек");
}
else
{
    Console.WriteLine($" В изначальном массиве ищем элементы по условию {action[condition]} {conditionNumer}");
    ArrayFillingByCondition(array, secondArray, condition, conditionNumer);
    Console.Write($"\n{PrintArray(array)} -> {PrintArray(secondArray)}");
}