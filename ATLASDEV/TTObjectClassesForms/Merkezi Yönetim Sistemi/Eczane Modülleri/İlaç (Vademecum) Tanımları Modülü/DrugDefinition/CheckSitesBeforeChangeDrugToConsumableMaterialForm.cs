
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
    public partial class CheckSitesBeforeChangeDrugToConsumableMaterialForm : TTForm
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
#region CheckSitesBeforeChangeDrugToConsumableMaterialForm_changeButton_Click
   string result = "E"; // ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Malzeme sarfa çevrilecek. Onaylıyor musunuz?");
            if (result == "E")
            {
                TTObjectDataSet dataset = new TTObjectDataSet();
                Dictionary<string, object> requiredProps = new Dictionary<string, object>();

                TTObjectDef drugDef = TTObjectDefManager.Instance.GetObjectDef(typeof(DrugDefinition));
                TTObjectDef consumableDef = TTObjectDefManager.Instance.GetObjectDef(typeof(ConsumableMaterialDefinition));


                TTObjectContext context = new TTObjectContext(false);
                Material mat = (Material)context.GetObject(_DrugDefinition.ObjectID, typeof(Material).Name);

                if (mat.SPTSDrugID != null)
                {
                    string result2 = "E";// ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Bu ilaç SPTS'de kaydı bulunmaktadır. Onaylıyor musunuz?");
                    if (result2 == "E")
                    {
                        IBindingList materialTree = context.QueryObjects(typeof(MaterialTreeDefinition).Name);
                        MultiSelectForm multiSelectForm = new MultiSelectForm();

                        foreach (MaterialTreeDefinition m in materialTree)
                        {
                            multiSelectForm.AddMSItem(m.Name, m.ObjectID.ToString(), m);
                        }

                        String mainkey = multiSelectForm.GetMSItem(null, "Malzeme Grubunu Seçiniz", true, true, false, false, false, false);
                        if (!string.IsNullOrEmpty(mainkey))
                        {
                            mat.MaterialTree = (MaterialTreeDefinition)multiSelectForm.MSSelectedItemObject;
                        }
                        else
                        {
                            throw new TTUtils.TTException("Listeden birini seçmeniz gerekmektedir.");
                        }

                        dataset.ChangeTTObjectObjectDef(_DrugDefinition.ObjectID, _DrugDefinition.ObjectDef.ID, consumableDef.ID, requiredProps);
                        context.Save();
                        context.Dispose();

                        List<string> keys = new List<string>();
                        List<object> values = new List<object>();

                        foreach (KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
                        {
                           // DrugDefinition.RemoteMethods.ChangedrugToConsumable(kp.Key, _DrugDefinition.ObjectID, keys, values);
                        }

                        //InfoBox.Alert("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
                        this.Close();
                    }
                    else
                    {
                        context.Dispose();
                        throw new TTUtils.TTException("İşlemden vazgeçildi!");
                        //this.Close();
                    }
                }
                else
                {
                    IBindingList materialTree = context.QueryObjects(typeof(MaterialTreeDefinition).Name);
                    MultiSelectForm multiSelectForm = new MultiSelectForm();

                    foreach (MaterialTreeDefinition m in materialTree)
                    {
                        multiSelectForm.AddMSItem(m.Name, m.ObjectID.ToString(), m);
                    }

                    String mainkey = multiSelectForm.GetMSItem(null, "Malzeme Grubunu Seçiniz", true, true, false, false, false, false);
                    if (!string.IsNullOrEmpty(mainkey))
                    {
                        mat.MaterialTree = (MaterialTreeDefinition)multiSelectForm.MSSelectedItemObject;
                    }
                    else
                    {
                        throw new TTUtils.TTException("Listeden birini seçmeniz gerekmektedir.");
                    }
                    dataset.ChangeTTObjectObjectDef(_DrugDefinition.ObjectID, _DrugDefinition.ObjectDef.ID, consumableDef.ID, requiredProps);
                    context.Save();
                    context.Dispose();

                    List<string> keys = new List<string>();
                    List<object> values = new List<object>();

                    foreach (KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
                    {
                        //DrugDefinition.RemoteMethods.ChangedrugToConsumable(kp.Key, _DrugDefinition.ObjectID, keys, values);
                    }

                   // InfoBox.Show("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
                    this.Close();
                }
            }
            else
                throw new TTUtils.TTException("İşlemden vazgeçildi");
#endregion CheckSitesBeforeChangeDrugToConsumableMaterialForm_changeButton_Click
        }

        private void ttbutton1_Click()
        {
#region CheckSitesBeforeChangeDrugToConsumableMaterialForm_ttbutton1_Click
   bool checkUpdate = true;
            this.controlGrid.Rows.Clear();
            this.changeButton.Visible = false;
            this.resultLabel.Visible = false;
            this.resultTextLabel.Visible = false;
            foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSites)
            {
                if (targetSite.Value.Name != "LOCALHOST" && targetSite.Value.IsTerminologyManagerSite.Value != true)
                {
                    ITTGridRow row = this.controlGrid.Rows.Add();
                    row.Cells["site"].Value = targetSite.Value.ObjectID;
                    try
                    {
                       /* switch (Material.RemoteMethods.IsDrug(targetSite.Key, this._ttObject.ObjectID.ToString()))
                        {
                            case -1:
                                row.Cells["status"].Value = "BULUNMUYOR!";
                                row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                                row.Cells["action"].ForeColor = Color.Red;
                                checkUpdate = false;
                                break;
                            case 0:
                                row.Cells["status"].Value = "Sarf Malzeme";
                                row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                                row.Cells["action"].ForeColor = Color.Red;
                                checkUpdate = false;
                                break;
                            case 1:
                                row.Cells["status"].Value = "İlaç";
                                row.Cells["action"].Value = "Güncellenebilir!";
                                row.Cells["action"].ForeColor = Color.Green;
                                break;
                        }*/
                    }
                    catch (Exception ex)
                    {
                        row.Cells["status"].Value = "SAHAYA ULAŞILAMIYOR";
                        row.Cells["action"].Value = "GÜNCELLENEMEZ!";
                        row.Cells["action"].ForeColor = Color.Red;
                        checkUpdate = false;
                    }
                }
            }

            if (checkUpdate)
            {
                this.resultLabel.Text = "Değişiklik yapılabilir.";
                this.resultLabel.ForeColor = Color.Green;
                this.resultTextLabel.Text = "Tüm sahalarda ilgili kayıt ilaç \r\nolduğu için işlem yapılabilir.";
                this.changeButton.Visible = true;
                this.resultLabel.Visible = true;
                this.resultTextLabel.Visible = true;
            }
            else {
                this.resultLabel.Text = "Değişiklik yapılamaz!";
                this.resultLabel.ForeColor = Color.Red;
                this.resultTextLabel.Text = "Tüm sahalarda ilgili kayıt ilaç olmadığı ya da \r\nulaşılamayan saha bulunduğu için işlem yapılamaz. Sahalara gönderim yapıldığı\r\nhalde sorun devam ederse bilgi işlem ile görüşünüz.";
                this.changeButton.Visible = false;
                this.resultLabel.Visible = true;
                this.resultTextLabel.Visible = true;
            }
#endregion CheckSitesBeforeChangeDrugToConsumableMaterialForm_ttbutton1_Click
        }
    }
}