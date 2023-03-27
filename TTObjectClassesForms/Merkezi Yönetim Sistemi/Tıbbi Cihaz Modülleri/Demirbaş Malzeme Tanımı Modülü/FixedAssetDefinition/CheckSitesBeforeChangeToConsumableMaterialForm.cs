
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
    public partial class CheckSitesBeforeChangeToConsumableMaterialForm : TTForm
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
#region CheckSitesBeforeChangeToConsumableMaterialForm_changeButton_Click
   string result = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Malzeme sarfa çevrilecek. Onaylıyor musunuz?");
            if (result == "E")
            {
                TTObjectDataSet dataset = new TTObjectDataSet();
                Dictionary<string, object> requiredProps = new Dictionary<string, object>();
                TTObjectDef fixedAssetDef = TTObjectDefManager.Instance.GetObjectDef(typeof(FixedAssetDefinition));
                TTObjectDef consumableDef = TTObjectDefManager.Instance.GetObjectDef(typeof(ConsumableMaterialDefinition));
                dataset.ChangeTTObjectObjectDef(_FixedAssetDefinition.ObjectID, _FixedAssetDefinition.ObjectDef.ID, consumableDef.ID, requiredProps);
                
                TTObjectContext context = new TTObjectContext(false);
                Material mat = (Material)context.GetObject(_FixedAssetDefinition.ObjectID, typeof(Material).Name);
                Guid consGuid = new Guid("db691203-2c64-426c-a737-d0e89859d767");
                mat.MaterialTree = (MaterialTreeDefinition)context.GetObject(consGuid, typeof(MaterialTreeDefinition).Name);
                context.Save();
                context.Dispose();

                List<string> keys = new List<string>();
                List<object> values = new List<object>();
                
                foreach(KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
                {
                    //FixedAssetDefinition.RemoteMethods.ChangeFixedAssetMaterialToConsumable(kp.Key, _FixedAssetDefinition.ObjectID, keys, values);
                }
                
                InfoBox.Show("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
                this.Close();
            }
            else
                InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
#endregion CheckSitesBeforeChangeToConsumableMaterialForm_changeButton_Click
        }

        private void ttbutton1_Click()
        {
#region CheckSitesBeforeChangeToConsumableMaterialForm_ttbutton1_Click
   bool checkUpdate = true;
            this.controlGrid.Rows.Clear();
            this.changeButton.Visible=false;
            this.resultLabel.Visible=false;
            this.resultTextLabel.Visible=false;
            foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSites)
            {   
             /*   if(targetSite.Value.Name!="LOCALHOST"&&targetSite.Value.IsTerminologyManagerSite.Value!=true){
                    ITTGridRow row = this.controlGrid.Rows.Add();
                    row.Cells["site"].Value = targetSite.Value.ObjectID;
                    try{
                    switch(Material.RemoteMethods.IsConsumable(targetSite.Key,this._ttObject.ObjectID.ToString())){
                        case -1:
                            row.Cells["status"].Value = "BULUNMUYOR!";
                            row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                            row.Cells["action"].ForeColor = Color.Red;
                            checkUpdate=false;
                            break;
                        case 0:
                            row.Cells["status"].Value = "Demirbaş Malzeme";
                            row.Cells["action"].Value = "Güncellenebilir!";
                            row.Cells["action"].ForeColor = Color.Green;                        
    
                            break;
                        case 1:
                            row.Cells["status"].Value = "Sarf edilebilen Malzeme";
                            row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                            row.Cells["action"].ForeColor = Color.Red;
                            checkUpdate=false;
                            break;
                    }
                    }catch(Exception ex){
                        row.Cells["status"].Value = "SAHAYA ULAŞILAMIYOR";
                        row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                        row.Cells["action"].ForeColor = Color.Red;  
                        checkUpdate=false;
                    }
                }
           */ }
            
            if(checkUpdate){
                this.resultLabel.Text="Değişiklik yapılabilir.";
                this.resultLabel.ForeColor = Color.Green;
                this.resultTextLabel.Text="Tüm sahalarda ilgili kayıt demirbaş malzeme\r\nolduğu için işlem yapılabilir.";
                this.changeButton.Visible=true;
                this.resultLabel.Visible=true;
                this.resultTextLabel.Visible=true;
            }else{
                this.resultLabel.Text="Değişiklik yapılamaz!";
                this.resultLabel.ForeColor = Color.Red;   
                this.resultTextLabel.Text="Tüm sahalarda ilgili kayıt demirbaş malzeme olmadığı ya da \r\nulaşılamayan saha bulunduğu için işlem yapılamaz. Sahalara gönderim yapıldığı\r\nhalde sorun devam ederse bilgi işlem ile görüşünüz.";
                this.changeButton.Visible=false;
                this.resultLabel.Visible=true;
                this.resultTextLabel.Visible=true;
            }
#endregion CheckSitesBeforeChangeToConsumableMaterialForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region CheckSitesBeforeChangeToConsumableMaterialForm_PreScript
    base.PreScript();
            this.cmdCancel.Visible=false;
            this.cmdOK.Visible=false;
#endregion CheckSitesBeforeChangeToConsumableMaterialForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CheckSitesBeforeChangeToConsumableMaterialForm_PostScript
    base.PostScript(transDef);
#endregion CheckSitesBeforeChangeToConsumableMaterialForm_PostScript

            }
                }
}