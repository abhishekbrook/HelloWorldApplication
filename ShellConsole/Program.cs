/* ----------------------------------------------------------------------------------------------------
 * This is the entry point of this project - Main Driver class.
 * This Project is developed using Visual Studio Community 2017 for Mac Version 7.1 (build 1297)
 * Target Framework on all Projects is selected as - Dot Net Framework 4.5
 * 
 * The ShellConsole project consumes a ClassLibrary project- HelloWorldClassLibrary included in the solution
 * HelloWorldClassLibrary currently provides methods to read and display data stored in file(config file)
 * It can be enhanced in future to read and display data stored in databases, xml or any other data source.
 * 
 * The library class FileDataModel implements generic interface IDataModel
 * The library class FileDataService implements generic interface IDataService
 * 
 * HelloWorldTestProject is a NUnit test project and has test cases.
 * 
 * Exception Logging is implemented in the project via log files using LoggingService class in HelloWorldClassLibrary.
 * 
 * We can dynamically inject the dependency (here IDataModel) and based on its pointing 
 * to the classes that implement it it will perform specific operations. 
 * By using IDataService reference pointing to FileDataModel we can read data from file, 
 * By using IDataService reference pointing to XMLDataModel we can read data from  XML file. 
 * By using IDataService reference pointing to DBDataModel we can read data from Database.
 * 
 * And by using Unity Container (Dependency Injection Pattern) 
 * we can dynamically inject this dependency into our application
 * ----------------------------------------------------------------------------------------------------
 */

using System;
using HelloWorldClassLibrary;
using HelloWorldClassLibrary.Services;
using Microsoft.Practices.Unity;

namespace ShellConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                // We will be using Unity IoC container to inject dependency - IDataModel
                // We used contructor injection in FileDataService.
				IUnityContainer unitycontainer = new UnityContainer();
				
                // Here we are registering IDataModel as FileDataModel object
                // because we want to read Hello World from a file
                // We can register it with any class implementing IDataModel interface
                // ex- DataBaseDataModel, XMLDataModel, etc.
                unitycontainer.RegisterType<IDataModel, FileDataModel>();

                // We are resolving dependency 
				FileDataService service = unitycontainer.Resolve<FileDataService>();

                // service instance is reading data from the file and storing in the model
                service.ReadData();
           
				// we are displaying stored data in the model as output
				// In our case its a string - "Hello World from the file"
				Console.WriteLine(service.DisplayData()); 
				Console.ReadLine();

			}
            catch (ResolutionFailedException res_ex)
            {
                LoggingService.WriteLog("main console app",res_ex); 
            }

			catch (Exception ex)
			{
				LoggingService.WriteLog("main console app", ex);
			}

		}
    }
}
