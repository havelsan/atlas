
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
    /// Taş Kırma Loklizasyonu Tanımları
    /// </summary>
    public partial class BreakingStonePartOfStoneDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Taş Kırma Bölgeleri Tanımları
    /// </summary>
        protected TTObjectClasses.StoneBreakUpPartOfStoneDefinition _StoneBreakUpPartOfStoneDefinition
        {
            get { return (TTObjectClasses.StoneBreakUpPartOfStoneDefinition)_ttObject; }
        }

        protected ITTLabel labelPartOfStone;
        protected ITTTextBox PartOfStone;
        override protected void InitializeControls()
        {
            labelPartOfStone = (ITTLabel)AddControl(new Guid("8e7b0110-07d9-4362-9a0f-5dfed92e324e"));
            PartOfStone = (ITTTextBox)AddControl(new Guid("b7fd4ab2-1694-470d-ae58-3710045340e0"));
            base.InitializeControls();
        }

        public BreakingStonePartOfStoneDefinitionForm() : base("STONEBREAKUPPARTOFSTONEDEFINITION", "BreakingStonePartOfStoneDefinitionForm")
        {
        }

        protected BreakingStonePartOfStoneDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}