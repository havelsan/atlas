
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
    public partial class KuduzProfilaksiIzlemForm : TTForm
    {
    /// <summary>
    /// Kuduz Profilaksi İzlem Veri Seti
    /// </summary>
        protected TTObjectClasses.KuduzProfilaksiVeriSeti _KuduzProfilaksiVeriSeti
        {
            get { return (TTObjectClasses.KuduzProfilaksiVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSImmunglobulinTuru;
        protected ITTObjectListBox SKRSImmunglobulinTuru;
        protected ITTLabel labelSKRSKuduzProfilaksiTamamlanma;
        protected ITTObjectListBox SKRSKuduzProfilaksiTamamlanma;
        protected ITTGrid KuduzProfilaksiUygProfilak;
        protected ITTListBoxColumn SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak;
        protected ITTLabel labelImmunglobulinMiktari;
        protected ITTTextBox ImmunglobulinMiktari;
        protected ITTTextBox Kilo;
        protected ITTLabel labelKilo;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            labelSKRSImmunglobulinTuru = (ITTLabel)AddControl(new Guid("bb986ec7-19be-41f3-a86e-eb18049db9f6"));
            SKRSImmunglobulinTuru = (ITTObjectListBox)AddControl(new Guid("669839a2-40d2-4ce3-9590-25dd9e735190"));
            labelSKRSKuduzProfilaksiTamamlanma = (ITTLabel)AddControl(new Guid("f5f0bb5b-5f52-483b-84c0-c67b944e9a6a"));
            SKRSKuduzProfilaksiTamamlanma = (ITTObjectListBox)AddControl(new Guid("1d6d1926-45ca-4856-8658-5f4f11c743d3"));
            KuduzProfilaksiUygProfilak = (ITTGrid)AddControl(new Guid("9c237b87-c153-4ac1-93ea-304a3e0da4c6"));
            SKRSUygulananKuduzProfilaksiKuduzProfilaksiUygProfilak = (ITTListBoxColumn)AddControl(new Guid("5ef74d48-fa1d-4aa2-98a6-9f204de4c532"));
            labelImmunglobulinMiktari = (ITTLabel)AddControl(new Guid("2fcdb38e-1225-4410-aa3c-e973b82c6f7c"));
            ImmunglobulinMiktari = (ITTTextBox)AddControl(new Guid("0eeb8166-333b-41ff-9b5c-943d55f27ff1"));
            Kilo = (ITTTextBox)AddControl(new Guid("08d2a2f3-a749-4c28-9f3c-71e4ac6b9b6f"));
            labelKilo = (ITTLabel)AddControl(new Guid("6e19fc6f-ae37-4ffe-ae78-4477bfe7dbfb"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("7d1f5161-99ef-4fbf-a972-b491eddecfc5"));
            base.InitializeControls();
        }

        public KuduzProfilaksiIzlemForm() : base("KUDUZPROFILAKSIVERISETI", "KuduzProfilaksiIzlemForm")
        {
        }

        protected KuduzProfilaksiIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}