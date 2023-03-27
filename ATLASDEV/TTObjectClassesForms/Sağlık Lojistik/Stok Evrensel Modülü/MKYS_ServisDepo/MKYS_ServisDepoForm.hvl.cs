
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
    public partial class MKYS_ServisDepoForm : TTDefinitionForm
    {
        protected TTObjectClasses.MKYS_ServisDepo _MKYS_ServisDepo
        {
            get { return (TTObjectClasses.MKYS_ServisDepo)_ttObject; }
        }

        protected ITTLabel labeltur;
        protected ITTTextBox tur;
        protected ITTTextBox faaliyetDurumu;
        protected ITTTextBox birimKodu;
        protected ITTTextBox birimKisaAdi;
        protected ITTTextBox birimKayitNo;
        protected ITTTextBox birimAdi;
        protected ITTTextBox bagliBirimID;
        protected ITTLabel labelfaaliyetDurumu;
        protected ITTLabel labelbirimKodu;
        protected ITTLabel labelbirimKisaAdi;
        protected ITTLabel labelbirimKayitNo;
        protected ITTLabel labelbirimAdi;
        protected ITTLabel labelbagliBirimID;
        override protected void InitializeControls()
        {
            labeltur = (ITTLabel)AddControl(new Guid("d7e20f0d-0b40-47e5-aa6c-47a91e329e7e"));
            tur = (ITTTextBox)AddControl(new Guid("076325bd-5b4b-4d1a-b383-a09bc84613f5"));
            faaliyetDurumu = (ITTTextBox)AddControl(new Guid("84ff96e6-5c40-4352-a2e8-edfb2f02a53e"));
            birimKodu = (ITTTextBox)AddControl(new Guid("66aabee0-fed3-42fc-bb6c-26330e678132"));
            birimKisaAdi = (ITTTextBox)AddControl(new Guid("96f77f10-9f64-493d-b748-9e4ebf282dae"));
            birimKayitNo = (ITTTextBox)AddControl(new Guid("6edd1d6f-7621-4097-8ba5-5e64f34a5f0b"));
            birimAdi = (ITTTextBox)AddControl(new Guid("730a3018-9adc-4103-be60-d68761241a26"));
            bagliBirimID = (ITTTextBox)AddControl(new Guid("46942973-ede5-4f79-84f4-14a0c2542222"));
            labelfaaliyetDurumu = (ITTLabel)AddControl(new Guid("4c835c55-e96a-4aed-980c-b8757e5e6bc8"));
            labelbirimKodu = (ITTLabel)AddControl(new Guid("e6fb5927-f585-428a-9ed6-32f75825cb9e"));
            labelbirimKisaAdi = (ITTLabel)AddControl(new Guid("d584c8fe-393a-4dee-97d4-d975b0948723"));
            labelbirimKayitNo = (ITTLabel)AddControl(new Guid("43666c17-1396-4c5b-adb0-51d302592b47"));
            labelbirimAdi = (ITTLabel)AddControl(new Guid("c2c6262d-e576-400e-a018-30bdfd873ab0"));
            labelbagliBirimID = (ITTLabel)AddControl(new Guid("e3a1b5b8-d469-4b7b-82d6-7a426f10965f"));
            base.InitializeControls();
        }

        public MKYS_ServisDepoForm() : base("MKYS_SERVISDEPO", "MKYS_ServisDepoForm")
        {
        }

        protected MKYS_ServisDepoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}