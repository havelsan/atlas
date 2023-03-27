
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
    /// Masa Tanımı
    /// </summary>
    public partial class CardDrawerDefinitionForm : TTForm
    {
        protected TTObjectClasses.ResCardDrawer _ResCardDrawer
        {
            get { return (TTObjectClasses.ResCardDrawer)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTObjectListBox StockControlSection;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTObjectListBox Store;
        protected ITTLabel labelStore;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("7cc35fe5-94cc-4798-a6dc-a6dccc23673c"));
            Location = (ITTTextBox)AddControl(new Guid("e8f369d1-339e-4502-b593-05810941ed31"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("6b1c5c45-436a-47cd-b1c9-dc754f3c7d7f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("aa5185d3-60a0-4b4d-96b2-aa82f3c24b6d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5b147e27-6090-4dd2-9bee-b4bc4789ff49"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("87e0916f-c871-4d5b-b992-586b1b9050d6"));
            StockControlSection = (ITTObjectListBox)AddControl(new Guid("6a2350af-72c6-423f-a127-d5dc60afce03"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("10d4b050-956c-44d3-8853-2992d03bc8d4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9cd83a1e-0f4b-49f3-9a1e-0243f49df038"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("a5e3f16a-ec4d-465f-84bf-434be487fb8a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("abb2cdcf-6e45-4f7f-8824-b7203c0c2968"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("55b93f57-76c3-4158-be3d-7cb8d4369765"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("301289f9-d103-45cc-90a6-735fd3538627"));
            Store = (ITTObjectListBox)AddControl(new Guid("b42eca4b-62b2-46d5-a3f7-705343ea5a43"));
            labelStore = (ITTLabel)AddControl(new Guid("25a6c820-17c3-4a54-a91d-94a1927218ac"));
            base.InitializeControls();
        }

        public CardDrawerDefinitionForm() : base("RESCARDDRAWER", "CardDrawerDefinitionForm")
        {
        }

        protected CardDrawerDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}