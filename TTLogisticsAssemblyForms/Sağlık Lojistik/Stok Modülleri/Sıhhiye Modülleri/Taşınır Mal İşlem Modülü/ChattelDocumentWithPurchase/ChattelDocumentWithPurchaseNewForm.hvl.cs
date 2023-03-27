
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
    public partial class ChattelDocumentWithPurchaseNewForm : BaseChattelDocumentWithPurchaseForm
    {
    /// <summary>
    /// Satınalma Yoluyla
    /// </summary>
        protected TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase
        {
            get { return (TTObjectClasses.ChattelDocumentWithPurchase)_ttObject; }
        }

        protected ITTTabPage AvailableOrdersTab;
        protected ITTLabel ttlabel7;
        protected ITTGrid OrderedSuppliersGrid;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn OrderNo;
        protected ITTGrid OrderedDetails;
        protected ITTCheckBoxColumn datagridviewcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn datagridviewcolumn2;
        protected ITTLabel ttlabel8;
        protected ITTButton cmdTransfer;
        protected ITTButton firmdef_ttbutton;
        protected ITTCheckBox chkFreeEntry;
        override protected void InitializeControls()
        {
            AvailableOrdersTab = (ITTTabPage)AddControl(new Guid("b4bd9458-7bc4-4cbe-b2c6-eaca1249b402"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("20b0793c-813d-4a04-ac84-97093b958c80"));
            OrderedSuppliersGrid = (ITTGrid)AddControl(new Guid("49ef5106-a06f-4922-bd92-9645eb46658b"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("70561e61-16bb-44bf-93fc-aa2a2cb863a3"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("98dac3c5-e8b9-4f20-ac48-3572e6b3fcb7"));
            OrderedDetails = (ITTGrid)AddControl(new Guid("5b1db678-4529-4303-9db0-1aeaeef843a6"));
            datagridviewcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("787debc7-a1bb-46de-9741-01e87a6f22c8"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("b2ef42c8-d862-4bbe-975f-de50595183bc"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("5c6a9590-b196-449a-9504-0d7e93fbb5bf"));
            datagridviewcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("e3cd511d-e251-4ece-ab0e-dd3939f9388e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("20c56b50-e623-4970-9a2a-191a58c9facd"));
            cmdTransfer = (ITTButton)AddControl(new Guid("8f4c655d-e830-4ac6-ae36-667e9a9f6de8"));
            firmdef_ttbutton = (ITTButton)AddControl(new Guid("8a67eeb0-0e44-408a-92f3-3dd953b9d955"));
            chkFreeEntry = (ITTCheckBox)AddControl(new Guid("5af535a7-cab4-442e-9dce-df0f374dffc2"));
            base.InitializeControls();
        }

        public ChattelDocumentWithPurchaseNewForm() : base("CHATTELDOCUMENTWITHPURCHASE", "ChattelDocumentWithPurchaseNewForm")
        {
        }

        protected ChattelDocumentWithPurchaseNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}