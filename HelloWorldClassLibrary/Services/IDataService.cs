using System;
namespace HelloWorldClassLibrary
{

    /// <summary>
    /// Generic interface for Data service.
    /// currently implemented by FileDataService
    /// In future can be implemented by DataBaseDataReader, XMLDataReader etc.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Reads the data from the source
        /// </summary>
        void ReadData();

        /// <summary>
        /// Displays the data.
        /// </summary>
        /// <returns>The data.</returns>
        string DisplayData();

    }
}
