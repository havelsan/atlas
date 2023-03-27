
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
    public partial class HandoverTypeForm : TTForm
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
#region HandoverTypeForm_PreScript
    base.PreScript();

            ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
            if (resUser != null)
            {
                if (resUser.SelectedSecMasterResource != null && resUser.SelectedSecMasterResource is ResCardDrawer)
                    this.CardDrawer.SelectedObject = resUser.SelectedSecMasterResource;
                this.CardDrawer.ListFilterExpression = resUser.GetCardDrawerFilter("OBJECTID IN");
            }
#endregion HandoverTypeForm_PreScript

            }
                }
}