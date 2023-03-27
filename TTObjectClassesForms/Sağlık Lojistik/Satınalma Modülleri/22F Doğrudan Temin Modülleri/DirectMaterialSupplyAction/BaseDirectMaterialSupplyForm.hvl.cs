
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
    /// Doğrudan Malzeme Tedarik 22F
    /// </summary>
    public partial class BaseDirectMaterialSupplyForm : TTForm
    {
    /// <summary>
    /// Doğrudan Malzeme Tedarik 22f
    /// </summary>
        protected TTObjectClasses.DirectMaterialSupplyAction _DirectMaterialSupplyAction
        {
            get { return (TTObjectClasses.DirectMaterialSupplyAction)_ttObject; }
        }

        protected ITTLabel labelDateOfSurgery;
        protected ITTDateTimePicker DateOfSurgery;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTCheckBox IsImmediate;
        protected ITTLabel labelDateOfSupply;
        protected ITTDateTimePicker DateOfSupply;
        protected ITTLabel labelDescriptionForWorkList;
        protected ITTTextBox DescriptionForWorkList;
        protected ITTLabel labelPatientEpisode;
        protected ITTObjectListBox PatientEpisode;
        protected ITTLabel labelProcedureByUser;
        protected ITTObjectListBox ProcedureByUser;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid TreatmentMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn AmountBaseTreatmentMaterial;
        protected ITTTextBoxColumn Note;
        override protected void InitializeControls()
        {
            labelDateOfSurgery = (ITTLabel)AddControl(new Guid("15497db1-9e00-4e4f-a490-656167ce9be4"));
            DateOfSurgery = (ITTDateTimePicker)AddControl(new Guid("6132afb6-905f-45b7-9dd0-172f276c8f92"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("c7f0e5e3-ad37-4b2f-9e5e-8349ff53516a"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("1e6ffbb4-a6d8-45cc-ba84-36f0252f4283"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0a4f47bb-0433-48d9-b48e-4e3d0897186c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("086395fe-21e8-4ee8-820c-9db2d40e761d"));
            IsImmediate = (ITTCheckBox)AddControl(new Guid("6e02c7b5-0729-4ead-a024-68b1e5b05fed"));
            labelDateOfSupply = (ITTLabel)AddControl(new Guid("4143f34b-b140-4e74-98d8-9e03ea9fb438"));
            DateOfSupply = (ITTDateTimePicker)AddControl(new Guid("268a0d0c-0096-493d-a8c6-4d015b706e48"));
            labelDescriptionForWorkList = (ITTLabel)AddControl(new Guid("0b536174-6579-432d-a19e-b81aabe59714"));
            DescriptionForWorkList = (ITTTextBox)AddControl(new Guid("e38eb4d6-8fa1-4a06-a6ec-eaea896ad4d4"));
            labelPatientEpisode = (ITTLabel)AddControl(new Guid("f40f50de-8b63-4330-b15a-78b820400903"));
            PatientEpisode = (ITTObjectListBox)AddControl(new Guid("18ab0bae-f96f-4ccf-8d4f-370d34791d92"));
            labelProcedureByUser = (ITTLabel)AddControl(new Guid("226a7001-2fd3-480b-bb4e-fe56bf986ff0"));
            ProcedureByUser = (ITTObjectListBox)AddControl(new Guid("5b2a9645-0387-40b2-92c5-41c9d088885e"));
            labelStore = (ITTLabel)AddControl(new Guid("a5d2cecd-416e-424a-ba99-5205478652fd"));
            Store = (ITTObjectListBox)AddControl(new Guid("98e30a03-4686-480b-b283-eb9470bfcebd"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c82f4b61-c064-429e-9c3c-2dc868eb1745"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("0cad3d34-0a8e-4677-b7de-f3d85ff36f40"));
            Material = (ITTListBoxColumn)AddControl(new Guid("3c4c985b-b062-4799-b8b7-1fa47767c74c"));
            AmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("b2330bd5-5f0b-4ef3-b2ad-cf889766a076"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("6a4856a3-3f8f-46a1-bade-6cff74dea642"));
            base.InitializeControls();
        }

        public BaseDirectMaterialSupplyForm() : base("DIRECTMATERIALSUPPLYACTION", "BaseDirectMaterialSupplyForm")
        {
        }

        protected BaseDirectMaterialSupplyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}