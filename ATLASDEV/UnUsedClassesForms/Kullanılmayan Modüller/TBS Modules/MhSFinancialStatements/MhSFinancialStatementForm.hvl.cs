
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
    /// Mali Tablo
    /// </summary>
    public partial class MhSFinancialStatementForm : TTForm
    {
    /// <summary>
    /// Mali Tablolar
    /// </summary>
        protected TTObjectClasses.MhSFinancialStatements _MhSFinancialStatements
        {
            get { return (TTObjectClasses.MhSFinancialStatements)_ttObject; }
        }

        protected ITTTextBox Header;
        protected ITTLabel ttlabel3;
        protected ITTTabControl tttabcontrol1;
        protected ITTGrid Lines;
        protected ITTTabPage tttabpage2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox4;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel ttlabel6;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel7;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelHeader;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            Header = (ITTTextBox)AddControl(new Guid("ff96b434-52f6-4ff7-b2a7-0701aaa21894"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("60c04479-e88a-47bd-b7e0-b7578557f325"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3a1bc1e9-997d-4614-8910-c8561fb27f4f"));
            Lines = (ITTGrid)AddControl(new Guid("8dc1b3b4-9558-4847-9f4b-adaa023f91ce"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("cb2fc96a-3403-4be6-a1d4-7aa238635f41"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eb70fdc9-1c3e-430e-99b8-7af67b9a0c9d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("c96332bc-ef33-4bbc-bdb5-a9a1cf959d7b"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("92977f64-2c63-4e0d-ac43-991924fe8b9d"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("f3e4b405-4e2d-4e72-a0e6-65a762996d3a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e95e4cb4-1340-4cfb-bc41-5c8257e5ccc6"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e2d4a02f-74b3-48c4-b9ea-748bb9b234a8"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("56962ad0-fa4e-40f9-8331-59467fda205b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("89d3e4f8-1cb7-4538-b110-22c88782b698"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4a15cc6c-08d3-4c34-a664-34f44bbc8775"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5d76d4d5-186d-4939-a1b5-404cadf4a742"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8ce0b15e-1d83-496e-a8a1-4973a6d71206"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b1ad5ec4-88a2-4ef5-9e8f-3b8c2ed861db"));
            labelHeader = (ITTLabel)AddControl(new Guid("477f9868-4dd3-45c7-a23b-15260bb79475"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d2b55427-abc9-4271-a5ba-d37416578fe6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("927aae46-62a3-4331-b6d8-d30775682c6f"));
            base.InitializeControls();
        }

        public MhSFinancialStatementForm() : base("MHSFINANCIALSTATEMENTS", "MhSFinancialStatementForm")
        {
        }

        protected MhSFinancialStatementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}