
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
    /// Sözleşme Bilgileri
    /// </summary>
    public partial class ContractForm : TTForm
    {
    /// <summary>
    /// İhalede Sözleşme Yapılan Her Firma İçin Sözleşme Bilgilerinin Tutulduğu Sınıftır.
    /// </summary>
        protected TTObjectClasses.Contract _Contract
        {
            get { return (TTObjectClasses.Contract)_ttObject; }
        }

        protected ITTGroupBox ContractInfoGroup;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox TTListBox;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel23;
        protected ITTTextBox txtNewBondAmount;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox BondAmount;
        protected ITTTextBox txtContractNo;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox Supplier;
        protected ITTTextBox tttextbox3;
        protected ITTDateTimePicker ContractStartDate;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker JobEndDate;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox txtTotalContractValue;
        protected ITTLabel labelJobStartDate;
        protected ITTDateTimePicker AssuranceStartDate;
        protected ITTEnumComboBox AssuranceType;
        protected ITTLabel labelContractStartDate;
        protected ITTLabel labelSupplier;
        protected ITTLabel labelAssuranceEndDate;
        protected ITTLabel labelAssuranceType;
        protected ITTTextBox KIKWage;
        protected ITTTextBox KIKWageRate;
        protected ITTLabel labelContractDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelAssuranceValue;
        protected ITTLabel labelKIKWageRate;
        protected ITTDateTimePicker ContractDate;
        protected ITTLabel labelAssuranceStartDate;
        protected ITTLabel labelJobEndDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelContractEndDate;
        protected ITTTextBox AssuranceValue;
        protected ITTDateTimePicker JobStartDate;
        protected ITTDateTimePicker ContractEndDate;
        protected ITTDateTimePicker AssuranceEndDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage Materials;
        protected ITTGrid ContractDetailsGrid;
        protected ITTCheckBoxColumn IncludeContract;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn Description;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ContractTime;
        protected ITTTabPage ContractTextTab;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            ContractInfoGroup = (ITTGroupBox)AddControl(new Guid("c7668c25-0a0e-4244-8a42-2afb4daec387"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("847be6d4-35fb-4f5d-a23d-5d4c84a07473"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("8b9d51e2-acac-4bc8-90f4-52e5f29bd17b"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("dfeaa617-5de4-463b-a3ff-5693a7133fa4"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6829502c-8059-49c1-a620-58d1be8bb1dc"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("29ad39ad-fbcd-43e2-a7c0-52bb5cfc5e77"));
            txtNewBondAmount = (ITTTextBox)AddControl(new Guid("e11ac20b-5a2d-49b7-9b60-a80c7ede3eb4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("47883317-c41e-48b8-af16-be8236bd4a49"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5d74f47d-bd21-42ed-935e-e5a825fb427a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c81ce914-eda0-45a2-8ad3-cefca9dcab85"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("59437046-5d43-4707-8f13-1fde71b7988a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("1fa684ba-7c5b-4a6b-b776-ead8e2048a2f"));
            BondAmount = (ITTTextBox)AddControl(new Guid("dd544d43-9c56-487a-a836-1b861b3e81b0"));
            txtContractNo = (ITTTextBox)AddControl(new Guid("179111ea-8e8b-4d1e-9f56-78dc0baa3713"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4c108d20-2026-4b70-b55c-580e98d28a3e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d8bb05ee-f41d-46a6-a4dd-a9e7e6518726"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("1e4c680b-89e5-41c4-be8d-0662e2e82e2a"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("31d7df06-a69c-4314-8d46-e2cb06314ec8"));
            ContractStartDate = (ITTDateTimePicker)AddControl(new Guid("7191d5ad-3a1b-4774-801b-1361a395d59b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bae0a175-9dce-40ce-8603-6b0e4050ce4f"));
            JobEndDate = (ITTDateTimePicker)AddControl(new Guid("9f52d472-f604-491c-a6d5-318dc9fd6bb0"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fe352c77-158d-49b1-94aa-6076da3aee77"));
            txtTotalContractValue = (ITTTextBox)AddControl(new Guid("de3164fa-e284-4727-be29-3728df8778b3"));
            labelJobStartDate = (ITTLabel)AddControl(new Guid("12ee24ce-2d39-48d1-a219-f92d93435b1b"));
            AssuranceStartDate = (ITTDateTimePicker)AddControl(new Guid("46d3a361-3e78-4ca0-87c6-379ba1caaccb"));
            AssuranceType = (ITTEnumComboBox)AddControl(new Guid("54eb2dc3-9892-427f-aa46-f06f70fb24fa"));
            labelContractStartDate = (ITTLabel)AddControl(new Guid("bb4c8331-be69-4d2c-8321-3800260ebcd1"));
            labelSupplier = (ITTLabel)AddControl(new Guid("a48ba35b-40e8-4d12-96f5-edbd7474735d"));
            labelAssuranceEndDate = (ITTLabel)AddControl(new Guid("43532378-d4ef-4b52-b8ed-4446572c81bf"));
            labelAssuranceType = (ITTLabel)AddControl(new Guid("55151df4-c072-45fb-9149-e68305630633"));
            KIKWage = (ITTTextBox)AddControl(new Guid("4d07db59-fd21-4dfb-9b14-4e14488d2f86"));
            KIKWageRate = (ITTTextBox)AddControl(new Guid("d4ef016d-5bf1-49d4-bbe5-d7da4bb022b1"));
            labelContractDate = (ITTLabel)AddControl(new Guid("e993cc35-e685-4a9b-bb44-557dc7a8a56f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bec8eeaf-8148-42d4-90cd-bfd3e9008efe"));
            labelAssuranceValue = (ITTLabel)AddControl(new Guid("1f96cb13-b6f4-43b7-8d3e-5d7b3661ba50"));
            labelKIKWageRate = (ITTLabel)AddControl(new Guid("16b0ab66-6b6a-4e8c-9239-b6af8e7a0199"));
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("2aab25c5-05c7-4484-baf6-62169b53e914"));
            labelAssuranceStartDate = (ITTLabel)AddControl(new Guid("dd8dbe01-e43c-48c0-8c58-ac8236a6ee40"));
            labelJobEndDate = (ITTLabel)AddControl(new Guid("ca64f754-803b-405f-b43c-a92c6229c279"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0d99caae-1dd8-4327-87a7-7d1823d61e27"));
            labelContractEndDate = (ITTLabel)AddControl(new Guid("2d0b535e-2998-4750-a42e-80ec6d75f8d0"));
            AssuranceValue = (ITTTextBox)AddControl(new Guid("3977b4ab-b793-4511-9775-91eaad251583"));
            JobStartDate = (ITTDateTimePicker)AddControl(new Guid("d2273a5b-400e-4649-b3ef-83ef2e0aa684"));
            ContractEndDate = (ITTDateTimePicker)AddControl(new Guid("ba9e02f8-c208-4f6c-b567-8c794f7d74d9"));
            AssuranceEndDate = (ITTDateTimePicker)AddControl(new Guid("13221528-4a2a-45cf-8eb6-8b49825bb5dc"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("00270a1f-4ceb-4f4b-abfd-cc24e942b6dd"));
            Materials = (ITTTabPage)AddControl(new Guid("178bee30-f8a7-472c-9df8-645aeabec70e"));
            ContractDetailsGrid = (ITTGrid)AddControl(new Guid("6f335bae-c40f-421a-b6f8-3c717578f69b"));
            IncludeContract = (ITTCheckBoxColumn)AddControl(new Guid("515ea44e-a220-4716-9600-73f0102e9ea6"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("47fd8778-bd0c-4d82-b733-72ba5f549f5a"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("be4a0e02-258b-4207-9325-bdb0845b5f3b"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("89ef6c53-de89-4bcd-9f13-8bc6b5a387e8"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("04cab807-f180-420f-b883-2b72f5636c7b"));
            ContractTime = (ITTTextBoxColumn)AddControl(new Guid("b40245a5-a4b8-4760-bc6e-daf14e6f2921"));
            ContractTextTab = (ITTTabPage)AddControl(new Guid("a16903dc-62bf-403d-b6c7-760bd81bf15e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3d3131d1-b8cf-4543-8861-910414b99a69"));
            base.InitializeControls();
        }

        public ContractForm() : base("CONTRACT", "ContractForm")
        {
        }

        protected ContractForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}