using System;

public abstract class Activity
{
    private DateTime date;
    private int length; // in minutes

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public DateTime Date
    {
        get { return date; }
        private set { date = value; }
    }

    public int Length
    {
        get { return length; }
        private set { length = value; }
    }

    public abstract double GetDistance(); // Distance in miles or kilometers
    public abstract double GetSpeed();    // Speed in mph or kph
    public abstract double GetPace();     // Pace in min per mile or min per km

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {this.GetType().Name} ({Length} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Length) * 60;
    }

    public override double GetPace()
    {
        return Length / distance;
    }
}


public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int length, double speed)
        : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Length) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // converting meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Length) * 60;
    }

    public override double GetPace()
    {
        return Length / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
