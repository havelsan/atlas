
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
    public partial class BaseSurAndManProcedure_CokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Ana Ameliyat ve Maniplasyon
    /// </summary>
        protected TTObjectClasses.BaseSurgeryAndManipulationProcedure _BaseSurgeryAndManipulationProcedure
        {
            get { return (TTObjectClasses.BaseSurgeryAndManipulationProcedure)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("0d254fd4-4c01-402a-bdbb-bd75d52ef38f"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("64e7a346-f223-43a2-9d7a-dd5996dec22e"));
            base.InitializeControls();
        }

        public BaseSurAndManProcedure_CokluOzelDurumForm() : base("BASESURGERYANDMANIPULATIONPROCEDURE", "BaseSurAndManProcedure_CokluOzelDurumForm")
        {
        }

        protected BaseSurAndManProcedure_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}