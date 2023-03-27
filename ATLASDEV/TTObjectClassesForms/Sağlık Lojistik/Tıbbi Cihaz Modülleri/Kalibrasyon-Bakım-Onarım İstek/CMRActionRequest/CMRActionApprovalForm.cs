
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
    /// Kademe Onay
    /// </summary>
    public partial class CMRActionApprovalForm : CMRActionBaseForm
    {
        override protected void BindControlEvents()
        {
            WorkShop.SelectedObjectChanged += new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            RequestType.SelectedIndexChanged += new TTControlEventDelegate(RequestType_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            WorkShop.SelectedObjectChanged -= new TTControlEventDelegate(WorkShop_SelectedObjectChanged);
            RequestType.SelectedIndexChanged -= new TTControlEventDelegate(RequestType_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void WorkShop_SelectedObjectChanged()
        {
#region CMRActionApprovalForm_WorkShop_SelectedObjectChanged
   this.ResponsibleWorkShopUser.ListFilterExpression = " USERRESOURCES(RESOURCE='"+this.WorkShop.SelectedObject.ObjectID.ToString()+"').EXISTS" ;
#endregion CMRActionApprovalForm_WorkShop_SelectedObjectChanged
        }

        private void RequestType_SelectedIndexChanged()
        {
#region CMRActionApprovalForm_RequestType_SelectedIndexChanged
   if(_CMRActionRequest.RequestType.Value == RequestTypeEnum.Repair)
            {
                this.RepairPlace.ReadOnly = false;
            }
#endregion CMRActionApprovalForm_RequestType_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region CMRActionApprovalForm_PreScript
    base.PreScript();
            
            if (_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
            {
                fixedAssetTypeTab.HideTabPage(StockTab);
                if ((bool)_CMRActionRequest.IsUnderGuaranty())
                {
                    GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _CMRActionRequest.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
                    this.DropStateButton(CMRActionRequest.States.Status);
                }
                else
                {
                    GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                    GuaranyStatuslabel.Text = "GARANTİ DIŞI";
                    Section.Required = true ;
                    WorkShop.Required = true ;
                    ResponsibleWorkShopUser.Required = true ;
                    this.DropStateButton (CMRActionRequest.States.GuarantyRepair);
                    
                    this.MilitaryUnit.SelectedObject = Common.GetCurrentMilitaryUnit(_CMRActionRequest.ObjectContext);
                }
            }
            else
            {
                fixedAssetTypeTab.HideTabPage(SerialTab);
                this.GuaranyStatuslabel.Visible = false;
            }
            
            if(_CMRActionRequest.RequestType != RequestTypeEnum.Maintenance )
            {
                RepairPlace.ReadOnly = false;
                RepairPlace.Required = true ;
            }
            
            string txtSeq = _CMRActionRequest.RequestNoSeq.Value.ToString();
            if(txtSeq.Length == 1)
            {
                txtSeq = "000"+txtSeq.ToString();
            }
            if(txtSeq.Length == 2)
            {
                txtSeq = "00"+txtSeq.ToString();
            }
            if(txtSeq.Length == 3)
            {
                txtSeq = "0"+txtSeq.ToString();
            }
            RequestNo.Text  = RequestNo.Text.Substring(0,4).ToString() +"-"+txtSeq.ToString();
#endregion CMRActionApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CMRActionApprovalForm_PostScript
    base.PostScript(transDef);
#endregion CMRActionApprovalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region CMRActionApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef !=null)
            {
                if (transDef.ToStateDefID  == CMRActionRequest.States.Status)
                {
                    string messageTxt = null;
                    foreach (CMR_ItemEquipment itemEquipment in _CMRActionRequest.CMR_ItemEquipments)
                    {
                        if (itemEquipment.IsNormal == false)
                        {
                            messageTxt = itemEquipment.ItemName.ToString() + "\r\n" + messageTxt ;
                        }
                    }
                    if (string.IsNullOrEmpty(messageTxt) == false)
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Muhtelif Malzeme Uyarısı", "Cihazla birlikte gidecek olan muhtelif malzemelerden :\r\n" + messageTxt.ToString() + "Tamam olarak işaretlenmemiştir.\r\nDevam Etmek İstiyor Musunuz?");
                        if (result == "V")
                            throw new Exception(SystemMessage.GetMessage(942));
                    }
                }
                
            }
#endregion CMRActionApprovalForm_ClientSidePostScript

        }
    }
}