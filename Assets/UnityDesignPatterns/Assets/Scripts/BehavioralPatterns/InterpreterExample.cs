using System.Collections.Generic;
using UnityEngine;

public class InterpreterExample : MonoBehaviour
{
    public abstract class Expression
    {
        public abstract bool Interpret(string context);
    }

    public class TerminalExpression : Expression
    {
        private string data;

        public TerminalExpression(string data)
        {
            this.data = data;
        }

        public override bool Interpret(string context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }

    public class OrExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public OrExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public override bool Interpret(string context)
        {
            return expr1.Interpret(context) || expr2.Interpret(context);
        }
    }

    public class AndExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public override bool Interpret(string context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }

    // Use this for initialization
    void Start()
    {
        Expression isMale = GetMaleExpression();
        Expression isMarriedWoman = GetMarriedWomanExpression();

        Debug.Log("John is male? " + isMale.Interpret("John"));
        Debug.Log("Julie is a married women? " + isMarriedWoman.Interpret("Married Julie"));
    }

    // Rule: Robert and John are male
    public static Expression GetMaleExpression()
    {
        Expression robert = new TerminalExpression("Robert");
        Expression john = new TerminalExpression("John");
        return new OrExpression(robert, john);
    }

    // Rule: Julie is a married women
    public static Expression GetMarriedWomanExpression()
    {
        Expression julie = new TerminalExpression("Julie");
        Expression married = new TerminalExpression("Married");
        return new AndExpression(julie, married);
    }
}