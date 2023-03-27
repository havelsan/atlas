
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
    /// Doktor Performans İşlem Giriş
    /// </summary>
    public partial class DPEntryForm : EpisodeActionForm
    {
    /// <summary>
    /// Doktor Performans İşlem Giriş
    /// </summary>
        protected TTObjectClasses.DoctorPerformanceEntry _DoctorPerformanceEntry
        {
            get { return (TTObjectClasses.DoctorPerformanceEntry)_ttObject; }
        }

        protected ITTGrid grdDPEntry;
        protected ITTDateTimePickerColumn Date;
        protected ITTListBoxColumn Procedure;
        protected ITTListBoxColumn Performer;
        override protected void InitializeControls()
        {
            grdDPEntry = (ITTGrid)AddControl(new Guid("f9feae33-a16c-4ccb-8127-f0bafc7097cf"));
            Date = (ITTDateTimePickerColumn)AddControl(new Guid("e4ce2b99-66d2-456b-b068-06cba2d5aa1a"));
            Procedure = (ITTListBoxColumn)AddControl(new Guid("f9437c79-4d39-4944-98eb-2bd92e325813"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("f91a6993-9a0e-4552-9832-2f59cd18bb78"));
            base.InitializeControls();
        }

        public DPEntryForm() : base("DOCTORPERFORMANCEENTRY", "DPEntryForm")
        {
        }

        protected DPEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}