
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
    public partial class NuclearMedicineCokluOzelDurum : TTForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGrid ttgridCokluOzelDurum;
        protected ITTListBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgridCokluOzelDurum = (ITTGrid)AddControl(new Guid("0a4cb33d-1781-4a41-97dc-a1fb7d966cf8"));
            cokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("3bc3d1c0-9a3d-4361-ad4d-3a5c0d822071"));
            base.InitializeControls();
        }

        public NuclearMedicineCokluOzelDurum() : base("NUCLEARMEDICINE", "NuclearMedicineCokluOzelDurum")
        {
        }

        protected NuclearMedicineCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}