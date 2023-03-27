
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
    /// Cerrahi Ekibi
    /// </summary>
    public partial class SurgeryPersonnelForm : TTForm
    {
    /// <summary>
    /// Ameliyat Kategorisi
    /// </summary>
        protected TTObjectClasses.SurgeryProcedure _SurgeryProcedure
        {
            get { return (TTObjectClasses.SurgeryProcedure)_ttObject; }
        }

        protected ITTGrid SurgeryPersonnelGrid;
        protected ITTListBoxColumn Personnel;
        protected ITTEnumComboBoxColumn Görevi;
        override protected void InitializeControls()
        {
            SurgeryPersonnelGrid = (ITTGrid)AddControl(new Guid("285c9632-912c-42f3-92c1-b1edc8daf3de"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("39cf651c-6756-4fc3-8ba8-4c85b8ce47ba"));
            Görevi = (ITTEnumComboBoxColumn)AddControl(new Guid("4379ef10-fa7d-4fd1-adc7-62a839e4f464"));
            base.InitializeControls();
        }

        public SurgeryPersonnelForm() : base("SURGERYPROCEDURE", "SurgeryPersonnelForm")
        {
        }

        protected SurgeryPersonnelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}