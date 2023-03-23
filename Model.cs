using System;
using System.Collections.Generic;
using System.Text;

public class Model
{
    private bool isOperator(char ch)
    {
        switch (ch)
        {
            case '+':
            case '-':
            case '*':
            case '/':
                return true;
            default:
                return false;
        }
    }

    private int getPriority(char op)
    {
        switch (op)
        {
            case '*':
            case '/':
                return 2;
            case '+':
            case '-':
                return 1;
        }
        return 0;
    }

    public string toRPN(string from)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Stack<char> op = new Stack<char>();

        for (int i = 0; i < from.Length; i++)
        {
            char ch = from[i];

            if (ch >= '0' && ch <= '9')
            {
                while (from[i] >= '0' && from[i] <= '9')
                {
                    stringBuilder.Append(from[i]);
                    if (i < from.Length - 1)
                        i++;
                    else
                        break;
                }
                stringBuilder.Append(' ');
            }
            else if (ch == '(')
            {
                op.Push('(');
            }
            else if (ch == ')')
            {
                while (op.Peek() != '(')
                    stringBuilder.Append(op.Pop()).Append(' ');

                op.Pop();
            }
            else if (isOperator(ch))
            {
                while (op.Count != 0 && getPriority(op.Peek()) >= getPriority(ch))
                    stringBuilder.Append(op.Pop()).Append(' ');

                op.Push(ch);
            }
        }
        while (op.Count != 0)
        {
            stringBuilder.Append(op.Pop()).Append(' ');
        }
        return stringBuilder.ToString();
    }

    public string doCalculate(string RPN)
    {

        Stack<int> st = new Stack<int>();
        string[] exp = RPN.Split(" ");

        int res = 0;

        for (int i = 0; i < exp.Length; i++)
        {
            if (exp[i][0] >= '0' || exp[i][0] <= '9')
            {
                st.Push(Int32.Parse(exp[i]));
            }
            else
            {
                int tmpNum;

                switch (exp[i][0])
                {
                    case '+':
                        res = st.Pop() + st.Pop();
                        st.Push(res);
                        break;
                    case '-':
                        tmpNum = st.Pop();
                        res = st.Pop() - tmpNum;
                        st.Push(res);
                        break;
                    case '*':
                        res = st.Pop() * st.Pop();
                        st.Push(res);
                        break;
                    case '/':
                        tmpNum = st.Pop();
                        res = st.Pop() / tmpNum;
                        st.Push(res);
                        break;
                    default:
                        break;
                }
            }
        }
        return st.Pop().ToString();
    }
}