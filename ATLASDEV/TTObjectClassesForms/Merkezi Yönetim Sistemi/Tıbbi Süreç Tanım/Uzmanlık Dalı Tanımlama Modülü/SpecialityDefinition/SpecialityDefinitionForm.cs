
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
    /// Uzmanlık Dalı Tanımlama
    /// </summary>
    public partial class SpecialityDefinitionForm : TerminologyManagerDefForm
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
#region SpecialityDefinitionForm_PreScript
    base.PreScript();
            
            if(_SpecialityDefinition.IsToBeConsultation != false)
                _SpecialityDefinition.IsToBeConsultation = true;
#endregion SpecialityDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SpecialityDefinitionForm_PostScript
    base.PostScript(transDef);            
            
                if(this.IsMinorSpeciality.Value == true &&  MHRSClinicCode == null)
                    throw new Exception("Yandal uzmanlığı seçtiyseniz MHRS Klinik Kodunu da girmelisiniz !");
#endregion SpecialityDefinitionForm_PostScript

            }
                }
}