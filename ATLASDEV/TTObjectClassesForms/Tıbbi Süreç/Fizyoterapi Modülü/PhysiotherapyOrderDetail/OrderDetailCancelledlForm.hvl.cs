
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
    /// Fizyoterapi iptal formu
    /// </summary>
    public partial class OrderDetailCancelledlForm : TTForm
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
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox DescriptionForWorkList;
        protected ITTLabel labelraporTakipNo;
        protected ITTLabel labelPlannedDate;
        protected ITTDateTimePicker PlannedDate;
        protected ITTLabel labelPhysiotherapyState;
        protected ITTEnumComboBox PhysiotherapyState;
        protected ITTLabel labelNote;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelFTRApplicationAreaDef;
        protected ITTObjectListBox FTRApplicationAreaDef;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelDescriptionForWorkList;
        override protected void InitializeControls()
        {
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("a2c249fb-7554-4f6e-8bcb-d79ef31b85b5"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("1d06b455-99a5-40bc-be35-569715e9ed88"));
            labelFinisherResUser = (ITTLabel)AddControl(new Guid("6cda35db-c644-467d-b21e-bfb908e34099"));
            FinisherResUser = (ITTObjectListBox)AddControl(new Guid("513faae0-4a7f-49ad-8dc2-91853b2e2f89"));
            labelStarterResUser = (ITTLabel)AddControl(new Guid("83a5fac7-5229-4563-9893-7766edaa7439"));
            StarterResUser = (ITTObjectListBox)AddControl(new Guid("174d8567-4a41-456b-9087-13afe107ba7e"));
            labelSessionNumber = (ITTLabel)AddControl(new Guid("79e54835-65ec-4b6a-aa56-352f144ca8f2"));
            SessionNumber = (ITTTextBox)AddControl(new Guid("2066f4a0-03c4-4875-b7ff-26377e9403d6"));
            raporTakipNo = (ITTTextBox)AddControl(new Guid("0035afa8-4b59-4ea2-a1f2-bb6ff2a330d5"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("dafdac74-2e9a-4851-941e-6d2bb106c9a3"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("b0d32e57-df70-4c1b-b6cc-572896cb04d9"));
            DescriptionForWorkList = (ITTTextBox)AddControl(new Guid("66664aba-1cf9-40b2-99b0-745be5ab5ff0"));
            labelraporTakipNo = (ITTLabel)AddControl(new Guid("766fddf5-23d2-45a4-95ce-41ca67c221a8"));
            labelPlannedDate = (ITTLabel)AddControl(new Guid("fb461d16-528c-4e74-8cce-434fc1e45bee"));
            PlannedDate = (ITTDateTimePicker)AddControl(new Guid("5f1c915d-c4d8-4798-ae3c-a0a8b58355cf"));
            labelPhysiotherapyState = (ITTLabel)AddControl(new Guid("4aac0502-c7d6-453d-94de-2d14a25721d2"));
            PhysiotherapyState = (ITTEnumComboBox)AddControl(new Guid("78381f20-e662-4f4b-ac86-a267fa9c2ea9"));
            labelNote = (ITTLabel)AddControl(new Guid("180917ba-6418-47e4-8f98-de1101584c11"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ef655378-e88c-435d-b21b-29acd9300e0f"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("ee8147e6-b0f2-4726-93d2-e8969bca40a5"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("60d38ac3-9c81-45c0-81ab-91754d27ceb3"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("fa4973d2-c380-473d-b815-a86907f94a91"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("5694a6be-7953-4b4f-b846-92bc4c2d091c"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("b0987ea6-444d-4c49-a05d-b40b28743931"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("d1c7b6e0-f58d-461d-9956-a358d031d95c"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("3de24f36-22b4-42bd-9a2d-919689a65785"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("d42e1818-5695-490c-9980-8dd85bbfbf81"));
            labelDescriptionForWorkList = (ITTLabel)AddControl(new Guid("7908414d-f002-4e72-bd95-cedb59d829d5"));
            base.InitializeControls();
        }

        public OrderDetailCancelledlForm() : base("PHYSIOTHERAPYORDERDETAIL", "OrderDetailCancelledlForm")
        {
        }

        protected OrderDetailCancelledlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}