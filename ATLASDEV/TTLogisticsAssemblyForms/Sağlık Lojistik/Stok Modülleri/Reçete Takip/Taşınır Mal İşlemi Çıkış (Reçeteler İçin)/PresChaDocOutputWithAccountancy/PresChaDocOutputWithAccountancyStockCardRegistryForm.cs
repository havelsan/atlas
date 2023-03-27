
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
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocOutputWithAccountancyStockCardRegistryForm : BasePresChaDocOutputWithAccountancyForm
    {
#region PresChaDocOutputWithAccountancyStockCardRegistryForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            TTObjectContext context = new TTObjectContext(false);
            if (_PresChaDocOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit != null)
            {
                if (_PresChaDocOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site != null)
                {
                    PresChaDocInputWithAccountancy inputDoc = (PresChaDocInputWithAccountancy)_PresChaDocOutputWithAccountancy.CreatePresChaInputDoc(_PresChaDocOutputWithAccountancy, _PresChaDocOutputWithAccountancy.ObjectContext);
                    _PresChaDocOutputWithAccountancy.SendGeneratedDocumentToTargetSite(inputDoc, _ChattelDocumentOutputWithAccountancy.Accountancy, _ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site);

                }
            }
            context.Dispose();
        }
        
#endregion PresChaDocOutputWithAccountancyStockCardRegistryForm_Methods
    }
}