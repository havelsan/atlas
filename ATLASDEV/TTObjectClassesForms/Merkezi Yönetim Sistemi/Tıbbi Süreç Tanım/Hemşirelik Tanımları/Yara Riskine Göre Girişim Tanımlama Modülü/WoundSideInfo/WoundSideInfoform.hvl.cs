
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
    /// Yara Taraf Bilgisi
    /// </summary>
    public partial class WoundSideInfoform : TerminologyManagerDefForm
    {
    /// <summary>
    /// Yara Taraf Bilgisi
    /// </summary>
        protected TTObjectClasses.WoundSideInfo _WoundSideInfo
        {
            get { return (TTObjectClasses.WoundSideInfo)_ttObject; }
        }

        protected ITTLabel labelSideInfo;
        protected ITTTextBox SideInfo;
        override protected void InitializeControls()
        {
            labelSideInfo = (ITTLabel)AddControl(new Guid("938ff043-4951-4336-8e87-e1f75cceab12"));
            SideInfo = (ITTTextBox)AddControl(new Guid("d4c0ef8c-86d4-411a-8ed9-4dec5dafd79d"));
            base.InitializeControls();
        }

        public WoundSideInfoform() : base("WOUNDSIDEINFO", "WoundSideInfoform")
        {
        }

        protected WoundSideInfoform(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}