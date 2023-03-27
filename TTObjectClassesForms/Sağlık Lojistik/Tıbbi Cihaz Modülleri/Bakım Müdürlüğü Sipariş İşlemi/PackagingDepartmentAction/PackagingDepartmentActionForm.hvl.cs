
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
    /// Ambalajlama İş İstek
    /// </summary>
    public partial class PackagingDepartmentActionForm : TTForm
    {
    /// <summary>
    /// Ambalajlama İş İstek
    /// </summary>
        protected TTObjectClasses.PackagingDepartmentAction _PackagingDepartmentAction
        {
            get { return (TTObjectClasses.PackagingDepartmentAction)_ttObject; }
        }

        protected ITTButton cmdSectionRequirement;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid PackagingDepConsMaterials;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn ReqMat;
        protected ITTListBoxColumn ReqDistType;
        protected ITTTextBoxColumn ReqAmount;
        protected ITTTextBoxColumn SuppAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn Store;
        protected ITTLabel labelResDivision;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelRequestNo;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Result;
        protected ITTLabel labelResult;
        protected ITTGrid SectionRequirements;
        protected ITTTextBoxColumn StockActionID;
        protected ITTStateComboBoxColumn State;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("34ac664e-75e2-4777-9998-3f5ce5102d4f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("eb3e69ce-4f59-449a-93c3-2c652dbfaa4e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("ebccf082-dd80-4fda-8b6e-f31871fa24fe"));
            PackagingDepConsMaterials = (ITTGrid)AddControl(new Guid("580d5c11-ab7b-46b6-8c07-27132f65467f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("ad033c6d-4ff7-4b44-9d08-f964ea784c8d"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("befb6b21-5c76-4ada-be6a-71f43b7591d1"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("bebff216-87c8-4b83-9b54-85a86d8adf84"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("fd4db219-a6b1-4f34-a60b-e89e85ab3751"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("bfe2dbc8-c141-4ec8-b199-da44e7f852e4"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("0a5c5c24-084e-4b07-8a1b-fd52665dd919"));
            ReqMat = (ITTListBoxColumn)AddControl(new Guid("786118c3-e3f8-457d-b655-88327a131b3d"));
            ReqDistType = (ITTListBoxColumn)AddControl(new Guid("f30c2679-891d-4946-9cf5-e7e42f50e69f"));
            ReqAmount = (ITTTextBoxColumn)AddControl(new Guid("56ca548f-8067-4e6e-bf04-8984a6dc6a16"));
            SuppAmount = (ITTTextBoxColumn)AddControl(new Guid("f89b45b6-fea5-4108-8de5-511c426e4c5a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1db802ac-6779-4755-bf01-49920e98f6dc"));
            Store = (ITTListBoxColumn)AddControl(new Guid("f689718f-53ca-4121-bf65-a582722cce76"));
            labelResDivision = (ITTLabel)AddControl(new Guid("99c8503a-46c2-4663-b3f8-23a5f1589522"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("c0254ae1-8b63-464b-b88f-80b871908e66"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("04218886-89d2-481a-a208-3fedb8078f99"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("24bed651-da20-4247-99a0-0eddb8569888"));
            labelStartDate = (ITTLabel)AddControl(new Guid("5a7297d5-ba2c-4e82-8549-3e4e1c03794f"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("0ba689af-d71a-4d8d-8332-8fd362c1e270"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("ebfa17c8-6e56-4c5c-88a3-1aff8fa5fd33"));
            RequestNo = (ITTTextBox)AddControl(new Guid("63b639b5-9de7-4e4e-87f0-2bf967aae011"));
            labelDescription = (ITTLabel)AddControl(new Guid("b18d5775-0609-4ca9-ae7b-ac4fcf10d19f"));
            Description = (ITTTextBox)AddControl(new Guid("ffa11dff-2192-415a-a827-a5b045760f8e"));
            Result = (ITTTextBox)AddControl(new Guid("2ac266d6-e2fc-409a-b870-fd143f57948e"));
            labelResult = (ITTLabel)AddControl(new Guid("d9a8cf57-7f59-49ab-9069-c28e40de7316"));
            SectionRequirements = (ITTGrid)AddControl(new Guid("e8f80613-151b-4d6d-ad07-3e89d0e057cd"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("2c64844b-62ac-4e29-a725-5a21eabe9965"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("dfa04d7a-d37e-41bb-a51f-924434fa5330"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2a1dd745-546b-4a3a-b947-b1a6f2acb044"));
            base.InitializeControls();
        }

        public PackagingDepartmentActionForm() : base("PACKAGINGDEPARTMENTACTION", "PackagingDepartmentActionForm")
        {
        }

        protected PackagingDepartmentActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}