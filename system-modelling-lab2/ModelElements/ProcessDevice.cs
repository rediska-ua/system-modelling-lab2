using System.ComponentModel;

namespace system_modelling_lab2.ModelElements;

public class ProcessDevice : Element
{

    private double _meanLoad;
    private Process _parent;

    public ProcessDevice(string nameOfElement, double delay, Process parent) 
        : base(nameOfElement, delay)
    {
        _parent = parent; 
    }

    public override void InAct()
    {
        State = 1;
        Tnext = Tcurr + GetDelay();
    }
    public override void OutAct()
    {
        base.OutAct();
        Tnext = double.MaxValue;
        State = 0;

        if (_parent.ProcessQueue > 0)
        {
            _parent.ProcessQueue -= 1;
            State = 1;
            Tnext = Tcurr + GetDelay();
        }
    }

    public override void PrintResult()
    {
        Console.WriteLine(Name + " quantity = " + Quantity +
            " Mean Load = " + _meanLoad / Tcurr);
    }
    public override void PrintInfo()
    {
        Console.WriteLine(Name + " state = " + State +
        " quantity = " + Quantity +
        " tnext = " + Tnext);
    }
    public override void DoStatistics(double delta)
    {
        _meanLoad = _meanLoad + State * delta;
    }
}
