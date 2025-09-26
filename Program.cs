// Question: Check the value of a out parameter at the method level

using System;
using System.Threading;

class OutExample
{
    public void OutMethod(out int a, Func<int> getCallerValue)      //the lambda does not just copy the value 90, it points to the variable a in Main.
    {
        Thread t = new Thread(() =>
        {

            Console.WriteLine(" value before assignment: " + getCallerValue());
        });

        t.Start();
        t.Join();

        a = 34;
        Console.WriteLine("Inside method after assignment: " + a);
    }
}
// we have to Point to a method 
class Program
{
    static void Main()
    {
        int a = 90;
        OutExample example = new OutExample();

        // Pass a lambda pointing to the variable in Main     (parameters) =>“goes to” expression

        example.OutMethod(out a, () => a);          //It creates a closure that captures the variable a from the caller's scope.
                                                    // Even though a is later assigned inside the method (as an out), the lambda still points to the original a from Main.

        Console.WriteLine("Value after method call: " + a);
    }
}
