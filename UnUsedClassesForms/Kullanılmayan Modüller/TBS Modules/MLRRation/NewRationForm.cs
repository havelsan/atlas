
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
    /// New Form
    /// </summary>
    public partial class NewRationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            buttonCreateRegimeGroup.Click += new TTControlEventDelegate(buttonCreateRegimeGroup_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            buttonCreateRegimeGroup.Click -= new TTControlEventDelegate(buttonCreateRegimeGroup_Click);
            base.UnBindControlEvents();
        }

        private void buttonCreateRegimeGroup_Click()
        {
#region NewRationForm_buttonCreateRegimeGroup_Click
   //            Guid? guid;
//            MLRRationRegimeGroup createdObject, rationRegimeGroup;
//            NewRationRegimeGroupForm newRationRegimeGroupForm;
//            TTObjectContext newContext;
//            DialogResult dResult;
//            System.Diagnostics.Debugger.Break();
//            newContext = new TTObjectContext(false);
//            rationRegimeGroup = new MLRRationRegimeGroup(newContext);
//            newRationRegimeGroupForm = new NewRationRegimeGroupForm();
//            newRationRegimeGroupForm.setRationProperties(this._MLRRation.ObjectID.ToString());
//            dResult = newRationRegimeGroupForm.ShowEdit(this.FindForm(),rationRegimeGroup);
//            System.Diagnostics.Debugger.Break();
//            if (dResult.Equals(DialogResult.OK))
//            {
//                System.Diagnostics.Debugger.Break();
//                guid = rationRegimeGroup.ObjectID;
//                newContext.Save();
//                createdObject = MLRRationRegimeGroup.getRationRegimeGroupUsingID(guid, this._MLRRation.ObjectContext);
//                this._MLRRation.RegimeGroups.Add(createdObject);
//                
//            }
//            newContext.Dispose();
#endregion NewRationForm_buttonCreateRegimeGroup_Click
        }

        protected override void PreScript()
        {
#region NewRationForm_PreScript
    if(this._MLRRation.CurrentStateDefID.Value.Equals(MLRRation.States.RegimeGroup))
               this.buttonCreateRegimeGroup.Visible = true;
#endregion NewRationForm_PreScript

            }
                }
}