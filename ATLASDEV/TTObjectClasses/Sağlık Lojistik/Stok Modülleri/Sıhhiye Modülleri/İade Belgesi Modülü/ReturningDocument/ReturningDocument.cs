
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
    /// İade Belgesi için kullanılan temel sınıftır
    /// </summary>
    public partial class ReturningDocument : StockAction, IAutoDocumentNumber, IStockTransferTransaction, IReturningDocument, ICheckStockActionOutDetail, IAutoDocumentRecordLog
    {
        public partial class GetReturningDocumentCensusReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class CensusReportNQL_ReturningDocument_Class : TTReportNqlObject
        {
        }

        

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            #endregion PreInsert
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval



            if (Store is DependentStoreDefinition)
            {
                if (((DependentStoreDefinition)Store).Site != null)
                {
                    throw new TTException(SystemMessage.GetMessage(1153));
                }
            }
            #endregion PreTransition_New2Approval
        }



        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled

            MKYSControl = false;

            #endregion PreTransition_Completed2Cancelled
        }



        protected void PreTransition_Approval2Complated()
        {
            // From State : Approval   To State : Complated
            #region PreTransition_Approval2Complated

            if (string.IsNullOrEmpty(MKYS_TeslimAlan))
                throw new Exception(TTUtils.CultureService.GetText("M27093", "Teslim Alan Boş Geçilemez."));
            if (string.IsNullOrEmpty(MKYS_TeslimEden))
                throw new Exception(TTUtils.CultureService.GetText("M27094", "Teslim Eden Boş Geçilemez."));


            #endregion PreTransition_Approval2Complated
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            if (ReturningDocumentMaterials != null)
            {
                if (ReturningDocumentMaterials.Count > 0)
                {
                    foreach (ReturningDocumentMaterial material in ReturningDocumentMaterials)
                    {
                        material.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                }
            }

            #endregion PostTransition_New2Cancelled
        }





        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
            #region PostTransition_Approval2Completed          

            if (TransDef != null)
            {
                if (RepairObjectID != null || MaterialRepairObjectID != null)
                {
                    IDeleteRecordDocumentWaste deleteRecordDocumentWaste = (IDeleteRecordDocumentWaste)ObjectContext.CreateObject("DELETERECORDDOCUMENTWASTE");
                    deleteRecordDocumentWaste.CreateDeleteRecordDocumentWaste(this, deleteRecordDocumentWaste);
                }

            }

            #endregion PostTransition_Approval2Completed
        }

        #region Methods

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {

                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ReturningDocumentMaterial detail in ReturningDocumentMaterials)
                {
                    foreach (StockTransaction inTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (inTrx.InOut == TransactionTypeEnum.In)
                        {
                            if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(inTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (inRecordLogs.ContainsKey(butce))
                            {
                                if (inRecordLogs[butce].Contains(detail) == false)
                                    inRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                inRecordLogs.Add(butce, dets);
                            }
                        }
                    }

                }

                if (inRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = ((MainStoreDefinition)DestinationStore).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)DestinationStore).Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, inLog.Value.Count, place, inLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }



        //private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        //public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        //{
        //    get
        //    {
        //        if (this.ReturningDocumentMaterials.Count > 0)
        //        {
        //            _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
        //            _documentRecordLogContents.Add(new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, this.ReturningDocumentMaterials.Count, this.Store.Name));
        //        }
        //        return _documentRecordLogContents;
        //    }
        //}

        public void SendDocumentToTargetSite()
        {
            List<TTObject> list = new List<TTObject>();

            list.Add((TTObject)this);
            foreach (ReturningDocumentMaterial matDet in ReturningDocumentMaterials)
            {
                list.Add((TTObject)matDet);
            }

            Sites site = (Sites)((DependentStoreDefinition)Store).Site;
            // ReturningDocument.RemoteMethods.UpdateReturnDepStore(site.ObjectID, list);

        }

        public void CancelDocumentToTargetSite()
        {
            List<TTObject> list = new List<TTObject>();

            list.Add((TTObject)this);
            foreach (ReturningDocumentMaterial matDet in ReturningDocumentMaterials)
            {
                list.Add((TTObject)matDet);
            }

            Sites site = (Sites)((DependentStoreDefinition)Store).Site;
            // ReturningDocument.RemoteMethods.CancelReturnDepStore(site.ObjectID, list);

        }

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

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReturningDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReturningDocument.States.New && toState == ReturningDocument.States.Approval)
                PreTransition_New2Approval();
            if (fromState == ReturningDocument.States.Approval && toState == ReturningDocument.States.Completed)
                PreTransition_Approval2Complated();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReturningDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReturningDocument.States.New && toState == ReturningDocument.States.Cancelled)
                PostTransition_New2Cancelled();

        }

        public void SendMYKSProperties()
        {
            MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.iadeEdilen;
            MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;

            if (StockActionSignDetails.Count == 0)
            {
                foreach (StockActionSignDetail sing in StockActionSignDetails)
                {

                    if (sing.SignUserType == SignUserTypeEnum.TeslimAlan)
                        MKYS_TeslimAlan = sing.SignUser.Person.FullName;
                    if (sing.SignUserType == SignUserTypeEnum.TeslimEden)
                    {
                        MKYS_TeslimEden = sing.SignUser.Person.FullName;
                    }

                }
            }


        }


    }
}