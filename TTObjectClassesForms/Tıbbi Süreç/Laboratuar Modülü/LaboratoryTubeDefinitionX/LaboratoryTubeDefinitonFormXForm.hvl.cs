
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
    /// Laboratuvar Örnek Tüp Tanım Formu
    /// </summary>
    public partial class LaboratoryTubeDefinitonFormX : TTForm
    {
    /// <summary>
    /// Laboratuvar Tüp Tanımları
    /// </summary>
        protected TTObjectClasses.LaboratoryTubeDefinitionX _LaboratoryTubeDefinitionX
        {
            get { return (TTObjectClasses.LaboratoryTubeDefinitionX)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox3;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("3e4c092a-765f-449f-9e36-04a2e1b17412"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("12305f1d-3f7a-4cd9-9c9c-3c32a1eea0f7"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("591450eb-294b-4a09-9938-4a0ff7ac756e"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("070d4b63-aa3d-4ae7-99ad-5968655be3ca"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4a581fe1-4c6a-42cd-88ae-6da48e2912ea"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("83d9d47c-de74-49c9-8256-7a25d1920437"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa9a76ea-de53-4f45-8ce7-7f30cc2dca55"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9aefba9c-5345-484d-80e0-9a3e61ad04fa"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("d9e67f87-34a0-47bd-a592-ca00d9d1b7dd"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("51464b53-0026-4a27-bc09-ec8d77ff7367"));
            base.InitializeControls();
        }

        public LaboratoryTubeDefinitonFormX() : base("LABORATORYTUBEDEFINITIONX", "LaboratoryTubeDefinitonFormX")
        {
        }

        protected LaboratoryTubeDefinitonFormX(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}