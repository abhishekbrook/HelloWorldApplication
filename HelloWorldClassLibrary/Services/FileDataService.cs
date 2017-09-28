/*  This library class FileDataService implements generic interface IDataService
 *  It provides methods to Read and display data.
 *  We use the constructor injection attribute above the constructor to inject IDataModel dependency.
 * 
 */

using System;
using System.Configuration;
using HelloWorldClassLibrary.Services;
using Microsoft.Practices.Unity;

namespace HelloWorldClassLibrary
{
    /// <summary>
    /// File data service.
    /// </summary>
    public class FileDataService : IDataService
    {
        private IDataModel dataModel = null;

        #region Constructors

        /// <summary>
        /// Default parameterless constructor required for Test Project
        /// </summary>

        public FileDataService()
        {
            this.dataModel = new FileDataModel();
        }

        /// <summary>
        /// Initializes a new instance of the FileDataService class.
        /// Injects the dependency IDataModel through constructor injection
        /// </summary>
        /// <param name="data">dataModel.</param>

        [InjectionConstructor]
        public FileDataService(IDataModel dataModel)
        {
            this.dataModel = dataModel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the data.
        /// </summary>
        /// <returns>The data.</returns>

        public string DisplayData()
        {
            if (dataModel != null)
                return dataModel.Data;
			else
				return string.Empty;
        }


        /// <summary>
        /// Reads the data from the config file and stores it in Model 
        /// </summary>

        public void ReadData()
        {
            try
            {
                // stores file data into model
                dataModel.Data = ConfigurationManager.AppSettings["data"].ToString();
            }
            catch (ConfigurationErrorsException con_ex)
            {   
                // log the exception
                LoggingService.WriteLog("ReadData",con_ex);
            }
			catch (Exception ex)
			{
				// log the exception
				LoggingService.WriteLog("ReadData", ex);
			}

        }
        #endregion
    }
}
