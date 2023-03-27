
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
    public partial class TreatmentMaterials_MedulaMalzemeForm : TTForm
    {
    /// <summary>
    /// Ana Tedavi Sarf Tabı
    /// </summary>
        protected TTObjectClasses.BaseTreatmentMaterial _BaseTreatmentMaterial
        {
            get { return (TTObjectClasses.BaseTreatmentMaterial)_ttObject; }
        }

        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabelSatinAlisTarihi;
        protected ITTObjectListBox TTListBoxMalzemeTuru;
        protected ITTLabel ttlabelMalzemeTuru;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTLabel ttlabelOzelDurum;
        protected ITTTextBox tttextboxMalzemeBrans;
        protected ITTTextBox tttextboxKDV;
        protected ITTTextBox tttextboxKodsuzMalzemeFiyati;
        protected ITTLabel ttlabelMalzemeBrans;
        protected ITTLabel ttlabelKDV;
        protected ITTLabel ttlabelKodsuzMalzemeFiyati;
        protected ITTGrid ttgridCokluOzelDurum;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d685a3c9-895a-4c50-9ed0-4b444288c7bd"));
            ttlabelSatinAlisTarihi = (ITTLabel)AddControl(new Guid("99317fd6-11cb-419d-a168-823e255af75d"));
            TTListBoxMalzemeTuru = (ITTObjectListBox)AddControl(new Guid("5331b0a7-176a-4d46-a578-ed3f4520d21b"));
            ttlabelMalzemeTuru = (ITTLabel)AddControl(new Guid("9a6854c1-b586-4245-abe5-2c568d6cb15a"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("d7b28f01-0eae-4961-9b8a-13d913a8369a"));
            ttlabelOzelDurum = (ITTLabel)AddControl(new Guid("a9815177-ab1e-41bb-8048-548171600a97"));
            tttextboxMalzemeBrans = (ITTTextBox)AddControl(new Guid("c7f11ef5-c6ae-4def-b8f9-387d86502026"));
            tttextboxKDV = (ITTTextBox)AddControl(new Guid("acb1d95a-7494-452e-893f-68d661a4537d"));
            tttextboxKodsuzMalzemeFiyati = (ITTTextBox)AddControl(new Guid("fbac8e02-57cf-4fa2-8f47-ed55a6a80414"));
            ttlabelMalzemeBrans = (ITTLabel)AddControl(new Guid("7ebe2dec-afbf-4977-ab73-705a81235056"));
            ttlabelKDV = (ITTLabel)AddControl(new Guid("35e187bb-58cc-4a2b-943d-e86801cc7c25"));
            ttlabelKodsuzMalzemeFiyati = (ITTLabel)AddControl(new Guid("c1e280c6-52bd-4d0a-9ff0-5c73a8d9592d"));
            ttgridCokluOzelDurum = (ITTGrid)AddControl(new Guid("de610fdb-d7e3-4199-a744-2498195cf1b0"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("043021d4-f95b-4130-bbaa-7c0a58620537"));
            base.InitializeControls();
        }

        public TreatmentMaterials_MedulaMalzemeForm() : base("BASETREATMENTMATERIAL", "TreatmentMaterials_MedulaMalzemeForm")
        {
        }

        protected TreatmentMaterials_MedulaMalzemeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}