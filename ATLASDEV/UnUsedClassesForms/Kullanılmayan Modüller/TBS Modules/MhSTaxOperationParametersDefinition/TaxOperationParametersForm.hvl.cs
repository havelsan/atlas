
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
    /// Vergi Parametreleri Tanımlama
    /// </summary>
    public partial class TaxOperationParametersForm : TTForm
    {
    /// <summary>
    /// Vergi İşlemleri Parametre Tanımlama
    /// </summary>
        protected TTObjectClasses.MhSTaxOperationParametersDefinition _MhSTaxOperationParametersDefinition
        {
            get { return (TTObjectClasses.MhSTaxOperationParametersDefinition)_ttObject; }
        }

        protected ITTListDefComboBox StampTaxAccount;
        protected ITTLabel labelDecisionStampType;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTLabel labelStampTaxAccount;
        protected ITTListDefComboBox DecisionStampType;
        protected ITTListDefComboBox DecisionStampAccount;
        protected ITTLabel labelDecisionStampAccount;
        protected ITTLabel labelIncomeTaxAccount;
        protected ITTLabel labelPaymentSlipDebitAccount;
        protected ITTListDefComboBox IncomeTaxAccount;
        override protected void InitializeControls()
        {
            StampTaxAccount = (ITTListDefComboBox)AddControl(new Guid("edcfbddd-c0ed-4991-acdc-01b14ea6f05c"));
            labelDecisionStampType = (ITTLabel)AddControl(new Guid("009587bc-8c9c-4f81-98b9-0e166fe9ccc4"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("0a5bf9ee-eb3a-4cab-aeff-17cacd8851c5"));
            labelStampTaxAccount = (ITTLabel)AddControl(new Guid("7f6b3e09-145e-49c3-9a98-31766f829fc0"));
            DecisionStampType = (ITTListDefComboBox)AddControl(new Guid("f750df97-2d15-4884-a177-4d987c121853"));
            DecisionStampAccount = (ITTListDefComboBox)AddControl(new Guid("8c6ea365-e152-45f4-ba7f-2aa3a79b967a"));
            labelDecisionStampAccount = (ITTLabel)AddControl(new Guid("32ca4989-d5f0-46d4-959d-604fe89cb87a"));
            labelIncomeTaxAccount = (ITTLabel)AddControl(new Guid("394a0683-5934-4890-9eba-c60a52e57237"));
            labelPaymentSlipDebitAccount = (ITTLabel)AddControl(new Guid("58a959b7-fc52-45d6-b3f1-cd7687a0b9cf"));
            IncomeTaxAccount = (ITTListDefComboBox)AddControl(new Guid("3d65815d-4946-4cb3-a8ed-f4ba3e7248aa"));
            base.InitializeControls();
        }

        public TaxOperationParametersForm() : base("MHSTAXOPERATIONPARAMETERSDEFINITION", "TaxOperationParametersForm")
        {
        }

        protected TaxOperationParametersForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}