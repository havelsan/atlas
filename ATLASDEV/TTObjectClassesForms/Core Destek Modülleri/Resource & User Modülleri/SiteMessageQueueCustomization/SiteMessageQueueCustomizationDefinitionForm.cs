
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
    public partial class SiteMessageQueueCustomizationDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            SiteRemoteMethodDefCustomizations.CellContentClick += new TTGridCellEventDelegate(SiteRemoteMethodDefCustomizations_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SiteRemoteMethodDefCustomizations.CellContentClick -= new TTGridCellEventDelegate(SiteRemoteMethodDefCustomizations_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SiteRemoteMethodDefCustomizations_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SiteMessageQueueCustomizationDefinitionForm_SiteRemoteMethodDefCustomizations_CellContentClick
   try
            {
                if (this.SiteRemoteMethodDefCustomizations.CurrentCell.OwningColumn.Name.Equals(SelectSiteRemoteMethodDefID.Name))
                {
                    SiteRemoteMethodDefCustomization siteRemoteMethodDefCustomization = this.SiteRemoteMethodDefCustomizations.CurrentCell.OwningRow.TTObject as SiteRemoteMethodDefCustomization;
                    Guid? returnValue = CommonForm.SelectRemoteMethodDef();
                    if (returnValue.HasValue)
                    {
                        TTRemoteMethodDef remoteMethodDef;
                        if (Common.ClientAsyncRemoteMethodDefs.TryGetValue((Guid)returnValue, out remoteMethodDef))
                        {
                            siteRemoteMethodDefCustomization.RemoteMethodDefID = remoteMethodDef.RemoteMethodDefID;
                            siteRemoteMethodDefCustomization.RemoteMethodDefName = remoteMethodDef.Name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion SiteMessageQueueCustomizationDefinitionForm_SiteRemoteMethodDefCustomizations_CellContentClick
        }

        protected override void PreScript()
        {
#region SiteMessageQueueCustomizationDefinitionForm_PreScript
    base.PreScript();

            ITTObject iTTObject = (ITTObject)this._SiteMessageQueueCustomization;
            if (iTTObject.IsNew)
            {
                this.IsActive.Value = true;
                this._SiteMessageQueueCustomization.MessageQueueMaxVolume = 250;
                this._SiteMessageQueueCustomization.MessageQueueMinVolume = 150;
                this._SiteMessageQueueCustomization.MessageSizeLimit = 3145728;
                this._SiteMessageQueueCustomization.MessageSuccessiveCount = 5;
                this._SiteMessageQueueCustomization.TurnCount = 5;
            }
#endregion SiteMessageQueueCustomizationDefinitionForm_PreScript

            }
                }
}