
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
    /// Depolama Kısım Tanımı
    /// </summary>
    public partial class StorageSectionDefinitionForm : TTForm
    {
        protected TTObjectClasses.ResStorageSection _ResStorageSection
        {
            get { return (TTObjectClasses.ResStorageSection)_ttObject; }
        }

        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTObjectListBox Store;
        protected ITTLabel labelStore;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            Accountancy = (ITTObjectListBox)AddControl(new Guid("9c07727b-0291-46d9-8714-887719dc2745"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("24b512de-1eaa-4906-af74-52717f0f7937"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("77e36c5d-733a-4911-b0ef-3df82421aa9c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("afed47b5-e2e0-4fe1-a980-23f46ef3d1be"));
            Location = (ITTTextBox)AddControl(new Guid("1a557ad1-c771-46f6-9710-6cf7229a8974"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("09e2abb6-5f5a-4bda-a6ed-23233d4563f1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b0695443-7db3-40b5-a213-c14752b872d9"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("ce7c1e8d-9226-40fe-b97b-4e19fb9b5df0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("00ac77ed-7c67-4935-a4cd-b1af64f17767"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("3d3ef4cb-cbf8-47ac-aa31-af584a5c3d20"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("5ddd8118-b405-4a0c-8b4f-a7b718199c7d"));
            Store = (ITTObjectListBox)AddControl(new Guid("3548f891-f0a2-41a6-8ffa-414711ead2eb"));
            labelStore = (ITTLabel)AddControl(new Guid("a884ad7e-8b16-4a8f-a22c-3a89f166e841"));
            labelLocation = (ITTLabel)AddControl(new Guid("ce0da818-ac07-4d65-80be-5bdb4154fb96"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("593898e2-1a18-4543-8c66-91212f40179b"));
            base.InitializeControls();
        }

        public StorageSectionDefinitionForm() : base("RESSTORAGESECTION", "StorageSectionDefinitionForm")
        {
        }

        protected StorageSectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}