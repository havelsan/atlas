
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
    public partial class PhysiotherapyRequestPlanningForm : TTForm
    {
    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest
        {
            get { return (TTObjectClasses.PhysiotherapyRequest)_ttObject; }
        }

        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTObjectListBox TTListBoxPhysiotherapist;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn Notes;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn KodsuzMalzemeFiyatı;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn SatinAlisTarihi;
        protected ITTLabel labelPhysiotherapist;
        protected ITTLabel labelPhysiotherapyStartDate;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("ea7f945f-3e93-4aa5-b772-e462f2c52e96"));
            TTListBoxPhysiotherapist = (ITTObjectListBox)AddControl(new Guid("78007dd9-64dd-4528-a784-f3fd47f9dc15"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1fd99b0f-573e-49dc-92cb-1bad827baa30"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("6630798f-dc38-41b0-bce3-a48a7705f159"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("3f460550-f2cc-4d0a-9a00-b46dd7510e78"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("3ba3841d-c6ed-40a8-835c-e67d68501db2"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a09676d9-d0af-4205-b0d2-bf021a5021f5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("59aa807a-3e23-4975-9534-23f0d7785c17"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("95de36dd-5f28-4f66-84ca-ff5e409931db"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("6be4c64c-b92a-44a9-8a48-e68e800a0969"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3f6e5417-4e3a-4e55-b320-93a3a4dc1841"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("4d7e2533-c123-4235-b15b-c14392a8b866"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("ae23868e-73d3-4310-8cdd-ef709ec9b0da"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("6723cae5-d2ae-4655-84ac-9226fa01537c"));
            KodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("65ed1091-9461-474a-ac9c-993c10ed2ebb"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("df6977c9-fe88-466f-a488-8d95ca8748d3"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("89d29150-f4b4-4960-92ea-bd36bc8c11fe"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("d8047cda-a38d-4a0e-bd4f-5913d5e919f2"));
            SatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("fedb8808-d8e2-41aa-8414-150faddce2cc"));
            labelPhysiotherapist = (ITTLabel)AddControl(new Guid("b850861e-a70c-4c0a-b6c0-59c77c4b8bf5"));
            labelPhysiotherapyStartDate = (ITTLabel)AddControl(new Guid("60071663-a0df-4874-b1af-304cdc439470"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("a3283c3d-33ef-4fa6-9882-0d77f759380d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ee7a7749-7f48-420d-bd72-18c9099b133d"));
            base.InitializeControls();
        }

        public PhysiotherapyRequestPlanningForm() : base("PHYSIOTHERAPYREQUEST", "PhysiotherapyRequestPlanningForm")
        {
        }

        protected PhysiotherapyRequestPlanningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}