
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
    /// Laboratuvar Etken Madde Tanım Formu
    /// </summary>
    public partial class LaboratoryIngredientDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Etken Madde Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryIngredientDefinition _LaboratoryIngredientDefinition
        {
            get { return (TTObjectClasses.LaboratoryIngredientDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTValueListBox ttvaluelistbox1;
        protected ITTCheckBox ttcheckbox4;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("9cc24fed-a72c-41c0-98ec-073f2a94bf6c"));
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("80bdb5bb-1dfc-4a43-899c-1f0c31e9adaa"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("d1bcfe92-8fda-43ca-b640-3049212b7597"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("13c93552-e652-442b-b51c-32f2c6c8ebfd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7af11cf6-e896-452b-980d-44bf9a252225"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("8934c865-2c3f-4b5f-9d2d-4cd997925c9c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8630a0ae-095f-4ac9-802e-4dff2636ea7e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6c57814a-a120-4388-a676-4fe5bf01cb97"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a9ad306c-afa0-40b7-8d87-a3fc5adf4d7f"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("0d06e9cc-41ba-456d-9fe7-cd2b436d94f5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a4b0e602-b5ad-4814-83bd-fe5cc4347a76"));
            base.InitializeControls();
        }

        public LaboratoryIngredientDefinitionForm() : base("LABORATORYINGREDIENTDEFINITION", "LaboratoryIngredientDefinitionForm")
        {
        }

        protected LaboratoryIngredientDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}