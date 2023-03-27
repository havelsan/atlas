
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
    /// Durum Takip
    /// </summary>
    public partial class ExternalSupplyTrackingForm : TTForm
    {
    /// <summary>
    /// Tedarik Takip Modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.SupplyTracking _SupplyTracking
        {
            get { return (TTObjectClasses.SupplyTracking)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ProjectsGrid;
        protected ITTTextBoxColumn clmProjectNo;
        protected ITTTextBoxColumn clmConfirmNo;
        protected ITTTextBoxColumn clmState;
        protected ITTTextBoxColumn clmGUID;
        protected ITTButtonColumn cmdCheck;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PurchaseItemsGrid;
        protected ITTListBoxColumn clm2PurchaseItem;
        protected ITTTextBoxColumn clm2Amount;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("cb99be39-305e-4ed3-97e4-684ece8f803d"));
            ProjectsGrid = (ITTGrid)AddControl(new Guid("7d4557aa-4ee3-4dbd-8e1b-5762812782a0"));
            clmProjectNo = (ITTTextBoxColumn)AddControl(new Guid("d8a0006c-5304-4f70-a7b0-1dc546ec486b"));
            clmConfirmNo = (ITTTextBoxColumn)AddControl(new Guid("89761d6a-8605-4650-810f-86cb430223da"));
            clmState = (ITTTextBoxColumn)AddControl(new Guid("d4f17b44-22e8-4778-aa7d-72fc7c3efe10"));
            clmGUID = (ITTTextBoxColumn)AddControl(new Guid("4e418889-5fcf-4b40-8d5b-64e1fd52c0b9"));
            cmdCheck = (ITTButtonColumn)AddControl(new Guid("39783ed8-65ee-4bfd-b5ed-315dede096f6"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("f780ffeb-5df0-49e9-afc5-760008936598"));
            PurchaseItemsGrid = (ITTGrid)AddControl(new Guid("42b04027-5379-4660-8088-17340ed4b5c8"));
            clm2PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("7e4a6c7b-34b7-4783-993c-41de3e7de8d1"));
            clm2Amount = (ITTTextBoxColumn)AddControl(new Guid("266647ff-e4bb-4d63-8f81-7c92d3ef1f75"));
            base.InitializeControls();
        }

        public ExternalSupplyTrackingForm() : base("SUPPLYTRACKING", "ExternalSupplyTrackingForm")
        {
        }

        protected ExternalSupplyTrackingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}