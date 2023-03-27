
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
    /// İBF Detayları
    /// </summary>
    public partial class AnnualRequirementDetailInListForm : TTForm
    {
        protected TTObjectClasses.AnnualRequirementDetailInList _AnnualRequirementDetailInList
        {
            get { return (TTObjectClasses.AnnualRequirementDetailInList)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid StoreStocksGrid;
        protected ITTListBoxColumn Store2;
        protected ITTTextBoxColumn Amount;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid DemandDetailsGrid;
        protected ITTListBoxColumn MasterResource;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTButtonColumn ServiceDemands;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("05ee9882-3ee7-467a-8904-79045f988bc9"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a22e1227-d711-4609-a378-90b6fa771fef"));
            StoreStocksGrid = (ITTGrid)AddControl(new Guid("17eebfb4-e656-4c0a-89bb-c15ed3b79ebf"));
            Store2 = (ITTListBoxColumn)AddControl(new Guid("6fc542b1-b97b-4fac-a970-5f2db77e6a32"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("792d269c-1026-48d0-afde-35e99ed752f6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c9e7208b-6e1c-4c1c-8626-9f834a0c1d67"));
            DemandDetailsGrid = (ITTGrid)AddControl(new Guid("8f4b4063-4c0d-45ca-b170-cb6276068f18"));
            MasterResource = (ITTListBoxColumn)AddControl(new Guid("19cca612-864c-4a7b-a359-21cfdad52528"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("7e045944-b287-40b2-8cad-557d9c0a3a36"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("0192ce11-a3e8-4289-9643-c83e3144ca28"));
            ServiceDemands = (ITTButtonColumn)AddControl(new Guid("93bd527f-f7af-4617-af9e-6cceb627d0b5"));
            base.InitializeControls();
        }

        public AnnualRequirementDetailInListForm() : base("ANNUALREQUIREMENTDETAILINLIST", "AnnualRequirementDetailInListForm")
        {
        }

        protected AnnualRequirementDetailInListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}