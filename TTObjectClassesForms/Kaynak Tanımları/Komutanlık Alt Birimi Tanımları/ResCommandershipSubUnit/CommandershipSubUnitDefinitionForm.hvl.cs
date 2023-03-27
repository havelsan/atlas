
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
    /// XXXXXXlık Alt Birim Tanımı
    /// </summary>
    public partial class CommandershipSubUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// XXXXXXlık Alt Birimi
    /// </summary>
        protected TTObjectClasses.ResCommandershipSubUnit _ResCommandershipSubUnit
        {
            get { return (TTObjectClasses.ResCommandershipSubUnit)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox ResCommanderShip;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("67590f89-e20b-490f-977d-1e2ed26cf407"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c9d1fe5f-f0b5-4d34-9862-54240102943f"));
            Location = (ITTTextBox)AddControl(new Guid("1fa2d8d4-face-4363-aa29-9e3e8358f3b7"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("946ff6ea-405b-4ad0-a4cd-7da3558a98a7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("95b9575b-16c5-4411-9641-071dfe26466d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d4ca1af8-72c9-4afb-9c7c-5e93a927d6a8"));
            labelStore = (ITTLabel)AddControl(new Guid("3be838bd-dba1-4275-b2b8-87bccf75fafd"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("dc30528b-ec5d-4272-bfef-9efd837ff5de"));
            Store = (ITTObjectListBox)AddControl(new Guid("e6358a21-31cd-4779-b573-d2044e8208d4"));
            ResCommanderShip = (ITTObjectListBox)AddControl(new Guid("1b9eb461-99e9-46ce-acd4-e9b5a488bf92"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("752865f7-226e-4c6c-be8e-adcab66467b3"));
            labelLocation = (ITTLabel)AddControl(new Guid("cc682eaf-5593-4191-bae1-5c85dea7d245"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("a776ca16-15f4-415a-a0bd-2b9d08151fbc"));
            base.InitializeControls();
        }

        public CommandershipSubUnitDefinitionForm() : base("RESCOMMANDERSHIPSUBUNIT", "CommandershipSubUnitDefinitionForm")
        {
        }

        protected CommandershipSubUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}