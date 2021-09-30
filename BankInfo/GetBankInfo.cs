using System;
using System.IO;
using System.Net;
using System.Xml;

namespace BankInfo
{
    public  class GetBankInfo
    {

        #region Конвертация бик
        public static string BicToIntCode(string bik)
        {
            var _url = "http://www.cbr.ru/CreditInfoWebServ/CreditOrgInfo.asmx";
            var _action = "http://web.cbr.ru/BicToIntCode";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelopeBicToIntCode(bik);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
               return soapResult;
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
                        return webRequest;
        }

        private static XmlDocument CreateSoapEnvelopeBicToIntCode( string bik)
        {


            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
            $@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                <soap:Body>
                <BicToIntCode xmlns = ""http://web.cbr.ru/"">
                <BicCode>{bik}</BicCode>
                </BicToIntCode>
                </soap:Body>
            </soap:Envelope>");
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        #endregion

        #region Получение банка
        public static string CreditInfoByIntCodeExXML(string codeBanc)
        {

            var _url = "http://www.cbr.ru/CreditInfoWebServ/CreditOrgInfo.asmx";
            var _action = "http://web.cbr.ru/CreditInfoByRegCodeShortXML";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelopeCreditInfoByIntCode(codeBanc);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                return soapResult;
            }
        }

        private static XmlDocument CreateSoapEnvelopeCreditInfoByIntCode(string codeBanc)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
            $@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
            xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
            xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <CreditInfoByRegCodeShortXML xmlns=""http://web.cbr.ru/"">
      <CredorgNumber>{codeBanc}</CredorgNumber>
    </CreditInfoByRegCodeShortXML>
  </soap:Body>
</soap:Envelope>");
            return soapEnvelopeDocument;
        }
        #endregion

        public static string Getcode(string xmldoc) 
        {            XmlDocument parsXmlDoc = new XmlDocument();
            parsXmlDoc.LoadXml(xmldoc);
            return parsXmlDoc.GetElementsByTagName("BicToIntCodeResult")[0].InnerText;
                   
        }


        public static string GetBank(string bik) 
        
        {
            string code = Getcode(BicToIntCode(bik));

            return CreditInfoByIntCodeExXML(code);

        }
    }
}
