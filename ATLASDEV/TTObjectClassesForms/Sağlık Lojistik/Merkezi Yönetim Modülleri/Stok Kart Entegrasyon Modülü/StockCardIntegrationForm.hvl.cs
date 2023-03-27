
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
    public partial class StockCardIntegrationForm : TTUnboundForm
    {
        protected ITTComboBox stockCardClassCombobox;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox stockCardNameTextBox;
        protected ITTButton createButton;
        protected ITTButton requestButton;
        protected ITTListView stockCardsListView;
        protected ITTTextBox stockNoTextBox;
        protected ITTTextBox stockCardEnglishNameTextBox;
        protected ITTTextBox barcodNoTextBox;
        protected ITTButton findButton;
        protected ITTObjectListBox SelectedStore;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTButton EscButton;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            stockCardClassCombobox = (ITTComboBox)AddControl(new Guid("caccf3ba-9c2b-4d23-ba26-84e942e36426"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c3f5c6d6-799e-48a5-94c6-2078223675ad"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b8da2579-3738-4ccd-be1b-df34165181c3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("239388bd-0d32-4085-b4f9-7a94d503527d"));
            stockCardNameTextBox = (ITTTextBox)AddControl(new Guid("f303f973-4220-4aca-baca-e34e7a4af08d"));
            createButton = (ITTButton)AddControl(new Guid("6f869257-1553-46fd-811b-3dfe32912e08"));
            requestButton = (ITTButton)AddControl(new Guid("4592c39e-8bab-424e-9db7-db4528f42a59"));
            stockCardsListView = (ITTListView)AddControl(new Guid("226132db-a0f9-4bc4-bd06-67fea09cb5ae"));
            stockNoTextBox = (ITTTextBox)AddControl(new Guid("f65418df-fec2-4884-9590-30abfd83b729"));
            stockCardEnglishNameTextBox = (ITTTextBox)AddControl(new Guid("604eabb3-fdb9-42f7-8c64-407e71aedd79"));
            barcodNoTextBox = (ITTTextBox)AddControl(new Guid("0e0974b0-ee0f-4a9c-a819-82eb824c7695"));
            findButton = (ITTButton)AddControl(new Guid("65c1dda6-9e9b-4a57-8890-63469696bf48"));
            SelectedStore = (ITTObjectListBox)AddControl(new Guid("5c049fce-a1f2-4777-ba09-6c1984c1bcda"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d6c910cc-f354-4ab6-ad73-9771858140e9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("70d0209d-2deb-420b-8dbe-add5264cd683"));
            EscButton = (ITTButton)AddControl(new Guid("b180715d-9d2d-4be1-b3cd-f56757ddbec9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d37612ed-afac-4404-af2b-c34e9e15a200"));
            base.InitializeControls();
        }

        public StockCardIntegrationForm() : base("StockCardIntegrationForm")
        {
        }

        protected StockCardIntegrationForm(string formDefName) : base(formDefName)
        {
        }
    }
}