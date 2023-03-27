
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
    public partial class DrugOrderIntroductionNewUnbound : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            EtkinMaddeListBox.SelectedObjectChanged += new TTControlEventDelegate(EtkinMaddeListBox_SelectedObjectChanged);
            CloseButton.Click += new TTControlEventDelegate(CloseButton_Click);
            saveButton.Click += new TTControlEventDelegate(saveButton_Click);
            DrugListview.DoubleClick += new TTControlEventDelegate(DrugListview_DoubleClick);
            EtkinMaddeListview.DoubleClick += new TTControlEventDelegate(EtkinMaddeListview_DoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            EtkinMaddeListBox.SelectedObjectChanged -= new TTControlEventDelegate(EtkinMaddeListBox_SelectedObjectChanged);
            CloseButton.Click -= new TTControlEventDelegate(CloseButton_Click);
            saveButton.Click -= new TTControlEventDelegate(saveButton_Click);
            DrugListview.DoubleClick -= new TTControlEventDelegate(DrugListview_DoubleClick);
            EtkinMaddeListview.DoubleClick -= new TTControlEventDelegate(EtkinMaddeListview_DoubleClick);
            base.UnBindControlEvents();
        }

        private void EtkinMaddeListBox_SelectedObjectChanged()
        {
#region DrugOrderIntroductionNewUnbound_EtkinMaddeListBox_SelectedObjectChanged
   this.EtkinMaddeListview.Items.Clear();
            EtkinMadde etkinMadde = (EtkinMadde)this.EtkinMaddeListBox.SelectedObject;
            ITTListViewItem item = this.EtkinMaddeListview.Items.Add(etkinMadde.etkinMaddeKodu);
            item.SubItems.Add(etkinMadde.etkinMaddeAdi);
            item.SubItems.Add(etkinMadde.ObjectID.ToString());
#endregion DrugOrderIntroductionNewUnbound_EtkinMaddeListBox_SelectedObjectChanged
        }

        private void CloseButton_Click()
        {
#region DrugOrderIntroductionNewUnbound_CloseButton_Click
   this.Close();
#endregion DrugOrderIntroductionNewUnbound_CloseButton_Click
        }

        private void saveButton_Click()
        {
#region DrugOrderIntroductionNewUnbound_saveButton_Click
   TTObjectContext objectContext = new TTObjectContext(true);
            
            if(((DrugDefinition)DrugListBox.SelectedObject).Name != null)
            {
                if(DrugName.Text != ((DrugDefinition)DrugListBox.SelectedObject).Name)
                {
                    if(this._PrescriptionTypeEnum == ((DrugDefinition)DrugListBox.SelectedObject).PrescriptionType )
                    {
                        if(DrugListBox.Text != null)
                        {
                            if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut ilaç değişcektir.\nDevam etmek istediğinize emin misiniz?") == "E")
                            {
                                Guid objectID = (Guid)DrugListBox.SelectedObjectID;
                                if(this.DrugListview.SelectedItems.Count > 0)
                                {
                                    Guid drugGuid = objectID;
                                    DrugDefinition drug = (DrugDefinition)objectContext.GetObject(drugGuid, typeof(DrugDefinition));
                                    this.Tag = drug;
                                }
                                this.Close();
                            }
                        }
                    }
                    else if(this._PrescriptionTypeEnum == 0)
                    {
                        if(DrugListBox.Text != null)
                        {
                            if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut ilaç değişcektir.\nDevam etmek istediğinize emin misiniz?") == "E")
                            {
                                Guid objectID = (Guid)DrugListBox.SelectedObjectID;
                                if(this.DrugListview.SelectedItems.Count > 0)
                                {
                                    Guid drugGuid = objectID;
                                    DrugDefinition drug = (DrugDefinition)objectContext.GetObject(drugGuid, typeof(DrugDefinition));
                                    this.Tag = drug;
                                }
                                this.Close();
                            }
                        }
                    }
                    else
                        InfoBox.Show("Farklı Reçete Türünden İlaç Yazamassınız!");
                }
                else
                    InfoBox.Show("Aynı İlaç Seçilmiştir!");
            }
            else
                InfoBox.Show("İlaç Seçiniz!");
#endregion DrugOrderIntroductionNewUnbound_saveButton_Click
        }

        private void DrugListview_DoubleClick()
        {
#region DrugOrderIntroductionNewUnbound_DrugListview_DoubleClick
   if(this.DrugListview.SelectedItems.Count > 0)
            {
                Guid selectObjectId =  new Guid(this.DrugListview.SelectedItems[0].SubItems[3].Text);
                this.DrugListBox.SelectedObjectID = selectObjectId;
            }
            else
            {
            
            }
#endregion DrugOrderIntroductionNewUnbound_DrugListview_DoubleClick
        }

        private void EtkinMaddeListview_DoubleClick()
        {
#region DrugOrderIntroductionNewUnbound_EtkinMaddeListview_DoubleClick
   if(this.DrugListview.SelectedItems.Count >= 0)
            {
                //string cod = ((EtkinMadde) this.EtkinMaddeListview.SelectedItems[0].Tag).ObjectID.ToString();
                string cod = this.EtkinMaddeListview.SelectedItems[0].SubItems[2].Text;
                SearchDruglist(cod);
            }
#endregion DrugOrderIntroductionNewUnbound_EtkinMaddeListview_DoubleClick
        }

#region DrugOrderIntroductionNewUnbound_Methods
        //  SearchActiveIngredien(this.DrugName.Text);  showda tetiklenicek

        public DrugOrderIntroductionNewUnbound(DrugOrderIntroduction drugOrderIntroduction)
            : this()
        {
            if (drugOrderIntroduction != null)
            {
                
                this.DrugName.Text =drugOrderIntroduction.DrugName ;
                TTObjectContext context = new TTObjectContext(true);
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject((Guid)drugOrderIntroduction.DrugObjectID, typeof(DrugDefinition));
                EtkinMadde etkinMadde = null;
                if (drugDefinition.EtkinMadde != null)
                {
                    etkinMadde = drugDefinition.EtkinMadde;
                    ITTListViewItem item = this.EtkinMaddeListview.Items.Add(etkinMadde.etkinMaddeKodu);
                    item.SubItems.Add(etkinMadde.etkinMaddeAdi);
                    item.SubItems.Add(etkinMadde.ObjectID.ToString());
                   // this.EtkinMaddeListBox.SelectedObject = etkinMadde;
                }
                
            }
        }
        
        public PrescriptionTypeEnum _PrescriptionTypeEnum;
        public DrugOrderIntroductionNewUnbound(OutPatientDrugOrder outPatienDrugOrder,PrescriptionTypeEnum prescriptionType)
            : this()
        {
            if (outPatienDrugOrder != null)
            {
                _PrescriptionTypeEnum = prescriptionType;
                this.DrugName.Text = outPatienDrugOrder.PhysicianDrug.Name;
                TTObjectContext context = new TTObjectContext(true);
                DrugDefinition drugDefinition = (DrugDefinition)context.GetObject((Guid)outPatienDrugOrder.PhysicianDrug.ObjectID, typeof(DrugDefinition));
                EtkinMadde etkinMadde = null;
                if (drugDefinition.EtkinMadde != null)
                {
                    etkinMadde = drugDefinition.EtkinMadde;
                    //etkinMadde = (EtkinMadde)context.GetObject(drugDefinition.EtkinMadde.ObjectID,typeof(EtkinMadde));
                    ITTListViewItem item = this.EtkinMaddeListview.Items.Add(etkinMadde.etkinMaddeKodu);
                    item.SubItems.Add(etkinMadde.etkinMaddeAdi);
                    //item.Tag = etkinMadde;
                    item.SubItems.Add(etkinMadde.ObjectID.ToString());
                    //this.EtkinMaddeListBox.SelectedObject = etkinMadde;
                }
                
            }
        }
        
        public void SearchDruglist(string cod)
        {
            this.DrugListview.Items.Clear();
            TTObjectContext context = new TTObjectContext(true);
            string filiter = "ETKINMADDE = '" + cod + "'";
            IList drugDefinitions = context.QueryObjects("DRUGDEFINITION", filiter);
            foreach (DrugDefinition drugDefinition in drugDefinitions)
            {
                if (drugDefinition != null)
                {
                    ITTListViewItem item = this.DrugListview.Items.Add(drugDefinition.Name);
                    item.SubItems.Add(drugDefinition.Barcode);
                    item.SubItems.Add(drugDefinition.PharmacyInheldStatus);
                    item.SubItems.Add(drugDefinition.ObjectID.ToString());
                }
            }
        }
        
#endregion DrugOrderIntroductionNewUnbound_Methods
    }
}