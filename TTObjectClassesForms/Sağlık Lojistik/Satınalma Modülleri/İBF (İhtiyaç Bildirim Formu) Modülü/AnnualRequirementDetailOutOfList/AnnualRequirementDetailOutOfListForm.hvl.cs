
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
    /// Ekli Liste Detayları
    /// </summary>
    public partial class AnnualRequirementDetailOutOfListForm : TTForm
    {
        protected TTObjectClasses.AnnualRequirementDetailOutOfList _AnnualRequirementDetailOutOfList
        {
            get { return (TTObjectClasses.AnnualRequirementDetailOutOfList)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid DemandDetailsGrid;
        protected ITTListBoxColumn MasterResource;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn Amount;
        protected ITTButtonColumn ServiceDemands;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid StoreStocksGrid;
        protected ITTListBoxColumn Store2;
        protected ITTTextBoxColumn Amount2;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("464f839a-5a54-45da-9022-00c76ba4d5b4"));
            DemandDetailsGrid = (ITTGrid)AddControl(new Guid("52d94f0f-1376-432d-a1db-b89816c47082"));
            MasterResource = (ITTListBoxColumn)AddControl(new Guid("08d03266-6b0a-40a3-a2e6-26509bfd57ca"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("631f0be6-8f9d-49db-bddb-2d5908aa5894"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("5cd6a6e3-fcef-4797-be7c-5eff65f753e0"));
            ServiceDemands = (ITTButtonColumn)AddControl(new Guid("c2b68263-f728-4066-9922-0e7d6dd7df61"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("050a35af-3f18-4acf-8b61-7ef2affb5e22"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("ec639d3d-4b38-488b-8078-cb0ea73ba802"));
            StoreStocksGrid = (ITTGrid)AddControl(new Guid("e81759f4-fccf-410f-995d-70cd8200747a"));
            Store2 = (ITTListBoxColumn)AddControl(new Guid("79d18b25-2fb6-43ee-b35e-4ed6f15a25e0"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("6b427fa2-ada4-4cfd-b846-b1d3a12ecc29"));
            base.InitializeControls();
        }

        public AnnualRequirementDetailOutOfListForm() : base("ANNUALREQUIREMENTDETAILOUTOFLIST", "AnnualRequirementDetailOutOfListForm")
        {
        }

        protected AnnualRequirementDetailOutOfListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}