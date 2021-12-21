using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LogicSimulator.Core.Core;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Gates;
using LogicSimulator.Core.Timers;

namespace LogicSimulator.ViewModels
{
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

        public static async Task<DigitalLogicDiagram> OpenDiagram()
        {
            var dlg = new OpenFileDialog()
            {
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter() { Name = "Xml Files", Extensions = new List<string> { "xml" } },
                    new FileDialogFilter() { Name = "All Files", Extensions = new List<string> { "*" } },
                }
            };
            var mainWindow = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;
            var result = await dlg.ShowAsync(mainWindow);
            if (result is { Length: >= 1 })
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
                using (var reader = XmlReader.Create(result[0]))
                {
                    return (DigitalLogicDiagram)s.ReadObject(reader);
                }
            }
            return null;
        }

        public static async Task SaveDiagram(DigitalLogicDiagram diagram)
        {
            var dlg = new SaveFileDialog()
            {
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter() { Name = "Xml Files", Extensions = new List<string> { "xml" } },
                    new FileDialogFilter() { Name = "All Files", Extensions = new List<string> { "*" } },
                },
                DefaultExtension = "xml",
                InitialFileName = "diagram"
            };
            var mainWindow = (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow;
            var result = await dlg.ShowAsync(mainWindow);
            if (result is { })
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
                    using (var writer = XmlWriter.Create(result, new XmlWriterSettings() { Indent = true, IndentChars = "    " }))
                    {
                        s.WriteObject(writer, diagram);
                    }
                }
            }
        }
    }
}
