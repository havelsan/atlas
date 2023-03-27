
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
    public partial class PsychologyTestRequestInfoForm : TTForm
    {
        protected TTObjectClasses.PsychologyTest _PsychologyTest
        {
            get { return (TTObjectClasses.PsychologyTest)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctorEpisodeAction;
        protected ITTObjectListBox ProcedureDoctorEpisodeAction;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl Description;
        override protected void InitializeControls()
        {
            labelProcedureDoctorEpisodeAction = (ITTLabel)AddControl(new Guid("667773dd-e3c4-40a1-ba60-b9d5f1fe7576"));
            ProcedureDoctorEpisodeAction = (ITTObjectListBox)AddControl(new Guid("bea33691-b979-4388-a460-7b2d3c9043a0"));
            labelDescription = (ITTLabel)AddControl(new Guid("1ae84cd5-519c-4701-bfc5-29d48a9514b9"));
            Description = (ITTRichTextBoxControl)AddControl(new Guid("2d51ba9b-9322-4b56-a9e5-89a256d10825"));
            base.InitializeControls();
        }

        public PsychologyTestRequestInfoForm() : base("PSYCHOLOGYTEST", "PsychologyTestRequestInfoForm")
        {
        }

        protected PsychologyTestRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}