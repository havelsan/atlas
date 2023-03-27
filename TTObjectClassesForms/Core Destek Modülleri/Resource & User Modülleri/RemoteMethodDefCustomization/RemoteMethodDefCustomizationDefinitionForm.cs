
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
    public partial class RemoteMethodDefCustomizationDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            SelectRemoteMethodDefButton.Click += new TTControlEventDelegate(SelectRemoteMethodDefButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectRemoteMethodDefButton.Click -= new TTControlEventDelegate(SelectRemoteMethodDefButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectRemoteMethodDefButton_Click()
        {
#region RemoteMethodDefCustomizationDefinitionForm_SelectRemoteMethodDefButton_Click
   try
            {
                Guid? returnValue = CommonForm.SelectRemoteMethodDef();
                if (returnValue.HasValue)
                {
                    TTRemoteMethodDef remoteMethodDef;
                    if (Common.ClientAsyncRemoteMethodDefs.TryGetValue((Guid)returnValue, out remoteMethodDef))
                    {
                        _RemoteMethodDefCustomization.RemoteMethodDefID = remoteMethodDef.RemoteMethodDefID;
                        _RemoteMethodDefCustomization.RemoteMethodDefName = remoteMethodDef.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion RemoteMethodDefCustomizationDefinitionForm_SelectRemoteMethodDefButton_Click
        }
    }
}