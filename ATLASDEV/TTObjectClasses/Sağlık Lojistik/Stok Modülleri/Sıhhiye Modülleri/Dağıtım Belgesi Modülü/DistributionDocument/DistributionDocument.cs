
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
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
    public partial class DistributionDocument : StockAction, IStockReservation, IAutoDocumentNumber, IStockTransferTransaction, IDistributionDocument, ICheckStockActionOutDetail, IAutoDocumentRecordLog
    {
        public partial class GetDistributionDocumentCensusReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class CensusReportNQL_DistributionDocument_Class : TTReportNqlObject
        {
        }

        

        protected void PostTransition_StockCardRegistry2Completed()
        {
            // From State : StockCardRegistry   To State : Completed
            #region PostTransition_StockCardRegistry2Completed

            if (TransDef != null && DistributionDepStoreObjectID != null)
            {
                SendDocumentToTargetSite();
            }

            #endregion PostTransition_StockCardRegistry2Completed
        }

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            if(DistributionDocumentMaterials != null)
            {
                if(DistributionDocumentMaterials.Count > 0)
                {
                    foreach(DistributionDocumentMaterial material in DistributionDocumentMaterials)
                    {
                        material.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                }
            }

            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_StockCardRegistry2Cancelled()
        {
            // From State : StockCardRegistry   To State : Cancelled
            #region PostTransition_StockCardRegistry2Cancelled

            if (DistributionDepStoreObjectID != null)
            {
                CancelDocumentToTargetSite();
            }

            #endregion PostTransition_StockCardRegistry2Cancelled
        }

        protected void PreTransition_StockCardRegistry2MKYS()
        {
            // From State : StockCardRegistry   To State : MKYS
            #region PreTransition_StockCardRegistry2MKYS
            /*
            if(Store != null && Store.UnitStoreGetData == null)
                throw new TTException(Store.Name + " adlı Ana Depo (Saymanlık) Tanımındaki MKYS Depo bilgisi boş olduğu için MKYS adımına geçilemez.");
            
            if(DestinationStore != null )
                throw new TTException(DestinationStore.Name + " adlı Ana Depo (Saymanlık) Tanımındaki MKYS Depo bilgisi boş olduğu için MKYS adımına geçilemez.");
            
            if(Store != null && Store is MainStoreDefinition)
            {
                if(((MainStoreDefinition)Store).Accountancy != null && ((MainStoreDefinition)Store).Accountancy.UnitStoreGetData == null)
                    throw new TTException(((MainStoreDefinition)Store).Accountancy.Name + " adlı Saymanlık Tanımındaki MKYS Depo bilgisi boş olduğu için MKYS adımına geçilemez.");
            }
            
            if(DestinationStore != null && DestinationStore is MainStoreDefinition)
            {
                if(((MainStoreDefinition)DestinationStore).Accountancy != null && ((MainStoreDefinition)DestinationStore).Accountancy.UnitStoreGetData == null)
                    throw new TTException(((MainStoreDefinition)DestinationStore).Accountancy.Name + " adlı Saymanlık Tanımındaki MKYS Depo bilgisi boş olduğu için MKYS adımına geçilemez.");
            }
*/
            #endregion PreTransition_StockCardRegistry2MKYS
        }

        protected void PreTransition_New2ClinicApproval()
        {
            // From State : New   To State : ClinicApproval
            #region PreTransition_New2ClinicApproval


            if (DestinationStore is DependentStoreDefinition)
            {
                if (((DependentStoreDefinition)DestinationStore).Site != null)
                {
                    throw new TTException(SystemMessage.GetMessage(1191));
                }
            }
            #endregion PreTransition_New2ClinicApproval
        }

        protected void PreTransition_MKYS2Completed()
        {
            // From State : MKYS   To State : Completed
            #region PreTransition_MKYS2Completed



            if (MKYSControl == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26672", "Önce MKYS Gönder Yapmanız Gerekmektedir.!"));
            }
            #endregion PreTransition_MKYS2Completed
        }

        protected void PostTransition_MKYS2Completed()
        {
            // From State : MKYS   To State : Completed
            #region PostTransition_MKYS2Completed

            if (TransDef != null && DistributionDepStoreObjectID != null)
            {
                SendDocumentToTargetSite();
            }

            #endregion PostTransition_MKYS2Completed
        }



        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled

            MKYSControl = false;

            #endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_StoreApproval2Completed()
        {
            // From State : StoreApproval   To State : Completed
            #region PreTransition_StoreApproval2Completed
            if (string.IsNullOrEmpty(MKYS_TeslimAlan))
                throw new Exception(TTUtils.CultureService.GetText("M27093", "Teslim Alan Boş Geçilemez."));
            if (string.IsNullOrEmpty(MKYS_TeslimEden))
                throw new Exception(TTUtils.CultureService.GetText("M27094", "Teslim Eden Boş Geçilemez."));
            #endregion PreTransition_StoreApproval2Completed
        }

        protected void PreTransition_Approval2StoreApproval()
        {
            // From State : Approval   To State : StoreApproval
            #region PreTransition_Approval2StoreApproval
            if (string.IsNullOrEmpty(MKYS_TeslimAlan))
                throw new Exception(TTUtils.CultureService.GetText("M27093", "Teslim Alan Boş Geçilemez."));
            if (string.IsNullOrEmpty(MKYS_TeslimEden))
                throw new Exception(TTUtils.CultureService.GetText("M27094", "Teslim Eden Boş Geçilemez."));
            #endregion PreTransition_Approval2StoreApproval
        }

        #region Methods
        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (DistributionDocumentMaterial detail in DistributionDocumentMaterials)
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

        public void SendDocumentToTargetSite()
        {
            List<TTObject> list = new List<TTObject>();
            TTObjectContext ctx = new TTObjectContext(false);
            list.Add((TTObject)this);
            foreach (DistributionDocumentMaterial matDet in DistributionDocumentMaterials)
            {
                foreach (FixedAssetOutDetail fixedAssetDetail in matDet.FixedAssetOutDetails)
                {
                    list.Add(fixedAssetDetail);
                    FixedAssetMaterialDefinition fixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)ctx.GetObject(fixedAssetDetail.FixedAssetMaterialDefinition.ObjectID, fixedAssetDetail.FixedAssetMaterialDefinition.ObjectDef);
                    fixedAssetMaterialDefinition.Resource = null;
                    fixedAssetMaterialDefinition.Stock = null;
                    list.Add(fixedAssetMaterialDefinition);
                }

                foreach (OuttableLot outtableLot in matDet.OuttableLots)
                {
                    if ((bool)outtableLot.isUse)
                    {
                        list.Add(outtableLot);
                    }
                }


                list.Add((TTObject)matDet);
            }
            ctx.Dispose();
            Sites site = (Sites)((DependentStoreDefinition)DestinationStore).Site;
            //DistributionDocument.RemoteMethods.UpdateDistributionDepStore(site.ObjectID, list);

        }

        public void CancelDocumentToTargetSite()
        {
            List<TTObject> list = new List<TTObject>();

            list.Add((TTObject)this);
            foreach (DistributionDocumentMaterial matDet in DistributionDocumentMaterials)
            {
                list.Add((TTObject)matDet);
            }

            Sites site = (Sites)((DependentStoreDefinition)DestinationStore).Site;
            //DistributionDocument.RemoteMethods.CancelDistributionDepStore(site.ObjectID, list);
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
            if (transDef.ObjectDef.CodeName != typeof(DistributionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DistributionDocument.States.StoreApproval  && toState == DistributionDocument.States.Completed)
                PreTransition_StoreApproval2Completed();


            if (fromState == DistributionDocument.States.Approval && toState == DistributionDocument.States.StoreApproval)
                PreTransition_Approval2StoreApproval();

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DistributionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DistributionDocument.States.New && toState == DistributionDocument.States.Cancelled)
                PostTransition_New2Cancelled();
        }


    }
}