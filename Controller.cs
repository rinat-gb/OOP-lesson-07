using System;

class Controller
{
    private View view;
    private Model model;

    public Controller()
    {
        view = new View();
        model = new Model();
    }
    public void run()
    {
        while (true)
        {
            Console.WriteLine("Введите математическое выражение или \"end\" для завершения работы");

            string input = view.getInput();

            if (input.Equals("end"))
            {
                break;
            }

            string RPN = model.toRPN(input);
            string result = model.doCalculate(RPN);
            view.showResult(result);
        }

    }
}