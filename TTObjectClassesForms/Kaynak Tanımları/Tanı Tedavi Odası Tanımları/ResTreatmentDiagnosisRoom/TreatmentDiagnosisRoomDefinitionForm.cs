
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
    /// Tanı Tedavi Odası Tanımı
    /// </summary>
    public partial class TreatmentDiagnosisRoomDefinitionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region TreatmentDiagnosisRoomDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResTreatmentDiagnosisRoom.EnabledType==null)
            {
                this._ResTreatmentDiagnosisRoom.EnabledType=ResourceEnableType.UnEnable;
            }
#endregion TreatmentDiagnosisRoomDefinitionForm_PostScript

            }
                }
}