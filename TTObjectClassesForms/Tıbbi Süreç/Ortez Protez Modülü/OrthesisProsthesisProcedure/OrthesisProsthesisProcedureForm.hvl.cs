
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
    public partial class OrthesisProsthesisProcedureForm : TTForm
    {
        protected TTObjectClasses.OrthesisProsthesisProcedure _OrthesisProsthesisProcedure
        {
            get { return (TTObjectClasses.OrthesisProsthesisProcedure)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MedulaBilgileri;
        protected ITTObjectListBox TTListBoxOrthesisAyniFarkliKesi;
        protected ITTObjectListBox ttobjectlistboxOrthesisOzelDurum;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        protected ITTLabel labelOzelDurum;
        protected ITTTextBox DrAnesteziTescilNo;
        protected ITTLabel labelAyniFarkliKesi;
        protected ITTLabel RaporTakipNoLabel;
        protected ITTTextBox tttextbox2;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1017ed9f-c047-4a38-80cd-82179e654903"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("a66a4891-6521-432f-b674-be673bf8787a"));
            TTListBoxOrthesisAyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("00f8da95-1a18-41bf-af70-a38acc0c2cfd"));
            ttobjectlistboxOrthesisOzelDurum = (ITTObjectListBox)AddControl(new Guid("17fb9153-9ced-47f2-89df-f8c3c8900499"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("0b82a771-18b5-4830-b333-cc3ddfcd8584"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("79cf1688-0da8-432c-b5dc-847ea130be8e"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("9cb3efe3-7ef9-4886-ba09-b8846b0db1ef"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("17f4c7c1-5949-4230-81c7-2f13a390b66e"));
            DrAnesteziTescilNo = (ITTTextBox)AddControl(new Guid("184d41e0-5c0a-46df-a84f-2b22a33debf6"));
            labelAyniFarkliKesi = (ITTLabel)AddControl(new Guid("ce55735e-af50-4bf0-a23e-27817ad092b1"));
            RaporTakipNoLabel = (ITTLabel)AddControl(new Guid("cd113c21-ed35-46f7-b819-a8cd7df7c4c0"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("3d4ae0c5-79d9-4c22-8b78-92c7c9e972a5"));
            base.InitializeControls();
        }

        public OrthesisProsthesisProcedureForm() : base("ORTHESISPROSTHESISPROCEDURE", "OrthesisProsthesisProcedureForm")
        {
        }

        protected OrthesisProsthesisProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}