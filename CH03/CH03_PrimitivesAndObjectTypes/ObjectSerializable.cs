namespace CH03_PrimitivesAndObjectTypes
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable]
    public class ObjectSerialize : IXmlSerializable
    {
        public object Object { get; set; }

        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        public void ReadXml(XmlReader reader)
        {

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Object");
            var properties = Object.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                try
                {
                    writer.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(Object).ToString());
                }
                catch { }
            }
            writer.WriteEndElement();
        }
    }
}
