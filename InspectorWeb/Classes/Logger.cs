using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;

namespace InspectorWeb.Classes
{
    public static class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Logger));

        public static void Configure()
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
                var log4NetConfig = new XmlDocument();
                log4NetConfig.Load(File.OpenRead(Path.Combine(path, "log4net.config")));
                var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                    typeof(log4net.Repository.Hierarchy.Hierarchy));
                log4net.Config.XmlConfigurator.Configure(repo, log4NetConfig.DocumentElement);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error configure log4net. " + ex.Message);
            }
        }

        public static void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex);
        }

        public static void Info(string message)
        {
            Log.Info(message);
        }

    }
}