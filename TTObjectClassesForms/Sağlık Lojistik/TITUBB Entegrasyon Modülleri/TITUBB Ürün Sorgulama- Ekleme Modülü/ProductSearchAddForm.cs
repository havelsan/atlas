
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
    /// TITUBB Ürün Sorgulama/ Ekleme
    /// </summary>
    public partial class ProductSearchAddForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdCreate.Click += new TTControlEventDelegate(cmdCreate_Click);
            cmdSearch.Click += new TTControlEventDelegate(cmdSearch_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCreate.Click -= new TTControlEventDelegate(cmdCreate_Click);
            cmdSearch.Click -= new TTControlEventDelegate(cmdSearch_Click);
            base.UnBindControlEvents();
        }

        private void cmdCreate_Click()
        {
#region ProductSearchAddForm_cmdCreate_Click
   //            ProductDefinition.NewProductDefinition product = (ProductDefinition.NewProductDefinition)productListView.SelectedItems[0].Tag;
//            Dictionary<string, List<TTObject>> results = ProductDefinition.RemoteMethods.CreateNewProduct(Sites.SiteMerkezSagKom, product);
//
//            foreach(KeyValuePair<string,List<TTObject>> result in results)
//            {
//                if(result.Value != null)
//                {
//                    foreach (TTObject obj in result.Value)
//                    {
//                        TTObjectContext context = new TTObjectContext(false);
//                        context.AddObject(obj);
//                        context.Save();
//                    }
//                    InfoBox.Show("Ürün Tanımlanmıştır", MessageIconEnum.InformationMessage);
//                }
//                else
//                {
//                    
//                    foreach (TTObject obj in result.Value)
//                    {
//                        TTObjectContext context = new TTObjectContext(false);
//                        context.AddObject(obj);
//                        context.Save();
//                    }
//                    InfoBox.Show(result.Key, MessageIconEnum.ErrorMessage);
//                }
//            }
#endregion ProductSearchAddForm_cmdCreate_Click
        }

        private void cmdSearch_Click()
        {
#region ProductSearchAddForm_cmdSearch_Click
   productListView.Items.Clear();
            if (string.IsNullOrEmpty(barcodeTxt.Text))
            {
                InfoBox.Show("Lütfen barkod giriniz");
            }
            else
            {
                Sites site = TTObjectClasses.SystemParameter.GetSite();
                TITUBBUrunServis.ProductServiceResult result = TITUBBUrunServis.WebMethods.GetUrunSync(site.ObjectID, string.Empty, string.Empty, barcodeTxt.Text);
                foreach (TITUBBUrunServis.Product product in result.Products)
                {

                    ProductDefinition.NewProductDefinition p = new ProductDefinition.NewProductDefinition();
                    p.Name = product.Name;
                    p.ProductNumber = product.ProductNumber;
                    p.ProductNumberType = product.ProductNumberType;
                    p.RegistrationDate = product.RegistrationDate;
                    p.TITUBBProductID = product.TITUBBProductID;

                    ProductDefinition.NewFirmDefinition firm = new ProductDefinition.NewFirmDefinition();
                    firm.IdentityNumber = product.Firm.IdentityNumber;
                    firm.Name = product.Firm.Name;
                    firm.Since = product.Firm.RegistrationDate;
                    firm.TITUBBFirmID = product.Firm.TITUBBFirmID;

                    p.Firm = firm;

                    List<ProductDefinition.NewProductSUTMatchDefinition> suts = new List<ProductDefinition.NewProductSUTMatchDefinition>();
                    foreach (TITUBBUrunServis.ProductSUTMatch sutMatch in product.ProductSUTMatches)
                    {
                        ProductDefinition.NewSUTAppendixDefinition sutAppendix = new ProductDefinition.NewSUTAppendixDefinition();
                        sutAppendix.Name = sutMatch.SUTAppendix.Name;
                        sutAppendix.TITUBBSUTAppendixID = sutMatch.SUTAppendix.TITUBBSUTAppendixID;

                        ProductDefinition.NewProductSUTMatchDefinition sutDef = new ProductDefinition.NewProductSUTMatchDefinition();
                        sutDef.Product = p;
                        sutDef.SUTAppendix = sutAppendix;
                        sutDef.SUTCode = sutMatch.SUTCode;
                        sutDef.SUTName = sutMatch.SUTName;
                        sutDef.SUTPrice = sutMatch.SUTPrice;
                        sutDef.TITUBBProductSUTMatchID = sutMatch.TITUBBProductSUTMatchID;
                        suts.Add(sutDef);
                    }
                    p.NewProductSUTMatchDefinitions = suts;

                    ITTListViewItem listViewItem = productListView.Items.Add(product.Name);
                    listViewItem.SubItems.Add(product.Firm.Name);
                    listViewItem.SubItems.Add(product.TITUBBProductID);
                    listViewItem.Tag = p;
                }
            }
#endregion ProductSearchAddForm_cmdSearch_Click
        }

#region ProductSearchAddForm_Methods
        //        public class NewFirmDefinition
//        {
//            public long IdentityNumber;
//            public string Name;
//            public DateTime Since;
//            public string TITUBBFirmID;
//        }
//        
//        public class NewProductDefinition
//        {
//            public string Name;
//            public string ProductNumber;
//            public string ProductNumberType;
//            public string TITUBBProductID;
//            public DateTime RegistrationDate;
//            public NewFirmDefinition Firm;
//            public List<NewProductSUTMatchDefinition> NewProductSUTMatchDefinitions;
//        }
//        
//        public class NewSUTAppendixDefinition
//        {
//            public string Name;
//            public string TITUBBSUTAppendixID;
//        }
//        
//        public class NewProductSUTMatchDefinition
//        {
//            public string SUTCode;
//            public string SUTName;
//            public Currency SUTPrice;
//            public string TITUBBProductSUTMatchID;
//            public NewProductDefinition Product ;
//            public NewSUTAppendixDefinition SUTAppendix;
//        }
        
#endregion ProductSearchAddForm_Methods
    }
}