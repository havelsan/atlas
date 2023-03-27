
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
    public partial class GMDNDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// GMDN Tanımları
    /// </summary>
        protected TTObjectClasses.GMDNDefinition _GMDNDefinition
        {
            get { return (TTObjectClasses.GMDNDefinition)_ttObject; }
        }

        protected ITTLabel labelStatement_Tr;
        protected ITTTextBox Statement_Tr;
        protected ITTLabel labelDetail;
        protected ITTTextBox Detail;
        protected ITTLabel labelName_Tr;
        protected ITTTextBox Name_Tr;
        protected ITTTextBox Name_En;
        protected ITTTextBox ConceptCode;
        protected ITTLabel labelName_En;
        protected ITTLabel labelConceptCode;
        override protected void InitializeControls()
        {
            labelStatement_Tr = (ITTLabel)AddControl(new Guid("17d92417-f9be-4afb-ab47-d1651cd71be5"));
            Statement_Tr = (ITTTextBox)AddControl(new Guid("dec0a4bb-7aca-4cc0-bc2c-353605ff993c"));
            labelDetail = (ITTLabel)AddControl(new Guid("f9114a53-c766-4ae3-a348-323277108bd2"));
            Detail = (ITTTextBox)AddControl(new Guid("c4568f1a-4284-4240-af63-b513e23f6e5a"));
            labelName_Tr = (ITTLabel)AddControl(new Guid("0e5f19a9-5749-4652-a008-eac19522bbfd"));
            Name_Tr = (ITTTextBox)AddControl(new Guid("3dd6bf45-5955-4bac-ba9b-b57092859e82"));
            Name_En = (ITTTextBox)AddControl(new Guid("4f6e9370-2a13-495f-979a-5b70e50d937c"));
            ConceptCode = (ITTTextBox)AddControl(new Guid("0127ff5d-90f3-4f2f-830c-310486407987"));
            labelName_En = (ITTLabel)AddControl(new Guid("61007237-894f-48d2-9779-db1641f1f65b"));
            labelConceptCode = (ITTLabel)AddControl(new Guid("6bdf60da-2965-4942-a521-c40c46e093ff"));
            base.InitializeControls();
        }

        public GMDNDefinitionForm() : base("GMDNDEFINITION", "GMDNDefinitionForm")
        {
        }

        protected GMDNDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}