
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
    public partial class CheckSitesBeforeChangeToFixedAssetForm : TTForm
    {
        override protected void BindControlEvents()
        {
            changeButton.Click += new TTControlEventDelegate(changeButton_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            changeButton.Click -= new TTControlEventDelegate(changeButton_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void changeButton_Click()
        {
#region CheckSitesBeforeChangeToFixedAssetForm_changeButton_Click
   string result = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Malzeme demirbaşa çevrilecek. Onaylıyor musunuz?");
            if (result == "E")
            {
                TTForm frm = new ChangeToFixedAssetFromConsumableForm();
                frm.ShowEdit(this.FindForm(), _ConsumableMaterialDefinition, false);
            }
            else
                InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
                
                this.Close();
#endregion CheckSitesBeforeChangeToFixedAssetForm_changeButton_Click
        }

        private void ttbutton1_Click()
        {
#region CheckSitesBeforeChangeToFixedAssetForm_ttbutton1_Click
   bool checkUpdate = true;
            this.controlGrid.Rows.Clear();
            this.changeButton.Visible=false;
            this.resultLabel.Visible=false;
            this.resultTextLabel.Visible=false;
            foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSites)
            {        
                if(targetSite.Value.Name!="LOCALHOST"&&targetSite.Value.IsTerminologyManagerSite.Value!=true){
                    ITTGridRow row = this.controlGrid.Rows.Add();
                    row.Cells["site"].Value = targetSite.Value.ObjectID;
                    try{
                   /* switch(Material.RemoteMethods.IsConsumable(targetSite.Key,this._ttObject.ObjectID.ToString())){
                        case -1:
                            row.Cells["status"].Value = "BULUNMUYOR!";
                            row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                            row.Cells["action"].ForeColor = Color.Red;
                            checkUpdate=false;
                            break;
                        case 0:
                            row.Cells["status"].Value = "Demirbaş Malzeme";
                            row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                            row.Cells["action"].ForeColor = Color.Red;
                            checkUpdate=false;
                            break;
                        case 1:
                            row.Cells["status"].Value = "Sarf edilebilen Malzeme";
                            row.Cells["action"].Value = "Güncellenebilir!";
                            row.Cells["action"].ForeColor = Color.Green;
                            break;
                    }*/
                    }catch(Exception ex){
                        row.Cells["status"].Value = "SAHAYA ULAŞILAMIYOR";
                        row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                        row.Cells["action"].ForeColor = Color.Red;    
                        checkUpdate=false;
                    }
                }
            }
            
            if(checkUpdate){
                this.resultLabel.Text="Değişiklik yapılabilir.";
                this.resultLabel.ForeColor = Color.Green;
                this.resultTextLabel.Text="Tüm sahalarda ilgili kayıt sarf edilebilir\r\nolduğu için işlem yapılabilir.";
                this.changeButton.Visible=true;
                this.resultLabel.Visible=true;
                this.resultTextLabel.Visible=true;
            }else{
                this.resultLabel.Text="Değişiklik yapılamaz!";
                this.resultLabel.ForeColor = Color.Red;   
                this.resultTextLabel.Text="Tüm sahalarda ilgili kayıt sarf edilebilir olmadığı ya da \r\nulaşılamayan saha bulunduğu için işlem yapılamaz. Sahalara gönderim yapıldığı\r\nhalde sorun devam ederse bilgi işlem ile görüşünüz.";
                this.changeButton.Visible=false;
                this.resultLabel.Visible=true;
                this.resultTextLabel.Visible=true;
            }
#endregion CheckSitesBeforeChangeToFixedAssetForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region CheckSitesBeforeChangeToFixedAssetForm_PreScript
    base.PreScript();
   this.cmdCancel.Visible=false;
   this.cmdOK.Visible=false;
#endregion CheckSitesBeforeChangeToFixedAssetForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CheckSitesBeforeChangeToFixedAssetForm_PostScript
    base.PostScript(transDef);
#endregion CheckSitesBeforeChangeToFixedAssetForm_PostScript

            }
                }
}