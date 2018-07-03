namespace ValidationRuleEngine.Helper
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class XMLHelper<T> where T : new()
    {
        public static readonly XMLHelper<T> Instance = new XMLHelper<T>();
        
        private XMLHelper()
        {
        }

        private XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        public XmlSerializer getSerializer()
        {
            return xmlSerializer;
        }

        /// <summary>
        /// Deserialize the XML to Configurations Business Object
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="response"></param>
        public void UnMarshalingFromXML(string filename, out T configs)
        {
            //configs = null;
            try
            {
                //XmlSerializer deserializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StreamReader(filename);
                configs = (T)xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Serialize the Configurations Business Object to XML
        /// </summary>
        /// <param name="response"></param>
        /// <param name="filename"></param>
        public void MarshalingToXML(T configs, string filename)
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                TextWriter textWriter = new StreamWriter(filename);
                xmlSerializer.Serialize(textWriter, configs, ns);
                textWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deserialize from XmlDocument to Configurations Object
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="response"></param>
        public void UnMarshalingFromXMLDocument(XmlDocument xmlDoc, out T xmlObject)
        {
            object obj = null;
            try
            {
                T configs = new T();
                XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
                //XmlSerializer ser = new XmlSerializer(configs.GetType());
                obj = xmlSerializer.Deserialize(reader);
                // Then you just need to cast obj into whatever type it is eg:
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                xmlObject = (T)obj;
            }
        }


        /// <summary>
        /// Serialize from Configurations to XmlDocument Object
        /// </summary>
        /// <param name="response"></param>
        /// <param name="xmlDoc"></param>
        public void MarshalingToXMLDocument(T xmlObject, out XmlDocument xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            //XmlSerializer serializer = new XmlSerializer(xmlObject.GetType());
            MemoryStream stream = new System.IO.MemoryStream();
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                xmlSerializer.Serialize(stream, xmlObject, ns);
                stream.Position = 0;
                doc.LoadXml(stream.ToString());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                xmlDoc = doc;
                stream.Close();
            }
        }

    }



    /// <summary>
    /// Summary description for XMLHelper.
    /// </summary>
    /*public class XMLHelper<T> where T : new()
        {
            private static readonly Lazy<XMLHelper<T>> lazy = new Lazy<XMLHelper<T>>(() => new XMLHelper<T>());

            public static XMLHelper<T> Instance
            {
                get
                {
                    return lazy.Value;
                }
            }

            private XMLHelper()
            {

            }

            private XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            public XmlSerializer getSerializer()
            {
                return xmlSerializer;
            }

            /// <summary>
            /// Deserialize the XML to Configurations Business Object
            /// </summary>
            /// <param name="filename"></param>
            /// <param name="response"></param>
            public void UnMarshalingFromXML(string filename, out T configs)
            {
                //configs = null;
                try
                {
                    //XmlSerializer deserializer = new XmlSerializer(typeof(T));
                    TextReader textReader = new StreamReader(filename);
                    configs = (T)xmlSerializer.Deserialize(textReader);
                    textReader.Close();
                }
                catch (Exception)
                {
                    throw; 
                }
            }



            /// <summary>
            /// Serialize the Configurations Business Object to XML
            /// </summary>
            /// <param name="response"></param>
            /// <param name="filename"></param>
            public void MarshalingToXML(T configs, string filename)
            {
                try
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    TextWriter textWriter = new StreamWriter(filename);
                    xmlSerializer.Serialize(textWriter, configs, ns);
                    textWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }


            /// <summary>
            /// Deserialize from XmlDocument to Configurations Object
            /// </summary>
            /// <param name="xmlDoc"></param>
            /// <param name="response"></param>
            public void UnMarshalingFromXMLDocument(XmlDocument xmlDoc, out T xmlObject)
            {
                object obj = null;
                try
                {
                    T configs = new T();
                    XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
                    //XmlSerializer ser = new XmlSerializer(configs.GetType());
                    obj = xmlSerializer.Deserialize(reader);
                    // Then you just need to cast obj into whatever type it is eg:
                }
                catch (Exception)
                {
                    throw; 
                }
                finally
                {
                    xmlObject = (T)obj;
                }
            }


            /// <summary>
            /// Serialize from Configurations to XmlDocument Object
            /// </summary>
            /// <param name="response"></param>
            /// <param name="xmlDoc"></param>
            public void MarshalingToXMLDocument(T xmlObject, out XmlDocument xmlDoc)
            {
                XmlDocument doc = new XmlDocument();
                //XmlSerializer serializer = new XmlSerializer(xmlObject.GetType());
                MemoryStream stream = new System.IO.MemoryStream();
                try
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    xmlSerializer.Serialize(stream, xmlObject, ns);
                    stream.Position = 0;
                    doc.LoadXml(stream.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    xmlDoc = doc;
                    stream.Close();
                }
            }
        }
   */ }

