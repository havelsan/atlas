
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
    /// Dağıtım Planı Girişi
    /// </summary>
    public partial class NewDistributionPlan : TTForm
    {
    /// <summary>
    /// Dağıtım Planı
    /// </summary>
        protected TTObjectClasses.METDistributionPlan _METDistributionPlan
        {
            get { return (TTObjectClasses.METDistributionPlan)_ttObject; }
        }

        protected ITTGrid Targets;
        protected ITTTextBox ALIAS;
        protected ITTLabel LABELALIAS;
        override protected void InitializeControls()
        {
            Targets = (ITTGrid)AddControl(new Guid("56c14cd3-2d83-4039-b204-1af0f2e45e62"));
            ALIAS = (ITTTextBox)AddControl(new Guid("e855181c-563e-44cb-8de1-d944e7554330"));
            LABELALIAS = (ITTLabel)AddControl(new Guid("db168b20-ce08-4e77-81dd-d23209b152b3"));
            base.InitializeControls();
        }

        public NewDistributionPlan() : base("METDISTRIBUTIONPLAN", "NewDistributionPlan")
        {
        }

        protected NewDistributionPlan(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}