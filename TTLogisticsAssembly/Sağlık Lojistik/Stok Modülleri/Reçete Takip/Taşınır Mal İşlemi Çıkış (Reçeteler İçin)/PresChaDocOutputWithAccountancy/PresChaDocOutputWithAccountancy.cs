
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
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocOutputWithAccountancy : ChattelDocumentOutputWithAccountancy, IAutoDocumentNumber, IAutoDocumentRecordLog, IBasePrescriptionTransaction, IChattelDocumentOutputWithAccountancy, ICheckStockActionOutDetail, IStockOutTransaction, IStockReservation
    {
        
                    
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (PresChaDocOutputDetWithAccountancy presChaDocOutputDetWithAccountancy in PresChaDocOutputWithAccountancyDetails)
                presChaDocOutputDetWithAccountancy.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

#region Methods
        public PresChaDocInputWithAccountancy CreatePresChaInputDoc(PresChaDocOutputWithAccountancy outputDocument, TTObjectContext context)
        {
            PresChaDocInputWithAccountancy presChaDocInputWithAccountancy = new PresChaDocInputWithAccountancy(context);
            presChaDocInputWithAccountancy.CurrentStateDefID = PresChaDocInputWithAccountancy.States.New;
            presChaDocInputWithAccountancy.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
            presChaDocInputWithAccountancy.IsEntryOldMaterial = true;
            outputDocument.InputDocumentObjectID = presChaDocInputWithAccountancy.ObjectID;

            foreach (PresChaDocOutputDetWithAccountancy outDet in outputDocument.PresChaDocOutputWithAccountancyDetails)
            {
                PresChaDocInputDetWithAccountancy inDet = new PresChaDocInputDetWithAccountancy(context);
                inDet.Amount = outDet.Amount;
                inDet.Material = outDet.Material;
                inDet.Price = outDet.Price;
                inDet.SentAmount = outDet.Amount;
                inDet.StockLevelType = outDet.StockLevelType;
                inDet.UnitPrice = outDet.UnitPrice;
                foreach (PrescriptionPaperOutDetail paper in outDet.PrescriptionPaperOutDetails)
                {
                    PrescriptionPaperInDetail prescriptionPaperInDetail = new PrescriptionPaperInDetail(context);
                    prescriptionPaperInDetail.SerialNo = paper.PrescriptionPaper.SerialNo;
                    prescriptionPaperInDetail.VolumeNo = paper.PrescriptionPaper.VolumeNo;
                    prescriptionPaperInDetail.StockActionDetailIn = inDet;
                }
                inDet.PresChaDocInputWithAccountancy = presChaDocInputWithAccountancy;
            }
            return presChaDocInputWithAccountancy;
        }

        public void SendGeneratedDocumentToTargetSite(PresChaDocInputWithAccountancy chatInputDocument, Accountancy sourceAccountancy, Sites targetSite)
        {
//            List<TTObject> list = new List<TTObject>();
//            bool senddable = false;
//            if (sourceAccountancy.AccountancyMilitaryUnit == null)
//                return;
//
//            if (sourceAccountancy.AccountancyMilitaryUnit.IsSupported == null)
//                return;
//
//            if ((bool)sourceAccountancy.AccountancyMilitaryUnit.IsSupported)
//            {
//                senddable = true;
//                list.Add(chatInputDocument.Accountancy);
//                list.Add((TTObject)chatInputDocument);
//
//                foreach (PresChaDocInputDetWithAccountancy chatDet in chatInputDocument.PresChaDocInputWithAccountancyDetails)
//                {
//                    foreach (PrescriptionPaperInDetail prescriptionPaperInDetail in chatDet.PrescriptionPaperInDetails)
//                        list.Add(prescriptionPaperInDetail);
//
//                    foreach (InvoiceDetail invoice in chatDet.InvoiceDetails)
//                        list.Add(invoice);
//
//                    list.Add((TTObject)chatDet);
//                }
//
//            }
//
//            if (senddable)
//            {
//                Sites site = (Sites)sourceAccountancy.AccountancyMilitaryUnit.Site;
//                PresChaDocOutputWithAccountancy.RemoteMethods.CreatePresInputSendingDoc(site.ObjectID, list, sourceAccountancy);
//            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresChaDocOutputWithAccountancy).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresChaDocOutputWithAccountancy.States.Completed && toState == PresChaDocOutputWithAccountancy.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }
        
    }
}