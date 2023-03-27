
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
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptionThirdForm : OutPatientPrescriptionBaseForm
    {
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.OutPatientPrescription _OutPatientPrescription
        {
            get { return (TTObjectClasses.OutPatientPrescription)_ttObject; }
        }

        protected ITTLabel labelEReceteNo;
        protected ITTTextBox ProtocolNoSubEpisode;
        protected ITTTextBox EReceteNo;
        protected ITTLabel labelProtocolNoSubEpisode;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DrugTabPage;
        protected ITTGrid OutPatientDrugOrders;
        protected ITTRichTextBoxControlColumn ProvisionDetail;
        protected ITTListBoxColumn Drug;
        protected ITTTextBoxColumn BarcodeLevel;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn RequiredAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn PackageAmount;
        protected ITTTextBoxColumn ReceivedPrice;
        protected ITTTextBoxColumn UsageNote;
        protected ITTEnumComboBoxColumn DrugSupply;
        protected ITTButtonColumn cmdSelectBarcodeLevel;
        protected ITTCheckBoxColumn ProvisionResult;
        protected ITTTextBox ID;
        protected ITTTextBox ReceiptNO;
        protected ITTTextBox PatientFullName;
        protected ITTLabel labelReceiptNO;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel6;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage1;
        protected ITTGrid SPTSDiagnosises;
        protected ITTTextBoxColumn Code;
        protected ITTTextBoxColumn Name;
        protected ITTTabPage tttabpage2;
        protected ITTGrid SPTSDiagnosisInfos;
        protected ITTListBoxColumn Diagnose;
        protected ITTTabPage tttabpage3;
        protected ITTLabel ttlabel8;
        protected ITTTextBox tttextbox4;
        protected ITTButton btnEReceteNoInQuiry;
        protected ITTButton cmdAddDetail;
        protected ITTTabPage tttabpage4;
        protected ITTTextBox tttextbox6;
        override protected void InitializeControls()
        {
            labelEReceteNo = (ITTLabel)AddControl(new Guid("b46bb98d-79b8-464a-8c12-21425abe4f37"));
            ProtocolNoSubEpisode = (ITTTextBox)AddControl(new Guid("336c2670-3e5a-45a1-a1bc-5d99d1b3f69f"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("955559c9-5bd7-45f7-8e1b-5f642246cc42"));
            labelProtocolNoSubEpisode = (ITTLabel)AddControl(new Guid("ece31801-9daf-43fc-a1b7-fc0616205e92"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("37d0d401-9a53-41c4-a8b7-5a5db6f4679a"));
            DrugTabPage = (ITTTabPage)AddControl(new Guid("af1fcc99-91e1-4b7b-989f-3a96ade8c43c"));
            OutPatientDrugOrders = (ITTGrid)AddControl(new Guid("62488578-0c62-4430-b404-795ada89c69b"));
            ProvisionDetail = (ITTRichTextBoxControlColumn)AddControl(new Guid("51350b0e-6480-4f7d-8641-434849b11278"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("c0cb449f-59d5-4038-aa81-f7a78ce72e7a"));
            BarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("a8b3a138-7ead-4dd8-a9d3-5bcd6a814610"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("c62f2b56-f487-46a8-918a-faf9cb3d9b3a"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("ad13279e-04e0-48f2-8d6a-0ac91c1a42e5"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("9d3f92aa-c216-4a4a-853c-7c74bd051a65"));
            RequiredAmount = (ITTTextBoxColumn)AddControl(new Guid("ec2dbc5e-990d-43e1-b1a5-0f436d159a97"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("29f3dd42-333f-4633-80a5-66c67fe8d3f5"));
            PackageAmount = (ITTTextBoxColumn)AddControl(new Guid("a29effad-7d80-4b76-8a7e-67d50ecf81e2"));
            ReceivedPrice = (ITTTextBoxColumn)AddControl(new Guid("354c9f4c-4011-4f38-bfbc-271878693284"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("b5246006-ec3f-4289-bfdf-4bccd903ead4"));
            DrugSupply = (ITTEnumComboBoxColumn)AddControl(new Guid("8f249058-b132-4217-8aa4-db3691528fde"));
            cmdSelectBarcodeLevel = (ITTButtonColumn)AddControl(new Guid("694db4e5-9dab-4d1c-8cf0-0eeebf987b9b"));
            ProvisionResult = (ITTCheckBoxColumn)AddControl(new Guid("be700c81-ef1f-4367-917b-e76b274834c6"));
            ID = (ITTTextBox)AddControl(new Guid("abac0831-a6a0-4657-b969-49e988bb15ac"));
            ReceiptNO = (ITTTextBox)AddControl(new Guid("8234b2f0-c196-490c-b5cf-4cbacbf1e864"));
            PatientFullName = (ITTTextBox)AddControl(new Guid("b581a12b-fa54-47b1-a2a3-70fc14a3695b"));
            labelReceiptNO = (ITTLabel)AddControl(new Guid("f1004a90-0243-4b25-b618-3c557870761d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f0b449e2-45eb-41f0-9e9b-41ca1d72949d"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("337ef42f-1ecc-4192-a7db-909b3ae1ffb5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("eff0fa37-14e1-4f7f-9bf5-9480fd0e0f41"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c74bd4aa-b59c-4194-a565-a3e3c044cdf2"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a1ecd804-6c4a-446e-be43-c786751d4cc4"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("b513a3b4-6570-45b6-8ba2-967355d379fa"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("2cbc8ff8-fb94-4592-af62-382032e7a6fe"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("60f81c36-1b5c-4fee-8031-1bf5f783607e"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("b430bf9b-3c00-45c7-89d4-fe7a622c348e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa775d8f-b593-43fd-a402-e230de67a5cb"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("27e62177-0884-4d8e-b96f-5304f4945358"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("91171432-38e9-478d-8d99-38177a4473ff"));
            SPTSDiagnosises = (ITTGrid)AddControl(new Guid("ccf8ff9c-7d01-4f41-a168-191ea1cfbea7"));
            Code = (ITTTextBoxColumn)AddControl(new Guid("fc614d87-e4d6-4ac1-a752-7a8cffb51b38"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("d5fbc097-1f14-4393-bce6-d11358d297f2"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("6b731f3b-3e01-4c08-b706-a64cea239b5b"));
            SPTSDiagnosisInfos = (ITTGrid)AddControl(new Guid("08338afe-1173-4020-b27c-68504b485de4"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("537613b0-e225-449c-a6ec-632d32ff68bb"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("bc5fd577-08af-4b49-8835-8589bf0858cd"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c29ce005-7034-4a58-8f3c-806be920d2eb"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("45500468-9920-422b-9a60-46d52002e455"));
            btnEReceteNoInQuiry = (ITTButton)AddControl(new Guid("e95c6cfc-3f8d-4c52-95d0-3fe2962f2fde"));
            cmdAddDetail = (ITTButton)AddControl(new Guid("2948ce7d-6751-433d-ad2f-0caacfa4c15b"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("a1f01676-4370-4a81-a5e2-fe40335e5d2d"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("e258edf9-6b70-48b9-8163-f2fec1656ac3"));
            base.InitializeControls();
        }

        public OutPatientPrescriptionThirdForm() : base("OUTPATIENTPRESCRIPTION", "OutPatientPrescriptionThirdForm")
        {
        }

        protected OutPatientPrescriptionThirdForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}