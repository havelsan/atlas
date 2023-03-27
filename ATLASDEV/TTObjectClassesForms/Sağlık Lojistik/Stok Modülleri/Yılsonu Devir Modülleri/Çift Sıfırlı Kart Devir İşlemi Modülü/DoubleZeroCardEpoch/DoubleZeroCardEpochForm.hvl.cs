
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
    /// Çift Sıfırlı Kart Devir 
    /// </summary>
    public partial class DoubleZeroCardEpochForm : TTForm
    {
    /// <summary>
    /// Çift Sıfırlı Kartlar Devir Belgesi
    /// </summary>
        protected TTObjectClasses.DoubleZeroCardEpoch _DoubleZeroCardEpoch
        {
            get { return (TTObjectClasses.DoubleZeroCardEpoch)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        protected ITTObjectListBox SelectedStockCard;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid DoubleZeroCardEpochMaterials;
        protected ITTTextBoxColumn NatoStockNo;
        protected ITTListBoxColumn DZStockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn OrderNo;
        protected ITTTextBoxColumn CardCount;
        protected ITTListBoxColumn DoubleZeroStock;
        protected ITTCheckBoxColumn AddedManually;
        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTTextBox TotalCardCount;
        protected ITTLabel labelTerm;
        protected ITTObjectListBox Term;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTotalCardCount;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCardDrawer;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("30a150ce-0c8e-43bb-ab2e-29251fde537f"));
            ttbutton2 = (ITTButton)AddControl(new Guid("b140b561-3fd1-46a9-b8f4-ec4f151a6f51"));
            ttbutton1 = (ITTButton)AddControl(new Guid("98f8207a-57d3-49d1-a213-38a6dbdd5ddd"));
            SelectedStockCard = (ITTObjectListBox)AddControl(new Guid("15425913-a693-421a-85e4-8e3657126dda"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("98ae92ee-63cf-4331-b539-2384769fb4e5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("0d40227e-d782-483e-948c-b73738091c85"));
            DoubleZeroCardEpochMaterials = (ITTGrid)AddControl(new Guid("786cfe1b-c4fc-476f-b13b-83720e5e1dde"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("c7e66068-6046-4434-b730-2f273a4a1cfe"));
            DZStockCard = (ITTListBoxColumn)AddControl(new Guid("ab858a56-f51f-4bbd-8c52-4983dc60e2e7"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("30567fb4-9451-42e5-ab9f-1a28939d0e84"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("94ec7d5c-23c9-4ce2-a2ed-3292be3a9a2e"));
            CardCount = (ITTTextBoxColumn)AddControl(new Guid("dc76854b-aef8-48b8-95a1-d50114e5ac57"));
            DoubleZeroStock = (ITTListBoxColumn)AddControl(new Guid("b9a5f2c3-f333-49eb-9fe2-20b462edda1e"));
            AddedManually = (ITTCheckBoxColumn)AddControl(new Guid("aeeb77e9-a051-4d00-975e-56f183ac37a9"));
            Description = (ITTTextBox)AddControl(new Guid("8d2771f1-892c-48c9-b8f7-8469983b4f8b"));
            ID = (ITTTextBox)AddControl(new Guid("07384bbb-5006-427f-adb8-5567a232f177"));
            TotalCardCount = (ITTTextBox)AddControl(new Guid("42b259da-956f-43ca-947d-8bcd08feccd8"));
            labelTerm = (ITTLabel)AddControl(new Guid("3efac382-347d-4125-87d8-4f2d68474420"));
            Term = (ITTObjectListBox)AddControl(new Guid("63617653-1d08-4fce-a3ea-07c64910cf02"));
            labelStore = (ITTLabel)AddControl(new Guid("6791a0e1-b28a-4c0d-aaf8-27f88136e4cf"));
            Store = (ITTObjectListBox)AddControl(new Guid("bcde3381-9a75-4315-bd09-739d04c03416"));
            labelID = (ITTLabel)AddControl(new Guid("f9a77f26-7f08-4e33-bf40-f4c4c495b027"));
            labelActionDate = (ITTLabel)AddControl(new Guid("203d880a-b0c4-455c-9ffa-90133d4faae9"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("55dde8da-3bfa-45f0-ac5c-55156a2fabee"));
            labelTotalCardCount = (ITTLabel)AddControl(new Guid("dacf6e9e-50bb-4dfc-8797-d1f818d37afd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("410d0d87-dfef-48fc-9a52-31cbf0141bec"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("75d29d68-4a56-4fb6-abee-4631b42e4a78"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("aa5683ab-ab0e-48c5-a5d4-be62f5984fc8"));
            base.InitializeControls();
        }

        public DoubleZeroCardEpochForm() : base("DOUBLEZEROCARDEPOCH", "DoubleZeroCardEpochForm")
        {
        }

        protected DoubleZeroCardEpochForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}