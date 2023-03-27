
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
    public partial class RadiologyTestCokluOzelDurum : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTGrid ttgridCokluOzelDurum;
        protected ITTListDefComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgridCokluOzelDurum = (ITTGrid)AddControl(new Guid("b35585e1-42b3-4b28-a453-c54b481d3800"));
            cokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("77deb271-a974-4af0-9a8f-a34b8e3a8ea3"));
            base.InitializeControls();
        }

        public RadiologyTestCokluOzelDurum() : base("RADIOLOGYTEST", "RadiologyTestCokluOzelDurum")
        {
        }

        protected RadiologyTestCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}