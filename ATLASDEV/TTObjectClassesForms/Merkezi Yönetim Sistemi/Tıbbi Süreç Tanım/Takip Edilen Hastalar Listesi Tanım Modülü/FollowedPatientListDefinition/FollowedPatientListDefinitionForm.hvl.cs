
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
    /// Takip Edilen Hasta Listesi Tanımlama
    /// </summary>
    public partial class FollowedPatientListDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Takip Edilen Hastalar Listesi Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.FollowedPatientListDefinition _FollowedPatientListDefinition
        {
            get { return (TTObjectClasses.FollowedPatientListDefinition)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelUniqueRefNo;
        protected ITTLabel labelDescription;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("62e0bb5a-cc6f-4552-b85d-a1eb6f02bfad"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f3ce6b22-a7a1-44e7-8e30-df3ff87db469"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("a6d76319-efef-4719-b89d-94b3a0d6ac31"));
            labelDescription = (ITTLabel)AddControl(new Guid("46f61db4-d84a-47ac-bcb1-98754ffdd445"));
            IsActive = (ITTCheckBox)AddControl(new Guid("9c1091a1-de36-42f7-92fe-f4cc6d077cba"));
            base.InitializeControls();
        }

        public FollowedPatientListDefinitionForm() : base("FOLLOWEDPATIENTLISTDEFINITION", "FollowedPatientListDefinitionForm")
        {
        }

        protected FollowedPatientListDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}