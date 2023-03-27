
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
    /// Ameliyat Masası Tanımı
    /// </summary>
    public partial class SurgeryDeskDefinitionForm : TTForm
    {
    /// <summary>
    /// Ameliyat Masası
    /// </summary>
        protected TTObjectClasses.ResSurgeryDesk _ResSurgeryDesk
        {
            get { return (TTObjectClasses.ResSurgeryDesk)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("46b41448-1c4a-48ff-8476-3fcbc4d8eb3a"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("146d9eff-8523-45ca-b55d-f51e6fa8ca7f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3794d30a-fde7-4d2c-9dd7-d573c38a97cb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("31fbb066-5532-40fd-b5c6-f8150347f84e"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7c5fc19d-2e92-4b73-9c9b-545eccbe91c3"));
            Location = (ITTTextBox)AddControl(new Guid("a8180aac-65fe-4552-a017-80931c761569"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("e6c42377-b953-4ac1-9ff8-ae765cdf6c6e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f0877815-7ca8-4fe7-b9e7-b9945381797a"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("309b083f-2775-462b-8c5a-9e231489debc"));
            labelLocation = (ITTLabel)AddControl(new Guid("cb30e986-0e61-419d-b5b0-5efff511e1f1"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("6812c2d9-4afd-40d1-a95f-c4565bfcf071"));
            base.InitializeControls();
        }

        public SurgeryDeskDefinitionForm() : base("RESSURGERYDESK", "SurgeryDeskDefinitionForm")
        {
        }

        protected SurgeryDeskDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}