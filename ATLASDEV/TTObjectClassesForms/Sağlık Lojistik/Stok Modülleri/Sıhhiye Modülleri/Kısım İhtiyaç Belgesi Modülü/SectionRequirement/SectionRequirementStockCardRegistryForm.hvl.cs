
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
    /// Kısım İhtiyaç Belgesi
    /// </summary>
    public partial class SectionRequirementStockCardRegistryForm : BaseSectionRequirementForm
    {
    /// <summary>
    /// Kısım İhtiyaç Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.SectionRequirement _SectionRequirement
        {
            get { return (TTObjectClasses.SectionRequirement)_ttObject; }
        }

        protected ITTLabel labelSequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTLabel labelRegistrationNumber;
        override protected void InitializeControls()
        {
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("41a3c4b7-af7a-47bf-9b47-eb867a36b5c9"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("06f06fb2-2656-4460-a0ab-d88e342563ba"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("5db1867b-cc27-4f2e-aacf-484ffe68fa6f"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("91aeec5a-b628-4c25-b063-40da1e55377b"));
            base.InitializeControls();
        }

        public SectionRequirementStockCardRegistryForm() : base("SECTIONREQUIREMENT", "SectionRequirementStockCardRegistryForm")
        {
        }

        protected SectionRequirementStockCardRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}