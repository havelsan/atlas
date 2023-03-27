
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel11;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNo;
        protected ITTTextBox OrderNo;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelID;
        protected ITTLabel labelFixedAsset;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTObjectListBox FixedAsset;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelOrderName;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        override protected void InitializeControls()
        {
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("178b6138-3406-49b4-9d9f-cc784710b900"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("799125e9-0d4d-4f7d-80fa-6a84b3db4797"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("7749c57c-9b78-4c74-baa7-b4330bb3fee7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("88c71be9-0e3f-422b-9b6b-81749de85290"));
            RequestNo = (ITTTextBox)AddControl(new Guid("9d20b54d-0930-4a71-ab43-c70a12056243"));
            OrderNo = (ITTTextBox)AddControl(new Guid("9e7d91c6-b0ef-4073-bbff-bc83c745be31"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("277c9c61-9057-4437-9bd3-d4b4324f559b"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("f8f7f0b6-7472-4627-9a2d-14e568c2c071"));
            labelFromResource = (ITTLabel)AddControl(new Guid("d181885e-26d7-42ad-b509-5f222c59dc9d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("940af233-d802-49f7-8e98-d504c001d65a"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c589d7c8-4709-4aea-858c-514370ae1d6b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b468e616-dd9c-4291-aee2-73222c9f9499"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("f8531202-139c-499c-a729-73d59273b691"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ada088e8-ffa3-496f-84e2-a42191aa3a68"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("865ce778-fde3-4287-9241-eec0c5dae3e8"));
            labelID = (ITTLabel)AddControl(new Guid("f969cdfe-1424-4b27-a15b-9c7c72a347c5"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("edb1ecb8-c5ed-406f-94b7-4a29ccc3e066"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("e2c4d761-1df7-43e6-995f-74e86fad24fe"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("fa3dca03-b000-40d7-83f1-189d9ecaca2e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("abc6dbbb-651e-4457-9489-dcc6d9141328"));
            labelOrderName = (ITTLabel)AddControl(new Guid("d041399f-1296-4eeb-87e6-608ba3a43cd3"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("347f6928-33c5-47e4-83a2-8dc83388aaf6"));
            labelActionDate = (ITTLabel)AddControl(new Guid("1c903a80-7027-445a-9238-71306113e39b"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("79e44ebf-942c-4db8-b5e5-d7c869a3e840"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("d69d8083-7d14-4cba-9fba-a2d352f69a57"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("2e6f21b2-8e35-4661-8070-24eb48ac54cf"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("fb139c1f-3e6f-40c9-b00c-0b17c47b3bfd"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("5f4eb416-80e7-4dd2-ab5e-da23dba54692"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("7402af0a-2abf-4514-bc8c-03211c8f941a"));
            base.InitializeControls();
        }

        public CalibrationForm_MaintenanceO() : base("MAINTENANCEORDER", "CalibrationForm_MaintenanceO")
        {
        }

        protected CalibrationForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}