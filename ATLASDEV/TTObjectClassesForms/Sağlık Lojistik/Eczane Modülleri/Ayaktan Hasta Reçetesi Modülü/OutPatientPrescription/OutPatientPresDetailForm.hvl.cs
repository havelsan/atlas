
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
    /// E Reçete Detay Ekleme
    /// </summary>
    public partial class OutPatientPresDetailForm : TTForm
    {
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.OutPatientPrescription _OutPatientPrescription
        {
            get { return (TTObjectClasses.OutPatientPrescription)_ttObject; }
        }

        protected ITTLabel labelEReceteNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid DrugGrid;
        protected ITTCheckBoxColumn Select;
        protected ITTListBoxColumn Drug;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBox DrugDescription;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdAddDrugDetail;
        protected ITTEnumComboBox descriptionType;
        protected ITTButton cmdAddSignedDrugDetail;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTGroupBox ttgroupbox2;
        protected ITTObjectListBox Diag;
        protected ITTLabel ttlabel3;
        protected ITTButton cmdAddDiag;
        protected ITTButton cmdAddSignedDiag;
        protected ITTGroupBox ttgroupbox3;
        protected ITTButton cmdAddPresDesc;
        protected ITTTextBox PresDesc;
        protected ITTEnumComboBox presDescriptionType;
        protected ITTLabel ttlabel10;
        protected ITTButton cmdAddSignedPresDesc;
        protected ITTTextBox EReceteNo;
        override protected void InitializeControls()
        {
            labelEReceteNo = (ITTLabel)AddControl(new Guid("8a3e96d3-afef-4cc7-9fc6-9622763a9bf1"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("39901fc3-cd4e-4da8-88fc-970a58ba6a06"));
            DrugGrid = (ITTGrid)AddControl(new Guid("e899a66c-be33-4507-a287-1acf13d9faf1"));
            Select = (ITTCheckBoxColumn)AddControl(new Guid("28682500-6949-4a30-bc5c-a5a1c770ddc2"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("a6ba9eaf-99fc-4a27-8731-d8d8c6f5e3d5"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("756b7eb0-52a7-4099-a14e-4dc1c822805a"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("9c405b72-49fe-4f06-b1fe-987185514066"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("3979eff6-37a7-458a-9e94-c4f53204b8df"));
            DrugDescription = (ITTTextBox)AddControl(new Guid("426415ff-2cdd-4a74-a314-09e69d4293bb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("06f47132-dbda-44c1-9829-b7c0916781be"));
            cmdAddDrugDetail = (ITTButton)AddControl(new Guid("d78ea3a5-4690-46a1-a6ef-06e2d3a24acc"));
            descriptionType = (ITTEnumComboBox)AddControl(new Guid("3739775f-b52f-44c6-bff5-d7afe44ccfb6"));
            cmdAddSignedDrugDetail = (ITTButton)AddControl(new Guid("7c7f475a-321f-4830-8350-96e35d90f22e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("51e5eb80-83e5-4bf4-9feb-d0e61d4a0c10"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c3ac952a-0085-475f-b103-cad49b31b1b7"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("fd68dda4-d2c3-4962-82da-b6559e59776a"));
            Diag = (ITTObjectListBox)AddControl(new Guid("8f9153f8-dbd5-4618-8303-89838924fdb3"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("28e8828c-3a62-47c1-b7d5-f7a9d34d7096"));
            cmdAddDiag = (ITTButton)AddControl(new Guid("cb4c17ec-f68c-4a91-88f3-5711c7b6d1eb"));
            cmdAddSignedDiag = (ITTButton)AddControl(new Guid("de6959d4-095e-4df5-b1b8-3245aebc0ca5"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("186dc7aa-bffc-49fb-9ece-d327c7fea542"));
            cmdAddPresDesc = (ITTButton)AddControl(new Guid("519ed6c4-c2a9-4ba1-a98f-1ff7fba8fb7f"));
            PresDesc = (ITTTextBox)AddControl(new Guid("c8681fc8-897c-47a6-97fa-b3656233f960"));
            presDescriptionType = (ITTEnumComboBox)AddControl(new Guid("8face5be-7671-48e2-a863-358be94b528c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("7fdd7915-cf08-4783-ac1d-53928eb6852d"));
            cmdAddSignedPresDesc = (ITTButton)AddControl(new Guid("339bcbb8-1157-458f-bda6-1eeb9a93b0c9"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("d43bd9b9-2306-435d-a818-07d35c0ad3d6"));
            base.InitializeControls();
        }

        public OutPatientPresDetailForm() : base("OUTPATIENTPRESCRIPTION", "OutPatientPresDetailForm")
        {
        }

        protected OutPatientPresDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}