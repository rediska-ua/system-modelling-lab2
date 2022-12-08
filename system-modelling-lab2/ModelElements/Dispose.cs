using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_modelling_lab2.ModelElements;

public class Dispose : Element
{
    public Dispose(string nameOfElement) : base(nameOfElement, 0) { }


    public override void InAct()
    {
        base.InAct();
        Quantity += 1;
    }
    public override void OutAct() { }
    
    public override void PrintInfo()
    {
        base.PrintResult();
    }
}
