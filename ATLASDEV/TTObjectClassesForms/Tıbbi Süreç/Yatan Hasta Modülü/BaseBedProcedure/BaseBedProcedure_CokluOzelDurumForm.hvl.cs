
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
    public partial class BaseBedProcedure_CokluOzelDurumForm : TTForm
    {
        protected TTObjectClasses.BaseBedProcedure _BaseBedProcedure
        {
            get { return (TTObjectClasses.BaseBedProcedure)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("5a896a2d-d565-4fa0-89d5-bca900d32c61"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("a41fece0-66c2-4d80-933e-ed261f80b555"));
            base.InitializeControls();
        }

        public BaseBedProcedure_CokluOzelDurumForm() : base("BASEBEDPROCEDURE", "BaseBedProcedure_CokluOzelDurumForm")
        {
        }

        protected BaseBedProcedure_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}