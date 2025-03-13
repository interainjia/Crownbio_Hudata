using System;
using System.Web.Services.Protocols;
using System.Xml;
namespace Crownbio.Common
{
    /// <summary>
    /// Òý·¢SoapExceptionÀà
    /// </summary>
    public class SoapExceptionEngine
    {
        private static XmlNode GetDetailNode(XmlDocument doc, string message, string description)
        {
            XmlNode node3 = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            XmlNode node5 = doc.CreateNode(XmlNodeType.Element, "message", null);
            XmlNode node6 = doc.CreateNode(XmlNodeType.Text, "messagetext", null);
            node6.Value = message;
            node5.AppendChild(node6);
            XmlNode node1 = doc.CreateNode(XmlNodeType.Element, "description", null);
            XmlNode node2 = doc.CreateNode(XmlNodeType.Text, "descriptiontext", null);
            node2.Value = description;
            node1.AppendChild(node2);
            node3.AppendChild(node5);
            node3.AppendChild(node1);
            return node3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static SoapException GetSoapException(string message)
        {
            return SoapExceptionEngine.GetSoapException(message, string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static SoapException GetSoapException(string message, Exception innerException)
        {
            return SoapExceptionEngine.GetSoapException(message, string.Empty, innerException);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static SoapException GetSoapException(string message, string description)
        {
            return SoapExceptionEngine.GetSoapException(message, description, null, string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="description"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static SoapException GetSoapException(string message, string description, Exception innerException)
        {
            return SoapExceptionEngine.GetSoapException(message, description, innerException, string.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="description"></param>
        /// <param name="innerException"></param>
        /// <param name="actor"></param>
        /// <returns></returns>
        public static SoapException GetSoapException(string message, string description, Exception innerException, string actor)
        {
            XmlDocument document1 = new XmlDocument();
            XmlNode node1 = SoapExceptionEngine.GetDetailNode(document1, message, description);
            return new SoapException(message, SoapException.ServerFaultCode, actor, node1, innerException);
        }
    }
}