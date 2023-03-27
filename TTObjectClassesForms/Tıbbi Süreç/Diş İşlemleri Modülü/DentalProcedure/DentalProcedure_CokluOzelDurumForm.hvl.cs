
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
    public partial class DentalProcedure_CokluOzelDurumForm : TTForm
    {
        protected TTObjectClasses.DentalProcedure _DentalProcedure
        {
            get { return (TTObjectClasses.DentalProcedure)_ttObject; }
        }

        protected ITTGrid ttgridOzelDurum;
        protected ITTListDefComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgridOzelDurum = (ITTGrid)AddControl(new Guid("2d5a9961-45ff-465a-985a-fce39765e46c"));
            cokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("f2715921-e16a-437d-b35c-e9625879094f"));
            base.InitializeControls();
        }

        public DentalProcedure_CokluOzelDurumForm() : base("DENTALPROCEDURE", "DentalProcedure_CokluOzelDurumForm")
        {
        }

        protected DentalProcedure_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}