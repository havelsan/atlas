//$B2940C8D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.IO;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ChattelDocumentOutputWithAccountancyServiceController : Controller
    {
        public class InputForReGeneration
        {
            public string ActionID
            {
                get;
                set;
            }
        }

        public class OutputForReGeneration
        {
            public string OutputMessage
            {
                get;
                set;
            }
            public bool IsTheActionGenerated
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OutputForReGeneration ReGenerateMyChattelDocumentOutputWithAccountancy(InputForReGeneration input)
        {

            OutputForReGeneration outputObject = new OutputForReGeneration();
            try
            {
                BindingList<StockAction.GetClonedStockAction_Class> otherClonedActions = StockAction.GetClonedStockAction(new Guid(input.ActionID));
                if (otherClonedActions.Count > 0)
                {
                    outputObject.IsTheActionGenerated = false;
                    outputObject.OutputMessage = " Bu işlem daha önce " + otherClonedActions[0].StockActionID.ToString() + " işlem olarak kopyanalmış bir daha kopyalamak istiyorsanız bu işlemi iptal etmeniz gerekmektedir.";
                    return outputObject;
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    ChattelDocumentOutputWithAccountancy currentAction = (ChattelDocumentOutputWithAccountancy)context.GetObject(new Guid(input.ActionID), typeof(ChattelDocumentOutputWithAccountancy));

                    if (currentAction != null && currentAction.CurrentStateDefID == ChattelDocumentOutputWithAccountancy.States.Cancelled)
                    {

                        ChattelDocumentOutputWithAccountancy newAction = (ChattelDocumentOutputWithAccountancy)currentAction.Clone();
                        newAction.CurrentStateDefID = ChattelDocumentOutputWithAccountancy.States.New;
                        newAction.Description = currentAction.Description + " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);
                        newAction.StockActionID.GetNextValue();

                        foreach (ChattelDocumentOutputDetailWithAccountancy item in currentAction.ChattelDocumentOutputDetailsWithAccountancy)
                        {
                            ChattelDocumentOutputDetailWithAccountancy detail = (ChattelDocumentOutputDetailWithAccountancy)item.Clone();
                            detail.StockAction = newAction;
                            detail.Status = StockActionDetailStatusEnum.New;
                        }

                        context.Save();

                        outputObject.IsTheActionGenerated = true;
                        outputObject.OutputMessage = newAction.StockActionID.ToString() + " numaralı işlem başarıyla oluşturulmuştur! İş listesinden kontrol ediniz!";
                    }
                    else
                    {
                        outputObject.IsTheActionGenerated = false;
                        outputObject.OutputMessage = TTUtils.CultureService.GetText("M26181", "İşlem kopyası oluşturma başarısız!");
                    }

                    return outputObject;
                }

            }
            catch (Exception ex)
            {
                outputObject.IsTheActionGenerated = false;
                outputObject.OutputMessage = ex.ToString();
                return outputObject;
            }

        }


        public class XmlProduct
        {
            public string GTIN { get; set; }
            public DateTime XD { get; set; }
            public string BN { get; set; }
            public List<string> SN { get; set; }
        }

        public List<XmlProduct> ProductXmlCreate(StockAction stockAction)
        {
            List<XmlProduct> xmlProducts = new List<XmlProduct>();
            List<string> setialNo = new List<string>();
            ChattelDocumentOutputWithAccountancy outAction = (ChattelDocumentOutputWithAccountancy)stockAction;
            foreach (ChattelDocumentOutputDetailWithAccountancy outDetail in outAction.ChattelDocumentOutputDetailsWithAccountancy)
            {
                foreach (ManuelReadQRCode qrcode in outDetail.ManuelReadQRCodes.Select(string.Empty))
                {
                    if (xmlProducts.Select(x => x.BN == qrcode.LotNo && x.GTIN == qrcode.Barcode && x.XD == (DateTime)qrcode.ExpirationDate).Any() == false)
                    {
                        XmlProduct product = new XmlProduct();
                        product.BN = qrcode.LotNo;
                        if (qrcode.Barcode.Length == 13)
                            product.GTIN = "0" + qrcode.Barcode;
                        else
                            product.GTIN = qrcode.Barcode;
                        product.XD = (DateTime)qrcode.ExpirationDate;
                        product.SN = new List<string>();
                        product.SN.Add(qrcode.SerialNo);
                        xmlProducts.Add(product);
                    }
                    else
                    {
                        xmlProducts.FirstOrDefault(x => x.BN == qrcode.LotNo && x.GTIN == qrcode.Barcode && x.XD == (DateTime)qrcode.ExpirationDate).SN.Add(qrcode.SerialNo);
                    }
                }
            }
            return xmlProducts;
        }

        public class DownloadFileInput
        {
            public Guid id { get; set; }
        }

        [HttpPost]
        public string CreateITSXmlFile(DownloadFileInput input)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            ChattelDocumentOutputWithAccountancy stockAction = objectContext.GetObject<ChattelDocumentOutputWithAccountancy>(input.id);

            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                const string ns = "http://www.w3.org/2001/XMLSchema-instance";
                const string its = "http://xxxxxx.com";
                writer.WriteStartElement("transfer");
                writer.WriteAttributeString("xmlns", "xsi", "", ns);
                writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation", its, "packageTransfer.xsd");

                string sourceGLN = ((MainStoreDefinition)stockAction.Store).Accountancy.GLNNo;
                string destinationGLN = stockAction.Accountancy.GLNNo;
                string documentNumber = stockAction.PTSNumber;//PTS NO OLACAK DEĞİŞECEK
                string documentDate = ((DateTime)stockAction.ActionDate).Year.ToString() + "-" + ((DateTime)stockAction.ActionDate).Month.ToString() + "-" + ((DateTime)stockAction.ActionDate).Day.ToString();
                string note = ((MainStoreDefinition)stockAction.Store).Name;
                string version = "1.4";
                string actionType = "T";  //T Transfer
                string containerTypen = "C"; //“P”: Palet, “C”: Koli, “S”: Bağ, “B”: Koli içi kutu, “E”: Küçük bağısimgeleyen
                string carrierLabel = "00000000000000000000"; //SSCC alanı yok o yüzden 20 tane 0 

                writer.WriteElementString("sourceGLN", sourceGLN);
                writer.WriteElementString("destinationGLN", destinationGLN);
                writer.WriteElementString("actionType", actionType);
                writer.WriteElementString("shipTo", destinationGLN);
                writer.WriteElementString("documentNumber", documentNumber);
                writer.WriteElementString("documentDate", documentDate);
                writer.WriteElementString("note", note);
                writer.WriteElementString("version", version);
                writer.WriteStartElement("carrier");
                writer.WriteAttributeString("containerTypen", containerTypen);
                writer.WriteAttributeString("carrierLabel", carrierLabel);

                List<XmlProduct> xmlProductionList = this.ProductXmlCreate(stockAction);
                foreach (XmlProduct product in xmlProductionList)
                {
                    writer.WriteStartElement("productList");
                    writer.WriteAttributeString("expirationDate", product.XD.Year.ToString() + "-" + product.XD.Month.ToString() + "-" + product.XD.Day.ToString());
                    writer.WriteAttributeString("lotNumber", product.BN);
                    writer.WriteAttributeString("GTIN", product.GTIN);
                    foreach (string serialNo in product.SN)
                    {
                        writer.WriteElementString("serialNumber", serialNo);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
            }

            return doc.OuterXml;
        }


    }
}