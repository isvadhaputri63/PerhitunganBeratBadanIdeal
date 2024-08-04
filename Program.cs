using System;

public abstract class Person
{
    private string name;
    private double height;
    private double weight;

    public Person(string name, double height, double weight)
    {
        this.name = name;
        this.height = height;
        this.weight = weight;
    }

    public abstract double CalculateIdealWeight();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Nama: {name}");
        Console.WriteLine($"Tinggi: {height} cm");
        Console.WriteLine($"Berat: {weight} kg");
    }
}

public class Male : Person
{
    public Male(string name, double height, double weight) : base(name, height, weight) { }

    public override double CalculateIdealWeight()
    {
        // Berat badan ideal untuk pria: 50 kg + 0,91 kg/cm di atas 152 cm
        return 50 + (0.91 * (Height - 152));
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Berat ideal: {CalculateIdealWeight()} kg");
    }
}

public class Female : Person
{
    public Female(string name, double height, double weight) : base(name, height, weight) { }

    public override double CalculateIdealWeight()
    {
        // Berat badan ideal untuk wanita: 45,5 kg + 0,91 kg/cm di atas 152 cm
        return 45.5 + (0.91 * (Height - 152));
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Berat ideal: {CalculateIdealWeight()} kg");
    }
}

public class WeightCalculator
{
    public void CalculateAndDisplay(Person person)
    {
        person.DisplayDetails();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Male male = new Male("Putraaa", 175, 70);
        Female female = new Female("Putriii", 160, 55);

        WeightCalculator calculator = new WeightCalculator();

        Console.WriteLine("Detail Laki-laki: ");
        calculator.CalculateAndDisplay(male);

        Console.WriteLine("\nDetail Perempuan:");
        calculator.CalculateAndDisplay(female);

        Console.ReadKey();
    }
}