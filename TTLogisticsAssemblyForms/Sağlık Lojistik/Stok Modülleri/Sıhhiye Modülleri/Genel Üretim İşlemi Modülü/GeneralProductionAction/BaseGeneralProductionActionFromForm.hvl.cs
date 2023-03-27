
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
    /// Genel Üretim İşlemi
    /// </summary>
    public partial class BaseGeneralProductionActionFrom : StockActionBaseForm
    {
    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
        protected TTObjectClasses.GeneralProductionAction _GeneralProductionAction
        {
            get { return (TTObjectClasses.GeneralProductionAction)_ttObject; }
        }

        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox Description;
        protected ITTTextBox UnitPrice;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Amount;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTLabel labelUnitPrice;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTGrid GeneralProductionOutDets;
        protected ITTListBoxColumn MaterialDet;
        protected ITTTextBoxColumn AmountGeneralProductionOutDet;
        protected ITTListDefComboBoxColumn DistributionType;
        protected ITTTextBoxColumn Exiting;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelAmount;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("95a3759c-aad8-4a3a-a9ea-8fd86f4c9b87"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("eb31263e-b7d7-4eb0-b70d-c37f7abe2484"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9b611ea6-f5cf-4245-84a7-823164261ca9"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("8cd9afa6-e8e2-4d04-bbaf-34ffcd16768d"));
            Description = (ITTTextBox)AddControl(new Guid("f18f60af-2b5f-470b-97e3-062cb281da64"));
            UnitPrice = (ITTTextBox)AddControl(new Guid("018227fd-c825-40d0-b631-7c62690057e6"));
            StockActionID = (ITTTextBox)AddControl(new Guid("727e42f3-4936-4b8f-8aeb-0fc4ee4b29ef"));
            Amount = (ITTTextBox)AddControl(new Guid("c7c354cf-7e51-416b-9e1c-7e2ff7480555"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("fd6a21ca-b557-48e7-9974-0e20e00e36b1"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("683cfe57-1053-4717-a560-78905ae5aea3"));
            labelUnitPrice = (ITTLabel)AddControl(new Guid("5497d584-dc84-4ad3-b590-a05296cbb27f"));
            labelStore = (ITTLabel)AddControl(new Guid("97a295a1-245b-494d-92f3-035d58fd0be2"));
            Store = (ITTObjectListBox)AddControl(new Guid("d7e8a125-c1c8-42f2-aabc-3625e41052f4"));
            labelMaterial = (ITTLabel)AddControl(new Guid("6e9e6c30-c48f-4bd6-8191-bbbfb1a587e4"));
            Material = (ITTObjectListBox)AddControl(new Guid("9fea0d40-b21f-4ef9-8ca2-5ddcfded7687"));
            GeneralProductionOutDets = (ITTGrid)AddControl(new Guid("2e153374-824b-488e-8f51-435f34cbe041"));
            MaterialDet = (ITTListBoxColumn)AddControl(new Guid("74ede182-0472-41c4-b8a4-0edbfffa1c58"));
            AmountGeneralProductionOutDet = (ITTTextBoxColumn)AddControl(new Guid("8261ddaa-b1f6-4034-9ac6-2a5241416521"));
            DistributionType = (ITTListDefComboBoxColumn)AddControl(new Guid("7578be1a-a886-43b0-a909-bfd8c645af46"));
            Exiting = (ITTTextBoxColumn)AddControl(new Guid("42326110-47fc-49a8-adc3-633e942d6d05"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("e0d7971b-1cbf-4a63-9d8e-acaa08ba61fa"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("11acebd4-6edf-4e1e-8782-9088739561a2"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("04aeac66-59cc-4232-819b-14104f4858dd"));
            labelAmount = (ITTLabel)AddControl(new Guid("fb59da7d-e8ee-48a3-91b0-88e30401e5bb"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("ed55f60c-faf9-417d-97b3-66b10a53d782"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("8405630f-9125-4669-a0d3-23509f06d797"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("56a87dfb-1b25-4e32-a93f-9dc39bfc4628"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("78426dda-a495-4150-98b3-354b5747f3e2"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("668a8151-e376-410d-add6-e8b0a59ef6f0"));
            base.InitializeControls();
        }

        public BaseGeneralProductionActionFrom() : base("GENERALPRODUCTIONACTION", "BaseGeneralProductionActionFrom")
        {
        }

        protected BaseGeneralProductionActionFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}