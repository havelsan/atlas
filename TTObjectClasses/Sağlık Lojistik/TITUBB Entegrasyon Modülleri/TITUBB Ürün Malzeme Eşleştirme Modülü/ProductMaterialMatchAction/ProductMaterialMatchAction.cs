
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// TITUBB Ãœrün Malzeme Eşleştirme
    /// </summary>
    public  partial class ProductMaterialMatchAction : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            
            

            foreach (ProductMaterialMatchDetail productMaterialMatchDetail in ProductMaterialMatchDetails)
            {
                TTObjectContext contex = new TTObjectContext(false);
                Material oldMaterial = (Material)contex.GetObject(productMaterialMatchDetail.Material.ObjectID, typeof(Material));
                MaterialProductLevel materialProductLevel = new MaterialProductLevel(contex);
                if (productMaterialMatchDetail.Product != null)
                    materialProductLevel.Product = productMaterialMatchDetail.Product;
                materialProductLevel.Material = oldMaterial;
                if (string.IsNullOrEmpty(productMaterialMatchDetail.Barcode) == false)
                    materialProductLevel.Barcode = productMaterialMatchDetail.Barcode;
                if(productMaterialMatchDetail.MatchReasonDefinition != null)
                    materialProductLevel.MatchReason = productMaterialMatchDetail.MatchReasonDefinition;
                contex.Save();
                contex.Dispose();
            }
            

#endregion PreTransition_New2Completed
        }

#region Methods
        public bool CheckedMaterial(ProductDefinition product, Material oldMaterial, ProductMaterialMatchAction productMaterialMatchAction)
        {
            bool check = true;
            if (product != null)
            {
                int count = 0;
                foreach (ProductMaterialMatchDetail detail in _ProductMaterialMatchDetails)
                {
                    if (detail.Material.ObjectID.Equals(oldMaterial.ObjectID) && detail.Product.ObjectID.Equals(product.ObjectID))
                        count++;
                }
                if (count > 0)
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25317", "Bu işlemde aynı malzemeler birden fazla eşleştirilmiştir."));
                    check = false;
                }

                foreach (MaterialProductLevel materialProductLevel in oldMaterial.MaterialProductLevels)
                {
                    if(materialProductLevel.Product != null)
                    {
                        if (materialProductLevel.Product.ObjectID.Equals(product.ObjectID))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage(product.Name + " isimli TITUBB malzemesi daha önce " + oldMaterial.Name + " isimli malzeme ile eşleştirilmiştir.");
                            check = false;
                        }
                    }
                }
                IList productLevels = ObjectContext.QueryObjects("MATERIALPRODUCTLEVEL", "PRODUCT =" + ConnectionManager.GuidToString(product.ObjectID));
                foreach (MaterialProductLevel productLevel in productLevels)
                {
                    if (productLevel.Material.ObjectID.Equals(oldMaterial.ObjectID) == false)
                    {
                        string result ="E";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Birden fazla eşleşme", product.Name + " isimli TITUBB malzemesi daha önce " + productLevel.Material.Name + " isimli malzeme ile de eşleştirilmiştir.\r\n İşleme devam etmek ister misiniz? ");
                        if (result == "H")
                            check = false;
                    }
                }
            }
            return check;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ProductMaterialMatchAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ProductMaterialMatchAction.States.New && toState == ProductMaterialMatchAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}