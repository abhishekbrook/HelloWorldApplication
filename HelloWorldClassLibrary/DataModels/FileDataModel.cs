using System;

namespace HelloWorldClassLibrary
{   
    /// <summary>
    /// File data model.
    /// </summary>
    public class FileDataModel:IDataModel
    {
        private string data = string.Empty; 

        public FileDataModel()
        {
        }


        #region Model Properties
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion
    }
}
