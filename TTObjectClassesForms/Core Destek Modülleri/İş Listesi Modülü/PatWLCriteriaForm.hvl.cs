
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
    /// Patoloji İş Listesi
    /// </summary>
    public partial class PatWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        protected ITTTextBox MaterialProtocolID;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox chkSpecialProcedure;
        override protected void InitializeControls()
        {
            MaterialProtocolID = (ITTTextBox)AddControl(new Guid("94556bc2-ac8b-491a-abb2-34cab9bc4d51"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bee68f95-69e6-43c2-a57b-219b5eb1f33a"));
            chkSpecialProcedure = (ITTCheckBox)AddControl(new Guid("cc7a22e1-6250-4709-9ad2-2c38b9431110"));
            base.InitializeControls();
        }

        public PatWLCriteriaForm() : base("PatWLCriteriaForm")
        {
        }

        protected PatWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}