using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class Create : Element
{
    public Create(string nameOfElement, double delay) : base(nameOfElement, delay)
    {
        Tnext = 0.0;
        Tcurr = 0.0;
    }

    public override void OutAct()
    {
        base.OutAct();
        Tnext = Tcurr + GetDelay();
        GoToTheNextElement();
    }
}
