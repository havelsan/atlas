
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Kısım İhtiyaç Belgesi
    /// </summary>
    public partial class SectionRequirementNewForm : BaseSectionRequirementForm
    {
        protected override void PreScript()
        {
#region SectionRequirementNewForm_PreScript
    base.PreScript();
             foreach (SectionRequirementMaterial sectionRequirementMaterial in _SectionRequirement.SectionRequirementMaterials)
            {
                
                if (sectionRequirementMaterial.Amount ==null || sectionRequirementMaterial.Amount ==0)
                    sectionRequirementMaterial.Amount = sectionRequirementMaterial.AcceptedAmount;
            }
#endregion SectionRequirementNewForm_PreScript

            }
                }
}