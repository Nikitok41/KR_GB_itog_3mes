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
