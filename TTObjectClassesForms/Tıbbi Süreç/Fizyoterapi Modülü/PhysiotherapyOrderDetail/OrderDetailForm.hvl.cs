
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
    /// Fizyoterapi İşlem Formu
    /// </summary>
    public partial class OrderDetailForm : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin  Uygulamasının Gerçekleştirildiği NEsnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrderDetail _PhysiotherapyOrderDetail
        {
            get { return (TTObjectClasses.PhysiotherapyOrderDetail)_ttObject; }
        }

        protected ITTLabel labelTreatmentRoom;
        protected ITTObjectListBox TreatmentRoom;
        protected ITTLabel labelFinisherResUser;
        protected ITTObjectListBox FinisherResUser;
        protected ITTLabel labelStarterResUser;
        protected ITTObjectListBox StarterResUser;
        protected ITTLabel labelSessionNumber;
        protected ITTTextBox SessionNumber;
        protected ITTTextBox raporTakipNo;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Duration;
        protected ITTTextBox Dose;
        protected ITTTextBox SeansGunSayisi;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox DescriptionForWorkList;
        protected ITTLabel labelraporTakipNo;
        protected ITTLabel labelPlannedDate;
        protected ITTDateTimePicker PlannedDate;
        protected ITTLabel labelPhysiotherapyState;
        protected ITTEnumComboBox PhysiotherapyState;
        protected ITTLabel labelNote;
        protected ITTRichTextBoxControl Note;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelFTRApplicationAreaDef;
        protected ITTObjectListBox FTRApplicationAreaDef;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelDuration;
        protected ITTLabel labelDose;
        protected ITTLabel labelSeansGunSayisi;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelDescriptionForWorkList;
        override protected void InitializeControls()
        {
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("10400a38-859e-4944-abd3-6a4de4a10804"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("48f01f35-2c4d-4199-870b-5de289410b4f"));
            labelFinisherResUser = (ITTLabel)AddControl(new Guid("f453e308-4a10-46f7-a38b-30607bd5d25d"));
            FinisherResUser = (ITTObjectListBox)AddControl(new Guid("8a98edf1-9124-4b09-be4d-419ab546a316"));
            labelStarterResUser = (ITTLabel)AddControl(new Guid("50cb0138-0ae4-404b-903e-8619f29334a3"));
            StarterResUser = (ITTObjectListBox)AddControl(new Guid("e67ea544-5d78-4080-b7a3-562658d81900"));
            labelSessionNumber = (ITTLabel)AddControl(new Guid("d6290627-782d-4c1d-a251-c1d3630fba17"));
            SessionNumber = (ITTTextBox)AddControl(new Guid("e89b2820-414c-4750-9b85-11594defae4b"));
            raporTakipNo = (ITTTextBox)AddControl(new Guid("ef535375-8480-4a46-9938-4a0e2725a83e"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("92412d2c-90e0-4f2d-9ce2-0a50c291e7b3"));
            Duration = (ITTTextBox)AddControl(new Guid("c093e01c-e156-41a6-9630-e6c82e33f511"));
            Dose = (ITTTextBox)AddControl(new Guid("1846874d-f943-4afe-afde-ad6453cde491"));
            SeansGunSayisi = (ITTTextBox)AddControl(new Guid("f400b9be-6aff-43ac-8db8-a0a9275c5ee5"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("c1c06614-a89a-489a-ae71-c68339464090"));
            DescriptionForWorkList = (ITTTextBox)AddControl(new Guid("58304239-0063-46e2-8634-c6723683cf04"));
            labelraporTakipNo = (ITTLabel)AddControl(new Guid("180cc6a6-5eca-4c18-a812-ccd133c03938"));
            labelPlannedDate = (ITTLabel)AddControl(new Guid("f7a9208d-0bc6-4ea4-8c7e-7be5b1f870d9"));
            PlannedDate = (ITTDateTimePicker)AddControl(new Guid("5540e932-0cd1-4b8e-8a92-83bae87f5c74"));
            labelPhysiotherapyState = (ITTLabel)AddControl(new Guid("7dc070ee-451b-4d95-8bec-2c2fef6b7691"));
            PhysiotherapyState = (ITTEnumComboBox)AddControl(new Guid("bcc5bd64-0ef2-46b4-bdb4-b5b2410b3c0b"));
            labelNote = (ITTLabel)AddControl(new Guid("83de19e5-ce32-41ef-ac1f-31824cf6586d"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("c12c05ce-9acf-4be2-831c-c5311542f945"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("b8da789d-d133-4107-ad33-a06ca695bdf7"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("38553af7-7a5c-422f-aea3-1cc0c27de31d"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("d8baf864-963f-4c01-8502-d6f05c480597"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("9cd99fab-5ead-466a-b4f9-90150c28eb2c"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("c4b933c4-2e9b-416d-ad33-2860ed9b3c12"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("7aaf8da9-a5ce-4434-8af5-668b7d5568fa"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("f0cfc59f-5896-4067-8e40-80496483a4c5"));
            labelDuration = (ITTLabel)AddControl(new Guid("046fa90d-71d1-4ba3-8ab1-53fb4b778ae3"));
            labelDose = (ITTLabel)AddControl(new Guid("66e30b1a-26d4-4c5e-adee-941d596fab52"));
            labelSeansGunSayisi = (ITTLabel)AddControl(new Guid("da76c78e-0133-4930-97cc-00b8b682fcc3"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("5bddaa55-0857-4e8a-838f-44c487adc61b"));
            labelDescriptionForWorkList = (ITTLabel)AddControl(new Guid("ed3e5f73-787e-4beb-887d-d1496c77edb3"));
            base.InitializeControls();
        }

        public OrderDetailForm() : base("PHYSIOTHERAPYORDERDETAIL", "OrderDetailForm")
        {
        }

        protected OrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}