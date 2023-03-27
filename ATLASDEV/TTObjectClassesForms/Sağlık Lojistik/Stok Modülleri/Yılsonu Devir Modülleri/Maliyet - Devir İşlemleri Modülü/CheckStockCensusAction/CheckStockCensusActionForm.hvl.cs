
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
    /// Yılsonu / Çift Sıfırlı Kart Devir İşlemi
    /// </summary>
    public partial class CheckStockCensusActionForm : TTForm
    {
    /// <summary>
    /// Yılsonu / Çift Sıfırlı Kart Devir İşlemi
    /// </summary>
        protected TTObjectClasses.CheckStockCensusAction _CheckStockCensusAction
        {
            get { return (TTObjectClasses.CheckStockCensusAction)_ttObject; }
        }

        protected ITTTextBox errorDoubleCarddrawer;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockCensusCardDrawers;
        protected ITTListBoxColumn CardDrawerStockCensusCardDrawer;
        protected ITTCheckBoxColumn IsDoubleZeroCompletedStockCensusCardDrawer;
        protected ITTCheckBoxColumn IsStockCensusCompletedStockCensusCardDrawer;
        protected ITTListBoxColumn ResUserStockCensusCardDrawer;
        protected ITTTextBoxColumn DoubleZeroObjectIDStockCensusCardDrawer;
        protected ITTTextBoxColumn StockCensusObjectIDStockCensusCardDrawer;
        protected ITTButton cmdUpdateCreationDate;
        protected ITTButton cmdDoubleZeroCensus;
        protected ITTButton cmdStockCensus;
        protected ITTTabPage tttabpage2;
        protected ITTGrid CensusSignUserDetails;
        protected ITTEnumComboBoxColumn InspectionUserTypeCensusSignUser;
        protected ITTListBoxColumn CensusSignUsersCensusSignUser;
        protected ITTTextBoxColumn NameStringCensusSignUser;
        protected ITTTextBoxColumn ShortMilitaryClassCensusSignUser;
        protected ITTTextBoxColumn ShortRankCensusSignUser;
        protected ITTTextBoxColumn EmploymentRecordIDCensusSignUser;
        protected ITTTextBox errorCreationDateTxt;
        protected ITTTextBox errorStockCardTxt;
        protected ITTTextBox errorDrawersTxt;
        protected ITTTextBox ID;
        protected ITTLabel labelAccountingTerm;
        protected ITTObjectListBox AccountingTerm;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdCheckErrors;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            errorDoubleCarddrawer = (ITTTextBox)AddControl(new Guid("39493515-a1c3-40c2-b6ba-39ac17d24bdd"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5ba34a2a-94c4-41e2-b316-bcf1a8482274"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("cc5a25b5-eac1-40de-9d88-6138e89f0724"));
            StockCensusCardDrawers = (ITTGrid)AddControl(new Guid("3e8ba7f5-7ae1-459e-b267-bc7bbf0b8d0f"));
            CardDrawerStockCensusCardDrawer = (ITTListBoxColumn)AddControl(new Guid("e6e16732-f8bf-4557-ae35-07d44583811f"));
            IsDoubleZeroCompletedStockCensusCardDrawer = (ITTCheckBoxColumn)AddControl(new Guid("9307abe5-99ec-48d8-9066-ae36f22825ec"));
            IsStockCensusCompletedStockCensusCardDrawer = (ITTCheckBoxColumn)AddControl(new Guid("eb7f8114-f877-406f-8465-3d1b1bcab44d"));
            ResUserStockCensusCardDrawer = (ITTListBoxColumn)AddControl(new Guid("bcc80442-ce0e-4d97-be91-1f3c592cc4b2"));
            DoubleZeroObjectIDStockCensusCardDrawer = (ITTTextBoxColumn)AddControl(new Guid("b9241296-3777-4bad-afde-510b87611e2a"));
            StockCensusObjectIDStockCensusCardDrawer = (ITTTextBoxColumn)AddControl(new Guid("7217e868-608e-4ed3-9b98-f9e541015a88"));
            cmdUpdateCreationDate = (ITTButton)AddControl(new Guid("182fd0e5-a14f-4271-9a65-f5dddbb0f214"));
            cmdDoubleZeroCensus = (ITTButton)AddControl(new Guid("6438eff1-2765-41bd-a376-f212bf65ae04"));
            cmdStockCensus = (ITTButton)AddControl(new Guid("42705e11-c69e-4082-834a-f4fe4f64f28b"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("d1ceeacc-dd8f-40c8-9cce-3e54cdb4c4c3"));
            CensusSignUserDetails = (ITTGrid)AddControl(new Guid("f8520d1c-24be-4ba6-b0b5-72b0dffc389b"));
            InspectionUserTypeCensusSignUser = (ITTEnumComboBoxColumn)AddControl(new Guid("53f2300d-83de-48d3-a115-89f589e1cb08"));
            CensusSignUsersCensusSignUser = (ITTListBoxColumn)AddControl(new Guid("c0e0af06-0f93-48ff-8516-36ac28aedc5d"));
            NameStringCensusSignUser = (ITTTextBoxColumn)AddControl(new Guid("473b64ff-80ff-467a-8f31-e6fb55dcd359"));
            ShortMilitaryClassCensusSignUser = (ITTTextBoxColumn)AddControl(new Guid("849baa43-6a4b-4931-9abf-5c090e907627"));
            ShortRankCensusSignUser = (ITTTextBoxColumn)AddControl(new Guid("53d3eaed-ebfe-4f4d-94f7-052c0dc20e0b"));
            EmploymentRecordIDCensusSignUser = (ITTTextBoxColumn)AddControl(new Guid("deb497b0-6df4-4948-866f-d11b723009a5"));
            errorCreationDateTxt = (ITTTextBox)AddControl(new Guid("ba831ac5-fcb6-43df-8112-022450e320f1"));
            errorStockCardTxt = (ITTTextBox)AddControl(new Guid("e7c86b32-9e3c-42fc-b452-feef3e60d945"));
            errorDrawersTxt = (ITTTextBox)AddControl(new Guid("c4a7acf3-725b-4f7e-b7c6-e7d489232869"));
            ID = (ITTTextBox)AddControl(new Guid("65304e81-5fe5-4cea-a219-c3e1950c49dd"));
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("894d0968-be3d-4ced-946b-bd9493707b5e"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("0ddeff4f-fcf8-441d-8405-3c23693a9e78"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e7ee7730-47e3-4b9d-a76a-86df9518417b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d17c1fa0-df8f-48b2-9b80-228c578b21f7"));
            cmdCheckErrors = (ITTButton)AddControl(new Guid("ceed496f-6db2-45db-9acf-c5d2c3bbdd6e"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("2937f5af-525a-4155-ac53-480a03a358f2"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("386499b6-3137-4455-9b1c-fd817ab1d474"));
            labelID = (ITTLabel)AddControl(new Guid("4c12382f-cb49-4f58-836c-9024cc91d192"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e0da15d6-076b-4b9e-8481-d7772b49891e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e8e771bd-5f00-4055-be4f-9b9b60e22cb0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4b52d14d-1533-4874-8069-0b5dccdb708c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9c928304-cc06-4dd2-b5c5-84bcb31d5e0a"));
            base.InitializeControls();
        }

        public CheckStockCensusActionForm() : base("CHECKSTOCKCENSUSACTION", "CheckStockCensusActionForm")
        {
        }

        protected CheckStockCensusActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}