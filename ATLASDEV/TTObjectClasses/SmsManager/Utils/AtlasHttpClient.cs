using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace AtlasSmsManager
{

    public class AtlasHttpClient
    {
        public static string PostXML(string path, string xmlData, Dictionary<string, string> headers, string contentType = "text/xml")
        {
            try
            {
                var res = "";
                byte[] bytes = Encoding.UTF8.GetBytes(xmlData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = contentType;
                request.Timeout = 300000000;
                if (headers != null && headers.Count > 0)
                {
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                // This sample only checks whether we get an "OK" HTTP status code back.
                // If you must process the XML-based response, you need to read that from
                // the response stream.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }


                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader rdr = new StreamReader(responseStream))
                    {
                        res = rdr.ReadToEnd();

                        //if (SmsManager.Instance is AsistApi)
                        //{
                        //    #region Pursaklar
                        //    int pFrom = res.IndexOf("<sendSmsResult>");
                        //    int pTo = res.LastIndexOf("</sendSmsResponse>");

                        //    String rawXmlOfSoap = res.Substring(pFrom, pTo - pFrom);
                        //    XDocument xDoc = XDocument.Parse(rawXmlOfSoap);

                        //    var sendSMSResult = from smsResult in xDoc.Descendants("sendSmsResult")
                        //                        select smsResult;

                        //    if (sendSMSResult != null && sendSMSResult.Count() > 0)
                        //    {
                        //        string errorCodeValue = sendSMSResult.FirstOrDefault().Element("ErrorCode").Value;
                        //        if (errorCodeValue != "0")
                        //            res = "-1";
                        //    }
                        //}
                        //#endregion Pursaklar
                    }

                    return res;
                }
            }
            catch
            {
                return "-1";
            }
        }
    }
}
