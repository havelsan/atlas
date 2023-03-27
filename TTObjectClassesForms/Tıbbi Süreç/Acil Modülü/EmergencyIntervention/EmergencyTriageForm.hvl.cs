
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
    /// Acil Hasta Triaj
    /// </summary>
    public partial class EmergencyTriageForm : EpisodeActionForm
    {
    /// <summary>
    /// Acil Hasta Müdahale İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.EmergencyIntervention _EmergencyIntervention
        {
            get { return (TTObjectClasses.EmergencyIntervention)_ttObject; }
        }

        protected ITTLabel labelInterventionEndTime;
        protected ITTDateTimePicker InterventionEndTime;
        protected ITTLabel labelInterventionStartTime;
        protected ITTDateTimePicker InterventionStartTime;
        protected ITTObjectListBox TriageCodeList;
        protected ITTRichTextBoxControl rchContinuousDrugs;
        protected ITTLabel lblContinuousDrugs;
        protected ITTRichTextBoxControl rchHabits;
        protected ITTLabel lblHabits;
        protected ITTRichTextBoxControl rchAllergy;
        protected ITTLabel lblAlergy;
        protected ITTCheckBox cbxTetanoz;
        protected ITTCheckBox cbxGebe;
        protected ITTRichTextBoxControl Habits;
        protected ITTLabel lblAliskanliklar;
        protected ITTRichTextBoxControl ContinuousDrugs;
        protected ITTLabel lblKullandigiIlaclar;
        protected ITTLabel ttlabel8;
        protected ITTTextBox LastEatingInfo;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage ttlabel3;
        protected ITTEnumComboBox ComplaintDurationType;
        protected ITTTextBox ComplaintDuration;
        protected ITTObjectListBox Complaint;
        protected ITTRichTextBoxControl ComplaintDescription;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox PatientHistory;
        protected ITTRichTextBoxControl PatientHistoryDescription;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker LastMenstrualPeriod;
        protected ITTLabel labelLastMenstrualPeriod;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage AllergyVaccination;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Reaction;
        protected ITTEnumComboBoxColumn Risk2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelAllergyInformation;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn Aşı;
        protected ITTTextBoxColumn Geçerliliği;
        protected ITTEnumComboBoxColumn Risk;
        override protected void InitializeControls()
        {
            labelInterventionEndTime = (ITTLabel)AddControl(new Guid("178163bf-0670-43a1-89a5-74a9186a724a"));
            InterventionEndTime = (ITTDateTimePicker)AddControl(new Guid("2a94c367-f4b7-4821-a395-9123c1f8c92e"));
            labelInterventionStartTime = (ITTLabel)AddControl(new Guid("085a6f6d-a39d-49a7-a199-b51a990a5dd2"));
            InterventionStartTime = (ITTDateTimePicker)AddControl(new Guid("c47761d1-75cb-45cb-ab39-39f94f3328d8"));
            TriageCodeList = (ITTObjectListBox)AddControl(new Guid("0c61f663-9dfe-47b2-9f03-d9d107c89836"));
            rchContinuousDrugs = (ITTRichTextBoxControl)AddControl(new Guid("2fc240f8-b175-42b5-a6a0-7e8623c889f5"));
            lblContinuousDrugs = (ITTLabel)AddControl(new Guid("c1597fd5-e1d7-4074-8874-ac7300cbcc51"));
            rchHabits = (ITTRichTextBoxControl)AddControl(new Guid("2ad198b8-3e80-4928-94e1-4a2858d26749"));
            lblHabits = (ITTLabel)AddControl(new Guid("4c81c464-6bbb-431a-8e3d-479035fdd808"));
            rchAllergy = (ITTRichTextBoxControl)AddControl(new Guid("d669778f-b374-4f2e-a4d3-e1e63bcddd26"));
            lblAlergy = (ITTLabel)AddControl(new Guid("5ae1f182-9e93-41de-ac4b-65b4466fbe47"));
            cbxTetanoz = (ITTCheckBox)AddControl(new Guid("8d0662cc-b6a6-4234-8b32-9068c7d3c114"));
            cbxGebe = (ITTCheckBox)AddControl(new Guid("da43b9e3-793e-4a71-9ef1-7865e9072641"));
            Habits = (ITTRichTextBoxControl)AddControl(new Guid("f29c1d84-44de-40e0-aff9-e62deac554aa"));
            lblAliskanliklar = (ITTLabel)AddControl(new Guid("4449c030-51b0-41ab-bb86-57e356cccf9c"));
            ContinuousDrugs = (ITTRichTextBoxControl)AddControl(new Guid("0009671d-1e8e-4727-b77c-d06759cfbd32"));
            lblKullandigiIlaclar = (ITTLabel)AddControl(new Guid("daf031e0-25c8-4234-a372-ad54669c2e6a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("82ff2f0c-9990-421c-b59d-796c20c32d04"));
            LastEatingInfo = (ITTTextBox)AddControl(new Guid("e4279fa8-9567-4cc5-a651-2037eeb40498"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("82f46110-108c-40ec-ac2d-756ae55df980"));
            ttlabel3 = (ITTTabPage)AddControl(new Guid("cb05da36-b234-40f8-92b9-59df10851fd6"));
            ComplaintDurationType = (ITTEnumComboBox)AddControl(new Guid("5d352216-529c-458e-9db1-61cd32f070e3"));
            ComplaintDuration = (ITTTextBox)AddControl(new Guid("c7104496-2a24-48c3-889c-bedda51fc07f"));
            Complaint = (ITTObjectListBox)AddControl(new Guid("4cf1ad80-c21a-4843-92f1-7f5f07f9d7bf"));
            ComplaintDescription = (ITTRichTextBoxControl)AddControl(new Guid("5d6e2370-7a1b-46c9-b745-b30ed8ea51f5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4261e16-5cce-49ff-b6a3-cdb85af9b28a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4bd496dd-5f37-4ec2-b41b-a867235f012d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6c54714b-78d7-4695-97ca-728de786f9b1"));
            PatientHistory = (ITTObjectListBox)AddControl(new Guid("d341e4da-82a1-4a0d-b3fa-1524c42fe381"));
            PatientHistoryDescription = (ITTRichTextBoxControl)AddControl(new Guid("78011ae5-dc0f-4884-bd05-fe4bf9c09577"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f3a89d5d-5d54-47ed-9bd8-64c24526ee7c"));
            LastMenstrualPeriod = (ITTDateTimePicker)AddControl(new Guid("4e34d17d-35cb-426a-8d49-40c66c92da3c"));
            labelLastMenstrualPeriod = (ITTLabel)AddControl(new Guid("4c6217b0-6074-45a5-b13b-b982572a7c8c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("fb73d836-da77-4534-9f72-1fee6a1ca465"));
            AllergyVaccination = (ITTTabPage)AddControl(new Guid("e7939a57-17ad-45ca-9f02-846af5391b1f"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("53744b4a-67d8-464b-b57f-5e41830eab05"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("dfa2a44f-0097-4473-a7e7-4e8f11249e72"));
            Reaction = (ITTTextBoxColumn)AddControl(new Guid("49b51cc4-0553-4075-a65f-3181178f0aab"));
            Risk2 = (ITTEnumComboBoxColumn)AddControl(new Guid("7c5084f4-2331-4fcc-9aa3-14226cb6c705"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7ef4678c-9e91-45a0-a434-e8c168ad93f8"));
            labelAllergyInformation = (ITTLabel)AddControl(new Guid("c47adb3f-dcd5-4f32-af52-d6d3f832118a"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("57d42cee-641c-4c10-805c-11a75633f6dc"));
            Aşı = (ITTTextBoxColumn)AddControl(new Guid("f79d3c52-c2d7-4e36-b8d1-cc1c6a1f9e48"));
            Geçerliliği = (ITTTextBoxColumn)AddControl(new Guid("ce6dc559-02e9-4592-bb7a-89df3d1d3405"));
            Risk = (ITTEnumComboBoxColumn)AddControl(new Guid("3365283a-9b14-43bb-b23c-fd882eb4be5c"));
            base.InitializeControls();
        }

        public EmergencyTriageForm() : base("EMERGENCYINTERVENTION", "EmergencyTriageForm")
        {
        }

        protected EmergencyTriageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}