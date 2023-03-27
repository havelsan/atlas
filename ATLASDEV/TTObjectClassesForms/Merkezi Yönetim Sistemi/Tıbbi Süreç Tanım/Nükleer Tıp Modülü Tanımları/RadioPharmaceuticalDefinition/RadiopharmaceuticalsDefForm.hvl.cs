
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
    /// Radyofarmasötik Malzeme Tanımlama
    /// </summary>
    public partial class RadiopharmaceuticalsDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Radyofarmasötik Malzeme Tanımlama
    /// </summary>
        protected TTObjectClasses.RadioPharmaceuticalDefinition _RadioPharmaceuticalDefinition
        {
            get { return (TTObjectClasses.RadioPharmaceuticalDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("043c5bad-4b59-44e9-a363-0f5c0a95c046"));
            Name = (ITTTextBox)AddControl(new Guid("68afd0be-1b95-4c9f-b2e7-9bc71b3fe7f5"));
            EnglishName = (ITTTextBox)AddControl(new Guid("3bcabc70-5082-4eaf-a5d4-a532eb990c8c"));
            Description = (ITTTextBox)AddControl(new Guid("35ffaca5-076a-41aa-acc8-cb2ecee868ff"));
            Code = (ITTTextBox)AddControl(new Guid("36785ece-8de3-4918-8800-c6f479af7072"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("3be37b1e-d612-4ab6-ba50-293f37c1d371"));
            labelDescription = (ITTLabel)AddControl(new Guid("edb6caba-03f2-445d-ab80-e9b249750ae3"));
            labelCode = (ITTLabel)AddControl(new Guid("5754131b-7080-4020-81e3-0bf10d423f66"));
            base.InitializeControls();
        }

        public RadiopharmaceuticalsDefForm() : base("RADIOPHARMACEUTICALDEFINITION", "RadiopharmaceuticalsDefForm")
        {
        }

        protected RadiopharmaceuticalsDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}