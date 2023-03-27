
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
    public partial class HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavisi Emrinin  Uygulamasının Gerçekleştirildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbarikOxygenTreatmentOrderDetail _HyperbarikOxygenTreatmentOrderDetail
        {
            get { return (TTObjectClasses.HyperbarikOxygenTreatmentOrderDetail)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("7805428b-e7dd-4edb-9a01-9237bf8db5f0"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("aea7aeb3-fe83-4ef5-ba21-2bdfb94fd92f"));
            base.InitializeControls();
        }

        public HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm() : base("HYPERBARIKOXYGENTREATMENTORDERDETAIL", "HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm")
        {
        }

        protected HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}