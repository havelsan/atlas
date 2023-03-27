
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
    /// Bağlı Birlik Malzeme Mevcut Sorgualama Formu
    /// </summary>
    public partial class SubUnitMatInheldForm : TTForm
    {
        override protected void BindControlEvents()
        {
            getSubInheld.Click += new TTControlEventDelegate(getSubInheld_Click);
            getInheld.Click += new TTControlEventDelegate(getInheld_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            getSubInheld.Click -= new TTControlEventDelegate(getSubInheld_Click);
            getInheld.Click -= new TTControlEventDelegate(getInheld_Click);
            base.UnBindControlEvents();
        }

        private void getSubInheld_Click()
        {
#region SubUnitMatInheldForm_getSubInheld_Click
   TTDataDictionary.Currency subInheld = 0;
            TTObjectContext objectContext = new TTObjectContext(false);
            IList depstore = objectContext.QueryObjects("DEPENDENTSTOREDEFINITION", "Site is not null");
            if(depstore.Count > 0)
            {
                Sites site = ((DependentStoreDefinition)depstore[0]).Site;
                foreach(SubUnitMatGridClass subUnitMatGrid in  _SubUnitMaterialInheld.SubUnitMatGrids)
                {
//                    subInheld =SubUnitMaterialInheld.Remote Methods.SearchSubMaterialInheld(site.ObjectID,subUnitMatGrid.Material);
//                    subUnitMatGrid.SubUniteMatInheld = subInheld;
//                    subUnitMatGrid.DifferenceInheld = subUnitMatGrid.StoreInheld - subUnitMatGrid.SubUniteMatInheld;
                }
            }
#endregion SubUnitMatInheldForm_getSubInheld_Click
        }

        private void getInheld_Click()
        {
#region SubUnitMatInheldForm_getInheld_Click
   TTObjectContext objectContext =  new TTObjectContext(false);
            IList depstore = objectContext.QueryObjects("DEPENDENTSTOREDEFINITION", "Site is not null");
            if(depstore.Count > 0)
            {
                IList stockList = objectContext.QueryObjects("STOCK", "STORE =" + ConnectionManager.GuidToString(((DependentStoreDefinition)depstore[0]).ObjectID));
                if (stockList.Count > 0)
                {
                   
                    foreach(Stock stock in stockList )
                    {
                        SubUnitMatGridClass subUnitMatGrid = new SubUnitMatGridClass(_SubUnitMaterialInheld.ObjectContext);
                        subUnitMatGrid.Material = stock.Material;
                        subUnitMatGrid.StoreInheld = stock.Inheld;
                        _SubUnitMaterialInheld.SubUnitMatGrids.Add(subUnitMatGrid);
                       
                    }
                    
                }
            }
#endregion SubUnitMatInheldForm_getInheld_Click
        }
    }
}