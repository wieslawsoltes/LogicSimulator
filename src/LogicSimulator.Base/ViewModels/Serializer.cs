using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Avalonia.Platform.Storage;
using LogicSimulator.Core.Core;
using LogicSimulator.Core.Diagrams;
using LogicSimulator.Core.Gates;
using LogicSimulator.Core.Timers;

namespace LogicSimulator.ViewModels;

public static class Serializer
{
    private static Type[] GetDiagramTypes()
    {
        return new[]
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

    private static List<FilePickerFileType> GetOpenFileTypes()
    {
        return new List<FilePickerFileType>
        {
            StorageService.Xml,
            StorageService.All
        };
    }

    private static List<FilePickerFileType> GetSaveFileTypes()
    {
        return new List<FilePickerFileType>
        {
            StorageService.Xml,
            StorageService.All
        };
    }

    public static async Task<DigitalLogicDiagram?> OpenDiagram()
    {
        var storageProvider = StorageService.GetStorageProvider();
        if (storageProvider is null)
        {
            return null;
        }

        var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open diagram",
            FileTypeFilter = GetOpenFileTypes(),
            AllowMultiple = false
        });

        var file = result.FirstOrDefault();

        if (file is not null && file.CanOpenRead)
        {
            try
            {
                await using var stream = await file.OpenReadAsync(); 
                var settings = new DataContractSerializerSettings()
                {
                    MaxItemsInObjectGraph = int.MaxValue,
                    PreserveObjectReferences = true,
                    IgnoreExtensionDataObject = true,
                    SerializeReadOnlyTypes = false,
                    KnownTypes = GetDiagramTypes(),
                };
                var s = new DataContractSerializer(typeof(DigitalLogicDiagram), settings);
                using var reader = XmlReader.Create(stream);
                return (DigitalLogicDiagram?)s.ReadObject(reader);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        return null;
    }

    public static async Task SaveDiagram(DigitalLogicDiagram? diagram)
    {
        if (diagram is null)
        {
            return;
        }

        var storageProvider = StorageService.GetStorageProvider();
        if (storageProvider is null)
        {
            return;
        }

        var file = await storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Save diagram",
            FileTypeChoices = GetSaveFileTypes(),
            SuggestedFileName = Path.GetFileNameWithoutExtension("diagram"),
            DefaultExtension = "xml",
            ShowOverwritePrompt = true
        });

        if (file is not null && file.CanOpenWrite)
        {
            try
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
                await using var stream = await file.OpenWriteAsync();
                await using var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, IndentChars = "    " });
                s.WriteObject(writer, diagram);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
