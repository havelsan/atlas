
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
    public  partial class MainStoreDistributionDoc : StockAction, IAutoDocumentNumber, IAutoDocumentRecordLog, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction
    {
        #region
        #region IAutoDocumentRecordLog Member
        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> GetDocumentRecordLogContents()
        {
            return DocumentRecordLogContents;
        }

        #endregion
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #region IStockTransferTransaction Members
        public void SetDestinationStore(Store value)
        {
            DestinationStore = value;
        }
        #endregion
        #endregion Methods


        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval
            if (string.IsNullOrEmpty(MKYS_TeslimAlan))
                throw new Exception(TTUtils.CultureService.GetText("M27093", "Teslim Alan Boş Geçilemez."));
            if (string.IsNullOrEmpty(MKYS_TeslimEden))
                throw new Exception(TTUtils.CultureService.GetText("M27094", "Teslim Eden Boş Geçilemez."));
            #endregion PreTransition_New2Approval
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : New   To State : Approval
            #region PreTransition_Approval2Completed
            if (string.IsNullOrEmpty(MKYS_TeslimAlan))
                throw new Exception(TTUtils.CultureService.GetText("M27093", "Teslim Alan Boş Geçilemez."));
            if (string.IsNullOrEmpty(MKYS_TeslimEden))
                throw new Exception(TTUtils.CultureService.GetText("M27094", "Teslim Eden Boş Geçilemez."));
            #endregion PreTransition_Approval2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled

            MKYSControl = false;

            #endregion PreTransition_Completed2Cancelled
        }

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (MainStoreDistDocDetail detail in MainStoreDistDocDetails)
                {
                    foreach (StockTransaction outTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (outTrx.InOut == TransactionTypeEnum.Out)
                        {
                            if (outTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(outTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)outTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (outRecordLogs.ContainsKey(butce))
                            {
                                if (outRecordLogs[butce].Contains(detail) == false)
                                    outRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                outRecordLogs.Add(butce, dets);
                            }
                        }

                    }
                }

                if (outRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outLog in outRecordLogs)
                    {
                        string place = DestinationStore.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outLog.Key);
                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }

        public void SetMKYSProperties()
        {
            MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;

            MainStoreDefinition mainStoreDefinition = Store as MainStoreDefinition; // Deponun bütçe türünden alınır
            if (mainStoreDefinition != null)
                MKYS_EButceTur = mainStoreDefinition.MKYS_ButceTuru;

            MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketim;



            if (StockActionSignDetails.Count == 0)
            {
                foreach (StockActionSignDetail sing in StockActionSignDetails)
                {

                    if (sing.SignUserType == SignUserTypeEnum.TeslimAlan)
                        MKYS_TeslimAlan = sing.SignUser.Person.FullName;
                    if (sing.SignUserType == SignUserTypeEnum.TeslimEden)
                    {
                        MKYS_TeslimEden = sing.SignUser.Person.FullName;
                        MKYS_CikisYapilanKisiTCNo = sing.SignUser.MkysUserName;
                    }

                }
            }



        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainStoreDistributionDoc).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainStoreDistributionDoc.States.New && toState == MainStoreDistributionDoc.States.Approval)
                PreTransition_New2Approval();

            if (fromState == MainStoreDistributionDoc.States.Approval && toState == MainStoreDistributionDoc.States.Completed) 
                 PreTransition_Approval2Completed();

            if (fromState == MainStoreDistributionDoc.States.Completed && toState == MainStoreDistributionDoc.States.Cancelled)
                PreTransition_Completed2Cancelled();

        }


        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            if (MainStoreDistDocDetails != null)
            {
                if (MainStoreDistDocDetails.Count > 0)
                {
                    foreach (MainStoreDistDocDetail material in MainStoreDistDocDetails)
                    {
                        material.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                }
            }

            #endregion PostTransition_New2Cancelled
        }


        protected void PostTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
            #region PostTransition_Approval2Cancelled

            if (MainStoreDistDocDetails != null)
            {
                if (MainStoreDistDocDetails.Count > 0)
                {
                    foreach (MainStoreDistDocDetail material in MainStoreDistDocDetails)
                    {
                        material.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                }
            }

            #endregion PostTransition_Approval2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainStoreDistributionDoc).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainStoreDistributionDoc.States.Approval && toState == MainStoreDistributionDoc.States.Cancelled) 
                PostTransition_Approval2Cancelled();

            if (fromState == MainStoreDistributionDoc.States.New && toState == MainStoreDistributionDoc.States.Cancelled) 
                PostTransition_New2Cancelled();
        }


    }
}