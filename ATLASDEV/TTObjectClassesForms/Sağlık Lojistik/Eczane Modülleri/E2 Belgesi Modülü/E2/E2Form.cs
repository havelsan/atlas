
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
    /// E2 Belgesi
    /// </summary>
    public partial class E2Form : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            Store.SelectedObjectChanged += new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Store.SelectedObjectChanged -= new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Store_SelectedObjectChanged()
        {
#region E2Form_Store_SelectedObjectChanged
   //            BindingList<E1> e1s = E1.GetE1s(_E2.ObjectContext, (DateTime)_E2.StartDate, (DateTime)_E2.EndDate, this.Store.SelectedObjectID.ToString());
//            Dictionary<Guid, double> dictionaryE1 = new Dictionary<Guid, double>();
//            
//            if(e1s.Count != 0)
//            {
//                foreach (E1 e1 in e1s)
//                {
//                    for(int i=0; i<e1.StockActionOutDetails.Count;i++)
//                    {
//                        if (!dictionaryE1.ContainsKey(((E1Material)e1.StockActionOutDetails[i]).Material.ObjectID))
//                        {
//                            dictionaryIn.Add( ((E1Material)e1.StockActionOutDetails[i]).Material.ObjectID, (double)((E1Material)e1.StockActionOutDetails[i]).Amount);
//                        }
//                        else
//                        {
//                            
//                            Material material = dictionaryE1[((E1Material)e1.StockActionOutDetails[i]).Material.ObjectID];
//                            dictionaryE1.ContainsValue
//                        }
//                    }
//                }
//                
//            }
#endregion E2Form_Store_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region E2Form_PreScript
    base.PreScript();
#endregion E2Form_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region E2Form_ClientSidePreScript
    base.ClientSidePreScript();
            
            if(this._E2.CurrentStateDefID == E2.States.Record)
            {
                E2DateEntryForm dateEntryForm = new E2DateEntryForm();
                DialogResult dialogResult = dateEntryForm.ShowEdit(this, this._E2, true);
                
                if(dialogResult == DialogResult.OK)
                    _E2.FillE2Material();
            }
#endregion E2Form_ClientSidePreScript

        }

#region E2Form_Methods
        private E2Material ContainsMaterial(Material pMat)
        {
            E2Material pRetVal = null;
            foreach(E2Material pOut in this._E2.StockActionOutDetails)
            {
                if(pOut.Material.ObjectID == pMat.ObjectID)
                {
                    pRetVal = pOut;
                    break;
                }
            }
            return pRetVal;
        }
        
#endregion E2Form_Methods
    }
}