﻿using System;
using System.IO;
using System.Xml.Serialization;

namespace GameSpyLib.XMLConfig
{
    /// <summary>
    /// This class represents an XML configuration parser and saver
    /// </summary>
    public class ConfigManager
    {
        public static XMLConfiguration xmlConfiguration { get; protected set; }

        public static bool Load()
        {
            // Load XML file
            {

                FileStream fstream = File.OpenRead(@"RetroSpyServer.xml");
                //FileStream fstream = new FileStream(fullpath, FileMode.Open,FileAccess.Read,FileShare.Read);

                fstream.Seek(0, SeekOrigin.Begin);
                //stream.Position = 0;
                XmlSerializer serializer = new XmlSerializer(typeof(XMLConfiguration));
                xmlConfiguration = (XMLConfiguration)serializer.Deserialize(fstream);
                fstream.Close();
            }

            // Perform XML validation
            {
                if (xmlConfiguration.Database == null)
                {
                    throw new Exception("Database configuration not specified!");
                }

                if (xmlConfiguration.Database.Type == GameSpyLib.Database.Entity.DatabaseEngine.Mysql)
                {
                    if (xmlConfiguration.Database.Username.Length < 1 ||
                        xmlConfiguration.Database.Hostname.Length < 1 || 
                        xmlConfiguration.Database.Databasename.Length < 1 ||
                        xmlConfiguration.Database.SslMode.Length < 1 )
                    {
                        throw new Exception("Invalid database configuration!");
                    }

                    if (xmlConfiguration.Database.Port < 1)
                        xmlConfiguration.Database.Port = 3306;
                }
                //issue if servers config not exsit this will not throw an exception
                if (xmlConfiguration.Servers == null || xmlConfiguration.Servers.Length < 1)
                {
                    throw new Exception("Server configuration not specified!");
                }



                foreach (ServerConfiguration servercfg in xmlConfiguration.Servers)
                {

                    if (servercfg.Hostname.Length < 1 ||
                        servercfg.Port < 1 ||
                        servercfg.Name.Length < 1)
                        throw new Exception(string.Format("Invalid {0} configuration", servercfg.Name));

                    servercfg.Name = servercfg.Name.ToUpperInvariant();
                }
            }

            return true;
        }
    }
}
