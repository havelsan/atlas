
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
    /// Laboratuvar Bakteri Grup Tanım Formu
    /// </summary>
    public partial class LaboratoryBacteriaGroupDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Bakteri Grup Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryBacteriaGroupDefinition _LaboratoryBacteriaGroupDefinition
        {
            get { return (TTObjectClasses.LaboratoryBacteriaGroupDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel2;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Ingredient;
        protected ITTTextBoxColumn ResistanceMM;
        protected ITTTextBoxColumn SensitiveMM;
        protected ITTTextBox tttextbox2;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("37db70b4-5527-4607-8eb3-6935c599d2e7"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("1e2abc7e-bfc3-4bb5-b4a8-8229c66c6a07"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2665807e-6b16-4ec6-8975-a3408344c4f4"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ff70a1f2-0d59-4366-864f-cef6348f6c49"));
            Ingredient = (ITTListBoxColumn)AddControl(new Guid("566db088-029d-4ee0-8cfb-5e8e2a2289ae"));
            ResistanceMM = (ITTTextBoxColumn)AddControl(new Guid("33922910-b962-4e12-9c28-e9c856d26223"));
            SensitiveMM = (ITTTextBoxColumn)AddControl(new Guid("c7dd2c59-9d1a-4cf6-aa7a-fa8ccaeffbd4"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b1d26aad-51a0-470d-b217-f114bb4be075"));
            base.InitializeControls();
        }

        public LaboratoryBacteriaGroupDefinitionForm() : base("LABORATORYBACTERIAGROUPDEFINITION", "LaboratoryBacteriaGroupDefinitionForm")
        {
        }

        protected LaboratoryBacteriaGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}