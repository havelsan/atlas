
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
    /// Ambulans İşlemleri
    /// </summary>
    public partial class Ambulans : ActionForm
    {
    /// <summary>
    /// Ambulans İşlemlerinin Gerçekleştirildiği Nesne
    /// </summary>
        protected TTObjectClasses.Ambulance _Ambulance
        {
            get { return (TTObjectClasses.Ambulance)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox Kilometer;
        protected ITTTextBox ArrivalRegion;
        protected ITTTextBox Note;
        protected ITTTextBox CommitterTelNo;
        protected ITTTextBox Committer;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox StartRegion;
        protected ITTTextBox DriverTelNo;
        protected ITTTextBox PatientName;
        protected ITTTextBox PatientAddress;
        protected ITTLabel labelExitTime;
        protected ITTDateTimePicker ExitTime;
        protected ITTDateTimePicker ReturnTime;
        protected ITTLabel labelNote;
        protected ITTLabel labelReturnTime;
        protected ITTLabel labelTransportationReason;
        protected ITTLabel labelAmbulancePlate;
        protected ITTLabel labelArrivalRegion;
        protected ITTLabel labelAmbulanceType;
        protected ITTEnumComboBox AmbulanceType;
        protected ITTEnumComboBox TransportationReason;
        protected ITTGrid AmbulancePersonnels;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Work;
        protected ITTDateTimePicker EstimatedReturnTime;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelCommitterTelNo;
        protected ITTLabel labelCommitter;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelStartRegion;
        protected ITTLabel labelDutyDate;
        protected ITTDateTimePicker DutyDate;
        protected ITTLabel labelDutyType;
        protected ITTEnumComboBox DutyType;
        protected ITTLabel labelDriverTelNo;
        protected ITTLabel labelStretcher;
        protected ITTEnumComboBox Stretcher;
        protected ITTLabel labelPatientMilitaryUnit;
        protected ITTObjectListBox PatientMilitaryUnit;
        protected ITTLabel labelPatientRank;
        protected ITTObjectListBox PatientRank;
        protected ITTLabel labelPatientName;
        protected ITTLabel labelPatientAddress;
        protected ITTObjectListBox Plate;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("4845f80a-cf92-40ae-9d4e-f53dafda5cfd"));
            Kilometer = (ITTTextBox)AddControl(new Guid("8f640f05-7b28-4487-b13d-1b6934b493f7"));
            ArrivalRegion = (ITTTextBox)AddControl(new Guid("35323715-9246-47b2-b341-4978ac116d4b"));
            Note = (ITTTextBox)AddControl(new Guid("36407b3b-869f-472e-9a58-cae76722a238"));
            CommitterTelNo = (ITTTextBox)AddControl(new Guid("7d102bc0-dd17-48c9-9c4e-588ff1dc9b58"));
            Committer = (ITTTextBox)AddControl(new Guid("69d9f59a-1812-43bc-98bf-0fec9af3e47d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("4aec3484-dbde-4be3-9168-4c0460278516"));
            StartRegion = (ITTTextBox)AddControl(new Guid("96728444-d5d2-40f5-a9cf-190090e660d3"));
            DriverTelNo = (ITTTextBox)AddControl(new Guid("c74b64ce-4797-489b-a192-fd8dfa90bd01"));
            PatientName = (ITTTextBox)AddControl(new Guid("afd95183-ec88-42ec-9f44-4f83aa402ba2"));
            PatientAddress = (ITTTextBox)AddControl(new Guid("94201125-cc24-459e-a895-529a897b8126"));
            labelExitTime = (ITTLabel)AddControl(new Guid("d8b11400-f25a-4fc8-8d59-15bf83747439"));
            ExitTime = (ITTDateTimePicker)AddControl(new Guid("454b963c-a3a6-4d48-ba14-31681100ab7d"));
            ReturnTime = (ITTDateTimePicker)AddControl(new Guid("09188728-e49b-4949-a227-3e256e2cf3f1"));
            labelNote = (ITTLabel)AddControl(new Guid("d2d8f6c3-b787-4b97-aad6-6454d8550794"));
            labelReturnTime = (ITTLabel)AddControl(new Guid("3a2e8836-e8c7-4519-bade-6f937d78928a"));
            labelTransportationReason = (ITTLabel)AddControl(new Guid("2d8fa793-6d44-42e7-b997-77e35aeb5af4"));
            labelAmbulancePlate = (ITTLabel)AddControl(new Guid("c312954d-bd54-4ca5-af4a-7a5a8aaf071c"));
            labelArrivalRegion = (ITTLabel)AddControl(new Guid("97e203cd-a7a9-4fee-aa46-b5e93216da8d"));
            labelAmbulanceType = (ITTLabel)AddControl(new Guid("a23fb3b6-c5de-414e-8cb9-cec8b18f03a5"));
            AmbulanceType = (ITTEnumComboBox)AddControl(new Guid("eedf8028-9680-4fcc-95cd-e6639654598e"));
            TransportationReason = (ITTEnumComboBox)AddControl(new Guid("65fe5cf8-37dc-4e4a-9e79-e712a9b48e79"));
            AmbulancePersonnels = (ITTGrid)AddControl(new Guid("8e07495a-6dd0-46cf-977d-d4489e2fd462"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("50911a08-1130-4673-9a93-57e2263e30b2"));
            Work = (ITTTextBoxColumn)AddControl(new Guid("c6f98bb7-74f8-46f3-977a-8a3ef019900a"));
            EstimatedReturnTime = (ITTDateTimePicker)AddControl(new Guid("85697975-8251-4ff2-b1d4-3ddd274af457"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b2cd53ce-2196-41f4-8d58-cc5992703ecc"));
            labelCommitterTelNo = (ITTLabel)AddControl(new Guid("5d3a6038-89e8-49dc-98d4-bbad26d6acd1"));
            labelCommitter = (ITTLabel)AddControl(new Guid("d73060ec-f4a2-4e1d-94b0-dfa6d3150b88"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("94a79bfd-8e34-4d86-9e4c-ed29eafb9257"));
            labelStartRegion = (ITTLabel)AddControl(new Guid("1df30b98-2feb-4965-8480-8696034d1a77"));
            labelDutyDate = (ITTLabel)AddControl(new Guid("c7583640-9d00-40bc-8c7f-5692d0c2df37"));
            DutyDate = (ITTDateTimePicker)AddControl(new Guid("93b0a4c0-8a11-4c11-813a-d0218dc025c8"));
            labelDutyType = (ITTLabel)AddControl(new Guid("a50a4965-39d2-4832-9c4d-84d47d1831ac"));
            DutyType = (ITTEnumComboBox)AddControl(new Guid("223c61e1-cb27-4c9f-8801-da903da000f5"));
            labelDriverTelNo = (ITTLabel)AddControl(new Guid("f3d1722d-ef74-4f66-9c4c-b335b1b74a3f"));
            labelStretcher = (ITTLabel)AddControl(new Guid("f532f514-f26f-49cb-8125-b805e88080a8"));
            Stretcher = (ITTEnumComboBox)AddControl(new Guid("e2c8f0b4-e52d-493f-bba8-ee926b550b8f"));
            labelPatientMilitaryUnit = (ITTLabel)AddControl(new Guid("824e95d5-4a05-4887-93cf-bfeff25a37bc"));
            PatientMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("ae42a644-8e12-4ab7-90c1-a59891ffe4e5"));
            labelPatientRank = (ITTLabel)AddControl(new Guid("235da6d0-2218-4003-8990-6921d82d6b15"));
            PatientRank = (ITTObjectListBox)AddControl(new Guid("d8b23ad3-0b07-4ca7-93fc-8043a9bc6d72"));
            labelPatientName = (ITTLabel)AddControl(new Guid("94a95f0a-49ef-4b0f-9772-b1c00963e1a5"));
            labelPatientAddress = (ITTLabel)AddControl(new Guid("e8bd94d9-6f21-4d65-a17a-aae8aeb95e25"));
            Plate = (ITTObjectListBox)AddControl(new Guid("72e600d4-0008-4e1c-94bd-060a9c9fe718"));
            base.InitializeControls();
        }

        public Ambulans() : base("AMBULANCE", "Ambulans")
        {
        }

        protected Ambulans(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}