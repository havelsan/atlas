
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
    /// XXXXXXlık Tanımı
    /// </summary>
    public partial class CommandershipDefinitionForm : TTForm
    {
    /// <summary>
    /// XXXXXXlık
    /// </summary>
        protected TTObjectClasses.ResCommandership _ResCommandership
        {
            get { return (TTObjectClasses.ResCommandership)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("0f81488b-18e9-4b2c-b46f-59a11fb4cdc0"));
            Location = (ITTTextBox)AddControl(new Guid("d11daba6-1751-4d80-bff5-1a7a0b6ddde4"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("da8ed926-8058-4801-9bf9-2a723cfcf853"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("59a754c2-a406-46e1-9b6c-679ec3b0c256"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3ce5dfdd-a207-40ff-ab53-f70401c57f44"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("6d3b63a5-0dbe-4584-bf97-30e70bef6a6a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("922d5a3e-0637-4c3f-b96c-49459858aae4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("30b08c94-ff1d-439c-830f-269945168d3f"));
            labelStore = (ITTLabel)AddControl(new Guid("0b840a04-fb8a-4f1c-ad3b-eeeec7a3d9c4"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("8c2758da-c907-479b-8eb4-d2a21f936d91"));
            Store = (ITTObjectListBox)AddControl(new Guid("39a55aca-28a7-4d1b-be8f-6d3911dffece"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("881201da-3ab5-44f8-a9c4-e7853e077f60"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c6d3c0f4-9fb3-4155-9ecd-2446f04b94d7"));
            base.InitializeControls();
        }

        public CommandershipDefinitionForm() : base("RESCOMMANDERSHIP", "CommandershipDefinitionForm")
        {
        }

        protected CommandershipDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}