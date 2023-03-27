
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
    /// HEK İşlemleri
    /// </summary>
    public partial class HEKForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTLabel labelPriceOfUniteCost;
        protected ITTTextBox PriceOfUniteCost;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage tttabpage2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox ItemDetail;
        protected ITTTabPage tttabpage4;
        protected ITTGrid MaintanenceOrderHEKReasons;
        protected ITTListBoxColumn CousesOfTheHekDefinitionMaintanenceOrderHEKReasons;
        protected ITTCheckBoxColumn CheckMaintanenceOrderHEKReasons;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox OrderNO;
        protected ITTTextBox RequestNO;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelID;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelOrderName;
        protected ITTGroupBox KomisyonGroupBox;
        protected ITTGrid HEKCommisionGrid;
        protected ITTTextBoxColumn Sıra;
        protected ITTListBoxColumn Rank;
        protected ITTListBoxColumn Name;
        protected ITTEnumComboBoxColumn Duty;
        protected ITTLabel labelOrderNO;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            labelPriceOfUniteCost = (ITTLabel)AddControl(new Guid("50faa124-a76d-41a5-be89-e0ad4e692802"));
            PriceOfUniteCost = (ITTTextBox)AddControl(new Guid("8dd67484-809d-4cbf-8cd3-a8fa9c931d46"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3c9a9101-330c-4a6b-bd6f-8d4b30cb63de"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("b0a6dca5-3fdf-49cd-9c99-5c0db3816846"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("e8db958b-07ce-4cff-9648-af1097321ecb"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("336da509-a67f-451f-a816-2f3c72456f74"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("6c79ae16-5df8-4e9b-9faa-b768a50fcc91"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("7b586213-3df8-4cc2-b8ce-acbbe0782a1a"));
            ItemDetail = (ITTTextBox)AddControl(new Guid("6f006c93-383f-4275-ad41-e24ae7237730"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("8645fda1-6e7e-4575-837c-96521a7830c5"));
            MaintanenceOrderHEKReasons = (ITTGrid)AddControl(new Guid("1d56bf08-2f8b-46c9-860e-a9312053f9f8"));
            CousesOfTheHekDefinitionMaintanenceOrderHEKReasons = (ITTListBoxColumn)AddControl(new Guid("f68d255d-1f0c-4c98-8abc-e7f41c733ce0"));
            CheckMaintanenceOrderHEKReasons = (ITTCheckBoxColumn)AddControl(new Guid("bf784533-c1fa-4b24-87ad-bbe6c9c788b4"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("07509815-f331-49b5-af77-9febd2447a53"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("66a1f4dd-d1bd-4715-a221-537de71c9013"));
            OrderNO = (ITTTextBox)AddControl(new Guid("f9b477bb-529d-480a-9b67-9bf7ebdac688"));
            RequestNO = (ITTTextBox)AddControl(new Guid("2e7f0a29-e083-4d89-a0af-c7c4efd91ccc"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("eb6f2cb8-8f99-4c08-a66b-8c424e280376"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("aab10386-bd15-4b7e-88d6-4557f0615d11"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f756eb4c-0ff7-4e50-bb05-a866553e3c51"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("4169eccb-f2df-4725-9ff8-095b5ab3f58f"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("68ffc61a-e558-46ba-8000-2442d0323dd6"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("fe82bdf7-f652-4768-b3ac-423e5fb447ef"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("46671ff0-0beb-434b-9181-54c0a847db3e"));
            labelID = (ITTLabel)AddControl(new Guid("ef1606f6-4c9d-4441-aca9-5bb4f658a402"));
            labelFromResource = (ITTLabel)AddControl(new Guid("222efbe6-4638-4ac2-8c3e-69d992987ccb"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("685dda69-e9ab-4cf2-a2ce-6e4b5cfa8c64"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("ef88340b-d0ac-4dc6-a56c-abfefabc8cce"));
            labelActionDate = (ITTLabel)AddControl(new Guid("ae5fc596-c9f1-4364-900b-b0bb7430dd8e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c1cbc484-ddb3-49bd-9427-bc1bb644e75f"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("68c68190-3f03-4e22-a5a0-cfe125289681"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("08564a3a-3331-4dfb-9c85-d5063350825d"));
            labelOrderName = (ITTLabel)AddControl(new Guid("4d4aa0b7-b9ee-4879-95dc-d8be0f700e78"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("be771df9-610e-422e-abc5-dd626a477068"));
            HEKCommisionGrid = (ITTGrid)AddControl(new Guid("24881788-ebad-4c73-be9d-9162913d88dc"));
            Sıra = (ITTTextBoxColumn)AddControl(new Guid("e82f55f1-7f5a-40ca-b9e4-c0667dc59500"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("5c3cbb50-aa37-4413-b4f7-81250256a3ea"));
            Name = (ITTListBoxColumn)AddControl(new Guid("8a6b7833-0ed8-4d13-ba29-2b57d08e9e66"));
            Duty = (ITTEnumComboBoxColumn)AddControl(new Guid("a1ab41ec-c239-4010-affc-349c89dd15cf"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("422cb17d-af15-483b-bc61-e86ff2a40a28"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("9f719d68-e7f6-4fc8-a76d-ed63e8d3badd"));
            base.InitializeControls();
        }

        public HEKForm_MaintenanceO() : base("MAINTENANCEORDER", "HEKForm_MaintenanceO")
        {
        }

        protected HEKForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}