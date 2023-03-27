
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
    public partial class DisTaahhutOkuKisiCevapForm : DisTaahhutOkuKisiForm
    {
        protected TTObjectClasses.DisTaahhutOkuKisi _DisTaahhutOkuKisi
        {
            get { return (TTObjectClasses.DisTaahhutOkuKisi)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTGrid taahhutNoDVOsTaahhutNoDVO;
        protected ITTTextBoxColumn taahhutNoTaahhutNoDVO;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("85a389df-8125-4a45-8960-cb277aef430f"));
            taahhutNoDVOsTaahhutNoDVO = (ITTGrid)AddControl(new Guid("3e27331c-1404-4ec2-abad-bf6b47ee1840"));
            taahhutNoTaahhutNoDVO = (ITTTextBoxColumn)AddControl(new Guid("18316603-5fbc-45e4-a685-332a5cf267f2"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("853b462b-93b2-4deb-9b37-16d25907a9a1"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("dfcbea31-a39a-454c-b077-b2b18f9126b7"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("13f42e49-8e38-4f95-8a82-687205c431d0"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("f64c3367-1175-4c9d-a296-b36b98083544"));
            base.InitializeControls();
        }

        public DisTaahhutOkuKisiCevapForm() : base("DISTAAHHUTOKUKISI", "DisTaahhutOkuKisiCevapForm")
        {
        }

        protected DisTaahhutOkuKisiCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}