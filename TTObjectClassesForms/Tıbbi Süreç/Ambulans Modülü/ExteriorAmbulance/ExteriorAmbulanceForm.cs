
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
    /// Dış Ambulans İşlemleri
    /// </summary>
    public partial class ExteriorAmbulanceForm : ActionForm
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
#region ExteriorAmbulanceForm_PreScript
    base.PreScript();
            if(this._ExteriorAmbulance.CurrentStateDefID == ExteriorAmbulance.States.AmbulanceEntry)
                if (this._ExteriorAmbulance.EnteranceTime == null)
                    this.EnteranceTime.Text = Common.RecTime().ToString();
#endregion ExteriorAmbulanceForm_PreScript

            }
                }
}