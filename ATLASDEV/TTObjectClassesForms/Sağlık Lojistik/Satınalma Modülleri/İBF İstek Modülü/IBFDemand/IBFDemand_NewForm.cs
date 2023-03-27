
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// İBF İstek Kayıt
    /// </summary>
    public partial class IBFDemand_NewForm : IBFDemand_BaseForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            IBFType.SelectedIndexChanged += new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            IBFYear.TextChanged += new TTControlEventDelegate(IBFYear_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            IBFType.SelectedIndexChanged -= new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            IBFYear.TextChanged -= new TTControlEventDelegate(IBFYear_TextChanged);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region IBFDemand_NewForm_cmdList_Click
   if(IBFType.SelectedItem == null || string.IsNullOrEmpty(IBFYear.Text) == true)
            {
                InfoBox.Show("İBF türü ve istek dönemi seçilmelidir.");
                return;
            }

            IList ardList = AnnualRequirementItemsDefinition.GetAnnualRequirementsDefByYearNQL(_IBFDemand.ObjectContext, Convert.ToInt32(IBFYear.Text), Convert.ToInt32(IBFType.SelectedItem.Value));
            if (ardList.Count == 0)
            {
                InfoBox.Show("Bu yıla ve İBF türüne ait tanım bulunamadı.");
                return;
            }
            _IBFDemand.AnnualReqItemsDefinition = (AnnualRequirementItemsDefinition)ardList[0];

            ClearChildrenCollections();
            ShowNeededGrids();
            
            TTObjectContext objectContext = _IBFDemand.ObjectContext;
            
            switch(Convert.ToInt32(IBFType.SelectedItem.Value))
            {
                case 0: //Piyasa İlaç
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_MarketDrugIn det = new IBFDet_MarketDrugIn(objectContext);
                        det.CurrentStateDefID = IBFDet_MarketDrugIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_MarketDrugIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 1: //XXXXXX İlaç
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_MilitaryDrugIn det = new IBFDet_MilitaryDrugIn(objectContext);
                        det.CurrentStateDefID = IBFDet_MilitaryDrugIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_MilitaryDrugIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 2: //XXXXXX İlaç
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_XXXXXXDrugIn det = new IBFDet_XXXXXXDrugIn(objectContext);
                        det.CurrentStateDefID = IBFDet_XXXXXXDrugIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_XXXXXXDrugIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 3: //Tıbbi Sarf
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_MedicalConsIn det = new IBFDet_MedicalConsIn(objectContext);
                        det.CurrentStateDefID = IBFDet_MedicalConsIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_MedicalConsIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 4: //Tıbbi Cihaz
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_MedicalEquipmentIn det = new IBFDet_MedicalEquipmentIn(objectContext);
                        det.CurrentStateDefID = IBFDet_MedicalEquipmentIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_MedicalEquipmentIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 5: //Yedek Parça
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_SparePartIn det = new IBFDet_SparePartIn(objectContext);
                        det.CurrentStateDefID = IBFDet_SparePartIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_SparePartIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 6: //Serum
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_SerumIn det = new IBFDet_SerumIn(objectContext);
                        det.CurrentStateDefID = IBFDet_SerumIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_SerumIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 7: //Kit
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_KitIn det = new IBFDet_KitIn(objectContext);
                        det.CurrentStateDefID = IBFDet_KitIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_KitIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 8: //Basılı Evrak
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_PrintedDocumentIn det = new IBFDet_PrintedDocumentIn(objectContext);
                        det.CurrentStateDefID = IBFDet_PrintedDocumentIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_PrintedDocumentIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                case 9: //Aşı
                    foreach(AnnualRequirementItem ard in ((AnnualRequirementItemsDefinition)ardList[0]).AnnualRequirementItems)
                    {
                        IBFDet_VaccineIn det = new IBFDet_VaccineIn(objectContext);
                        det.CurrentStateDefID = IBFDet_VaccineIn.States.New;
                        det.OrderNo = _IBFDemand.IBFDet_VaccineIns.Count + 1;
                        det.IBFDemand = _IBFDemand;
                        det.PurchaseItemDef = ard.PurchaseItemDef;
                        det.NSN = det.PurchaseItemDef.GetNSN();
                    }
                    break;
                    
                default:
                    break;
            }
#endregion IBFDemand_NewForm_cmdList_Click
        }

        private void IBFType_SelectedIndexChanged()
        {
#region IBFDemand_NewForm_IBFType_SelectedIndexChanged
   ClearChildrenCollections();
#endregion IBFDemand_NewForm_IBFType_SelectedIndexChanged
        }

        private void IBFYear_TextChanged()
        {
#region IBFDemand_NewForm_IBFYear_TextChanged
   ClearChildrenCollections();
#endregion IBFDemand_NewForm_IBFYear_TextChanged
        }

        protected override void PreScript()
        {
#region IBFDemand_NewForm_PreScript
    base.PreScript();
#endregion IBFDemand_NewForm_PreScript

            }
            
#region IBFDemand_NewForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == IBFDemand.States.ClinicApproval)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _IBFDemand.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                switch (_IBFDemand.IBFType)
                {
                    case IBFTypeEnum.Asi:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_VaccineIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PrintedDocumentIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_XXXXXXDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.Kit:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KitIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MilitaryDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.PiyasaIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MarketDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.Serum:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SerumIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MedicalEquipmentIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MedicalConsIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SpareIBFReport), true, 1, parameter);
                        break;
                        
                    default:
                        break;
                }
                
                if(_IBFDemand.IBFDetDetailOuts.Count > 0)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EkliListeReport), true, 1, parameter);
            }
        }
        
#endregion IBFDemand_NewForm_Methods
    }
}