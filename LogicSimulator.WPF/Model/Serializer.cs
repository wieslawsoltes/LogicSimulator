using System;
using System.Runtime.Serialization;
using System.Xml;
using LogicSimulator.Core.Core;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Gates;
using LogicSimulator.Core.Timers;

namespace LogicSimulator.Model;

public static class Serializer
{
    public static Type[] GetDiagramTypes()
    {
        return new Type[]
        { 
            typeof(DigitalPin),
            typeof(DigitalSignal),
            typeof(DigitalWire),
            typeof(AndGate),
            typeof(OrGate),
            typeof(NotGate),
            typeof(BufferGate),
            typeof(NandGate),
            typeof(NorGate),
            typeof(XorGate),
            typeof(XnorGate),
            typeof(TimerPulse),
            typeof(TimerOnDelay),
            typeof(DigitalLogicDiagram)
        };
    }

    public static DigitalLogicDiagram OpenDiagram()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog()
        {
            DefaultExt = "xml",
            Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*",
            FilterIndex = 0
        };

        if (dlg.ShowDialog() == true)
        {
            var settings = new DataContractSerializerSettings()
            {
                MaxItemsInObjectGraph = int.MaxValue,
                PreserveObjectReferences = true,
                IgnoreExtensionDataObject = true,
                SerializeReadOnlyTypes = false,
                KnownTypes = GetDiagramTypes(),
            };
            var s = new DataContractSerializer(typeof(DigitalLogicDiagram), settings);
            using (var reader = XmlReader.Create(dlg.FileName))
            {
                return (DigitalLogicDiagram)s.ReadObject(reader);
            }
        }
        return null;
    }

    public static void SaveDiagram(DigitalLogicDiagram diagram)
    {
        var dlg = new Microsoft.Win32.SaveFileDialog()
        {
            DefaultExt = "xml",
            Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*",
            FilterIndex = 0,
            FileName = "diagram"
        };

        if (dlg.ShowDialog() == true)
        {
            if (diagram != null)
            {
                var settings = new DataContractSerializerSettings()
                {
                    MaxItemsInObjectGraph = int.MaxValue,
                    PreserveObjectReferences = true,
                    IgnoreExtensionDataObject = true,
                    SerializeReadOnlyTypes = false,
                    KnownTypes = GetDiagramTypes(),
                };
                var s = new DataContractSerializer(diagram.GetType(), settings);
                using (var writer = XmlWriter.Create(dlg.FileName, new XmlWriterSettings() { Indent = true, IndentChars = "    " }))
                {
                    s.WriteObject(writer, diagram);
                }
            }
        }
    }
}