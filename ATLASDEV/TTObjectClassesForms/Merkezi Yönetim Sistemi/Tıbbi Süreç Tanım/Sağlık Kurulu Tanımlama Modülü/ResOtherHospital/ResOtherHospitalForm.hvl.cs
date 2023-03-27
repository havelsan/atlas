
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
    /// DiğerXXXXXX XXXXXXleri
    /// </summary>
    public partial class ResOtherHospitalForm : TTDefinitionForm
    {
    /// <summary>
    /// Diğer XXXXXX
    /// </summary>
        protected TTObjectClasses.ResOtherHospital _ResOtherHospital
        {
            get { return (TTObjectClasses.ResOtherHospital)_ttObject; }
        }

        protected ITTLabel labelSite;
        protected ITTObjectListBox Site;
        protected ITTLabel labelQref;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelSite = (ITTLabel)AddControl(new Guid("7b5aab1a-fca1-41a4-9965-f261e455d46b"));
            Site = (ITTObjectListBox)AddControl(new Guid("692f390b-5874-4489-a0c9-92db7b21095b"));
            labelQref = (ITTLabel)AddControl(new Guid("3ef030d3-5aba-48b4-b6a8-be96f71041d4"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("da877fce-bb15-4c72-a066-7a7172f56abc"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0158b01a-58d9-47e8-9969-4df5b05c1a78"));
            Location = (ITTTextBox)AddControl(new Guid("c57dd2c2-59bf-45d5-a067-c70d083a18c7"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("f54cad7f-78cd-4395-9c3b-b9c0308401f9"));
            labelName = (ITTLabel)AddControl(new Guid("a0c8aa34-a57a-47d9-8fee-3e283b1808fd"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("d17799de-d429-4b1c-8bc2-d31cec2fada3"));
            labelLocation = (ITTLabel)AddControl(new Guid("6c8fba79-c0d1-40b6-be08-9efa1febe77a"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("bd6fdcbf-ce38-4c75-b37b-c8b88c9fc1af"));
            base.InitializeControls();
        }

        public ResOtherHospitalForm() : base("RESOTHERHOSPITAL", "ResOtherHospitalForm")
        {
        }

        protected ResOtherHospitalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}