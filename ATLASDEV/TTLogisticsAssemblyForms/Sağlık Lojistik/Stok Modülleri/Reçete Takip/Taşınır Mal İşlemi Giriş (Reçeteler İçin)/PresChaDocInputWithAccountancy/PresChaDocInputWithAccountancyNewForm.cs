
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocInputWithAccountancyNewForm : BasePresChaDocInputWithAccountancyForm
    {
        protected override void PreScript()
        {
#region PresChaDocInputWithAccountancyNewForm_PreScript
    base.PreScript();
            txtTotalPrice.Text = CalculateTotalPrice().ToString();
#endregion PresChaDocInputWithAccountancyNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PresChaDocInputWithAccountancyNewForm_PostScript
    base.PostScript(transDef);

            foreach (ITTGridRow row in this.PresChaDocInputWithAccountancyDetails.Rows)
            {

                PresChaDocInputDetWithAccountancy presChaDocInputDetWithAccountancy = this._PresChaDocInputWithAccountancy.PresChaDocInputWithAccountancyDetails[row.Index];
                if (presChaDocInputDetWithAccountancy.ConflictAmount.HasValue && presChaDocInputDetWithAccountancy.ConflictAmount.Value != 0 && string.IsNullOrEmpty(presChaDocInputDetWithAccountancy.ConflictSubject))
                {
                    ITTGridCell cell = row.Cells[ConflictSubjectPresChaDocInputDetWithAccountancy.Name];
                    cell.SetErrorText("Uyuşmazlık Miktarı sıfırdan farklı olduğundan Uyuşmazlık Konusu girilmesi zorunludur.");
                    cell.Required = true;
                }
            }
#endregion PresChaDocInputWithAccountancyNewForm_PostScript

            }
                }
}