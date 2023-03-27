
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
    public partial class CMRActionBaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region CMRActionBaseForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _CMRActionRequest.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            switch(item.Name)
            {
                case "FixedAssetMaterialDefinition":

                    if(_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
                    {
                        if(_CMRActionRequest.FixedAssetMaterialDefinition != null)
                        {
                            FixedAssetMaterialDefinition fmd = _CMRActionRequest.FixedAssetMaterialDefinition;
                            TTListDef listDef = TTObjectDefManager.Instance.ListDefs["FixedAssetMaterialDefFormList"];
                            TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef);
                            frm.ShowReadOnly(this.FindForm(),listDef,fmd);
                        }
                        else
                        {
                            InfoBox.Show("Önce Tıbbi Cihazı Seçiniz.");
                        }
                    }
                    else
                    {
                        InfoBox.Show("Stok Numaralı ( El Aletleri) için bu işlemi açamazsınız.");
                    }
                    break;
                case "FixedAssetDefinition":

                    if(_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
                    {
                        if(_CMRActionRequest.FixedAssetMaterialDefinition != null)
                        {
                            FixedAssetDefinition fd = _CMRActionRequest.FixedAssetMaterialDefinition.FixedAssetDefinition;
                            TTListDef listDef2 = TTObjectDefManager.Instance.ListDefs["FixedAssetDefFormList"];
                            TTDefinitionForm frm2 = TTDefinitionForm.GetEditForm(listDef2);
                            frm2.ShowReadOnly(this.FindForm(),listDef2,fd);
                        }
                        else
                        {
                            InfoBox.Show("Önce Tıbbi Cihazı Seçiniz.");
                        }
                    }
                    else
                    {
                        if(_CMRActionRequest.FixedAssetDefinition != null)
                        {
                            FixedAssetDefinition fd = _CMRActionRequest.FixedAssetDefinition;
                            TTListDef listDef2 = TTObjectDefManager.Instance.ListDefs["FixedAssetDefFormList"];
                            TTDefinitionForm frm2 = TTDefinitionForm.GetEditForm(listDef2);
                            frm2.ShowReadOnly(this.FindForm(),listDef2,fd);
                        }
                        else
                        {
                            InfoBox.Show("Önce Demirbaş Malzeme Seçiniz.");
                        }
                    }

                    break;
                    //ERDALLLL
                case "WorkRequest":
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IsIstekveIsEmri), true, 1, parameter);
                    break;
                    
                case "UserMaintenance":
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UserMaintenanceReport), true, 1, parameter);
                    break;
                case "UnitMaintenance":
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UnitMaintenanceReport), true, 1, parameter);
                    break;
                case "HasarveDurumTespitRaporu":
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu1), true, 1, parameter);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HasarveDurumTespitRaporu2), true, 1, parameter);
                    break;
        default:
            break;
        }
#endregion CMRActionBaseForm_tttoolstrip1_ItemClicked
        }

        protected override void PreScript()
        {
#region CMRActionBaseForm_PreScript
    base.PreScript();
            
            if(_CMRActionRequest.CurrentStateDefID != CMRActionRequest.States.Request)
                tttoolstrip1.Items["ReportMenu"].Visible = false;
#endregion CMRActionBaseForm_PreScript

            }
                }
}