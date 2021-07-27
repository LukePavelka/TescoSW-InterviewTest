using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using TescoSWLibrary.Xml;
using TescoSWLibrary.Xml.Models;

namespace TescoSWWpf
{
    public class FileXml
    {
        public static CarRootModel LoadFromDisk()
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse XML Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if ((bool)openFile.ShowDialog())
            {
                CarRootModel Data = new CarRootModel();
                try
                {
                    Data = Car.XmlDeserialise(openFile.FileName ?? null);
                }
                catch (Exception e)
                {
                    string Message = "Xml cannot be loaded because it does not match the model.\n" +
                                      "The Application can be loaded with an xml that has a model designed specifically for it.";

                    MessageBox.Show($"{Message}\n\n\nRaw Error:\n{e}", "Error");
                }
                return Data;
            }
            else
            {
                return new CarRootModel();
            }
        }
    }
}
