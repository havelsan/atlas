
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
    public partial class PriceFormulationForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PriceFormulationCommision;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTEnumComboBoxColumn Title;
        protected ITTTextBoxColumn ClassRank;
        protected ITTListBoxColumn NameSurname;
        protected ITTEnumComboBoxColumn CommisionDuty;
        protected ITTCheckBoxColumn PrimeBackup;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid PurchaseProjectDetailItems;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTCheckBoxColumn AppPriceCalculated;
        protected ITTTextBoxColumn PriceFormulationDesc;
        override protected void InitializeControls()
        {
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("7934ce7c-52d7-40d0-92ea-adfaf9d227d2"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8366fc86-c8c3-4aa7-bab5-37730fc4b325"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d76b2341-e7b7-4cff-9140-514ddba77cfe"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("9046f785-301e-4243-9576-3212cfaa685e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9988e1e3-ba45-42ab-b398-a52c6d6d8699"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3bf38e04-f921-4a12-9d2e-f81feaa4290b"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("a62b86dc-60f6-42bb-b33b-d57c52b9906b"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("bfc7fd8a-477e-4770-bfd8-5df69a4f9c2e"));
            PriceFormulationCommision = (ITTGrid)AddControl(new Guid("22bcefba-607f-4e86-9028-d657169c8788"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("b719c58d-b8b0-43d0-b663-9cdadc62ab57"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("17726057-bafb-4e12-a83b-58f3beb697f3"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("4277d6bd-331f-4512-b2b3-56e9d8bf7ff8"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("60c89310-3ff8-4563-9c0b-54e93c959b0e"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("a40393e3-f08a-4453-ba14-6a3b8ec23b9b"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("080fd455-ae15-401b-9556-d3818fa1496d"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1976d91c-7eab-485f-a7b7-6bc3e31a922a"));
            PurchaseProjectDetailItems = (ITTGrid)AddControl(new Guid("9fd4791c-da18-4cfa-8589-208d5c48b1a1"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("eb047aa4-815a-49e4-8680-88eceb4b3fdc"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("f2ec775d-9c6e-47af-bd16-4ae70616bd19"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("ce4032ab-dbc0-4086-9008-bc65b4a850a3"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("f60c6524-0890-4550-92c0-3281ffbb2ba2"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("ecda2835-d0b9-4573-bac5-bcafa1e44099"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("97dd62ca-1d09-4e81-a870-3a5fd59340be"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("1c83405a-9dcf-4a7a-abed-b9f78f7fe271"));
            AppPriceCalculated = (ITTCheckBoxColumn)AddControl(new Guid("7c190237-3689-4b64-8741-82fd7f0003fc"));
            PriceFormulationDesc = (ITTTextBoxColumn)AddControl(new Guid("6b60578b-8396-4ecd-be41-62cba476690b"));
            base.InitializeControls();
        }

        public PriceFormulationForm() : base("PURCHASEPROJECT", "PriceFormulationForm")
        {
        }

        protected PriceFormulationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}