
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
    public partial class DialysisOrderDetail_CokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
        protected TTObjectClasses.DialysisOrderDetail _DialysisOrderDetail
        {
            get { return (TTObjectClasses.DialysisOrderDetail)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("b1a2e10a-aa54-42eb-99cc-b87c76fb8791"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("22f5a5df-22fd-41d0-98c4-9d7b919aeed6"));
            base.InitializeControls();
        }

        public DialysisOrderDetail_CokluOzelDurumForm() : base("DIALYSISORDERDETAIL", "DialysisOrderDetail_CokluOzelDurumForm")
        {
        }

        protected DialysisOrderDetail_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}