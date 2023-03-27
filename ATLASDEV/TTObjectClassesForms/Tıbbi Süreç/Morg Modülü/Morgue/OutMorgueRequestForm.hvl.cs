
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
    public partial class OutMorgueRequestForm : EpisodeActionForm
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
        protected ITTObjectListBox SKRSDeathPlace;
        protected ITTTextBox tttextbox4;
        protected ITTButton cmdAutopsy;
        protected ITTLabel ttlabel19;
        protected ITTLabel ttlabel17;
        protected ITTTextBox tttextbox3;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("735e754b-dd28-4a5b-ad81-669fc651ec8f"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("6deb76af-28cd-4c00-a784-8484d0ed0c8a"));
            SKRSDeathPlace = (ITTObjectListBox)AddControl(new Guid("bffcbb1a-3daa-4586-b119-18bcda71cc16"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("d2b14f33-dcad-4afd-9d6b-7fb7812dacc9"));
            cmdAutopsy = (ITTButton)AddControl(new Guid("46859c9c-a64d-4755-a7bc-f208416baebf"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("1c200cfa-410f-42d2-b9d5-69f42cde3447"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("de267751-a26c-46f4-a786-e8a47e5e5e99"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("6370698b-8b9f-4bbd-84e6-bdde882726e3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fe6c62b1-b4b5-479b-b2f8-bbbf046311b9"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("d1fd64a7-81c0-4180-b84c-ac4dd427572a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ec902d95-a167-428a-9235-80479db50201"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("65acbf0e-0f8f-4304-9991-e48b117c629f"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("4f7e8caf-27eb-4d98-a1c5-b4d571be86df"));
            StatisticalDeathReason = (ITTEnumComboBox)AddControl(new Guid("aab98bd1-31f1-4f82-b720-ff7cf97169b3"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("58ad5ea4-5fc6-4e6f-8a13-10d1c6fe2be9"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("8db955aa-1239-45cd-8253-69403bd68787"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("e2184aea-223e-48c7-ab00-9bb1af670022"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("170e95d2-c673-4a6a-83df-53a0779acb3b"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("1a921eb6-5e25-4839-9d91-ee7553bfa37e"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("eee2f4c9-56f9-4f87-a09f-32e189549590"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bf4071ff-2a95-44c6-ad0f-d95e876b26d9"));
            CitizenshipNoOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("eb42ac51-9614-4995-b7cb-e853438e28c3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a57ff8db-5f19-494d-b156-c438428edda6"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e8f8365e-5fde-419a-a832-2e75ad55552d"));
            DeathBodyAdmittedFrom = (ITTTextBox)AddControl(new Guid("81796dcb-03dd-4202-b1a8-3249dcc0d891"));
            AddressOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("865050bb-865f-4b2e-8c02-266eff94c5a9"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b0b9cb06-11a1-45c3-9247-12437019d20c"));
            PhoneNumberOfAdmittedFrom = (ITTTextBox)AddControl(new Guid("e4c63fb5-7f7b-47c8-b861-54659476a46a"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("abf174dc-214f-4d0b-ba7f-03e6d964bc2c"));
            BithDate = (ITTDateTimePicker)AddControl(new Guid("89ad8659-a057-42a3-a6bc-f2fcf1a0a047"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("72d43628-af4a-4597-865c-1dc27d3e1939"));
            BirthPalce = (ITTObjectListBox)AddControl(new Guid("58fab5e7-c710-449c-b505-ff85d71faf99"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("2e33b6ae-bdae-460a-afb9-46174941239e"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c0bfdb18-34bd-4dc1-85a6-ed14534e8c36"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("0fe2bff5-021a-4c79-a829-bb395f0fd98b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("aaeb01c3-d821-47d2-ae96-f7c10c02c8d4"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("5440c763-94ce-4240-9912-af4796ef2078"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("57206884-779e-4ef8-8ec3-129d74b11d5e"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("da600839-73f0-4c98-8609-854746bb50cb"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("422a4288-7075-4d2d-931a-933ac99fe021"));
            PatientName = (ITTTextBox)AddControl(new Guid("24c88a71-565c-498e-93cf-77cd0429c465"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("0c7f9a04-c406-4a80-b4b6-65b9b4daa361"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a72d00da-6c67-48c4-83dc-73532078d650"));
            DeathReportNo = (ITTTextBox)AddControl(new Guid("1f70ada7-4bcd-448c-a416-be368b53450e"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("dab656f4-3682-44a8-8ba9-a01494f85c7a"));
            DateOfDeathReport = (ITTDateTimePicker)AddControl(new Guid("7beac528-b231-40ee-ae89-2aad4dbe2354"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("44dd5ef7-676d-4825-9a91-a609d28d8995"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("72a703eb-fc74-4740-a9ca-281966a375f7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("878eed38-24c1-40f9-927b-2ec02922d1ba"));
            tttabpageRreport = (ITTTabPage)AddControl(new Guid("e25fba28-a3de-4c7e-b383-cc8ff6d78113"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("63089d04-478f-479c-a5b9-d64975afead6"));
            base.InitializeControls();
        }

        public OutMorgueRequestForm() : base("MORGUE", "OutMorgueRequestForm")
        {
        }

        protected OutMorgueRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}