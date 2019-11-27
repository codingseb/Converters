using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Data;

namespace CodingSeb.Converters
{
    /// <summary>
    /// To Convert a string to a filename appending the directory and a extension
    /// </summary>
    public class FileNameConverter : BaseConverter, IValueConverter
    {
        /// <summary>
        /// The extension to add to the binding with the dot.
        /// By default ".png"
        /// </summary>
        public string Extension { get; set; } = ".png";

        /// <summary>
        /// An optional prefix to add to the filename
        /// By default : string.Empty
        /// </summary>
        public string FileNamePrefix { get; set; } = string.Empty;

        /// <summary>
        /// The optional directory (from PathFrom) where to find the file
        /// By default string.Empty (look directly in the root folder)
        /// In case of DirectoryPathFrom == AbsoluteDirectrory must provide a full path to the directory.
        /// </summary>
        public string Directory { get; set; } = string.Empty;

        /// <summary>
        /// The root directory from where to find the file.
        /// By default ExecutingAssemblyDirectory
        /// </summary>
        public DirectoryPath DirectoryPathFrom { get; set; } = DirectoryPath.ExecutingAssemblyDirectory;

        /// <summary>
        /// if <c>true</c> the converter return a Uri in place of a string
        /// if <c>false</c> the converter return a string
        /// By default : false 
        /// </summary>
        public bool AsUri { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result;
            switch (DirectoryPathFrom)
            {
                case DirectoryPath.AbsolutePath:
                    result = Path.Combine(Directory, FileNamePrefix + value.ToString() + Extension);
                    break;
                case DirectoryPath.EntryAssemblyDirectory:
                    result = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Directory, FileNamePrefix + value.ToString() + Extension);
                    break;
                case DirectoryPath.ExecutingAssemblyDirectory:
                    result = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), Directory, FileNamePrefix + value.ToString() + Extension);
                    break;
                default:
                    Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), DirectoryPathFrom.ToString());

                    result = Path.Combine(Environment.GetFolderPath(specialFolder), Directory, FileNamePrefix + value.ToString() + Extension);
                    break;
            }

            return AsUri ? (object)new Uri(result) : result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Path.GetFileNameWithoutExtension(value.ToString());
        }
    }
}
