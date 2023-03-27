
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
    public partial class IQIntelligenceTestReportForm : TTForm
    {
    /// <summary>
    /// IQ Zeka Testi Raporu
    /// </summary>
        protected TTObjectClasses.IQIntelligenceTestReport _IQIntelligenceTestReport
        {
            get { return (TTObjectClasses.IQIntelligenceTestReport)_ttObject; }
        }

        protected ITTLabel labelAddedUser;
        protected ITTObjectListBox AddedUser;
        protected ITTRichTextBoxControl Comment;
        protected ITTRichTextBoxControl TotalIntelligence;
        protected ITTRichTextBoxControl VerbalIntelligence;
        protected ITTRichTextBoxControl PerformanceIntelligence;
        protected ITTRichTextBoxControl TestPurpose;
        protected ITTRichTextBoxControl CriticalLifeEvent;
        protected ITTRichTextBoxControl TestXXXXXX;
        protected ITTLabel labelVerbalIntelligence;
        protected ITTLabel labelTotalIntelligence;
        protected ITTLabel labelTestPurpose;
        protected ITTLabel labelTestXXXXXX;
        protected ITTLabel labelPerformanceIntelligence;
        protected ITTLabel labelCriticalLifeEvent;
        protected ITTLabel labelComment;
        protected ITTLabel labelPatientJob;
        protected ITTObjectListBox PatientJob;
        protected ITTLabel labelEducationStatus;
        protected ITTObjectListBox EducationStatus;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        override protected void InitializeControls()
        {
            labelAddedUser = (ITTLabel)AddControl(new Guid("1a6cfe19-ed1b-48ad-95fe-c06e204328dc"));
            AddedUser = (ITTObjectListBox)AddControl(new Guid("5dbadf39-dbf2-4919-8a80-4acb8359c8bb"));
            Comment = (ITTRichTextBoxControl)AddControl(new Guid("06e31961-a92f-46dc-9b50-4257b4adbf63"));
            TotalIntelligence = (ITTRichTextBoxControl)AddControl(new Guid("bbf09535-c8a2-4f72-a8c7-cd0b9087cd98"));
            VerbalIntelligence = (ITTRichTextBoxControl)AddControl(new Guid("b18efe74-ca10-4c3b-a821-35bdb5df5e86"));
            PerformanceIntelligence = (ITTRichTextBoxControl)AddControl(new Guid("614e5ec8-9b1f-4ace-8d12-b9477278a827"));
            TestPurpose = (ITTRichTextBoxControl)AddControl(new Guid("eef75d5e-52c7-4078-8819-ab30a1713668"));
            CriticalLifeEvent = (ITTRichTextBoxControl)AddControl(new Guid("f032c1f4-1703-459e-86fd-e886a613de86"));
            TestXXXXXX = (ITTRichTextBoxControl)AddControl(new Guid("a960b349-073b-4422-9564-fed220975e1f"));
            labelVerbalIntelligence = (ITTLabel)AddControl(new Guid("0fde469a-0a13-4c91-8899-583593ac9dfc"));
            labelTotalIntelligence = (ITTLabel)AddControl(new Guid("202d4a7b-9fba-4078-8e6a-7132672a3f6d"));
            labelTestPurpose = (ITTLabel)AddControl(new Guid("a22c759c-fc5f-4b4d-bd7c-d9af600475b6"));
            labelTestXXXXXX = (ITTLabel)AddControl(new Guid("a8ce2974-9dff-43e4-bd53-6d836a8651bc"));
            labelPerformanceIntelligence = (ITTLabel)AddControl(new Guid("24e67829-d434-4617-9289-5f782f4f8f04"));
            labelCriticalLifeEvent = (ITTLabel)AddControl(new Guid("032c2f1e-ecbb-4c35-9c6f-d372248a1b64"));
            labelComment = (ITTLabel)AddControl(new Guid("685bbf34-c00c-4bde-acd6-69ae0dfaabfc"));
            labelPatientJob = (ITTLabel)AddControl(new Guid("d66a56fd-2184-4200-81fb-7d60d94441ff"));
            PatientJob = (ITTObjectListBox)AddControl(new Guid("e75ad248-e45b-4f5a-af17-76ba00d1f691"));
            labelEducationStatus = (ITTLabel)AddControl(new Guid("ebad3355-75e4-4834-9a79-8af0606acce1"));
            EducationStatus = (ITTObjectListBox)AddControl(new Guid("bc486ec4-9d71-4ea5-96ca-ac4aa46edbca"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("94fde257-ae0b-4ed5-91d6-d6f6d06b8e65"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("80bf3598-5992-4f69-aecc-f4d4d2b51b69"));
            base.InitializeControls();
        }

        public IQIntelligenceTestReportForm() : base("IQINTELLIGENCETESTREPORT", "IQIntelligenceTestReportForm")
        {
        }

        protected IQIntelligenceTestReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}