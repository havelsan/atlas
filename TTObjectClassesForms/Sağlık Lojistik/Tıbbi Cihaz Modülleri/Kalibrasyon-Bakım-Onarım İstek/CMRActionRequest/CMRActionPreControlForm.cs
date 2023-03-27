
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
    /// Ön Kontrol
    /// </summary>
    public partial class CMRActionPreControlForm : CMRActionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdate.Click += new TTControlEventDelegate(cmdUpdate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdate.Click -= new TTControlEventDelegate(cmdUpdate_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdate_Click()
        {
#region CMRActionPreControlForm_cmdUpdate_Click
   TTVisual.TTForm updateForm = new TTFormClasses.CMRActionUpdateForm();
            TTFormClasses.CMRActionPreControlForm controlForm = new TTFormClasses.CMRActionPreControlForm();
            //updateForm.StartPosition = FormStartPosition.CenterScreen;
            updateForm.ShowEdit(controlForm.FindForm(), _CMRActionRequest);
            if (updateForm.DialogResult == DialogResult.OK)
            {
                this.AddStateButton(CMRActionRequest.States.Status);
            }
#endregion CMRActionPreControlForm_cmdUpdate_Click
        }

        protected override void PreScript()
        {
#region CMRActionPreControlForm_PreScript
    base.PreScript();
#endregion CMRActionPreControlForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region CMRActionPreControlForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if(this.WorkShop.SelectedObject != null)
            {
                this.ResponsibleWorkShopUser.ListFilterExpression = " USERRESOURCES(RESOURCE='"+this.WorkShop.SelectedObject.ObjectID.ToString()+"').EXISTS" ;
                
            }
            if (_CMRActionRequest.FixedAssetType == FixedAssetTypeEnum.SerialNO)
            {
                fixedAssetTypeTab.HideTabPage(StockTab);
                if ((bool)_CMRActionRequest.IsUnderGuaranty())
                {
                    GuaranyStatuslabel.Text = "GARANTİ KAPSAMINDA - Garanti Bitiş Tarihi:" + _CMRActionRequest.FixedAssetMaterialDefinition.GuarantyEndDate.Value.ToString();
                }
                else
                {
                    GuaranyStatuslabel.ForeColor = System.Drawing.Color.Red;
                    GuaranyStatuslabel.Text = "GARANTİ DIŞI";
                }
                
                if (_CMRActionRequest.FixedAssetMaterialDefinition.SerialNumber == null || _CMRActionRequest.FixedAssetMaterialDefinition.Mark == null || _CMRActionRequest.FixedAssetMaterialDefinition.Model == null)
                {
                    this.DropStateButton(CMRActionRequest.States.Status);
                    TTVisual.InfoBox.Show("Demirbaş bilgilerini güncellemelisiniz.", MessageIconEnum.InformationMessage);
                }
                else
                {
                    this.cmdUpdate.Enabled = false;
                }
            }
            else
            {
                fixedAssetTypeTab.HideTabPage(SerialTab);
                this.GuaranyStatuslabel.Visible = false;
            }
#endregion CMRActionPreControlForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CMRActionPreControlForm_PostScript
    base.PostScript(transDef);
#endregion CMRActionPreControlForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region CMRActionPreControlForm_ClientSidePostScript
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
#endregion CMRActionPreControlForm_ClientSidePostScript

        }
    }
}