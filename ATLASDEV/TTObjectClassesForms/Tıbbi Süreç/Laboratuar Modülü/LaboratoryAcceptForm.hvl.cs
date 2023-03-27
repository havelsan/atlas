
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
    /// Laboratuvar Kabul (Numune Alma)
    /// </summary>
    public partial class LaboratoryAcceptForm : TTUnboundForm
    {
        protected ITTButton ttbutton2;
        protected ITTButton ButtonAccept;
        protected ITTGrid GridRequestedTests;
        protected ITTTextBoxColumn Counter;
        protected ITTTextBoxColumn WorkResource;
        protected ITTListBoxColumn LaboratoryTest;
        protected ITTTextBoxColumn RequestResource;
        protected ITTRichTextBoxControlColumn SubActionProcedureObjectID;
        protected ITTTextBox Barcode;
        protected ITTLabel ttlabel11;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox PatientSex;
        protected ITTTextBox PatientStatus;
        protected ITTTextBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTTextBox PatientClinicPoliclinic;
        protected ITTTextBox AgeYear;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTTextBox PatientName;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTTextBox PatientUniqueRefNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox LaboratoryResDepartment;
        protected ITTObjectListBox TestTubeDefinition;
        protected ITTObjectListBox LaboratoryAcceptTemplateList;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttbutton2 = (ITTButton)AddControl(new Guid("351fcda6-b21f-4c41-80fb-33f581c6ee96"));
            ButtonAccept = (ITTButton)AddControl(new Guid("54170828-153a-480c-b517-9d7ac261e5f8"));
            GridRequestedTests = (ITTGrid)AddControl(new Guid("451ed8cf-1359-4ed0-9489-179c2570a605"));
            Counter = (ITTTextBoxColumn)AddControl(new Guid("e0386d65-189a-4372-9ec5-f6c74b302ee6"));
            WorkResource = (ITTTextBoxColumn)AddControl(new Guid("d4fc6918-eb71-49e5-b5fb-34704aebd5bd"));
            LaboratoryTest = (ITTListBoxColumn)AddControl(new Guid("945e2d42-6dc0-4573-8eaa-4ed264f1fa6a"));
            RequestResource = (ITTTextBoxColumn)AddControl(new Guid("2c7b9d35-fd4b-4b6c-b5e1-11b92926ef96"));
            SubActionProcedureObjectID = (ITTRichTextBoxControlColumn)AddControl(new Guid("c14438e1-4072-4aa6-b26b-7a03e820d1df"));
            Barcode = (ITTTextBox)AddControl(new Guid("8919b6d0-35d0-41c9-a40e-625138c7c063"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("eed9dc5a-af2a-4fc8-addc-87cbd739be17"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b6ba743d-0946-4252-a2bc-9c7563d91fb9"));
            PatientSex = (ITTTextBox)AddControl(new Guid("2ef2407c-2950-484d-b434-4d198fd6f77a"));
            PatientStatus = (ITTTextBox)AddControl(new Guid("0d35f1a2-2af2-4f3e-8d6f-85c622e970fe"));
            PatientRoom = (ITTTextBox)AddControl(new Guid("62ba1b40-0c41-4e83-9044-3d44bd95cd3a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f71e693b-f897-4b51-a15b-eed658f3110d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("eb477a5e-463e-47a7-b6a2-f9a61ca86b55"));
            PatientClinicPoliclinic = (ITTTextBox)AddControl(new Guid("8e94cbe4-b14c-44ac-ab34-e26df26b2cd5"));
            AgeYear = (ITTTextBox)AddControl(new Guid("da3f8697-4a2e-40f5-ac5e-c91523cab49e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7da1fa55-3606-448b-a8e9-31178a3e3cc3"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7311a321-a8d0-44f3-907d-d239ee97bbcf"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("03e94881-8d23-454f-a3c7-05bbfd0ad4cc"));
            PatientName = (ITTTextBox)AddControl(new Guid("e9683bd4-edcd-4683-936a-1456f795e0f1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b23eaa79-73ac-4ae4-a978-c4e880ee0071"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8f09137c-f7d1-4ee6-a4b1-2654e749d3aa"));
            PatientUniqueRefNo = (ITTTextBox)AddControl(new Guid("20c88df6-4837-4b13-9a25-de6586a822a6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e51a6eb5-638f-4ccb-9e36-97c430d39501"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2f9c377c-92d1-41f7-8f35-b8bd88e0b240"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("56c1f940-ac4d-4ed8-bf6f-d9340d4a428a"));
            LaboratoryResDepartment = (ITTObjectListBox)AddControl(new Guid("8cd8264c-7fc6-482a-ac56-3c755eaf7291"));
            TestTubeDefinition = (ITTObjectListBox)AddControl(new Guid("ade348c9-ce18-4c3e-b44e-4033d57769b9"));
            LaboratoryAcceptTemplateList = (ITTObjectListBox)AddControl(new Guid("f3d57a5e-92a2-4fb7-81a6-3609f4e4f28c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7dbd55d1-c0cd-437e-ae0d-b3af88fe2073"));
            base.InitializeControls();
        }

        public LaboratoryAcceptForm() : base("LaboratoryAcceptForm")
        {
        }

        protected LaboratoryAcceptForm(string formDefName) : base(formDefName)
        {
        }
    }
}