
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
    public partial class DentalQueue : TTForm
    {
        override protected void BindControlEvents()
        {
            TTListBoxProcedure.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxProcedure_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TTListBoxProcedure.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxProcedure_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void TTListBoxProcedure_SelectedObjectChanged()
        {
#region DentalQueue_TTListBoxProcedure_SelectedObjectChanged
   TTObjectContext context = new TTObjectContext(false);            
            if (this.TTListBoxProcedure.SelectedValue != null) {
                BindingList<TTObjectClasses.DentalQueue> list = TTObjectClasses.DentalQueue.DentalQueueItemsByProcedure(context, Common.RecTime().AddDays(-10), Common.RecTime().AddDays(10), this.TTListBoxProcedure.SelectedObject.ObjectID);
                this.OrderNo.Text ="" + (list.Count + 1);
            }
#endregion DentalQueue_TTListBoxProcedure_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region DentalQueue_PreScript
    base.PreScript();
            if (this._DentalQueue.Patient != null)
                this.TTListBoxPatient.SelectedValue = this._DentalQueue.Patient.ObjectID;
#endregion DentalQueue_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalQueue_PostScript
    base.PostScript(transDef);
#endregion DentalQueue_PostScript

            }
                }
}