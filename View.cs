using System;

public class View
{
    public string getInput()
    {
        return Console.ReadLine() ?? "end";
    }

    public void showResult(string result)
    {
        Console.WriteLine("Результат: {result}");
    }
}