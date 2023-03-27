
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
    /// Fizyoterapi Planlama Formu
    /// </summary>
    public partial class PhysiotherapyPlanForm : BasePhysiotherapyOrderForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTButton ttButtonRaporSorgu;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNoPhysiotherapyRequest;
        protected ITTTextBox Duration;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Amount;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox PhysiotherapistOrder;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel lblRaporBilgileri;
        protected ITTLabel lblTedaviTuru;
        protected ITTEnumComboBox cmbTedaviTuru;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTLabel labelMedulaRaporTakipNoPhysiotherapyRequest;
        protected ITTGrid MedulaReportResults;
        protected ITTTextBoxColumn ReportChasingNoMedulaReportResult;
        protected ITTTextBoxColumn ReportNumberMedulaReportResult;
        protected ITTTextBoxColumn ReportRowNumberMedulaReportResult;
        protected ITTTextBoxColumn ResultCodeMedulaReportResult;
        protected ITTTextBoxColumn ResultExplanationMedulaReportResult;
        protected ITTDateTimePickerColumn SendReportDateMedulaReportResult;
        protected ITTButtonColumn btnMeduladanSil;
        protected ITTLabel labelTreatmentStartDateTime;
        protected ITTDateTimePicker TreatmentStartDateTime;
        protected ITTLabel labelTreatmentRoom;
        protected ITTObjectListBox TreatmentRoom;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTRichTextBoxControl ReasonOfRejection;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelNoteToPhysiotherapist;
        protected ITTLabel labelDuration;
        protected ITTLabel labelAmount;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTLabel labelReasonOfRejection;
        protected ITTLabel labelPhysiotherapist;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTCheckBox chkPatientPay;
        override protected void InitializeControls()
        {
            ttButtonRaporSorgu = (ITTButton)AddControl(new Guid("d01d044f-0d08-4df3-9cf0-235b3cca2fa0"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("c1b9a199-86a7-490d-9e78-c26efcb6ba6b"));
            MedulaRaporTakipNoPhysiotherapyRequest = (ITTTextBox)AddControl(new Guid("bdc78869-d7b4-4f7d-acac-bb63182b9dc7"));
            Duration = (ITTTextBox)AddControl(new Guid("480abb6a-6349-45b7-9f55-349af995dd40"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("411f2781-54df-4836-95c8-43642cc667a2"));
            Amount = (ITTTextBox)AddControl(new Guid("c062a126-d128-43df-a261-777182df8950"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("e827cc12-f61d-4aed-9318-b6e0a556eea3"));
            PhysiotherapistOrder = (ITTTextBox)AddControl(new Guid("fda5e07c-0b51-449a-9ef7-e005f8786782"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("95d26095-86f5-433d-bea6-363b8dfe345b"));
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("4364f315-9212-4148-bf1c-5c8130ade776"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("cbac9b81-8ba4-4228-8330-8be4df3be195"));
            cmbTedaviTuru = (ITTEnumComboBox)AddControl(new Guid("d9c816e4-40f9-4d0b-88e1-90af6f041df1"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("ef678826-76f2-4c4e-b230-b8e197ae1c67"));
            labelMedulaRaporTakipNoPhysiotherapyRequest = (ITTLabel)AddControl(new Guid("6343f402-03b9-45a9-ab9c-db3fdba089a6"));
            MedulaReportResults = (ITTGrid)AddControl(new Guid("1f9597e8-235e-4fe1-ab6a-21db3684d4ef"));
            ReportChasingNoMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("a4390581-cc01-47c6-b698-321157f02a9d"));
            ReportNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("4bd85038-5c80-4afd-a0a4-2f2ddd4def22"));
            ReportRowNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("91169e0d-53b5-449c-b886-cd425b1a6e75"));
            ResultCodeMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("a5c0e369-2878-46c9-8271-01dbf8009c08"));
            ResultExplanationMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("a6839b02-5018-4820-8c35-b98f24832097"));
            SendReportDateMedulaReportResult = (ITTDateTimePickerColumn)AddControl(new Guid("af59bca2-eb24-4080-bb89-bd1f71944e07"));
            btnMeduladanSil = (ITTButtonColumn)AddControl(new Guid("b998fe36-5f5e-4122-8e6e-c770c4ab0135"));
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("f22bc7fe-cd9a-462a-9584-1f7844e8d1ac"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("87f9fe03-e2c6-498a-bd3a-35efbeef7060"));
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("b94fdb2d-adb3-45d7-9706-0ae5ab3f26c3"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("7c8865c8-e4d9-4280-ae47-23d7092ad71c"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("da098038-5e05-4edf-858b-97e0e4f68787"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("282894f7-43fb-45a6-aea5-a7501bd684d4"));
            ReasonOfRejection = (ITTRichTextBoxControl)AddControl(new Guid("9b5a140e-1d9a-4da2-a702-c476e7d24d48"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("40cbaca2-0306-4945-a6df-0cd77f07d337"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("e7521b73-3254-4d3f-a655-5a0be2337332"));
            labelNoteToPhysiotherapist = (ITTLabel)AddControl(new Guid("b5362dbd-5bf5-4528-b308-5e534af48b50"));
            labelDuration = (ITTLabel)AddControl(new Guid("65dca6a8-7516-463c-b914-c0b03eaacc3c"));
            labelAmount = (ITTLabel)AddControl(new Guid("28120f3b-3b1b-4e0e-a13a-c87233978da4"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("d84a5921-a1b6-4b43-bfb6-cfb35f61ae09"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("feed7d3a-69c7-49fd-9db1-d0c8f976ee31"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0e8c766a-1420-4ec7-b61a-c50a0d7461f8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d37084af-81a8-4f60-8369-4af736c3509d"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("31b9cf49-3dfa-4ee4-a334-2fcf76d55c23"));
            labelReasonOfRejection = (ITTLabel)AddControl(new Guid("05cfefd4-c914-4a2d-a011-bc8118e60b7a"));
            labelPhysiotherapist = (ITTLabel)AddControl(new Guid("e9f38fda-e056-48c5-9aea-03e88fd9e18d"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("b5f7825c-ef62-45d9-9a28-c5576fb9de30"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("c143b0fe-28d3-4533-b272-8eaf0db2da17"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("4e726cc6-45f5-41c4-946d-4ddb70038149"));
            chkPatientPay = (ITTCheckBox)AddControl(new Guid("36d879b1-2b4f-4f31-8103-43a5ba3a0e7e"));
            base.InitializeControls();
        }

        public PhysiotherapyPlanForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyPlanForm")
        {
        }

        protected PhysiotherapyPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}