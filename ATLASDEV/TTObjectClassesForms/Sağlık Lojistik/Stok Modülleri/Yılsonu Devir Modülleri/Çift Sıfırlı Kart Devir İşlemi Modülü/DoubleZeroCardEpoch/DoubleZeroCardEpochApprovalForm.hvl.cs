
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
    public partial class DoubleZeroCardEpochApprovalForm : TTForm
    {
    /// <summary>
    /// Çift Sıfırlı Kartlar Devir Belgesi
    /// </summary>
        protected TTObjectClasses.DoubleZeroCardEpoch _DoubleZeroCardEpoch
        {
            get { return (TTObjectClasses.DoubleZeroCardEpoch)_ttObject; }
        }

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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ec38a2aa-e514-42dc-ab2d-a968b83dfa7d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("be03cd71-247b-47ef-a5ab-af80a85c9d16"));
            DoubleZeroCardEpochMaterials = (ITTGrid)AddControl(new Guid("4f8c4f0e-0f06-47d7-9ba1-1098456138d5"));
            NatoStockNo = (ITTTextBoxColumn)AddControl(new Guid("7a843332-a8d0-43d4-8742-92cddb106dde"));
            DZStockCard = (ITTListBoxColumn)AddControl(new Guid("86fb4d86-ed91-4a76-9818-e15508bc4eb3"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("d47e4d79-e1ef-4550-91d1-c9611e945e33"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("1dfe7341-0e02-46c7-a395-27c0722d1d0c"));
            CardCount = (ITTTextBoxColumn)AddControl(new Guid("dbce6140-391f-475e-8185-b6a919a52154"));
            DoubleZeroStock = (ITTListBoxColumn)AddControl(new Guid("3eb51d55-e6fa-41ac-83cf-d0f469a4bdd5"));
            AddedManually = (ITTCheckBoxColumn)AddControl(new Guid("53e47eb4-d02f-47ee-bd00-349249fd3090"));
            Description = (ITTTextBox)AddControl(new Guid("2aa9fb7d-3054-4cbc-bc54-a8364885d9dc"));
            ID = (ITTTextBox)AddControl(new Guid("a288ae9c-583e-4bef-ad50-fc6c76c22e4d"));
            TotalCardCount = (ITTTextBox)AddControl(new Guid("a3163855-0956-4d4b-b1c9-144d1e68a714"));
            labelTerm = (ITTLabel)AddControl(new Guid("4aaf824a-6d1e-4f72-92c9-63233a154c7f"));
            Term = (ITTObjectListBox)AddControl(new Guid("0846939f-40d6-4a57-abf0-b202762ad0df"));
            labelStore = (ITTLabel)AddControl(new Guid("4a0914fc-fcc5-4def-b7f7-39098caa7067"));
            Store = (ITTObjectListBox)AddControl(new Guid("1cb819ac-7b8f-4201-8846-4cc3665d141f"));
            labelID = (ITTLabel)AddControl(new Guid("4f39d789-d3e0-4d76-ae7c-9d37948dc7ad"));
            labelActionDate = (ITTLabel)AddControl(new Guid("92fc5c01-af8a-4619-93cf-ff36a7627a60"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4d7381d3-a6f4-4f8a-a7a8-c0c1f6915625"));
            labelTotalCardCount = (ITTLabel)AddControl(new Guid("04a81bd6-5818-4604-a193-fcf4296a0098"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5b44733f-5f05-40dd-9964-cbe09bca7fa4"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("9e109d2d-5f58-4ab5-b9df-628a63a20e77"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("d6df556a-7abd-4056-817e-83741883b0e8"));
            base.InitializeControls();
        }

        public DoubleZeroCardEpochApprovalForm() : base("DOUBLEZEROCARDEPOCH", "DoubleZeroCardEpochApprovalForm")
        {
        }

        protected DoubleZeroCardEpochApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}