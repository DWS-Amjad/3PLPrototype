namespace Helper
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class XMLManagement<T> where T : new()
    {
        public static readonly XMLManagement<T> Instance = new XMLManagement<T>();
        
        private XMLManagement()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public TResult GetInstance<TResult>(XElement xElement)
        {
            XmlSerializer serializer = null; 
            try
            {
                serializer = new XmlSerializer(Type.GetType(xElement
                                    .Attribute(XName.Get("type")).Value));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Type");
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            using (TextReader reader = new StringReader(xElement.ToString()))
            {
                return (TResult)serializer.Deserialize(reader);
            }
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
            configs = new T();
            try
            {
                //XmlSerializer deserializer = new XmlSerializer(typeof(T));
                TextReader textReader = new StreamReader(filename);
                configs = (T)xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
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
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        public T UnMarshalingFromXElement(XElement element)
        {
            object obj = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                obj = (T)serializer.Deserialize(element.CreateReader());
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return (T)obj;
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
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
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
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
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
    /*public class XMLManagement<T> where T : new()
        {
            private static readonly Lazy<XMLManagement<T>> lazy = new Lazy<XMLManagement<T>>(() => new XMLManagement<T>());

            public static XMLManagement<T> Instance
            {
                get
                {
                    return lazy.Value;
                }
            }

            private XMLManagement()
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

