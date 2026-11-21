using System;
using System.Text.RegularExpressions;

// 1.
interface ICalc
{
    int Less(int valueToCompare);
    int Greater(int valueToCompare);
}

class Array : ICalc
{
    private int[] arr;

    public Array(int[] numbers)
    {
        arr = numbers;
    }

    public int Less(int valueToCompare)
    {
        int count = 0;

        foreach(int number in arr)
        {
            if (number < valueToCompare)
            { 
                count++;
            }
        }
        return count;
    }

    public int Greater(int valueToCompare)
    {
        int count = 0;

        foreach (int number in arr)
        {
            if(number > valueToCompare)
            {  
                count++; 
            }
        }
        return count;
    }
}

// 2.
interface IOutput2
{
    void ShowEven();
    void ShowOdd();
}

class Arr : IOutput2
{
    private int[] arr;

    public Arr(int[] numbers)
    {
        arr = numbers;
    }

    public void ShowEven()
    {
        Console.WriteLine("Even elements: ");
        foreach (int number in arr)
        {
            if (number % 2 == 0)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }

    public void ShowOdd()
    {
        Console.WriteLine("Odd elements: ");
        foreach(int number in arr)
        {
            if(number % 2 != 0)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}

// 3.
interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int valueToCompare);
}

class Array2 : ICalc2
{
    private int[] arr;

    public Array2(int[] numbers)
    {
        arr = numbers;
    }

    public int CountDistinct()
    {
        HashSet<int> unique = new HashSet<int>(arr);

        return unique.Count;
    }

    public int EqualToValue(int valueToCompare)
    {
        int count = 0;
        foreach (int number in arr)
        {
            if (number == valueToCompare)
            {
                count++;
            }
        }
        return count;
    }
}

// 4.
interface IRemoteControl
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

class Television : IRemoteControl
{
    public void TurnOn()
    {
        Console.WriteLine("Televisor turned on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Televisor turned off");
    }

    public void SetChannel(int channel)
    {
        if (channel > 0)
        {
            Console.WriteLine("Changed televisor channel on " + channel);
        }
        else
        {
            Console.WriteLine("Invalid channel!");
        }
    }
}

class Radio : IRemoteControl
{
    public void TurnOn()
    {
        Console.WriteLine("Radio is turned on");
    }
    public void TurnOff()
    {
        Console.WriteLine("Radio is turned off");
    }

    public void SetChannel(int channel)
    {
        if (channel > 0)
        {
            Console.WriteLine("Radio changed on wave" + channel);
        }
        else
        {
            Console.WriteLine("Invalid wave!");
        }
    }
}

// 5.
interface IValidator
{
    bool Validate();
}

class PasswordValidator : IValidator
{
    private string password;

    public PasswordValidator(string password)
    {
        this.password = password;
    }

    public bool Validate()
    {
        if (password.Length < 8)
            return false;

        bool hasLetter = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsLetter(c))
                hasLetter = true;

            if (char.IsDigit(c))
                hasDigit = true;
        }

        return hasLetter && hasDigit;
    }
}

class EmailValidator : IValidator
{
    private string email;

    public EmailValidator(string email)
    {
        this.email = email;
    }

    public bool Validate()
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        return Regex.IsMatch(email, pattern);
    }
}

class Program
{
    static void Main()
    {
        // Task 1
        Array array = new Array(new int[] { 1, 5, 8, 3, 10, 5 });

        Console.WriteLine("Elements lesser than 5: " + array.Less(5));
        Console.WriteLine("Elements greater than 5" + array.Greater(5));

        // Task 2
        Arr arr = new Arr(new int[] { 1, 10, 3, 7, 45, 50 });

        arr.ShowEven();
        arr.ShowOdd();

        // Task 3
        Array2 array2 = new Array2(new int[] { 1, 2, 2, 6, 9, 3, 3, 10, 5, 10 });

        Console.WriteLine("Quantity of unique elements: " + array2.CountDistinct());
        Console.WriteLine("Quantity of elements, equal to 2: " + array2.EqualToValue(2));

        // Task 4
        Television tv = new Television();
        Radio radio = new Radio();

        tv.TurnOn();
        tv.SetChannel(5);
        tv.TurnOff();
        Console.WriteLine();
        radio.TurnOn();
        radio.SetChannel(17);
        radio.TurnOff();

        // Task 5
        Console.Write("Enter the password: ");
        string password = Console.ReadLine();

        PasswordValidator passwordValidator =
            new PasswordValidator(password);

        if (passwordValidator.Validate())
            Console.WriteLine("Password entered correctly");
        else
            Console.WriteLine("Password incorrect");

        Console.WriteLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        EmailValidator emailValidator =
            new EmailValidator(email);

        if (emailValidator.Validate())
            Console.WriteLine("Email entered correctly");
        else
            Console.WriteLine("Email incorrect");
    }
}