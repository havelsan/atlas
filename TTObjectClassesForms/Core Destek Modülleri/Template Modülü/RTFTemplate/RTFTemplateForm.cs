
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
    /// Metin Şablon Tanımı
    /// </summary>
    public partial class RTFTemplateForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            btnCreateNewGroup.Click += new TTControlEventDelegate(btnCreateNewGroup_Click);
            btnEditGroup.Click += new TTControlEventDelegate(btnEditGroup_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCreateNewGroup.Click -= new TTControlEventDelegate(btnCreateNewGroup_Click);
            btnEditGroup.Click -= new TTControlEventDelegate(btnEditGroup_Click);
            base.UnBindControlEvents();
        }

        private void btnCreateNewGroup_Click()
        {
#region RTFTemplateForm_btnCreateNewGroup_Click
   TTObjectContext objectContext=new TTObjectContext(false);
            TemplateGroup tGroup= new TemplateGroup(objectContext);
            RTFTemplateGroupForm frm = new RTFTemplateGroupForm();
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            result = frm.ShowEdit(this,tGroup);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                objectContext.Save();
                this._RTFTemplate.TemplateGroup=tGroup;
            }
            else
                objectContext.Dispose();
#endregion RTFTemplateForm_btnCreateNewGroup_Click
        }

        private void btnEditGroup_Click()
        {
#region RTFTemplateForm_btnEditGroup_Click
   if(this._RTFTemplate.TemplateGroup!=null)
            {
                Guid savePointGuid  = this._RTFTemplate.ObjectContext.BeginSavePoint();
                TTVisual.TTForm frm = TTVisual.TTForm.GetEditForm(this._RTFTemplate.TemplateGroup);
                System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
                if (frm == null)
                {
                    TTVisual.InfoBox.Show("Şablon Grupları için tanım ekranı yapılmamıştır.");
                }
                else
                {
                    result = frm.ShowEdit(this,this._RTFTemplate.TemplateGroup);
                    if(result != System.Windows.Forms.DialogResult.OK)
                        this._RTFTemplate.ObjectContext.RollbackSavePoint(savePointGuid);
                }
            }
            else
            {
                TTVisual.InfoBox.Show("Henüz Şablon Grubu Seçmediniz.");
            }
#endregion RTFTemplateForm_btnEditGroup_Click
        }

#region RTFTemplateForm_ClientSideMethods
        public static void NoChangeOtherUsersTeamplate(Guid templateObjectId, bool isDelete)
        {
            
            TTObjectContext contextOpen = new TTObjectContext(false);
            RTFTemplate rftTmplt = (RTFTemplate)contextOpen.GetObject(templateObjectId, "RTFTEMPLATE");
            
            if(rftTmplt.ResUser != null)
            {
                if(!rftTmplt.ResUser.ObjectID.Equals(((ResUser)Common.CurrentUser.UserObject).ObjectID))
                {
                    string warnnigString  = "şablon size ait değildir . \nDevam etmek istediğinize emin misiniz?"; 
                    if(isDelete)
                        warnnigString = "Sildiğiniz " + warnnigString;
                    else
                        warnnigString = "Değişiklik yaptığınız " + warnnigString;
                            
                    if(TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", warnnigString) == "H")
                        throw new TTUtils.TTException(SystemMessage.GetMessage(42));
                    
                }
            } 
        }
        
#endregion RTFTemplateForm_ClientSideMethods
    }
}