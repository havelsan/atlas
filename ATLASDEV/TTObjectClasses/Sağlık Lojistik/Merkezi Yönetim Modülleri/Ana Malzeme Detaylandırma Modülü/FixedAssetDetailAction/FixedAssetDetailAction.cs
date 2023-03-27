
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
    /// Ana Malzeme Detaylandırma İşlemi
    /// </summary>
    public  partial class FixedAssetDetailAction : BaseCentralAction
    {
        
                    
        protected override void PreInsert()
        {
#region PreInsert
            


            base.PreInsert();

            if (string.IsNullOrEmpty(WorkListDescription))
            {
                if (StockCard != null)
                    WorkListDescription = StockCard.NATOStockNO + " - " + StockCard.Name + " Detaylandırılması";
            }



#endregion PreInsert
        }

        protected void PreTransition_StageTwo2StageThree()
        {
            // From State : StageTwo   To State : StageThree
#region PreTransition_StageTwo2StageThree
            
            




            int errorCount = 0;
            foreach (FixedAssetDetailActionDet det in FixedAssetDetailActionDetails)
            {
                if (det.IsBMM == false)
                    errorCount = errorCount + 1;
            }

            if (errorCount > 0)
                throw new TTException("Henüz tamamlanmamış " + errorCount.ToString() + " detay bulunmaktadır");

            List<TTObject> objList = PrepareRemoteObject(this);
            // FixedAssetDetailAction.RemoteMethods.SendFixedAssetDetailAction(Sites.SiteMerkezSagKom, objList);
           // FixedAssetDetailAction.RemoteMethods.SendCreatingCenterFixDetAc(Sites.SiteMerkezSagKom, objList);


#endregion PreTransition_StageTwo2StageThree
        }

        protected void PreTransition_StageTwo2StageOne()
        {
            // From State : StageTwo   To State : StageOne
#region PreTransition_StageTwo2StageOne
            





            foreach (FixedAssetDetailActionDet det in FixedAssetDetailActionDetails)
            {
                det.IsBMM = false;
                det.IsAccountancy = false;
            }

           

#endregion PreTransition_StageTwo2StageOne
        }

        protected void PreTransition_StageThree2Completed()
        {
            // From State : StageThree   To State : Completed
#region PreTransition_StageThree2Completed
            






            int errorCount = 0;
            foreach (FixedAssetDetailActionDet det in FixedAssetDetailActionDetails)
            {
                if (det.IsETKM == false)
                    errorCount = errorCount + 1;
            }

            if (errorCount > 0)
                throw new TTException("Henüz tamamlanmamış " + errorCount.ToString() + " detay bulunmaktadır");

            foreach (FixedAssetDetailActionDet detail in FixedAssetDetailActionDetails)
            {
                detail.FixedAssetMaterialDefinition.IsApprovalFixedAsset = true;
                if (detail.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail != null)
                {
                    FixedAssetMaterialDefinitionDetail det = detail.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail;
                    if (det.FixedAssetDetailMarkDef != null)
                        detail.FixedAssetMaterialDefinition.Mark = det.FixedAssetDetailMarkDef.MarkName;
                    else
                        detail.FixedAssetMaterialDefinition.Mark = "-";

                    if (det.FixedAssetDetailModelDef != null)
                        detail.FixedAssetMaterialDefinition.Model = det.FixedAssetDetailModelDef.ModelName;
                    else
                        detail.FixedAssetMaterialDefinition.Model = "-";

                    if (det.SerialNumber != null)
                        detail.FixedAssetMaterialDefinition.SerialNumber = det.SerialNumber;
                    else
                        detail.FixedAssetMaterialDefinition.SerialNumber = "-";

                    if (det.Frequency != null)
                        detail.FixedAssetMaterialDefinition.Frequency = det.Frequency.ToString();
                    else
                        detail.FixedAssetMaterialDefinition.Frequency = "-";

                    if (det.Voltage != null)
                        detail.FixedAssetMaterialDefinition.Voltage = det.Voltage.ToString();
                    else
                        detail.FixedAssetMaterialDefinition.Voltage = "-";

                    if (det.Power != null)
                        detail.FixedAssetMaterialDefinition.Power = det.Power.ToString();
                    else
                        detail.FixedAssetMaterialDefinition.Power = "-";

                    if (det.GuarantyStartDate != null)
                        detail.FixedAssetMaterialDefinition.GuarantyStartDate = det.GuarantyStartDate;
                    if (det.GuarantiePeriod != null)
                        detail.FixedAssetMaterialDefinition.GuarantyEndDate = ((DateTime)det.GuarantyStartDate).AddDays((int)det.GuarantiePeriod);
                    if (det.LastCalibrationDate != null)
                        detail.FixedAssetMaterialDefinition.LastCalibrationDate = det.LastCalibrationDate;
                    if (det.LastMaintenanceDate != null)
                        detail.FixedAssetMaterialDefinition.LastMaintenanceDate = det.LastMaintenanceDate;
                }
            }




#endregion PreTransition_StageThree2Completed
        }

        protected void PostTransition_StageThree2Completed()
        {
            // From State : StageThree   To State : Completed
#region PostTransition_StageThree2Completed
            
            


            List<TTObject> objList = PrepareRemoteObject(this);
            //FixedAssetDetailAction.RemoteMethods.SendFixedAssetDetailAction(this.FromSite.ObjectID, objList);
          //  FixedAssetDetailAction.RemoteMethods.SendFixedAssetDetailAction(Sites.SiteSihhiIkmal, objList);


#endregion PostTransition_StageThree2Completed
        }

        protected void PreTransition_StageThree2StageOne()
        {
            // From State : StageThree   To State : StageOne
#region PreTransition_StageThree2StageOne
            




            foreach (FixedAssetDetailActionDet det in FixedAssetDetailActionDetails)
            {
                det.IsBMM = false;
                det.IsAccountancy = false;
                det.IsETKM = false;
            }

          




#endregion PreTransition_StageThree2StageOne
        }

        protected void PostTransition_StageThree2StageOne()
        {
            // From State : StageThree   To State : StageOne
#region PostTransition_StageThree2StageOne
            
            
            

            List<TTObject> objList = PrepareRemoteObject(this);
         //   FixedAssetDetailAction.RemoteMethods.SendFixedAssetDetailAction(this.FromSite.ObjectID, objList);


#endregion PostTransition_StageThree2StageOne
        }

        protected void PreTransition_StageOne2StageTwo()
        {
            // From State : StageOne   To State : StageTwo
#region PreTransition_StageOne2StageTwo
            




            int errorCount = 0;
            bool setError = false;
            foreach (FixedAssetDetailActionDet det in FixedAssetDetailActionDetails)
            {
                if (det.IsAccountancy == false)
                    errorCount = errorCount + 1;
                if (det.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.IsSetSystemUnit == YesNoEnum.Yes && det.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails.Count < 2)
                    setError = true;
            }

            if (errorCount > 0)
                throw new TTException("Henüz tamamlanmamış " + errorCount.ToString() + " detay bulunmaktadır");

            if (setError)
                throw new TTException(TTUtils.CultureService.GetText("M26846", "Set detayı girilmemiş malzeme bulunmaktadır. Lütfen onları tamamlayarak işleme devam ediniz."));


#endregion PreTransition_StageOne2StageTwo
        }

#region Methods
        public void CreateFixedAssetMaterialAddList(Stock stock, double missingCount, List<FixedAssetMaterialDefinition> fadlist, TTObjectContext context, Accountancy accountancy)
        {
            StockTransaction firtsTrx = null;
            foreach (StockTransaction trx in stock.GetRestFIFOTransactions())
            {
                firtsTrx = trx;
                break;
            }

            if (firtsTrx != null)
            {
                for (int i = 0; i < missingCount; i++)
                {
                    FixedAssetInDetail fixedAssetInDetail = new FixedAssetInDetail(context);
                    fixedAssetInDetail.Description = stock.Material.Name;
                    fixedAssetInDetail.Frequency = string.Empty;
                    fixedAssetInDetail.GuarantyEndDate = null;
                    fixedAssetInDetail.GuarantyStartDate = null;
                    fixedAssetInDetail.Mark = string.Empty;
                    fixedAssetInDetail.Model = string.Empty;
                    fixedAssetInDetail.Power = string.Empty;
                    fixedAssetInDetail.ProductionDate = null;
                    fixedAssetInDetail.SerialNumber = string.Empty;
                    fixedAssetInDetail.Status = FixedAssetStatusEnum.New;
                    fixedAssetInDetail.Voltage = string.Empty;
                    fixedAssetInDetail.StockActionDetail = firtsTrx.StockActionDetail;
                    fixedAssetInDetail.SetNewFixedAssetSerialNumber();

                    FixedAssetMaterialDefinition fixedAssetMaterialDefinition = new FixedAssetMaterialDefinition(context);
                    fixedAssetMaterialDefinition.CopyFromFixedAssetInDetail(fixedAssetInDetail);
                    fixedAssetMaterialDefinition.Stock = stock;
                    fixedAssetMaterialDefinition.Accountancy = accountancy;
                    fixedAssetMaterialDefinition.LastCalibrationDate = TTObjectDefManager.ServerTime.Date;
                    fixedAssetMaterialDefinition.LastMaintenanceDate = TTObjectDefManager.ServerTime.Date;
                    fixedAssetMaterialDefinition.Status = FixedAssetStatusEnum.New;

                    FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(context);
                    fixedAssetTransaction.FixedAsset = fixedAssetMaterialDefinition;
                    fixedAssetTransaction.StockTransaction = firtsTrx;
                    fixedAssetTransaction.Resource = FindResource(stock.Store);
                    fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                    fadlist.Add(fixedAssetMaterialDefinition);
                }
            }
        }

        public Resource FindResource(Store store)
        {
            Resource resource = null;
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            IBindingList resources = Resource.GetResourceByStore(readOnlyContext, store.ObjectID);
            if (resources.Count > 0)
            {
                resource = ((Resource)resources[0]);
            }
            return resource;
        }

        public List<TTObject> PrepareRemoteObject(FixedAssetDetailAction fixedAssetDetailAction)
        {
            List<TTObject> objList = new List<TTObject>();
            objList.Add(fixedAssetDetailAction);
            foreach (FixedAssetDetailActionDet det in fixedAssetDetailAction.FixedAssetDetailActionDetails)
            {
                objList.Add(det);
                objList.Add(det.FixedAssetMaterialDefinition);
                objList.Add(det.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail);
                if (det.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails != null)
                {
                    foreach (SetMaterialDetailDef setMaterialDetailDef in det.FixedAssetMaterialDefinition.FixedAssetMaterialDefDetail.SetMaterialDetails)
                        objList.Add(setMaterialDetailDef);
                }
            }
            return objList;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FixedAssetDetailAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FixedAssetDetailAction.States.StageTwo && toState == FixedAssetDetailAction.States.StageThree)
                PreTransition_StageTwo2StageThree();
            else if (fromState == FixedAssetDetailAction.States.StageTwo && toState == FixedAssetDetailAction.States.StageOne)
                PreTransition_StageTwo2StageOne();
            else if (fromState == FixedAssetDetailAction.States.StageThree && toState == FixedAssetDetailAction.States.Completed)
                PreTransition_StageThree2Completed();
            else if (fromState == FixedAssetDetailAction.States.StageThree && toState == FixedAssetDetailAction.States.StageOne)
                PreTransition_StageThree2StageOne();
            else if (fromState == FixedAssetDetailAction.States.StageOne && toState == FixedAssetDetailAction.States.StageTwo)
                PreTransition_StageOne2StageTwo();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FixedAssetDetailAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FixedAssetDetailAction.States.StageThree && toState == FixedAssetDetailAction.States.Completed)
                PostTransition_StageThree2Completed();
            else if (fromState == FixedAssetDetailAction.States.StageThree && toState == FixedAssetDetailAction.States.StageOne)
                PostTransition_StageThree2StageOne();
        }

    }
}