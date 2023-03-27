
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
    public partial class DeleteRecordDocumentWasteForm : BaseDeleteRecordDocumentWasteForm
    {
        protected override void PreScript()
        {
            #region DeleteRecordDocumentWasteForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            #endregion DeleteRecordDocumentWasteForm_PreScript

        }





        #region DeleteRecordDocumentWasteForm_Methods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _DeleteRecordDocumentWaste.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Alert(value + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
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
                    InfoBox.Alert("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Miktar girişi
                string retAmount = InputForm.GetText("Miktar Bilgisini Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                
                DeleteRecordDocumentWasteMaterialOut returningDocument = _DeleteRecordDocumentWaste.DeleteRecordDocumentWasteOutMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.Amount = amount;
            }
        }
        
#endregion DeleteRecordDocumentWasteForm_Methods
    }
}