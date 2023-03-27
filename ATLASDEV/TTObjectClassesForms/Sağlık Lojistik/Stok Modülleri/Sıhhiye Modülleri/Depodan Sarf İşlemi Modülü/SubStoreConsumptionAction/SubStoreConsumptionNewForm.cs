
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
    /// Depodan Sarf
    /// </summary>
    public partial class SubStoreConsumptionNewForm : BaseSubStoreConsumptionActionForm
    {
#region SubStoreConsumptionNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            Material material = null;
            IBindingList materials = _SubStoreConsumptionAction.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
            if (materials.Count == 0)
                InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar girişi
                string retAmount = InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                SubStoreConsumptionDetail returningDocument = _SubStoreConsumptionAction.SubStoreConsumptionActionDetails.AddNew();
                returningDocument.Material = material;
                returningDocument.Amount = amount;

                //Malzeme durumu girişi
                List<ComboListItem> stockLevelList = new List<ComboListItem>();
                IBindingList stockLevels = _SubStoreConsumptionAction.ObjectContext.QueryObjects("STOCKLEVELTYPE", "", "STOCKLEVELTYPESTATUS");
                
                foreach (StockLevelType item in stockLevels)
                {
                    stockLevelList.Add(new ComboListItem(item.StockLevelTypeStatus, item.Description));
                }
                ComboListItem retStockLevelType = InputForm.GetValueListItem("Malzeme Durumunu Seçiniz.", stockLevelList.ToArray());
  
                if (retStockLevelType != null)
                {
                    int deger = Convert.ToInt32(retStockLevelType.DataValue);

                    switch ((StockLevelTypeEnum)retStockLevelType.DataValue)
                    {
                        case StockLevelTypeEnum.Hek:
                            returningDocument.StockLevelType = StockLevelType.HekStockLevel;
                            break;
                        case StockLevelTypeEnum.New:
                            returningDocument.StockLevelType = StockLevelType.NewStockLevel;
                            break;
                        case StockLevelTypeEnum.Used:
                            returningDocument.StockLevelType = StockLevelType.UsedStockLevel;
                            break;
                        default:
                            throw new TTException("Yeni,Kullanılmış yada Hek malzeme durumu dışında bir malzeme durumu geldi.");
                        //break;
                    }
                }
                else
                {
                   InfoBox.Show("Malzeme Durumunu Doldurunuz.", MessageIconEnum.ErrorMessage);
                }
            }
        }
        
#endregion SubStoreConsumptionNewForm_ClientSideMethods
    }
}