
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
    /// Oral Diagnoz ve Radyoloji
    /// </summary>
    public partial class DentalExaminationNewForm : EpisodeActionForm
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
#region DentalExaminationNewForm_PreScript
    base.PreScript();
            if (this._DentalExamination.MenuDefinition != null)
            {
                if (this._DentalExamination.MenuDefinition.Caption_Shadow.Contains("KONTROL") == true)//Menu Definitionın Captionında "KONTROL" ifadesi varsa kontol Muayenesidir.
                    this._DentalExamination.IsFollowUpExam = true;
                else
                    this._DentalExamination.IsFollowUpExam = false;

            }
#endregion DentalExaminationNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalExaminationNewForm_PostScript
    base.PostScript(transDef);
#endregion DentalExaminationNewForm_PostScript

            }
                }
}