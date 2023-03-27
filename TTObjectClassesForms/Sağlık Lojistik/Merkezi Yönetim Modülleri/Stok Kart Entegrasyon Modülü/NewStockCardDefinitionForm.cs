
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
    /// Stok Kart Bilgileri
    /// </summary>
    public partial class NewStockCardDefinitionForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            EscButton.Click += new TTControlEventDelegate(EscButton_Click);
            SaveButton.Click += new TTControlEventDelegate(SaveButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            EscButton.Click -= new TTControlEventDelegate(EscButton_Click);
            SaveButton.Click -= new TTControlEventDelegate(SaveButton_Click);
            base.UnBindControlEvents();
        }

        private void EscButton_Click()
        {
#region NewStockCardDefinitionForm_EscButton_Click
   this.DialogResult = DialogResult.Cancel;
#endregion NewStockCardDefinitionForm_EscButton_Click
        }

        private void SaveButton_Click()
        {
#region NewStockCardDefinitionForm_SaveButton_Click
   try
            {
                NewStockCardDefinition.Status = (StockCardStatusEnum)Status.SelectedItem.Value;
                NewStockCardDefinition.Name = Name.Text;
                if (string.IsNullOrEmpty(NewStockCardDefinition.Name))
                    throw new Exception("Türkçe Adı boş olamaz.");

                if (Globals.IsDate(CreationDate.Text) == false)
                    throw new Exception("Açılış Tarihi boş olamaz.");
                NewStockCardDefinition.CreationDate = Convert.ToDateTime(CreationDate.Text);

                NewStockCardDefinition.CardDrawer = CardDrawer.SelectedObject as ResCardDrawer;
                if (NewStockCardDefinition.CardDrawer == null)
                    throw new Exception("Bağlı Olduğu Grup boş olamaz.");

                NewStockCardDefinition.StockCardPicture = StockCardPicture.Image;
                if (StockCardMaterials.Items.Count > 0)
                {
                    foreach (ITTListViewItem item in StockCardMaterials.Items)
                    {
                        if (item.Checked)
                        {
                            //if((bool)((Material)item.Tag).IsOldMaterial)
                            //    throw new Exception("Eski malzemeyi burda oluştur yapamazsınız.");
                            NewStockCardDefinition.SelectedMaterials.Add((Material)item.Tag);
                        }
                    }
                }

                if (NewStockCardDefinition.SelectedMaterials.Count == 0)
                    throw new Exception("Stoğu Oluşturulacak Malzeme boş olamaz.");

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion NewStockCardDefinitionForm_SaveButton_Click
        }

#region NewStockCardDefinitionForm_Methods
        public NewStockCard NewStockCardDefinition;

        public class NewStockCard
        {
            public string Name;
            public StockMethodEnum StockMethod;
            public StockCardStatusEnum Status;
            public ResCardDrawer CardDrawer;
            public DateTime CreationDate;
            public List<Material> SelectedMaterials;
            public Store SelectedStore;
            public Sites CreatedSite;
            public Image StockCardPicture;
            public NewStockCard(RemotingInfoClass.StockCardInfo stockCardInfo, Store selectedStore)
            {
                Name = stockCardInfo.stockCard.Name;
                Status = StockCardStatusEnum.NewCard;
                CreationDate = TTObjectDefManager.ServerTime;
                StockMethod = stockCardInfo.stockCard.StockMethod.Value;
                SelectedStore = selectedStore;
                SelectedMaterials = new List<Material>();
                CreatedSite = stockCardInfo.createdSite;
                StockCardPicture = (Image)stockCardInfo.stockCard.CardPicture;
            }
        }


        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AcceptButton = (IButtonControl)SaveButton;
            this.CancelButton = (IButtonControl)EscButton;
        }

        public static NewStockCardDefinitionForm ShowNewStockCardDefinitionForm(RemotingInfoClass.StockCardInfo stockCardInfo, Store selectedStore)
        {
            NewStockCardDefinitionForm newStockCardDefinitionForm = new NewStockCardDefinitionForm();
            newStockCardDefinitionForm.NATOStockNO.Text = stockCardInfo.stockCard.NATOStockNO;
            newStockCardDefinitionForm.DistributionType.SelectedObject = stockCardInfo.distributionTypeDefinition;
            newStockCardDefinitionForm.EnglishName.Text = stockCardInfo.stockCard.EnglishName;
            newStockCardDefinitionForm.Name.Text = stockCardInfo.stockCard.Name;
            newStockCardDefinitionForm.StockMethod.SelectedValue = stockCardInfo.stockCard.StockMethod;
            newStockCardDefinitionForm.CreationDate.NullableValue = TTObjectDefManager.ServerTime;
            newStockCardDefinitionForm.StockCardPicture.Image = (Image)stockCardInfo.stockCard.CardPicture;
            if (stockCardInfo.stockCard.StockMethod.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(StockMethodEnum).Name];
                EnumValueDef enumValueDef = dataType.EnumValueDefs[(int)stockCardInfo.stockCard.StockMethod.Value];
                foreach (ITTComboBoxItem item in newStockCardDefinitionForm.StockMethod.Items)
                {
                    if (item.Text.Equals(enumValueDef.DisplayText))
                        newStockCardDefinitionForm.StockMethod.SelectedItem = item;
                }
            }

            // Stok Kartı Statusu New yapılıyor.
            TTDataType statusDataType = TTObjectDefManager.Instance.DataTypes[typeof(StockCardStatusEnum).Name];
            EnumValueDef statusEnumValueDef = statusDataType.EnumValueDefs["NewCard"];
            foreach (ITTComboBoxItem item in newStockCardDefinitionForm.Status.Items)
            {
                if (item.Text.Equals(statusEnumValueDef.DisplayText))
                    newStockCardDefinitionForm.Status.SelectedItem = item;
            }

            if (stockCardInfo.materialInfos.Count > 0)
            {
                foreach (RemotingInfoClass.MaterialInfo materialInfo in stockCardInfo.materialInfos)
                {
                    if (materialInfo.material.IsOldMaterial == false)
                    {
                        string materialName = string.Empty;
                        if (string.IsNullOrEmpty(materialInfo.material.Barcode))
                            materialName = materialInfo.material.Name;
                        else
                            materialName = materialInfo.material.Barcode + " - " + materialInfo.material.Name;

                        ITTListViewItem item = newStockCardDefinitionForm.StockCardMaterials.Items.Add(materialName);
                        item.Tag = materialInfo.material;
                    }
                }
            }

            newStockCardDefinitionForm.NewStockCardDefinition = new NewStockCard(stockCardInfo, selectedStore);
            return newStockCardDefinitionForm;
        }
        
        public static NewStockCardDefinitionForm ShowNewStockCardDefinitionFormForStockNumberTransfer(RemotingInfoClass.StockCardInfo stockCardInfo, Store selectedStore)
        {
            NewStockCardDefinitionForm newStockCardDefinitionForm = new NewStockCardDefinitionForm();
            newStockCardDefinitionForm.NATOStockNO.Text = stockCardInfo.stockCard.NATOStockNO;
            newStockCardDefinitionForm.DistributionType.SelectedObject = stockCardInfo.distributionTypeDefinition;
            newStockCardDefinitionForm.EnglishName.Text = stockCardInfo.stockCard.EnglishName;
            newStockCardDefinitionForm.Name.Text = stockCardInfo.stockCard.Name;
            newStockCardDefinitionForm.StockMethod.SelectedValue = stockCardInfo.stockCard.StockMethod;
            newStockCardDefinitionForm.CreationDate.NullableValue = TTObjectDefManager.ServerTime;
            newStockCardDefinitionForm.StockCardPicture.Image = (Image)stockCardInfo.stockCard.CardPicture;
            if (stockCardInfo.stockCard.StockMethod.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(StockMethodEnum).Name];
                EnumValueDef enumValueDef = dataType.EnumValueDefs[(int)stockCardInfo.stockCard.StockMethod.Value];
                foreach (ITTComboBoxItem item in newStockCardDefinitionForm.StockMethod.Items)
                {
                    if (item.Text.Equals(enumValueDef.DisplayText))
                        newStockCardDefinitionForm.StockMethod.SelectedItem = item;
                }
            }

            // Stok Kartı Statusu New yapılıyor.
            TTDataType statusDataType = TTObjectDefManager.Instance.DataTypes[typeof(StockCardStatusEnum).Name];
            EnumValueDef statusEnumValueDef = statusDataType.EnumValueDefs["NewCard"];
            foreach (ITTComboBoxItem item in newStockCardDefinitionForm.Status.Items)
            {
                if (item.Text.Equals(statusEnumValueDef.DisplayText))
                    newStockCardDefinitionForm.Status.SelectedItem = item;
            }

            if (stockCardInfo.materialInfos.Count > 0)
            {
                foreach (RemotingInfoClass.MaterialInfo materialInfo in stockCardInfo.materialInfos)
                {
                    string materialName = string.Empty;
                    if(string.IsNullOrEmpty(materialInfo.material.Barcode))
                        materialName = materialInfo.material.Name;
                    else
                        materialName = materialInfo.material.Barcode + " - " + materialInfo.material.Name;
                    
                    ITTListViewItem item = newStockCardDefinitionForm.StockCardMaterials.Items.Add(materialName);
                    item.Tag = materialInfo.material;
                }
            }

            newStockCardDefinitionForm.NewStockCardDefinition = new NewStockCard(stockCardInfo, selectedStore);
            return newStockCardDefinitionForm;
        }
        
#endregion NewStockCardDefinitionForm_Methods
    }
}