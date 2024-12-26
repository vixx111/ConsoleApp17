using System;

public class PhoneCall
{
    private int duration;
    private decimal costPerMinute;

    public PhoneCall(int duration, decimal costPerMinute)
    {
        this.duration = duration;
        this.costPerMinute = costPerMinute;
    }
    public string GetInfo()
    {
        return $"Продолжительность разговора: {duration} мин, Стоимость одной минуты: {costPerMinute} руб.";
    }
    public decimal CalculateTotalCost()
    {
        return duration * costPerMinute;
    }
}

public class DailyCalls : PhoneCall
{
    private int numberOfCalls;
    public DailyCalls(int duration, decimal costPerMinute, int numberOfCalls)
        : base(duration, costPerMinute)
    {
        this.numberOfCalls = numberOfCalls;
    }
    public decimal CalculateDailyTotalCost()
    {
        return CalculateTotalCost() * numberOfCalls;
    }
    public new string GetInfo()
    {
        return base.GetInfo() + $", Количество разговоров: {numberOfCalls}";
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите продолжительность одного разговора в минутах:");
        string durationInput = Console.ReadLine();
        Console.WriteLine("Введите стоимость одной минуты:");
        string costInput = Console.ReadLine();
        Console.WriteLine("Введите количество разговоров за сутки:");
        string callsInput = Console.ReadLine();
        if (int.TryParse(durationInput, out int duration) &&
            decimal.TryParse(costInput, out decimal cost) &&
            int.TryParse(callsInput, out int numberOfCalls))
        {
            DailyCalls dailyCalls = new DailyCalls(duration, cost, numberOfCalls);
            decimal totalCost = dailyCalls.CalculateDailyTotalCost();
            Console.WriteLine(dailyCalls.GetInfo());
            Console.WriteLine($"Общая стоимость разговоров за сутки: {totalCost} руб.");
        }
        else
        {
            Console.WriteLine("Введите корректные значения.");
        }
    }
}