
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
    /// Son Kontrol
    /// </summary>
    public partial class LastControlForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdPackagingDep.Click += new TTControlEventDelegate(cmdPackagingDep_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPackagingDep.Click -= new TTControlEventDelegate(cmdPackagingDep_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void cmdPackagingDep_Click()
        {
#region LastControlForm_MaintenanceO_cmdPackagingDep_Click
   if (_MaintenanceOrder.PackagingDepartment != null && _MaintenanceOrder.PackagingDepartmentDesc != null)
            {
                PackagingDepartmentAction packagingDepartmentAction = new PackagingDepartmentAction(_MaintenanceOrder.ObjectContext);
                packagingDepartmentAction.RequestNo = _MaintenanceOrder.RequestNo;
                packagingDepartmentAction.StartDate = DateTime.Now;
                packagingDepartmentAction.ResDivision = _MaintenanceOrder.PackagingDepartment;
                packagingDepartmentAction.Description = _MaintenanceOrder.PackagingDepartmentDesc;
                packagingDepartmentAction.FixedAssetMaterialDefinition = _MaintenanceOrder.FixedAssetMaterialDefinition ;
                packagingDepartmentAction.MaintenanceOrder = _MaintenanceOrder;
                packagingDepartmentAction.CurrentStateDefID = PackagingDepartmentAction.States.New;
                this.cmdPackagingDep.Enabled = false;
                _MaintenanceOrder.PackagingDepSendingDate = DateTime.Now ;
            }
            else
            {
                TTVisual.InfoBox.Show("İlgili bölüm ve/veya işin açıklaması girilmeden ambalajlama işlemi başlatamazsınız"); 
            }
#endregion LastControlForm_MaintenanceO_cmdPackagingDep_Click
        }

        private void ttbutton1_Click()
        {
#region LastControlForm_MaintenanceO_ttbutton1_Click
   if (_MaintenanceOrder.FaalMalzemeImza.Count == 0)
            {

                //teknisyen1
                CMRActionSignDetail cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Teknisyen;
                if(_MaintenanceOrder.GetState("Repair", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Repair", true).User.UserObject;
                //teknisyen2
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Teknisyen;
                if(_MaintenanceOrder.GetState("Repair", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Repair", true).User.UserObject;
                //teknisyen3
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Teknisyen;
                if(_MaintenanceOrder.GetState("Repair", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Repair", true).User.UserObject;
               //kısımamiri1
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                if(_MaintenanceOrder.GetState("DivisionSectionApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("DivisionSectionApproval", true).User.UserObject;
                //kısımamiri2
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.KısımAmiri;
                if(_MaintenanceOrder.GetState("DivisionSectionApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("DivisionSectionApproval", true).User.UserObject;
                //onay1
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Onay;
                if(_MaintenanceOrder.GetState("Completed", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Completed", true).User.UserObject;
                //onay2
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.Onay;
                if(_MaintenanceOrder.GetState("Completed", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("Completed", true).User.UserObject;
                //Mua.Kont. ve Klt. Ynt. Bl.A
                cmrActionSignDetail = _MaintenanceOrder.FaalMalzemeImza.AddNew();
                cmrActionSignDetail.SignUserType = SignUserTypeEnum.MuaKontKltYntBlA;
                if(_MaintenanceOrder.GetState("TechnicalDirectorApproval", true) != null)
                    cmrActionSignDetail.SignUser = (ResUser)_MaintenanceOrder.GetState("TechnicalDirectorApproval", true).User.UserObject;
                
              
                
                
            }
#endregion LastControlForm_MaintenanceO_ttbutton1_Click
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region LastControlForm_MaintenanceO_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
          
            switch (item.Name)
            {
                case "FonksiyonMuayeneFormu":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_FonksiyonMuayeneFormu), true, 1, parameters);
                    break;

                case "SonMuayeneFormu":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SonMuayeneFormu), true, 1, parameters);
                    break;

                case "SonMuayeneKarti":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SonMuayeneKarti), true, 1, parameters);
                    break;

                case "FaalMalzemeRaporu":
                    if(this.ReportNo.ToString() != "")
                    {
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_FaalMalzemeRaporu), true, 1, parameters);
                 
                                   
                    break;
                    }
                    else 
                    {
                    string message = "Rapor Numarası Boş Geçilemez !";
                    throw new TTUtils.TTException(message);
                    //break;
                    }

                case "OnleyiciDuzelticiFaaliyetRaporu":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnleyiciDuzelticiFaaliyetRaporu), true, 1, parameters);
                    break;

                case "AmbalajTutanagi":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AmbalajTutanagi), true, 1, parameters);
                    break;

                case "TeslimTesellumBelgesi":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TeslimTesellumBelgesi), true, 1, parameters);
                    break;

                /*
                 *  26.04.2012 Tarihinde Erkan Yelkovan talebiyle çıkartılmıştır. ET
                 * 
                 *  21.10.2012 Tarihinde 8040 nolu pb ye bağlı olarak Erkan beyin bilgisi dahilinde rapor yeniden açılmıştır.db
                 *  -------------------
                 *  06.05.2013 tarihinde istek üzerine yeniden kaldırılmıştır.SS
                */
//                case "ArizaliCihazIslemRaporu":
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ArizaliCihazIslemRaporu), true, 1,parameters);
//                    break;
                //----------------------
                case "GondermeEtiketi":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SendingSticker), true, 1, parameters);
                    break;
                case "KapiCikis":
                    pc.Add("VALUE", _MaintenanceOrder.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("TTOBJECTID", pc);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MalzemeNizamiyeCikisFormu), true, 1, parameters);
                    break;

                default:
                    break;
            }
#endregion LastControlForm_MaintenanceO_tttoolstrip1_ItemClicked
        }

        protected override void PreScript()
        {
#region LastControlForm_MaintenanceO_PreScript
    base.PreScript();
            
            if (_MaintenanceOrder.MaintenanceOrderType.TypeCode == "IS")
            {
                this.DropStateButton(MaintenanceOrder.States.Repair);
                this.DropStateButton(MaintenanceOrder.States.Dispatch);
            }
            else
            {
                this.DropStateButton(MaintenanceOrder.States.Manufacturing);
                //this.DropStateButton(MaintenanceOrder.States.SupplyApproval);
            }

            IList packagingAction = PackagingDepartmentAction.GetPackagingDepartmentAction(_MaintenanceOrder.ObjectContext, _MaintenanceOrder.ObjectID);
            if (packagingAction.Count > 0)
            {
                PackagingDepartmentAction packagingDepartmentAction = (PackagingDepartmentAction)packagingAction[0];
                this.cmdPackagingDep.Enabled = false;
                this.PackagingDepActionStatus.Text = packagingDepartmentAction.CurrentStateDef.DisplayText.ToString();
               
//                if (packagingDepartmentAction.CurrentStateDefID != PackagingDepartmentAction.States.Completed && packagingDepartmentAction.CurrentStateDefID != PackagingDepartmentAction.States.Cancelled)
//                {
//                    this.DropStateButton(MaintenanceOrder.States.Repair);
//                    this.DropStateButton(MaintenanceOrder.States.Dispatch);
//                    this.DropStateButton(MaintenanceOrder.States.LastControl);
//                }
            }
#endregion LastControlForm_MaintenanceO_PreScript

            }
                }
}