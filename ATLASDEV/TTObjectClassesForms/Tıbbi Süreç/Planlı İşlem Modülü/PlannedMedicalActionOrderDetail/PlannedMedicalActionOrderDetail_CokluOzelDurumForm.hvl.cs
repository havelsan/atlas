
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
    public partial class PlannedMedicalActionOrderDetail_CokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Uygulama
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrderDetail _PlannedMedicalActionOrderDetail
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrderDetail)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("cf91ef37-2c14-4f66-aee3-700c308b5220"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("c849af05-830f-411d-802c-1cd9b83da158"));
            base.InitializeControls();
        }

        public PlannedMedicalActionOrderDetail_CokluOzelDurumForm() : base("PLANNEDMEDICALACTIONORDERDETAIL", "PlannedMedicalActionOrderDetail_CokluOzelDurumForm")
        {
        }

        protected PlannedMedicalActionOrderDetail_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}