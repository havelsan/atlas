
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
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCOHTransferDocumentConstitutionForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals _HealthCommitteeExaminationFromOtherHospitals
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelHospital;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox Unit;
        protected ITTTextBox DocumentNumber;
        protected ITTTextBox ExplanationOfRequest;
        protected ITTTextBox textSentOtherResources;
        protected ITTObjectListBox Hospital;
        protected ITTLabel labelUnit;
        protected ITTLabel labelExplanationOfRequest;
        protected ITTObjectListBox Speciality;
        protected ITTLabel lblSpeciality;
        protected ITTLabel labelSentOtherResources;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("485b5662-055f-472a-a8fb-b4f5c0a55db8"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("bdaff748-1b88-4f36-a083-067b08a3c8e2"));
            labelHospital = (ITTLabel)AddControl(new Guid("66436470-cfd9-4601-8e12-13d0ffd76d30"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2d6ca965-23a3-48c1-a3db-249e5434e303"));
            Unit = (ITTObjectListBox)AddControl(new Guid("64283147-0984-46ea-b482-256fc242e7f1"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("36354840-6797-41e5-863f-3dfa95acfd78"));
            ExplanationOfRequest = (ITTTextBox)AddControl(new Guid("714804d7-95d3-469d-8edf-f3ec33d56efe"));
            textSentOtherResources = (ITTTextBox)AddControl(new Guid("a6f368af-0e39-410d-975e-72f091ba67b5"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("60464661-437c-40a8-af66-79a1d297ae63"));
            labelUnit = (ITTLabel)AddControl(new Guid("9cf4f581-35fd-442c-93c1-8839d99239d7"));
            labelExplanationOfRequest = (ITTLabel)AddControl(new Guid("524ecc45-f937-4bb2-b7da-a7c089a9a1c9"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("8e0c4152-4fbe-411d-8439-92a1df5e4d28"));
            lblSpeciality = (ITTLabel)AddControl(new Guid("214029d7-7532-4d18-a5c2-a276f971b84f"));
            labelSentOtherResources = (ITTLabel)AddControl(new Guid("018799e7-bca1-45c8-8df1-1167a4c11865"));
            base.InitializeControls();
        }

        public HCOHTransferDocumentConstitutionForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", "HCOHTransferDocumentConstitutionForm")
        {
        }

        protected HCOHTransferDocumentConstitutionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}