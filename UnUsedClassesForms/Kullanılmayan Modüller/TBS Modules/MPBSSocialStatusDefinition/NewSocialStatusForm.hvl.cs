
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
    /// Sosyal Statü Tanımlama
    /// </summary>
    public partial class NewSocialStatusForm : TTForm
    {
    /// <summary>
    /// Sosyal Statü Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSSocialStatusDefinition _MPBSSocialStatusDefinition
        {
            get { return (TTObjectClasses.MPBSSocialStatusDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("627ee724-25ed-42ad-ae2b-56a4966a5964"));
            labelName = (ITTLabel)AddControl(new Guid("0219ae56-d436-429f-a91a-c2b4098d3413"));
            base.InitializeControls();
        }

        public NewSocialStatusForm() : base("MPBSSOCIALSTATUSDEFINITION", "NewSocialStatusForm")
        {
        }

        protected NewSocialStatusForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}