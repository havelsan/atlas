
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
    /// Diş Konsültasyon
    /// </summary>
    public partial class DentalConsultationStartForm : DentalExaminationStartForm
    {
        protected override void PreScript()
        {
#region DentalConsultationStartForm_PreScript
    base.PreScript();
#endregion DentalConsultationStartForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalConsultationStartForm_PostScript
    base.PostScript(transDef);
#endregion DentalConsultationStartForm_PostScript

            }
                }
}