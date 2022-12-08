using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class Process : Element
{
    private int _queue, _maxqueue, _failure;
    private double _meanQueue;
    public List<ProcessDevice> processDevices = new List<ProcessDevice>();
    public Process(string nameOfElement, int maxQueue) : base(nameOfElement, 0)
    {
        _queue = 0;
        _maxqueue = maxQueue;
        _meanQueue = 0.0;
    }
    
    public override void InAct()
    {
        foreach (ProcessDevice device in processDevices)
        {
            if (device.State == 0)
            {
                Console.WriteLine(device.Name + " started working ");
                device.InAct();
                Console.WriteLine($" Tnext of {device.Name}  = {device.Tnext}");
                if (device.Tnext < Tnext) Tnext = device.Tnext;
                return;
            }
        }

        Console.WriteLine(" There is no empty device ");
        if (ProcessQueue < MaxQueue)
            ProcessQueue += 1;
        else
            _failure++;
    }

    public override void OutAct()
    {
        foreach (ProcessDevice device in processDevices)
        {
            if (device.Tnext == Tnext)
            {
                Console.WriteLine(device.Name + " stopped working ");
                Quantity += 1;
                device.OutAct();
                GoToTheNextElement();
            }
        }
        Tnext = double.MaxValue;

        foreach (ProcessDevice device in processDevices)
            if (device.Tnext < Tnext) Tnext = device.Tnext;

    }

    public override double Tcurr
    {
        get => base.Tcurr;
        set {
            base.Tcurr = value;
            foreach (ProcessDevice device in processDevices)
                device.Tcurr = value;
        }
    }

    public int Failure
    {
        get => _failure;
    }
    public int ProcessQueue
    {
        get => _queue;
        set => _queue = value;
    }

    public int MaxQueue
    {
        get => _maxqueue;
        set => _maxqueue = value;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("failure = " + Failure);
    }

    public override void DoStatistics(double delta)
    {
        _meanQueue = GetMeanQueue() + _queue * delta;
    }
    public double GetMeanQueue()
    {
        return _meanQueue;
    }
}
