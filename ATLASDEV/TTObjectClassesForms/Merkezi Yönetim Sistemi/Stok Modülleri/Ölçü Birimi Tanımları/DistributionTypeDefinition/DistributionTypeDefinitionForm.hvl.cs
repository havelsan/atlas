
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
    public partial class DistributionTypeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ölçü Birimi Tanımları
    /// </summary>
        protected TTObjectClasses.DistributionTypeDefinition _DistributionTypeDefinition
        {
            get { return (TTObjectClasses.DistributionTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelMKYS_DistType;
        protected ITTEnumComboBox MKYS_DistType;
        protected ITTLabel labelQREF;
        protected ITTLabel labelDistributionType;
        protected ITTTextBox DistributionType;
        protected ITTTextBox QREF;
        override protected void InitializeControls()
        {
            labelMKYS_DistType = (ITTLabel)AddControl(new Guid("05c447fe-37b7-4bd7-84e6-21417e11c6cf"));
            MKYS_DistType = (ITTEnumComboBox)AddControl(new Guid("2d9d2234-0cd8-4dcd-89f1-3a360cf19908"));
            labelQREF = (ITTLabel)AddControl(new Guid("dd160edb-db7d-4381-80fa-25b126b30240"));
            labelDistributionType = (ITTLabel)AddControl(new Guid("1d301d71-035b-41be-bf89-5e7dba28e77b"));
            DistributionType = (ITTTextBox)AddControl(new Guid("40ea76ec-a9ea-4cca-a452-b5e041357ec0"));
            QREF = (ITTTextBox)AddControl(new Guid("9af2948c-d5c0-48aa-8b0e-e5e00b8d4e3b"));
            base.InitializeControls();
        }

        public DistributionTypeDefinitionForm() : base("DISTRIBUTIONTYPEDEFINITION", "DistributionTypeDefinitionForm")
        {
        }

        protected DistributionTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}