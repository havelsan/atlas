
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
    /// Loj.Şb./İkmal Md.İBF Giriş
    /// </summary>
    public partial class AR_LogBrIBFRegistryForm : AR_BaseForm
    {
        override protected void BindControlEvents()
        {
            IBFYear.TextChanged += new TTControlEventDelegate(IBFYear_TextChanged);
            IBFType.SelectedIndexChanged += new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IBFYear.TextChanged -= new TTControlEventDelegate(IBFYear_TextChanged);
            IBFType.SelectedIndexChanged -= new TTControlEventDelegate(IBFType_SelectedIndexChanged);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void IBFYear_TextChanged()
        {
#region AR_LogBrIBFRegistryForm_IBFYear_TextChanged
   _AnnualRequirement.ClearChildrenCollections();
#endregion AR_LogBrIBFRegistryForm_IBFYear_TextChanged
        }

        private void IBFType_SelectedIndexChanged()
        {
#region AR_LogBrIBFRegistryForm_IBFType_SelectedIndexChanged
   _AnnualRequirement.ClearChildrenCollections();
#endregion AR_LogBrIBFRegistryForm_IBFType_SelectedIndexChanged
        }

        private void cmdList_Click()
        {
#region AR_LogBrIBFRegistryForm_cmdList_Click
   if(_AnnualRequirement.IBFType == null || _AnnualRequirement.IBFYear == null)
            {
                InfoBox.Show(SystemMessage.GetMessage(65));
                return;
            }
            
            if(_AnnualRequirement.CheckDemands(Convert.ToInt32(_AnnualRequirement.IBFType.Value), _AnnualRequirement.IBFYear.Value))
            {
                _AnnualRequirement.FillDemands(Convert.ToInt32(_AnnualRequirement.IBFType.Value), _AnnualRequirement.IBFYear.Value);
                ShowNeededGrids();
            }
            else
            {
                InfoBox.Show(SystemMessage.GetMessage(66));
            }
#endregion AR_LogBrIBFRegistryForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region AR_LogBrIBFRegistryForm_PreScript
    base.PreScript();
            
//            if(_AnnualRequirement.AnnualRequirementDetailInLists.Count > 0 || _AnnualRequirement.AnnualRequirementDetailOutOfLists.Count > 0)
//                cmdList.Visible = false;

//            Guid hospGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
//            ResHospital hosp = (ResHospital)_AnnualRequirement.ObjectContext.GetObject(hospGuid, "RESHOSPITAL");
//            
//            Accountancy.ListFilterExpression = "ACCOUNTANCYMILITARYUNIT = '" + hosp.MilitaryUnit.ObjectID.ToString() + "'";
#endregion AR_LogBrIBFRegistryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AR_LogBrIBFRegistryForm_PostScript
    base.PostScript(transDef);
#endregion AR_LogBrIBFRegistryForm_PostScript

            }
            
#region AR_LogBrIBFRegistryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == AnnualRequirement.States.AccountancyApproval)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _AnnualRequirement.ObjectID.ToString());
                parameter.Add("TTOBJECTID", objectID);
                switch (_AnnualRequirement.IBFType)
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
                
                if(_AnnualRequirement.AnnualRequirementDetailOutOfLists.Count > 0)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EkliListeReport), true, 1, parameter);
            }
        }
        
#endregion AR_LogBrIBFRegistryForm_Methods
    }
}