
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
    public partial class LaboratoryCokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Test
    /// </summary>
        protected TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure
        {
            get { return (TTObjectClasses.LaboratoryProcedure)_ttObject; }
        }

        protected ITTGrid ttgridOzelDurum;
        protected ITTListDefComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgridOzelDurum = (ITTGrid)AddControl(new Guid("88a606f4-e833-4115-972a-2107eeec8285"));
            cokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("47937d52-b1d1-4d6c-9209-e04636ae72fa"));
            base.InitializeControls();
        }

        public LaboratoryCokluOzelDurumForm() : base("LABORATORYPROCEDURE", "LaboratoryCokluOzelDurumForm")
        {
        }

        protected LaboratoryCokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}