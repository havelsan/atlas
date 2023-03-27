
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
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresDistributionDocumentRequestForm : BasePresDistributionDocumentForm
    {
        protected override void PreScript()
        {
#region PresDistributionDocumentRequestForm_PreScript
    base.PreScript();
            if(_PresDistributionDocument.DistributionDepStoreObjectID != null)
            {
                this.DropStateButton(PresDistributionDocument.States.New);
                this.DropStateButton(PresDistributionDocument.States.Cancelled);
            }
#endregion PresDistributionDocumentRequestForm_PreScript

            }
                }
}