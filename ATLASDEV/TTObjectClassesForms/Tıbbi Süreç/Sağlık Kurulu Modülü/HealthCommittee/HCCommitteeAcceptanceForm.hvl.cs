
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
    /// Heyet Kabul Formu
    /// </summary>
    public partial class HCCommitteeAcceptanceForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTLabel labelBodyMassIndex;
        protected ITTTextBox BodyMassIndex;
        protected ITTTextBox HCWeight;
        protected ITTTextBox HCHeight;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox HCDecisionTime;
        protected ITTLabel labelOpeningDateEpisode;
        protected ITTDateTimePicker OpeningDateEpisode;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelReasonForExaminationHCRequestReason;
        protected ITTObjectListBox ReasonForExaminationHCRequestReason;
        protected ITTLabel labelHCRequestReason;
        protected ITTObjectListBox HCRequestReason;
        protected ITTLabel labelHCWeight;
        protected ITTLabel labelHCHeight;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelProtocolNo;
        protected ITTEnumComboBox HCDecisionUnitOfTime;
        protected ITTLabel labelHCDecisionTime;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn DoctorBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn UnitBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn SpecialityBaseHealthCommittee_HospitalsUnitsGrid;
        override protected void InitializeControls()
        {
            labelBodyMassIndex = (ITTLabel)AddControl(new Guid("11eb0a65-b990-4c47-bd7a-cec8bee64f2a"));
            BodyMassIndex = (ITTTextBox)AddControl(new Guid("7e557207-7ca3-49cb-8f7d-b40f243cef0d"));
            HCWeight = (ITTTextBox)AddControl(new Guid("937f324a-ec6d-46f3-925a-fa185736ca95"));
            HCHeight = (ITTTextBox)AddControl(new Guid("602f5a77-2bf5-4d22-97fd-dba10b793d03"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5b566faa-89a7-4a30-99a1-5914f4982100"));
            HCDecisionTime = (ITTTextBox)AddControl(new Guid("c5d7ea0f-31a8-4bcc-8986-3affaf7489ca"));
            labelOpeningDateEpisode = (ITTLabel)AddControl(new Guid("923930e3-587b-45c6-bc4e-5cda3cc4dfc5"));
            OpeningDateEpisode = (ITTDateTimePicker)AddControl(new Guid("f34185b4-a9b3-4d89-8eef-828d200b16cc"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("882264a6-6eef-484b-9c12-21ea7799dfd4"));
            labelReasonForExaminationHCRequestReason = (ITTLabel)AddControl(new Guid("f6e6f2dc-8b43-4ee1-a318-4c3df8db0921"));
            ReasonForExaminationHCRequestReason = (ITTObjectListBox)AddControl(new Guid("cf14344e-75d1-4ca7-a3c0-52ff80190710"));
            labelHCRequestReason = (ITTLabel)AddControl(new Guid("d2e74f7b-b301-4351-9d7b-a373d0d73017"));
            HCRequestReason = (ITTObjectListBox)AddControl(new Guid("bdc3d22b-6323-4dbc-b73b-77571bcd9293"));
            labelHCWeight = (ITTLabel)AddControl(new Guid("fb1485ad-3e36-4857-b39f-eb4cd4e35907"));
            labelHCHeight = (ITTLabel)AddControl(new Guid("437f08fd-2f95-4f38-a207-c32a09f8642f"));
            labelReportDate = (ITTLabel)AddControl(new Guid("27703b04-456f-413a-9619-dd63c1f4d6a3"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("fa12f6e7-0983-439d-b7c0-ff2d60d274c7"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("0cfbe8d8-509a-443b-853b-e532899fcbf8"));
            HCDecisionUnitOfTime = (ITTEnumComboBox)AddControl(new Guid("0312a80d-5b1d-472d-a573-f3bb1e20b116"));
            labelHCDecisionTime = (ITTLabel)AddControl(new Guid("caf93fd9-8cdf-4de2-8ef2-8a8bf4f1f003"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("15652cc9-553d-47a5-8002-84e8f9bc0fe8"));
            DoctorBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("f7a7a8d4-3f9a-455a-8159-9eb1a02df320"));
            UnitBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("d1d69aa8-13db-419f-965c-ea7e4a4b115d"));
            SpecialityBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("13a22d64-298e-4cc0-a840-2d593c8e0297"));
            base.InitializeControls();
        }

        public HCCommitteeAcceptanceForm() : base("HEALTHCOMMITTEE", "HCCommitteeAcceptanceForm")
        {
        }

        protected HCCommitteeAcceptanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}