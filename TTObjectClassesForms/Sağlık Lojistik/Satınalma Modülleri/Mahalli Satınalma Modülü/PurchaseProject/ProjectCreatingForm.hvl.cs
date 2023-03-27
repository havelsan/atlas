
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
    public partial class ProjectCreatingForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ItemDetailsGrid;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTButtonColumn Details;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelConfirmNO;
        protected ITTTextBox ConfirmNO;
        protected ITTDateTimePicker ConfirmDate;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTLabel labelConfirmDate;
        protected ITTLabel labelPurchaseProjectNO;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("a5b08faf-68cd-4c49-8190-18290600b7ea"));
            ItemDetailsGrid = (ITTGrid)AddControl(new Guid("289f5bee-a622-4e22-b9c9-a796f5f3917f"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("55bfc1dc-9849-473d-9913-d598fad90203"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("fc29a02c-a652-4783-9110-f5d7ad6f43df"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("6d10c650-3bf5-418f-864b-2b495a53e5ea"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("f399e0ef-a290-42c8-a0dd-51f6876cd168"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("50ce59c6-67ee-4516-98dd-a64c45d094a0"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("e6471edb-c5b7-46ad-8d86-0e6a1acf3891"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3606d529-edd9-4151-b08c-3fb2af41f20a"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("aaa8e42d-90bf-4537-801c-314afe872046"));
            Details = (ITTButtonColumn)AddControl(new Guid("faaecede-10e2-4163-b35d-c92b46e8d94e"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a8cf295f-567a-4080-bc00-74efaf2fefde"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("7e5eeeb4-a611-4797-a7bc-9b3a753391ed"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("de3b8670-0192-4aba-9eb7-9e4042812091"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("395a4fa3-c449-4fc4-ac31-a827c4ee2dbc"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("b4ab01ca-51df-4ae4-ba8d-d4e4911571e8"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("c0d056c9-60f9-4e25-a4c2-e091d1728329"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("32003c77-cc69-4c01-a7ba-2d1c8c33cc42"));
            base.InitializeControls();
        }

        public ProjectCreatingForm() : base("PURCHASEPROJECT", "ProjectCreatingForm")
        {
        }

        protected ProjectCreatingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}