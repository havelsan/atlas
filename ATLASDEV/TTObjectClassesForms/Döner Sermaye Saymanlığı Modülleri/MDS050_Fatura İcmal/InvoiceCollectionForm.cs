
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
    public partial class InvoiceCollectionForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region InvoiceCollectionForm_Methods
        public InvoiceCollection currentObject;
        TTObjectContext context = new TTObjectContext(false);
        
        public InvoiceCollectionForm(InvoiceCollection ic)
        {
            currentObject = ic;
        }
//        public InvoiceCollectionForm()
//        {
//            currentObject =  new InvoiceCollection(context); 
//        }
         
        
        public void loadObjectFromForm()
        {
//            currentObject.Capacity = tbCapacity.Text;
//            
//            currentObject.InvoiceTerm = (cbInvoiceTerm.SelectedItem == null) ? null:cbInvoiceTerm.SelectedItem.Value;
//            currentObject.Capacity = tbCapacity.Text;
//            currentObject.Capacity = tbCapacity.Text;
//            currentObject.Capacity = tbCapacity.Text;
//            currentObject.Capacity = tbCapacity.Text;
        }
        
#endregion InvoiceCollectionForm_Methods
    }
}