
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// PTS Giriş İşlemi
    /// </summary>
    public  partial class PTSAction : StockAction, IStockAction
    {
        protected void PreTransition_Approval2CreateInputDocument()
        {
            // From State : Approval   To State : CreateInputDocument
#region PreTransition_Approval2CreateInputDocument
            


            CreateInputDocument();
                

#endregion PreTransition_Approval2CreateInputDocument
        }

        protected void PreTransition_CreateInputDocument2Completed()
        {
            // From State : CreateInputDocument   To State : Completed
#region PreTransition_CreateInputDocument2Completed
            sendToIts();
#endregion PreTransition_CreateInputDocument2Completed
        }

#region Methods
        [Serializable]
        public class TestWebCaller : IWebMethodCallback
        {
            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                    System.IO.File.AppendAllText("c:\\temp\\webmethodcalls.txt", returnValue.ToString());
                else
                    System.IO.File.AppendAllText("c:\\temp\\webmethodcalls.txt", "hello world");
                return false;
            }
            
            public TTObjectContext ObjectContext { get {return new TTObjectContext(false); } }
        }
        
        public void CreateInputDocument()
        {
            ChattelDocumentWithPurchase chattelDocumentWithPurchase = new ChattelDocumentWithPurchase(ObjectContext);
            chattelDocumentWithPurchase.AccountingTerm = AccountingTerm;
            chattelDocumentWithPurchase.ConclusionDateTime = ConclusionDateTime;
            chattelDocumentWithPurchase.ConclusionNumber = ConclusionNumber;
            chattelDocumentWithPurchase.ContractDateTime = ContractDateTime;
            chattelDocumentWithPurchase.ContractNumber = ContractNumber;
            chattelDocumentWithPurchase.ExaminationReportDate = ExaminationReportDate;
            chattelDocumentWithPurchase.ExaminationReportNo = ExaminationReportNo;
            chattelDocumentWithPurchase.FreeEntry = true;
            chattelDocumentWithPurchase.Store = Store;
            chattelDocumentWithPurchase.Supplier = Supplier;
            chattelDocumentWithPurchase.CurrentStateDefID = ChattelDocumentWithPurchase.States.New;

            foreach (PTSActionDetail pTSActionDetail in PTSActionDetails)
            {
                ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase = chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.AddNew();
                chattelDocumentDetailWithPurchase.Amount = pTSActionDetail.Amount;
                chattelDocumentDetailWithPurchase.ExpirationDate = pTSActionDetail.ExpirationDate;
                chattelDocumentDetailWithPurchase.LotNo = pTSActionDetail.LotNo;
                chattelDocumentDetailWithPurchase.Material = pTSActionDetail.Material;
                chattelDocumentDetailWithPurchase.Price = pTSActionDetail.Price;
                chattelDocumentDetailWithPurchase.StockLevelType = pTSActionDetail.StockLevelType;
                chattelDocumentDetailWithPurchase.UnitPrice = pTSActionDetail.UnitPrice;
                if (pTSActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                {
                    foreach (QRCodeInDetail qRCodeIn in chattelDocumentDetailWithPurchase.QRCodeInDetails)
                    {
                        QRCodeInDetail qRCodeInDetail = (QRCodeInDetail)qRCodeIn.Clone();
                        qRCodeInDetail.StockActionDetail = chattelDocumentDetailWithPurchase;
                    }
                }
            }
            
            ChattelDocumentObjectID = chattelDocumentWithPurchase.ObjectID;
            
        }

        public void AddPTSActionDetails(XmlDocument document, PTSAction pTSAction)
        {
            XmlNodeList xnList = document.SelectNodes("transfer/carrier/carrier/productList/serialNumber");
            XmlNodeList sourceGLNList = document.SelectNodes("transfer/sourceGLN");
            XmlNodeList destinationGLNList = document.SelectNodes("transfer/destinationGLN");
            XmlNodeList actionTypeList = document.SelectNodes("transfer/actionType");
            XmlNodeList productList = document.SelectNodes("transfer/carrier/carrier/productList");

            string sourceGLN = string.Empty;
            string destinationGLN = string.Empty;
            string actionType = string.Empty;
            string GTIN = string.Empty;
            string lotNumber = string.Empty;
            string expirationDate = string.Empty;
            string serialNumber = string.Empty;

            foreach (XmlNode xn in sourceGLNList)
                sourceGLN = xn.InnerText;

            foreach (XmlNode xn in destinationGLNList)
                destinationGLN = xn.InnerText;

            foreach (XmlNode xn in actionTypeList)
                actionType = xn.InnerText;



            IList list = pTSAction.ObjectContext.QueryObjects("SUPPLIER", "GLNNO = '" + sourceGLN + "'");
            if (list.Count > 0)
                pTSAction.Supplier = (Supplier)list[0];
            else
                TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27074", "Tedarikçi Bulunamadı."));

            foreach (XmlNode xn in productList)
            {
                GTIN = xn.Attributes.GetNamedItem("GTIN").Value; ;
                lotNumber = xn.Attributes.GetNamedItem("lotNumber").Value;
                expirationDate = xn.Attributes.GetNamedItem("expirationDate").Value;
                int serinoAmount = xn.ChildNodes.Count;

                IList materialList = pTSAction.ObjectContext.QueryObjects("MATERIAL", "BARCODE = '" + GTIN.Substring(1, 13) + "'");
                if (materialList.Count == 1)
                {
                    PTSActionDetail ptsActionDetail = new PTSActionDetail(pTSAction.ObjectContext);
                    ptsActionDetail.StockAction = pTSAction;
                    ptsActionDetail.Material = (Material)materialList[0];
                    ptsActionDetail.LotNo = lotNumber;
                    ptsActionDetail.ExpirationDate = Convert.ToDateTime(expirationDate);
                    ptsActionDetail.StockLevelType = StockLevelType.NewStockLevel;


                    if (ptsActionDetail.Material.PackageAmount != null)
                    {
                        if ((double)ptsActionDetail.Material.PackageAmount > 0)
                            ptsActionDetail.Amount = (double)ptsActionDetail.Material.PackageAmount * serinoAmount;
                        else
                            ptsActionDetail.Amount = serinoAmount;
                    }
                    else
                    {
                        ptsActionDetail.Amount = serinoAmount;
                    }


                    foreach (XmlNode qd in xnList)
                    {
                        QRCodeInDetail qRCodeInDetail = new QRCodeInDetail(pTSAction.ObjectContext);
                        qRCodeInDetail.StockActionDetail = ptsActionDetail;
                        qRCodeInDetail.OrderNo = qd.InnerText;
                        qRCodeInDetail.Barcode = GTIN;
                        qRCodeInDetail.ExpireDate = Convert.ToDateTime(expirationDate);
                        qRCodeInDetail.LotNo = lotNumber;
                    }

                }
                else if (materialList.Count > 1)
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(GTIN.Substring(1, 13) + " barkodlu malzeme birden fazla bulunmuştur.");
                }
                else
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(GTIN.Substring(1, 13) + " barkodlu malzeme bulunamamıştır.");
                }
            }
            
        }
        
        public void sendToIts()
        {
            foreach (PTSActionDetail pTSActionDetail in PTSActionDetails)
            {
                //int count = pTSActionDetail.QRCodeInDetails.Count;
                //ITSSarfBildirimServis.XXXXXXSarfTypeURUN[] urunList = new ITSSarfBildirimServis.XXXXXXSarfTypeURUN[count];
                //int i=0;
                //foreach (QRCodeInDetail item in pTSActionDetail.QRCodeInDetails)
                //{
                //    ITSSarfBildirimServis.XXXXXXSarfTypeURUN urun = new ITSSarfBildirimServis.XXXXXXSarfTypeURUN();
                //    urun.GTIN = item.Barcode;
                //    urun.BN = item.LotNo;
                //    urun.SN = item.OrderNo;
                //    urun.XD = Convert.ToDateTime(pTSActionDetail.ExpirationDate);//Son Kullanma tarihis
                //    urunList[i] = urun;
                //    i++;
                //}

                //ITSSarfBildirimServis.XXXXXXSarfCevapType response = new ITSSarfBildirimServis.XXXXXXSarfCevapType();
                //ITSSarfBildirimServis.XXXXXXSarfType request = new ITSSarfBildirimServis.XXXXXXSarfType();
                //request.URUNLER = urunList;
                //request.DT = "D";
                //request.FR = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");
                //request.ISACIKLAMA = "";

                //string hatakodu = string.Empty;
                //response = ITSSarfBildirimServis.WebMethods.XXXXXXSarfBildir(Sites.SiteLocalHost, request);

                //for (int j=0; j < response.URUNLER.Length; j++)
                //{
                //    if (!response.URUNLER[j].UC.Equals("00000"))
                //    {
                //        IList list = pTSActionDetail.ObjectContext.QueryObjects("ITSERRORCODEDEFINITION", "Code = '" + response.URUNLER[j].UC + "'");
                //        if (list.Count > 0)
                //        {
                //            ITSErrorCodeDefinition err = new ITSErrorCodeDefinition();
                //            err = (ITSErrorCodeDefinition)list[0];
                //            hatakodu += response.URUNLER[j].GTIN + "  hata: " + err.Description + " - ";
                //        }
                //        else
                //        {
                //            hatakodu += response.URUNLER[j].GTIN + "  hatakodu: " + response.URUNLER[j].UC + " - ";
                //        }
                //    }
                //}

                //if (!hatakodu.Equals(""))
                //{
                //    throw new TTException("ITS ye bildirim yapılamadı. " + hatakodu);
                //}
                //else
                //{
                //    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26170", "İşlem Başarı İle Gerçekleşti."));
                //}
            } 
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PTSAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PTSAction.States.Approval && toState == PTSAction.States.CreateInputDocument)
                PreTransition_Approval2CreateInputDocument();
            else if (fromState == PTSAction.States.CreateInputDocument && toState == PTSAction.States.Completed)
                PreTransition_CreateInputDocument2Completed();
        }

    }
}