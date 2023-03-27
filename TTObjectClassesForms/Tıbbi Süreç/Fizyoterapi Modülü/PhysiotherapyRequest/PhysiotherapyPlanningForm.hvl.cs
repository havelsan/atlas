
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
    public partial class PhysiotherapyPlanningForm : TTForm
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
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("39f41613-dfd0-46a6-bbb4-8c52cc4b9ca8"));
            TTListBoxPhysiotherapist = (ITTObjectListBox)AddControl(new Guid("c30f10cc-757b-4f20-93eb-be48026ae6da"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("01b1a642-0bb3-4186-a513-09cf2071891b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fbb8de4e-ef4e-41e8-99e7-766404da5216"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("b34e5884-ccb2-47b8-bb55-3f51c9a8fa86"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("2c33437b-2ca8-44f9-a7c7-f5d051833ace"));
            Material = (ITTListBoxColumn)AddControl(new Guid("638a5439-1dba-4b5c-b940-8be9d70f6eec"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("5373f640-c1d6-4234-bb15-c77042f33472"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("4d84c339-db98-49e4-93d4-8740c2a7a41c"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("0ebab9a9-0182-478a-af47-3dfaae5bbf7e"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("a2757e9e-11a2-4499-8f99-477a73f41d0f"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("f78f83e7-5775-4550-b692-7e51755a1863"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("5b874919-428f-425d-ab12-7da8a8170a03"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("4227b7bb-21b5-4896-942c-aef6bab69b02"));
            KodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("af8a4854-214e-4ea6-bad9-f28a2a55cf86"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("1c81cbf9-1e51-4747-9dab-3ee7fe0ed112"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("dad732da-25eb-41b3-a5f6-e5df79dd3aa9"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("a2d3b7ce-c312-4920-8084-557523c7cae9"));
            SatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("27f20674-05dc-43b6-b3d9-63ba89b80c2d"));
            labelPhysiotherapist = (ITTLabel)AddControl(new Guid("b1b7f80c-a498-47af-b03c-0edd283109d5"));
            labelPhysiotherapyStartDate = (ITTLabel)AddControl(new Guid("1346c63b-c834-4a7c-8516-dbb148103992"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("f1111682-de49-4970-8b40-d63808a1de4d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("18777c8f-ae0d-4145-94e9-029c6650fdf4"));
            base.InitializeControls();
        }

        public PhysiotherapyPlanningForm() : base("PHYSIOTHERAPYREQUEST", "PhysiotherapyPlanningForm")
        {
        }

        protected PhysiotherapyPlanningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}