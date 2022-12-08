using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class Element
{
    private string _name;
    private double _tnext;
    private double _delayMean, _delayDev;
    private string _distribution;
    private int _quantity;
    private double _tcurr;
    private int _state;
    private static int _nextId = 0;
    private int _id;

    public List<Tuple<Element, double>> _nextElements;
    public Element()
    {
        _tnext = double.MaxValue;
        _delayMean = 1.0;
        _distribution = "exp";
        _tcurr = _tnext;
        _state = 0;
        _nextElements = new List<Tuple<Element, double>>();
        _id = _nextId;
        _nextId++;
        _name = "Element " + _id;
    }
    public Element(double delay) : this()
    {
        _delayMean = delay;
    }
    public Element(string nameOfElement, double delay) : this(delay)
    {
        _name = nameOfElement + ", id: " + _id;
    }

    public double DelayDev
    {
        get => _delayDev;
        set => _delayDev = value;
    }

    public string Distribution
    {
        get => _distribution;
        set => _distribution = value;
    }
    
    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public virtual double Tcurr
    {
        get => _tcurr;
        set => _tcurr = value;
    }

    public int State
    {
        get => _state;
        set => _state = value;
    }

    public double Tnext
    {
        get => _tnext;
        set => _tnext = value;
    }

    public double DelayMean
    {
        get => _delayMean;
        set => _delayMean = value;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public double GetDelay()
    {

        double delay = Distribution switch
        {
            "exp" => FunRand.Exp(DelayMean),
            "norm" => FunRand.Norm(DelayMean, DelayDev),
            "unif" => FunRand.Unif(DelayMean, DelayDev),
            _ => DelayMean,
        };
        
        return delay;
    }

    public virtual void InAct()
    {
    }
    public virtual void OutAct()
    {
        _quantity++;
    }

    protected void GoToTheNextElement()
    {
        Random rnd = new Random();
        double randNum = rnd.NextDouble();
        double sum = 0;
        Console.WriteLine(randNum);

        foreach(Tuple<Element, double> elem in _nextElements)
        {
            sum += elem.Item2;

            if (randNum < sum)
            {
                Console.WriteLine($"{elem.Item1.Name} called from random choice");
                elem.Item1.InAct();
                return;
            }    
        }
    }

    public virtual void PrintResult()
    {
        Console.WriteLine(Name + " quantity = " + _quantity);
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine(Name + " state = " + _state +
        " quantity = " + _quantity +
        " tnext = " + _tnext);
    }
    public virtual void DoStatistics(double delta)
    {
    }
}
