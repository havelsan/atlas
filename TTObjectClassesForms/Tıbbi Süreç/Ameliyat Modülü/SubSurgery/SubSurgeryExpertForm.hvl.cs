
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
    /// Ek Ameliyat
    /// </summary>
    public partial class SubSurgeryExpertForm : EpisodeActionForm
    {
    /// <summary>
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
        protected TTObjectClasses.SubSurgery _SubSurgery
        {
            get { return (TTObjectClasses.SubSurgery)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid SubSurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTTabPage CodelessDirectPurchase;
        protected ITTGrid CodelessMaterialDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn txtKesinMiktar;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox MasterResource;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfProcedureObject;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("bc71d127-3672-49d2-bdf3-2b58ebae4a03"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("651370da-4af8-470b-8756-5e147e02e1bc"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("95b01436-6f55-4ce4-92b2-0fa3f962b8f3"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("f9fc10e5-9625-4c6a-ad42-ecac296b6ab4"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("c375a6d3-f310-4dcc-9f65-ecdc34512eb0"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("0563ef43-ba9e-4fdf-a64e-582371dc0905"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("167d20b5-95ab-420b-be16-b05a7b7efa0a"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("541dc8fd-4c2e-42c9-a9ee-95b14e2a9a67"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("9e2db7f1-5501-4bf8-8c77-0f9261058e4a"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("5a9c96df-c56b-4025-9a7e-97761ebc6eb3"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("4b7af359-19c6-4f8f-baeb-96deeda854ac"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("a56d6732-4113-4b2e-85d7-5ccd00a2f563"));
            SubSurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("d540dead-e9ec-41b9-8dda-2af13a2d71c3"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("d1cb2c59-0e22-4b26-8113-9c808e7fb0a0"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("5cb54093-d965-409b-b79f-70081284a40a"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("70a88f66-f649-4821-8f45-5bd9a0bd8ce1"));
            CodelessDirectPurchase = (ITTTabPage)AddControl(new Guid("dfef1496-4457-4efa-9f55-480f25137e92"));
            CodelessMaterialDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("64adef90-7187-4ad6-9a08-e9faaa34c62c"));
            DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("07bd6e98-861b-4ee0-bd2e-667e09a8b33b"));
            txtKesinMiktar = (ITTTextBoxColumn)AddControl(new Guid("579c4c99-026a-4d38-bd7e-ff643515c642"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("533bc07d-f2e2-4528-9647-2bb39be18d5a"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("c99bdf25-c3d3-46da-b02a-d4fae2b4d318"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2692b14f-f5a4-4ebd-b9d2-931ed69f415d"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("10767308-0a9b-47b5-9c1c-8f49b6ef5de7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aec362fb-7306-4375-813f-91d07be978b3"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("1079318a-d5bd-41fe-a58b-9bbf2a0387ab"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("bc7b7b5b-4a2c-4739-ab08-eeea9eaa03b4"));
            Emergency = (ITTCheckBox)AddControl(new Guid("aa4732c7-1a5f-4d61-8ee4-3f198022feba"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("e821df1d-96f8-4251-9c07-4ac47c96e7cf"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("8907790b-1564-43f3-8529-3ee3b40480e7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("70c480d6-5968-478f-89cf-111718eb78ce"));
            labelRoom = (ITTLabel)AddControl(new Guid("5927c041-0222-4263-aac3-0e40ee643a37"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("474e418e-e8c2-420f-96d7-779453324305"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("2cc38cb4-bb8c-4afc-ab93-9766afe6d7a5"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("f67cac34-88da-4404-b17c-555f2d2b6409"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("25399a76-1ccb-40b5-9f02-40dd655d34c0"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("f10fab5d-65ef-4d79-a7df-abb156a9241c"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("ac2d2f0b-30d8-4d97-8423-9eebaab445e7"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("3fa54b97-6079-4db8-81da-e34801063fbd"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("cbc832c5-8b42-4163-8efd-2ed06d752c0a"));
            base.InitializeControls();
        }

        public SubSurgeryExpertForm() : base("SUBSURGERY", "SubSurgeryExpertForm")
        {
        }

        protected SubSurgeryExpertForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}