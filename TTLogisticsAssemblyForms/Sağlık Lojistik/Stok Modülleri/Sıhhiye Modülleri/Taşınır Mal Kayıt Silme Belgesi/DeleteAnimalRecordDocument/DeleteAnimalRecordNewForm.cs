
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
    public partial class DeleteAnimalRecordNewForm : BaseDeleteAnimalRecordForm
    {
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DeleteAnimalRecordNewForm_PostScript
    base.PostScript(transDef);
            
    
            string errMsg = string.Empty;
            
            foreach(DeleteRecordDocAnimalDetail det in _DeleteAnimalRecordDocument.DeleteRecordDocumentAnimalOutMaterials)
            {
                if(det.Material is ConsumableMaterialDefinition || det.Material is DrugDefinition)
                    errMsg += "\r\n" + det.Material.Name;
                else if(det.Material is FixedAssetDefinition)
                {
                    if(((FixedAssetDefinition)det.Material).IsAnimal == null)
                        errMsg += "\r\n" + det.Material.Name;
                    else
                        if(((FixedAssetDefinition)det.Material).IsAnimal == false)
                            errMsg += "\r\n" + det.Material.Name;
                }
            }

            if (!string.IsNullOrEmpty(errMsg))
                throw new TTException("Bu işlem sadece hayvan türündeki demirbaşlar için kullanılabilir. Aşağıdaki malzemeler için kullanılamaz." + errMsg);
#endregion DeleteAnimalRecordNewForm_PostScript

            }
            
#region DeleteAnimalRecordNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _DeleteAnimalRecordDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamad?.", MessageIconEnum.ErrorMessage);
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
                DeleteRecordDocAnimalDetail returningDocument = _DeleteAnimalRecordDocument.DeleteRecordDocumentAnimalOutMaterials.AddNew();
                returningDocument.Material = material;
            }
        }
        
#endregion DeleteAnimalRecordNewForm_ClientSideMethods
    }
}