
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
    /// Karar Pulu İşlem Türü Tanımı
    /// </summary>
    public partial class DecisionStampOperationTypeDefinitionForm : TTForm
    {
    /// <summary>
    /// Karar Pulu İşlem Türü
    /// </summary>
        protected TTObjectClasses.MhSDecisionStampOperationTypeDefinition _MhSDecisionStampOperationTypeDefinition
        {
            get { return (TTObjectClasses.MhSDecisionStampOperationTypeDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox Ratio;
        protected ITTLabel labelRatio;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTTextBox Code;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("1b801c5e-bb01-4f90-9a36-037ec98c0341"));
            Ratio = (ITTTextBox)AddControl(new Guid("2f059dc0-f928-4a8a-b063-2c5c6999aeb1"));
            labelRatio = (ITTLabel)AddControl(new Guid("0d05deec-3684-463f-b51d-2c843a7689a5"));
            labelCode = (ITTLabel)AddControl(new Guid("ec81d795-d6e9-4a87-986e-5300f2deb5bf"));
            labelName = (ITTLabel)AddControl(new Guid("ac040db2-7a65-4649-b6d2-f1b7a254ee21"));
            Code = (ITTTextBox)AddControl(new Guid("aaad25b1-b6df-4856-8879-e1265277c235"));
            base.InitializeControls();
        }

        public DecisionStampOperationTypeDefinitionForm() : base("MHSDECISIONSTAMPOPERATIONTYPEDEFINITION", "DecisionStampOperationTypeDefinitionForm")
        {
        }

        protected DecisionStampOperationTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}