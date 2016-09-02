using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Attrahere.Tools.DataIO
{
    public static class FractalWriter
    {
        public static void SaveAs(Model.GeneratorSettings generatorSettings, string filename)
        {
            if (File.Exists(filename))
            {
                MessageBoxResult result = MessageBox.Show("File '" + filename + "'already exist. Do you wan to overrite it?", "File exist", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _saveAs(generatorSettings, filename);
                }
            }
            else
            {
                _saveAs(generatorSettings, filename);
            }       
        }

        private static void _saveAs(Model.GeneratorSettings generatorSettings, string filename)
        {
            FileInfo fi = new FileInfo(filename);
            switch (fi.Extension)
            {
                case ".att1":
                    FractalWriter._saveAs_Att1(generatorSettings, filename);
                    break;
                default:
                    MessageBox.Show("File extension is not supported");
                    break;
            }
        }

        public static Model.GeneratorSettings LoadData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);              
                switch (fi.Extension)
                {
                    case ".att1":
                        return _load_Att1(filename);
                    default:
                        MessageBox.Show("File extension is not supported");
                        break;
                }
            }
            MessageBox.Show("File do not exist");
            return null;
        }

        private static void _saveAs_Att1(Model.GeneratorSettings generatorSettings, string filename)
        {
            FileStream stream = File.Create(filename);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, new Model.Extensions.IOData_Att1(generatorSettings));
            stream.Close();
        }

        private static Model.GeneratorSettings _load_Att1(string filename)
        {
            FileStream stream = File.OpenRead(filename);
            var formatter = new BinaryFormatter();
            Model.Extensions.IOData_Att1 data = (Model.Extensions.IOData_Att1)formatter.Deserialize(stream);
            stream.Close();
            return data.ReturnSettings();
        }
    }
}
