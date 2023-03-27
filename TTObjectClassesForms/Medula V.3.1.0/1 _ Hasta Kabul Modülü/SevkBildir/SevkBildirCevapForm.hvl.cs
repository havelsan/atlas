
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
    /// Sevk Bildir Cevap
    /// </summary>
    public partial class SevkBildirCevapForm : BaseSevkBildirForm
    {
    /// <summary>
    /// Sevk Bildir
    /// </summary>
        protected TTObjectClasses.SevkBildir _SevkBildir
        {
            get { return (TTObjectClasses.SevkBildir)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labelsevkEdilisTarihiCevap;
        protected ITTLabel labeltakipNoCevap;
        protected ITTTextBox sevkEdilisTarihiCevap;
        protected ITTTextBox sonucMesaji;
        protected ITTTextBox takipNoCevap;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("2e0c2d00-fbbb-4340-b233-302eec2ab142"));
            labelsevkEdilisTarihiCevap = (ITTLabel)AddControl(new Guid("7f4a5360-a6a4-4d81-950b-355b525e3366"));
            labeltakipNoCevap = (ITTLabel)AddControl(new Guid("12ee2ff3-8cdb-413f-8360-3eb205418126"));
            sevkEdilisTarihiCevap = (ITTTextBox)AddControl(new Guid("dd3f02be-ac12-4fe1-87bd-ddcc11b330e7"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("6349c2dd-0dda-4e79-b7c7-0597892e23f6"));
            takipNoCevap = (ITTTextBox)AddControl(new Guid("6873714c-f205-4db2-b86c-cbc02e5eb02d"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("f860a970-2047-4c1b-a12d-e5d9ebdfe22c"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("c9e11bb5-a35a-4001-806e-dbe757944fcc"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("ba055483-ed99-4b7e-9786-b54438140394"));
            base.InitializeControls();
        }

        public SevkBildirCevapForm() : base("SEVKBILDIR", "SevkBildirCevapForm")
        {
        }

        protected SevkBildirCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}