using System.Collections.Generic;
using System.Diagnostics.Tracing;
using system_modelling_lab2.ModelElements;

namespace system_modelling_lab2;

class SimModel
{
    public static void Main(string[] args)
    {
        Create creator = new Create("Create", 3);
        Process process_1 = new Process("Process1", 6);
        Process process_2 = new Process("Process2", 4);
        Process process_3 = new Process("Process3", 6);
        Dispose dispose = new Dispose("Dispose");

        List<ProcessDevice> p1Devices = new List<ProcessDevice>()
        {
            new ProcessDevice("PROCESS_1_DEVICE_1", 4, process_1)
        };
        List<ProcessDevice> p2Devices = new List<ProcessDevice>()
        {
            new ProcessDevice("PROCESS_2_DEVICE_1", 6, process_2)
        };
        List<ProcessDevice> p3Devices = new List<ProcessDevice>()
        {
            new ProcessDevice("PROCESS_3_DEVICE_1", 3, process_3)
        };

        process_1.processDevices = p1Devices;
        process_2.processDevices = p2Devices;
        process_3.processDevices = p3Devices;

        creator._nextElements = new List<Tuple<Element, double>> {
            new Tuple<Element, double>(process_1, 1.0)
        };
        process_1._nextElements = new List<Tuple< Element, double>> {
            new Tuple<Element, double>(process_2, 1.0)
        };
        process_2._nextElements = new List<Tuple<Element, double>> {
            new Tuple<Element, double>(process_3, 1.0)
        };
        process_3._nextElements = new List<Tuple<Element, double>> {
            new Tuple<Element, double>(dispose, 1.0)
        };

        List<Element> list = new List<Element>() { creator, process_1, process_2, process_3, dispose };
        Model model = new Model(list);
        model.Simulate(1000);
    }
}
