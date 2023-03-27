
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
    public partial class PhysiotherapyCokluOzelDurum : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("707c269f-749f-4563-b589-9ae8295daf45"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("8f2541da-d77b-45a9-a762-7b04ee46b68d"));
            base.InitializeControls();
        }

        public PhysiotherapyCokluOzelDurum() : base("PHYSIOTHERAPYORDER", "PhysiotherapyCokluOzelDurum")
        {
        }

        protected PhysiotherapyCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}