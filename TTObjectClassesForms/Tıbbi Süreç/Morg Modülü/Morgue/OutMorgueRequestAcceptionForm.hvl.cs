
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
    /// Morg İşlemleri
    /// </summary>
    public partial class OutMorgueRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageMorgue;
        protected ITTTextBox tttextbox3;
        protected ITTEnumComboBox DeathPlace;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel18;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox StatisticalDeathReason;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTLabel labelReasonForDeath;
        protected ITTEnumComboBox PatientSex;
        protected ITTLabel ttlabel13;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox CitizenshipNoOfAdmittedFrom;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTTextBox DeathBodyAdmittedFrom;
        protected ITTTextBox AddressOfAdmittedFrom;
        protected ITTLabel ttlabel7;
        protected ITTTextBox PhoneNumberOfAdmittedFrom;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker BithDate;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox BirthPalce;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelDoctorFixed;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTTextBox PatientName;
        protected ITTLabel labelSenderDoctor;
        protected ITTLabel ttlabel3;
        protected ITTTextBox DeathReportNo;
        protected ITTObjectListBox SenderDoctor;
        protected ITTDateTimePicker DateOfDeathReport;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpageRreport;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("ee3a35c5-9ec5-4430-89fd-dad5a119c8ff"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("c5946f6c-87c0-476b-8374-35105429ce1e"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("18870348-ed31-47b7-8044-0995e6810de1"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("c46b2a2b-0330-46de-be04-ecb7f3fa0472"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7e75a7b7-a6ff-4646-802d-a0193c6e1be8"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("e5e37bea-07dc-4e07-8722-67b5191bdee6"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("bf890071-af25-406b-81e8-0bda35aa8043"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("d1274a86-4c50-4dd8-a448-410bf09ed234"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("4293e66f-76b6-41d2-ab31-fa2f77d9ea5c"));
            StatisticalDeathReason = (ITTEnumComboBox)AddControl(new Guid("6d5bd6f3-94a5-401d-ac38-887f54c5201c"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("de70b657-2e37-4ca5-b94e-b9700ff783b1"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("0ccfca54-43e8-49cd-bca5-2972f503a682"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("24cbde9f-e9f0-4df7-bf24-4f2168081451"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("48874af9-e293-43f9-af32-3f914573974e"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("f4bc4a39-facd-4070-87b1-bfc602aa49cb"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("27605351-d751-4b3d-9ffe-08b937d0742c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4a21040a-62b5-4e87-9565-f522ffc03bd1"));
            CitizenshipNoOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("d8bf1de1-9e67-4459-8dc6-1b7e444c5d26"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("fa0edbb1-2ad4-4e37-9b39-6617765515cb"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4dea2631-f7ab-41c4-a42d-6bd57a8371d3"));
            DeathBodyAdmittedFrom = (ITTTextBox)AddControl(new Guid("7502819d-43fd-497e-b51b-74acc5db93b7"));
            AddressOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("768610f6-a59a-45b2-97d0-63ef81a3684b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1ccb5dcf-d3ba-491e-ad7c-8e4784ce7d5e"));
            PhoneNumberOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("fa2f2a23-f898-46a0-b84b-b7b0e1a72426"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("f01d932c-8a7b-4681-bcb6-ba042c9e5b4b"));
            BithDate = (ITTDateTimePicker)AddControl(new Guid("081e6a65-f297-4445-92f3-c57d7445c064"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5836aca3-5c11-4928-acfe-1a3daf85f362"));
            BirthPalce = (ITTObjectListBox)AddControl(new Guid("47211235-2328-4e5d-a430-2c050a4a2aec"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("6a9c240c-9ec5-471d-9a13-0ffd7e3dac38"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("20fcf274-71cb-47a6-8e98-0836ba74e3b7"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("13214fcf-a9af-4271-9795-83ef30b80cf9"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("bccf0821-1965-4923-869a-f422a2285e51"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("23df2c1f-2994-4a2c-a1b2-b70bc20efdc2"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("9b2be5a6-31d5-4e8c-a0d1-67a755192bc5"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b0a991a9-7a81-42a8-9597-e6eb9711b13b"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("a5c5d6b0-f609-4d09-aaac-78695660051b"));
            PatientName = (ITTTextBox)AddControl(new Guid("0d805ab8-9a95-4d15-a2c9-f807faed79fb"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("bc30f329-2425-42f3-a33e-960af8a8139e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8a9c6730-6267-42c9-b050-88ff7a0eab36"));
            DeathReportNo = (ITTTextBox)AddControl(new Guid("75d6a666-4a58-439a-895f-7e9456dd56d3"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("22c6758a-7d97-4ca5-b5de-e39296d498d6"));
            DateOfDeathReport = (ITTDateTimePicker)AddControl(new Guid("5ce70163-c391-49be-a36b-059465b45111"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("70056035-2fc6-4b89-97a3-d5f8ae9b5ff0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2102fde0-de05-4483-878e-d23274369a92"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f09fdbef-6709-49d5-8464-e3bd872819e8"));
            tttabpageRreport = (ITTTabPage)AddControl(new Guid("13b651a1-e44d-4537-bde4-8a8a0bab98fc"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("8a785ca4-4703-433b-a91b-4120a0e63e5e"));
            base.InitializeControls();
        }

        public OutMorgueRequestAcceptionForm() : base("MORGUE", "OutMorgueRequestAcceptionForm")
        {
        }

        protected OutMorgueRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}