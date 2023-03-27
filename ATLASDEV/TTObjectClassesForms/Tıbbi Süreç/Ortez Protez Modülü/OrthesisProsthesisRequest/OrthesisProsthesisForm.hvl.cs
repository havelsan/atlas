
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage OrtesisProtesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn SpecificNote;
        protected ITTTextBoxColumn Price;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn PatientPays;
        protected ITTListBoxColumn Technician;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTListBoxColumn OrtezProtez_OzelDurum;
        protected ITTListBoxColumn AnesteziDrTescilNo;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTTextBoxColumn Kdv;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTTabPage DirectPurchaseMaterials;
        protected ITTGrid OPDirectPurchaseGrid;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTTabPage CodelessDirectPurchase;
        protected ITTGrid CodelessMaterialDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn txtKesinMiktar;
        protected ITTTextBox ProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessDate;
        protected ITTGrid ReturnDescriptionGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTLabel ReturnDescriptionsLabel;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel2;
        protected ITTTabControl NotesTab;
        protected ITTTabPage NoteTechnicanTab;
        protected ITTTextBox TechnicianNote;
        protected ITTTabPage NoteChief;
        protected ITTTextBox ChiefTechnicianNote;
        protected ITTTabPage NoteWarranty;
        protected ITTTextBox WarrantyNote;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("dc573fe1-60df-40de-8580-4a327bca9348"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("0635e83b-b120-4c52-b338-067c29569701"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("73951c34-05e2-4419-a95f-895d5c2ad64f"));
            OrtesisProtesis = (ITTTabPage)AddControl(new Guid("4809d90c-3058-47b8-9470-9afc1e91187e"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("4cb26ddf-4a8d-4426-acdc-870d302d08c2"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5c8b8ccc-594c-41d9-8c97-7c72df4d5d8e"));
            SpecificNote = (ITTTextBoxColumn)AddControl(new Guid("c5d77592-59eb-463a-838b-f32da40ed084"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("21cbb4b9-fcdc-46f3-9333-539ba4449f57"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("7fc9f36a-ffd0-43b5-95cc-02e892b8b583"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b998dd37-78cc-4f55-abd8-eb74f11bac3f"));
            PatientPays = (ITTCheckBoxColumn)AddControl(new Guid("4ef9ea67-4636-488c-a17f-933236d1dc90"));
            Technician = (ITTListBoxColumn)AddControl(new Guid("c1da2fad-4671-47cf-b20b-8acc185caa4a"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("3550c8c7-90ff-46cf-a680-dc233b07c067"));
            OrtezProtez_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("df74ffcd-0dc6-45e8-a539-a7c42b4743a8"));
            AnesteziDrTescilNo = (ITTListBoxColumn)AddControl(new Guid("b84f1f67-f552-45e9-bb63-69517ba4fa97"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("fd62e6c1-c490-48cd-be0d-9fff080af8e2"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("87d3a19b-2fe9-4933-b0e5-ef0a8ef91b81"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("4963ee59-989f-4801-91c3-a7ecc99da4ad"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("f42b5242-bf5d-4349-a1cb-cc5fd46fbd83"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("05e79d5a-1e86-4db9-9fc1-fc9367048209"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("4b7cb798-0a4b-4012-a063-22e999d0f10e"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("7bd71011-faa2-4259-9a3c-dffca219955a"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("821b2495-ff1c-4b2e-b91b-fec093d91cc0"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("a9e90294-bef8-42ca-bb84-c27f9b7e2834"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("9206a6a5-db1d-4124-8f46-78321fb8c856"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("2c5d2e16-6b28-44c7-97e3-4497b1526b9b"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("55229e51-fac1-4700-b9c1-b851986738c1"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("a226a75c-c644-408c-86ec-1d5ef0fa2772"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("650115a2-6bf5-442b-8e78-92524f78f9a1"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("5aca04dd-cc85-4985-9eb3-987686f83210"));
            DirectPurchaseMaterials = (ITTTabPage)AddControl(new Guid("18b1020b-f563-4b1c-a11c-842dc4bfcd25"));
            OPDirectPurchaseGrid = (ITTGrid)AddControl(new Guid("7ee03f94-f287-4932-9c28-24f85bd33e55"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("97730acb-94dd-45f1-9946-1b4af27de1e1"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("6fb3e920-b096-43eb-9b34-601dfada0c08"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("716b44c5-14e6-4d96-a5ec-44a5974a1987"));
            CodelessDirectPurchase = (ITTTabPage)AddControl(new Guid("0836b1e4-68e5-4866-b723-b502d1ad2766"));
            CodelessMaterialDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("ec9d48f9-8f82-4c83-ad31-213109a7b057"));
            DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("5fd04070-70cd-4aae-a8be-7b69dbebefaa"));
            txtKesinMiktar = (ITTTextBoxColumn)AddControl(new Guid("4d797d0b-017b-41ca-924c-14c065cf5f67"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1eea9bb1-4259-4261-b0ee-1a866aab958c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("9c19bd59-57dc-463e-98e3-9c8defc1925f"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("72eeb8d1-7784-4fcd-81d3-d86c0705919b"));
            ReturnDescriptionGrid = (ITTGrid)AddControl(new Guid("2a1df4dc-ef95-4d4b-aeca-f41e3e8b19d8"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("9e66bcd1-2361-499e-9519-a9e70848c6da"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("a4512325-9b04-45c3-b772-55aebe7b0ed9"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("447e058d-28e6-4861-8f51-5301dd5822f0"));
            ReturnDescriptionsLabel = (ITTLabel)AddControl(new Guid("0111219b-2e4f-4541-b854-a1a3d546171c"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("067bba76-50be-4112-96a9-425c93304da4"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("ee3bec2f-275a-41e0-a3fb-887f4cc7e756"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f43322d2-313b-4068-9132-e0283aa43aa1"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a1b9311b-bb3a-4ff8-bf19-89809b7fe005"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("3bfe9f0b-3329-4dc6-84ce-cef256106f73"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("531913c5-41e6-44eb-8187-ece6bc8610ec"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("3d284c2e-1649-45a8-8ee8-27a48952ad91"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("ca0f1c99-917b-45bb-b2ce-964fe2f11da3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("de13d24f-6bf6-499f-9680-d338a0cb4a1f"));
            NotesTab = (ITTTabControl)AddControl(new Guid("38ea2e44-8391-442f-9a3c-909b2d766b7f"));
            NoteTechnicanTab = (ITTTabPage)AddControl(new Guid("6cee608e-b3b6-42c9-9959-26c64ba67ebe"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("5171d96d-cbfe-4d04-a864-61f6aee72518"));
            NoteChief = (ITTTabPage)AddControl(new Guid("9683dde4-d6c4-410a-84dd-4c735e6733e1"));
            ChiefTechnicianNote = (ITTTextBox)AddControl(new Guid("9f22d51e-882c-4f3c-bd79-9a20da0f7e66"));
            NoteWarranty = (ITTTabPage)AddControl(new Guid("292ab22e-bd72-47aa-9fb7-e69da868701d"));
            WarrantyNote = (ITTTextBox)AddControl(new Guid("cd5ffc43-4dd3-4efa-b1c6-c964f8e47ba6"));
            base.InitializeControls();
        }

        public OrthesisProsthesisForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisForm")
        {
        }

        protected OrthesisProsthesisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}