
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
    /// Ex Olan Hastaların Morg İşlemleri
    /// </summary>
    public partial class MorgueExDischargeForm : TTForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTGrid MorgueDeathType;
        protected ITTListBoxColumn SKRSOlumSekliMorgueDeathType;
        protected ITTListBoxColumn MorgueMorgueDeathType;
        protected ITTLabel labelDeathReason;
        protected ITTGrid DeathReasonDiagnosis;
        protected ITTListBoxColumn SKRSICDDeathReasonDiagnosis;
        protected ITTListBoxColumn SKRSOlumNedeniTuruDeathReasonDiagnosis;
        protected ITTCheckBox PatientCameEx;
        protected ITTCheckBox AutopsyToDo;
        protected ITTCheckBox SendToMorgue;
        protected ITTLabel labelDateOfDeathReport;
        protected ITTDateTimePicker DateOfDeathReport;
        protected ITTLabel labelNote;
        protected ITTRichTextBoxControl Note;
        protected ITTLabel labelSKRSInjuryPlace;
        protected ITTObjectListBox SKRSInjuryPlace;
        protected ITTLabel labelInjuryDate;
        protected ITTDateTimePicker InjuryDate;
        protected ITTCheckBox InjuryExisting;
        protected ITTLabel labelSKRSDeathReason;
        protected ITTObjectListBox SKRSDeathReason;
        protected ITTLabel labelSKRSDeathPlace;
        protected ITTObjectListBox SKRSDeathPlace;
        protected ITTLabel labelDeathReasonEvaluation;
        protected ITTRichTextBoxControl DeathReasonEvaluation;
        protected ITTLabel labelDiedClinic;
        protected ITTObjectListBox DiedClinic;
        protected ITTLabel labelNurse;
        protected ITTObjectListBox Nurse;
        protected ITTLabel labelExternalSenderDoctorMorgueUnR;
        protected ITTTextBox ExternalSenderDoctorMorgueUnR;
        protected ITTTextBox ExternalSenderDoctorToMorgue;
        protected ITTTextBox ExternalDoctorFixedUniqueNo;
        protected ITTTextBox ExternalDoctorFixed;
        protected ITTLabel labelExternalSenderDoctorToMorgue;
        protected ITTLabel labelSenderDoctor;
        protected ITTObjectListBox SenderDoctor;
        protected ITTLabel labelExternalDoctorFixedUniqueNo;
        protected ITTLabel labelExternalDoctorFixed;
        protected ITTLabel labelDoctorFixed;
        protected ITTObjectListBox DoctorFixed;
        protected ITTLabel labelMernisDeathReasons;
        protected ITTObjectListBox MernisDeathReasons;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            MorgueDeathType = (ITTGrid)AddControl(new Guid("dfd67212-c634-4074-b0a2-433fa5dcd743"));
            SKRSOlumSekliMorgueDeathType = (ITTListBoxColumn)AddControl(new Guid("f8a38e88-92b7-4a60-a533-23ceee85b21d"));
            MorgueMorgueDeathType = (ITTListBoxColumn)AddControl(new Guid("3ff0887c-e44b-4d10-a1f0-af82ed7a253f"));
            labelDeathReason = (ITTLabel)AddControl(new Guid("47e5f772-37df-4d41-823f-b6617ab728bc"));
            DeathReasonDiagnosis = (ITTGrid)AddControl(new Guid("825f9090-6572-451d-8023-fb0641e748d3"));
            SKRSICDDeathReasonDiagnosis = (ITTListBoxColumn)AddControl(new Guid("082695cd-7de0-4bdf-b2fe-f10014afe71d"));
            SKRSOlumNedeniTuruDeathReasonDiagnosis = (ITTListBoxColumn)AddControl(new Guid("e882c01c-617e-468b-8b48-3adcd8e27a33"));
            PatientCameEx = (ITTCheckBox)AddControl(new Guid("b25f5276-a05a-4e05-8f1d-6258f312976c"));
            AutopsyToDo = (ITTCheckBox)AddControl(new Guid("795be243-0a3a-43d6-a098-76ba3e961e2e"));
            SendToMorgue = (ITTCheckBox)AddControl(new Guid("0e76b9d4-4d2e-4def-ad68-3a6c4c427b11"));
            labelDateOfDeathReport = (ITTLabel)AddControl(new Guid("ce7171df-2729-49ba-ab13-cb5617d3b683"));
            DateOfDeathReport = (ITTDateTimePicker)AddControl(new Guid("655f9827-8e58-4034-bb0d-8423c2f495d6"));
            labelNote = (ITTLabel)AddControl(new Guid("53526e7e-b379-40f6-9445-0ffcf921791d"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("c13998ae-2595-4750-a807-ec8b5bea157c"));
            labelSKRSInjuryPlace = (ITTLabel)AddControl(new Guid("aac3744f-9bb1-4f48-8cc9-e4f9bb9059aa"));
            SKRSInjuryPlace = (ITTObjectListBox)AddControl(new Guid("e6fa73d2-1871-4c55-bfa8-49a873b733cc"));
            labelInjuryDate = (ITTLabel)AddControl(new Guid("b59a2e0c-5a9c-4ed4-af0d-b522bbe8b3e7"));
            InjuryDate = (ITTDateTimePicker)AddControl(new Guid("72930cfd-87ac-4302-a854-fceea08fc6ad"));
            InjuryExisting = (ITTCheckBox)AddControl(new Guid("752f2da9-ce08-4245-82b7-dd2cea14b006"));
            labelSKRSDeathReason = (ITTLabel)AddControl(new Guid("15f80190-4ce5-46a0-b6dd-bb54833ce5dc"));
            SKRSDeathReason = (ITTObjectListBox)AddControl(new Guid("1e0c0e88-bc56-48af-8e8d-86158f5c1555"));
            labelSKRSDeathPlace = (ITTLabel)AddControl(new Guid("b4b518f5-9dfa-4bac-ba85-3ab8b889e0a2"));
            SKRSDeathPlace = (ITTObjectListBox)AddControl(new Guid("730b835f-fd45-4376-9a5e-33cbaeba6cfa"));
            labelDeathReasonEvaluation = (ITTLabel)AddControl(new Guid("2d36486c-560d-4403-8bf6-6b45bef25e0e"));
            DeathReasonEvaluation = (ITTRichTextBoxControl)AddControl(new Guid("4dffd529-8c07-43ca-8d4a-c87e9ac0ac79"));
            labelDiedClinic = (ITTLabel)AddControl(new Guid("2d6e5e53-cf0b-4910-8243-5e7c1d7f7441"));
            DiedClinic = (ITTObjectListBox)AddControl(new Guid("f42b9152-8e19-4cad-9cb1-f5aa3d65192a"));
            labelNurse = (ITTLabel)AddControl(new Guid("36e9fd34-aa3e-490b-8542-f862377b89f4"));
            Nurse = (ITTObjectListBox)AddControl(new Guid("75a90bc4-9c1c-424d-9473-591bef5fac23"));
            labelExternalSenderDoctorMorgueUnR = (ITTLabel)AddControl(new Guid("0dc9bfb9-1412-48db-8629-f0e319aae7a7"));
            ExternalSenderDoctorMorgueUnR = (ITTTextBox)AddControl(new Guid("83cd4084-1bdf-4048-b2b1-8e1d3f5b6661"));
            ExternalSenderDoctorToMorgue = (ITTTextBox)AddControl(new Guid("f4d653ec-d165-4c32-8d8b-6ed2973c224e"));
            ExternalDoctorFixedUniqueNo = (ITTTextBox)AddControl(new Guid("5e9115e1-d8ee-42b5-bae6-d20118aa4f66"));
            ExternalDoctorFixed = (ITTTextBox)AddControl(new Guid("5b7f1290-1689-4943-8c13-50d47c6c4c33"));
            labelExternalSenderDoctorToMorgue = (ITTLabel)AddControl(new Guid("4ef15d78-51cd-49fd-8bb7-f34a0d158693"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("0edd0b0c-0ff8-438f-8d36-123c4bf96cbd"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("f43d60c2-4496-46f0-bcd0-8dffbfb27cc9"));
            labelExternalDoctorFixedUniqueNo = (ITTLabel)AddControl(new Guid("49f4af17-4c85-4c01-a3a4-0131b4f99a61"));
            labelExternalDoctorFixed = (ITTLabel)AddControl(new Guid("651179a3-9bce-4e20-be35-ba30f0d846e4"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("98618ca1-967e-4326-a2fc-238ea1ca8194"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("31936c1f-43ef-442c-9230-c00eb9aa8918"));
            labelMernisDeathReasons = (ITTLabel)AddControl(new Guid("7215b451-7e13-48ef-9fcc-75a324e3adac"));
            MernisDeathReasons = (ITTObjectListBox)AddControl(new Guid("3e2df476-1589-4ebf-8fc0-c62de2f7c514"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("443befb3-0b48-4187-b4ad-434bbd6e54a6"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("cd0d94c8-64eb-4ee9-8d79-25a8130c3283"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("828613d5-4d4f-4594-8715-b1818c1bd9da"));
            base.InitializeControls();
        }

        public MorgueExDischargeForm() : base("MORGUE", "MorgueExDischargeForm")
        {
        }

        protected MorgueExDischargeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}