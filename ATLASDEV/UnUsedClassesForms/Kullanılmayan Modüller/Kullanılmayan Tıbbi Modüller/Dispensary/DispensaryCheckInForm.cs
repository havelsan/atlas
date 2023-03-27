
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
    /// Bakımevi
    /// </summary>
    public partial class DispensaryCheckInForm : EpisodeActionForm
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
#region DispensaryCheckInForm_PostScript
    base.PostScript(transDef);
            
            if (transDef != null)
            {
                if (transDef.ToStateDefID == Dispensary.States.Dispansary)
                {
                    if(this.StayingDate.ControlValue == null)
                        throw new Exception("Yatış Tarihi boş geçilemez.");
                }
            }
#endregion DispensaryCheckInForm_PostScript

            }
                }
}