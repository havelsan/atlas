
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class NursingAppliProgressForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hemşire Güncesi Sekmesi
    /// </summary>
        protected TTObjectClasses.NursingAppliProgress _NursingAppliProgress
        {
            get { return (TTObjectClasses.NursingAppliProgress)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTCheckBox HandOverNote;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("d0040ee8-66a0-44f5-b72e-29d75d8d058d"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("37c54ab4-a73e-4d21-bbb2-4a8d39e43cd3"));
            HandOverNote = (ITTCheckBox)AddControl(new Guid("e3a715a5-6e5a-405f-84cc-469638f9b992"));
            labelDescription = (ITTLabel)AddControl(new Guid("377c9350-cb88-4280-8903-2af77165f19b"));
            Description = (ITTTextBox)AddControl(new Guid("a203fd93-13b2-49e1-afba-0175da481f7d"));
            base.InitializeControls();
        }

        public NursingAppliProgressForm() : base("NURSINGAPPLIPROGRESS", "NursingAppliProgressForm")
        {
        }

        protected NursingAppliProgressForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}