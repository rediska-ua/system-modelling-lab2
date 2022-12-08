using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class Model
{

    private List<Element> _list = new List<Element>();
    private double _tnext, _tcurr;
    private Element? _el;
    public Model(List<Element> elements)
    {
        _list = elements;
        _tnext = 0.0;
        _tcurr = _tnext;
    }

    public void Simulate(double time)
    {
        while (_tcurr < time)
        {
            _tnext = double.MaxValue;
            foreach (Element el in _list)
            {
                if (el.Tnext < _tnext)
                {
                    _tnext = el.Tnext;
                    _el = el;
                }
            }
            Console.WriteLine("\nIt's time for event in " + _el?.Name + ", time = " + _tnext);

            foreach (Element el in _list) el.DoStatistics(_tnext - _tcurr);

            _tcurr = _tnext;

            foreach (Element el in _list) el.Tcurr = _tcurr;

            _el?.OutAct();

            Console.WriteLine("tcurr: " + _tcurr);

            foreach (Element el in _list)
            {
                if (el.Tnext == _tcurr)
                {
                    el.OutAct();
                }
            }

            PrintInfo();
        }
        PrintResult();
    }

    public void PrintInfo()
    {
        foreach (Element e in _list)
        {
            e.PrintInfo();
        }
    }
    public void PrintResult()
    {
        Console.WriteLine("\n-------------RESULTS-------------");
        foreach (Element e in _list)
        {
            e.PrintResult();
            if (e is Process) {
                Process p = (Process)e;
                Console.WriteLine("Mean length of queue = " +
                p.GetMeanQueue() / _tcurr
                + "\nFailure probability = " +
                p.Failure / (double)p.Quantity);
            }
        }
    }
}
