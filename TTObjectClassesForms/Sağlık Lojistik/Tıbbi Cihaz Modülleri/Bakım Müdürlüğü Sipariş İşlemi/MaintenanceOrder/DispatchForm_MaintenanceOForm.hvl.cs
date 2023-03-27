
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
    /// Gönderme Kısmı
    /// </summary>
    public partial class DispatchForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox RequestNo;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox OrderNO;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox FixedAsset;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CheckDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker OrderDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelResDivision;
        protected ITTLabel labelOrderStatus;
        protected ITTEnumComboBox OrderStatus;
        protected ITTEnumComboBox ArrivalType;
        protected ITTLabel labelDeviceSendingDate;
        protected ITTDateTimePicker DeviceSendingDate;
        protected ITTLabel labelArrivalType;
        override protected void InitializeControls()
        {
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("b06fa673-533a-459e-b559-fd391a674cd9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("49b68cc6-6c51-44da-8a56-14146e4300cd"));
            RequestNo = (ITTMaskedTextBox)AddControl(new Guid("7993530f-d80e-4c65-b84d-acc9e6319b5f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6b1ba5fc-c4e3-4037-9bb4-b65322f55f9f"));
            OrderNO = (ITTTextBox)AddControl(new Guid("bc0ac369-010f-41e4-8403-965ec1f46d53"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bd74d26e-dcfc-4afe-a6c9-522b2e15daef"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("8d78cbca-8574-486d-8f9c-54db0eb75e32"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("d639cca0-8a18-48ed-8070-f3f0a4edcae8"));
            labelOrderName = (ITTLabel)AddControl(new Guid("123200fb-7845-40b1-8546-6ea556705e50"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("18fbfa43-3374-4ed2-afa3-c6d5b4ba942a"));
            CheckDate = (ITTDateTimePicker)AddControl(new Guid("edfcc834-ea13-4e54-8d7c-3b3bb82cc7c1"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("f89fd229-f388-4725-b977-3c7022cafd93"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("6e7d003b-7031-4c43-b67c-69b366abc575"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("2fff0f40-929b-4a93-9186-42bf22cdc08d"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("a83f5bf1-67a6-4eed-9f10-d4feb96cd113"));
            labelID = (ITTLabel)AddControl(new Guid("9a58d318-f4f3-4414-be08-824cabd5d6e2"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("22c04099-6b1a-45d9-998d-266a680365be"));
            labelFromResource = (ITTLabel)AddControl(new Guid("4aa9f911-1cd6-4823-9113-410fc9804b60"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("93396745-9f35-4442-870c-8312aa4fb404"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3bc7c9b7-647f-4a07-9408-f4961b524924"));
            labelActionDate = (ITTLabel)AddControl(new Guid("324a3a40-bf2a-46bf-ac66-bcad87047d6c"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("e8726d30-7df2-4283-b5f0-a39190e968dc"));
            labelResDivision = (ITTLabel)AddControl(new Guid("5aca7e4b-0c6f-48c5-8702-f9482f43dc1d"));
            labelOrderStatus = (ITTLabel)AddControl(new Guid("41d6465e-9db8-46f6-bd6c-34296979bdd4"));
            OrderStatus = (ITTEnumComboBox)AddControl(new Guid("5bb94d26-9731-450a-87c7-622144b76b47"));
            ArrivalType = (ITTEnumComboBox)AddControl(new Guid("3e3d4fa2-074b-43ca-bd40-a29faae49370"));
            labelDeviceSendingDate = (ITTLabel)AddControl(new Guid("815727a4-b948-4fe9-837f-15764e57167d"));
            DeviceSendingDate = (ITTDateTimePicker)AddControl(new Guid("bb85e2a0-9a2e-491a-8517-1a7c53b60029"));
            labelArrivalType = (ITTLabel)AddControl(new Guid("6b8c5597-6736-4827-b97c-1f11ca1ffe49"));
            base.InitializeControls();
        }

        public DispatchForm_MaintenanceO() : base("MAINTENANCEORDER", "DispatchForm_MaintenanceO")
        {
        }

        protected DispatchForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}