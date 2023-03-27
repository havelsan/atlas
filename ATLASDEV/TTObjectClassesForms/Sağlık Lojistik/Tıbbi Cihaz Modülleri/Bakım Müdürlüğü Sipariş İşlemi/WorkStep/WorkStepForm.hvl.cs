
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
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public partial class WorkStepForm : TTForm
    {
    /// <summary>
    /// Yardımcı Atölye İş İstek
    /// </summary>
        protected TTObjectClasses.WorkStep _WorkStep
        {
            get { return (TTObjectClasses.WorkStep)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTCheckBox chkOrderCompleted;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid WorkStepConsumedMaterials;
        protected ITTListBoxColumn RequestMaterial;
        protected ITTListBoxColumn RequestDistType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistType;
        protected ITTTextBoxColumn ReqAmount;
        protected ITTTextBoxColumn SuppAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn Store;
        protected ITTLabel labelWorkload;
        protected ITTTextBox Workload;
        protected ITTLabel labelComment;
        protected ITTTextBox Comment;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ResponsibleUser;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection1;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelRequestNo;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("9bdfe6a2-8e6d-47c0-9296-022587a13631"));
            chkOrderCompleted = (ITTCheckBox)AddControl(new Guid("6af606c4-84bd-44e3-957d-afca4fba8d59"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("89290f9d-43f0-4580-b6ab-1fec823ccbe9"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("a4019d33-efa6-4386-b98f-a364c0b1d6ad"));
            WorkStepConsumedMaterials = (ITTGrid)AddControl(new Guid("cdb2778f-657a-4393-9be8-a55276e41d57"));
            RequestMaterial = (ITTListBoxColumn)AddControl(new Guid("266f3147-7080-4893-b424-afcc8efa6363"));
            RequestDistType = (ITTListBoxColumn)AddControl(new Guid("6ffb265c-017b-41f8-a889-38137184189e"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("ac6bb219-71a4-413a-b53e-e87e78caf10f"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("377c6dc1-c2c9-4cf2-b152-5695e1f63ac0"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("af0384e4-74ed-4828-ad51-2ad169693554"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("4e5d1369-cee1-4844-9f5c-92c686c63ab3"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a83db3c7-ac89-44d0-b253-323f4bca9a21"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("d2361244-32f1-42e7-a6f4-4391a2c83caf"));
            ReqAmount = (ITTTextBoxColumn)AddControl(new Guid("07d1b4ef-a442-40bb-9273-cb4edf616f8a"));
            SuppAmount = (ITTTextBoxColumn)AddControl(new Guid("a699b9fa-1a50-44ef-b8b7-2a41fd54a7d5"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d45df898-c6ed-47c7-b969-48f35d00546f"));
            Store = (ITTListBoxColumn)AddControl(new Guid("50b684d3-8bd4-4185-9753-df8873dbbb57"));
            labelWorkload = (ITTLabel)AddControl(new Guid("4f8ba92f-ad04-4fdd-bc77-452abdde9663"));
            Workload = (ITTTextBox)AddControl(new Guid("836e75e1-0409-4e83-a365-917644f2ff61"));
            labelComment = (ITTLabel)AddControl(new Guid("683e3634-4b79-4dac-aa6c-5bac9217f9c3"));
            Comment = (ITTTextBox)AddControl(new Guid("80fcd4a7-0ad1-4810-95d6-1db5ff61da81"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("488ad8d3-1b2b-4b1d-bf25-debd314afadf"));
            ResponsibleUser = (ITTObjectListBox)AddControl(new Guid("b84f67de-bf97-461f-99d7-dc99e154915a"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("65f3517d-513e-48d4-a00b-2f2725dda536"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("f6d08857-9867-4b07-b37b-64002f980c7d"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("12dc375a-731b-4e71-ab2a-2c9a8a3b985f"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("19593c8a-99c2-41ac-823c-9b34acaf8e93"));
            labelSection = (ITTLabel)AddControl(new Guid("b4598367-c01b-4255-be31-42127c64f44c"));
            Section = (ITTObjectListBox)AddControl(new Guid("a6cd3b41-1706-4a08-b665-b7d1af9a3950"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("e0482741-c616-4b71-968f-6abad8a8f738"));
            SenderSection1 = (ITTObjectListBox)AddControl(new Guid("18f60ce7-0e26-4da4-9e79-ef5e8f8a5a24"));
            labelDescription = (ITTLabel)AddControl(new Guid("fbbe897e-df17-4df5-8c4b-afdf1dc87f22"));
            Description = (ITTTextBox)AddControl(new Guid("254219bc-1f23-4f53-8a9c-06c0c4a42a68"));
            RequestNo = (ITTTextBox)AddControl(new Guid("a137044e-d5d0-4ffd-a299-d89fd42a13a1"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("de625149-7218-4513-a26c-194dabac7724"));
            base.InitializeControls();
        }

        public WorkStepForm() : base("WORKSTEP", "WorkStepForm")
        {
        }

        protected WorkStepForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}