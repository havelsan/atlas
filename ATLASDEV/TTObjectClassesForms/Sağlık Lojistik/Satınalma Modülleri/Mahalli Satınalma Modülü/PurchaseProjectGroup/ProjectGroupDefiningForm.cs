
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
    /// Proje Grubu Tanımlama
    /// </summary>
    public partial class ProjectGroupDefiningForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region ProjectGroupDefiningForm_PreScript
    this.DropStateButton(PurchaseProjectGroup.States.Cancelled);
#endregion ProjectGroupDefiningForm_PreScript

            }
            
#region ProjectGroupDefiningForm_Methods
        public void ShowEdit_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
        }
        
#endregion ProjectGroupDefiningForm_Methods
    }
}