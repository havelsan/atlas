
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
    /// Laboratuvar İstek İşlemde Formu
    /// </summary>
    public partial class LaboratoryRequestProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Laboratuvar
    /// </summary>
        protected TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get { return (TTObjectClasses.LaboratoryRequest)_ttObject; }
        }

        protected ITTTextBox textBarcode;
        protected ITTLabel labelBarcode;
        protected ITTButton cmdSendRequest;
        protected ITTTabControl TabControlLabProcedures;
        protected ITTTabPage TabPageLabProcedures;
        protected ITTGrid GridLabProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn LabProcedure;
        protected ITTStateComboBoxColumn CurrentState;
        protected ITTTextBoxColumn SampleRejectReason;
        protected ITTTextBoxColumn Result;
        protected ITTEnumComboBoxColumn Warning;
        protected ITTTextBoxColumn Reference;
        protected ITTRichTextBoxControlColumn SpecialReference;
        protected ITTTextBoxColumn Unit;
        protected ITTButtonColumn Detail;
        protected ITTButtonColumn Cancel;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ResultNote;
        protected ITTRichTextBoxControlColumn LongReport;
        protected ITTDateTimePickerColumn islemTarihi;
        protected ITTListBoxColumn drAnestezitescilNo;
        protected ITTListBoxColumn ozelDurum;
        protected ITTButtonColumn cokluOzelDurum;
        protected ITTTabControl TabForInformations;
        protected ITTTabPage tttabpage1;
        protected ITTEnumComboBox PatientGroup;
        protected ITTEnumComboBox PatientSex;
        protected ITTTextBox PatientAge;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ReasonForAdmisson;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelPreInformation;
        protected ITTCheckBox Urgent;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextBarcode;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage2;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox requestDoctor;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTTabPage tttabpage3;
        protected ITTEnumComboBox Gebelik;
        protected ITTDateTimePicker SonAdetTarihi;
        protected ITTLabel labelSonAdetTarihi;
        protected ITTLabel labelGebelik;
        protected ITTTabPage TabPageFutureRequest;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel3drawgradient;
        protected ITTButton ttPrintResultReport;
        override protected void InitializeControls()
        {
            textBarcode = (ITTTextBox)AddControl(new Guid("c3ecd463-1686-4e30-9d59-9ff0aeb8de35"));
            labelBarcode = (ITTLabel)AddControl(new Guid("87506753-6093-46e8-b9d0-d268abce5e28"));
            cmdSendRequest = (ITTButton)AddControl(new Guid("3a1fd4e1-8e1d-4e90-a5ce-075c3da7e27d"));
            TabControlLabProcedures = (ITTTabControl)AddControl(new Guid("dcce9696-9691-446d-a9e4-0fe41a63f3c3"));
            TabPageLabProcedures = (ITTTabPage)AddControl(new Guid("077ef7d4-fe3a-45f8-bfc0-76ff97d82771"));
            GridLabProcedures = (ITTGrid)AddControl(new Guid("ef3ca5e0-b64c-42b1-868b-fcda4761bc27"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("1a32ff91-9686-47e3-a9a2-d49ec3d93d8b"));
            LabProcedure = (ITTTextBoxColumn)AddControl(new Guid("f4c0c8af-371f-4733-a03d-517f26d2aac3"));
            CurrentState = (ITTStateComboBoxColumn)AddControl(new Guid("cd0be5e6-e9a7-4767-8690-ac17a0cbc6aa"));
            SampleRejectReason = (ITTTextBoxColumn)AddControl(new Guid("28a872f3-3796-4ad2-8192-f8b48dfb3096"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("22b4f630-9502-48be-9bb0-e7ec1a7503ee"));
            Warning = (ITTEnumComboBoxColumn)AddControl(new Guid("f09ad361-84a2-4afa-93f9-109e84e9319e"));
            Reference = (ITTTextBoxColumn)AddControl(new Guid("3b7a912b-656e-4d4c-b863-19d16b927a72"));
            SpecialReference = (ITTRichTextBoxControlColumn)AddControl(new Guid("546d23fd-95a7-4f84-bd8f-f3dd3642de32"));
            Unit = (ITTTextBoxColumn)AddControl(new Guid("db51df90-fa1a-42a2-9ed2-499169e983de"));
            Detail = (ITTButtonColumn)AddControl(new Guid("b6892e6b-40e1-4320-9009-819611c41eb3"));
            Cancel = (ITTButtonColumn)AddControl(new Guid("dc7a519d-3cfb-46f5-bac5-8ce76c8e888f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("18c2bdd6-d5ff-42fa-8526-31b549d450ce"));
            ResultNote = (ITTTextBoxColumn)AddControl(new Guid("a1014c90-b750-4a89-b4d1-ab512f55f370"));
            LongReport = (ITTRichTextBoxControlColumn)AddControl(new Guid("e4cf9348-80b0-4da5-93c4-e6776efa3a59"));
            islemTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("1df4632d-487c-445e-8a51-567e87172ce6"));
            drAnestezitescilNo = (ITTListBoxColumn)AddControl(new Guid("9bbfb74d-b0ab-4fa8-bcf4-15a815f81c30"));
            ozelDurum = (ITTListBoxColumn)AddControl(new Guid("db6c160f-9df7-4c02-8ed6-75ae23877b13"));
            cokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("e2c3b492-7cd6-43b1-b13f-f7252954847c"));
            TabForInformations = (ITTTabControl)AddControl(new Guid("e9849c0c-da7c-4702-b580-5144b2f4cd8d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("96389f99-be09-4b2f-9049-1b8dd57ee5cd"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("4609f8be-f0db-4a91-8e5f-1898559af6c9"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("ab68f911-767f-4c43-8f9e-53c08797d6d5"));
            PatientAge = (ITTTextBox)AddControl(new Guid("befc886e-0b1c-4ca0-84f2-4921b922169d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e434603b-7554-4bc0-aae9-3677a95aa001"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("685d500a-2e83-4e27-9a57-23dc5f37d808"));
            ReasonForAdmisson = (ITTTextBox)AddControl(new Guid("f122ee4d-6e85-4057-90db-e7e1ffcebdde"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d359e6bb-316a-4a6b-8331-1e190e2a0030"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f7c54c65-a031-41c6-b196-7fae35eb9314"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("53f1e6b5-9505-4dad-8b81-c3567e95f015"));
            Urgent = (ITTCheckBox)AddControl(new Guid("42772cd9-783c-4aed-8fb5-6bf0a99d3c99"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d2cc353c-8cda-4d88-aa99-97f3ba15e936"));
            tttextBarcode = (ITTTextBox)AddControl(new Guid("eeba6474-20a4-451e-a599-2386d89bc4f4"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3115802a-f349-4b45-a0cb-7226994d6953"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("dd605a7d-0d33-4317-9166-f5e9aa9a45f2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("84368358-5e05-456e-8c31-53aac25db353"));
            requestDoctor = (ITTObjectListBox)AddControl(new Guid("7c970a90-9a4b-45a8-9576-c3c041ea6a5d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7e188531-2a33-4520-9f2b-1c7406b7783f"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("dc13ffd0-b204-40b8-b048-098f12d77afa"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("40b4d954-96de-4f14-bdc4-a62185bf163b"));
            Gebelik = (ITTEnumComboBox)AddControl(new Guid("d37e406f-b807-4c42-aa94-136c56928c4c"));
            SonAdetTarihi = (ITTDateTimePicker)AddControl(new Guid("d18955c3-f675-497c-b4a9-a8ab81b885ea"));
            labelSonAdetTarihi = (ITTLabel)AddControl(new Guid("8ba4e0c5-e1da-4f1e-9a7e-8b13c41f31be"));
            labelGebelik = (ITTLabel)AddControl(new Guid("f75079fa-7665-455e-8bad-af97b3d1b9ae"));
            TabPageFutureRequest = (ITTTabPage)AddControl(new Guid("cda594ef-42c4-4e72-9f8a-9d081f24b153"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("475b1da1-8ee8-4eb2-97be-86cce2f949c5"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("05fa9215-82f5-4cc5-a588-56972b26e3bd"));
            ttlabel3drawgradient = (ITTLabel)AddControl(new Guid("b7331fb8-6dd2-46c9-a958-5b25e0b2d4a5"));
            ttPrintResultReport = (ITTButton)AddControl(new Guid("a917d419-4d71-476f-82fc-370737ce1f12"));
            base.InitializeControls();
        }

        public LaboratoryRequestProcedureForm() : base("LABORATORYREQUEST", "LaboratoryRequestProcedureForm")
        {
        }

        protected LaboratoryRequestProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}