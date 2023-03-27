
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
    public partial class MHRSYonetimForm : TTForm
    {
        protected TTObjectClasses.MHRSYonetim _MHRSYonetim
        {
            get { return (TTObjectClasses.MHRSYonetim)_ttObject; }
        }

        protected ITTTabControl tbMHRSIslemleri;
        protected ITTTabPage tabPageRandevuPlanlariSorgulama;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tabPageKlinikHekimBildirimi;
        protected ITTButton btnSetMHRSClinicCode;
        protected ITTButton btnHekimEkle;
        protected ITTGrid gridMHRSHekim;
        protected ITTTextBoxColumn txtHekimEklePoliklinik;
        protected ITTTextBoxColumn txtHekimEkleHekim;
        protected ITTTextBoxColumn txtHekimEkleBilgi;
        protected ITTButton btnKlinikEkle;
        protected ITTGrid gridMHRSyeEklenenPoliklinikler;
        protected ITTTextBoxColumn txtMHRSyeEklenenPoliklinic;
        protected ITTTextBoxColumn txtMHRSyeEklendi;
        protected ITTGrid gridMHRSPoliklinic;
        protected ITTTextBoxColumn txtMHRSPoliklinic;
        protected ITTTextBoxColumn txtMHRSPoliklinicMHRSClinic;
        protected ITTCheckBoxColumn ckcMHRSyeGonder;
        protected ITTButton btnAltKlinikEkle;
        protected ITTGrid gridMHRSyeEklenenAltPoliklinikler;
        protected ITTTextBoxColumn txtMHRSyeEklenenAltPoliklinic;
        protected ITTTextBoxColumn txtMHRSyeEklendiAltKlinik;
        override protected void InitializeControls()
        {
            tbMHRSIslemleri = (ITTTabControl)AddControl(new Guid("9972fe8f-fae8-48c1-9f41-c670febe993a"));
            tabPageRandevuPlanlariSorgulama = (ITTTabPage)AddControl(new Guid("03985ad9-20f6-40bb-8736-58c7d62a65f8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ccea25c2-d212-4fe8-9802-6d31f6180b13"));
            tabPageKlinikHekimBildirimi = (ITTTabPage)AddControl(new Guid("e8656f36-107e-4a25-aa86-f1ecf9da38bc"));
            btnSetMHRSClinicCode = (ITTButton)AddControl(new Guid("8b4eab38-c5e6-4c79-aed7-de2dcea91d37"));
            btnHekimEkle = (ITTButton)AddControl(new Guid("c4cb3ced-707e-44e3-b1e7-5676c1be0d5c"));
            gridMHRSHekim = (ITTGrid)AddControl(new Guid("58813b67-56c1-440c-8d6e-a9e35eb44ee7"));
            txtHekimEklePoliklinik = (ITTTextBoxColumn)AddControl(new Guid("91e60f50-a9bc-4adc-9ee9-18933c70bbc1"));
            txtHekimEkleHekim = (ITTTextBoxColumn)AddControl(new Guid("2c46df65-1db5-4044-9d3c-ca304975e722"));
            txtHekimEkleBilgi = (ITTTextBoxColumn)AddControl(new Guid("bc0e29bf-5558-4f96-9e0e-384018f47fd0"));
            btnKlinikEkle = (ITTButton)AddControl(new Guid("53586ba0-a7d9-45e1-9c25-fd3593be1cba"));
            gridMHRSyeEklenenPoliklinikler = (ITTGrid)AddControl(new Guid("33f3e064-815a-4238-9320-e70463c908ab"));
            txtMHRSyeEklenenPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("9b805211-45cb-4f09-b609-9566b2015e03"));
            txtMHRSyeEklendi = (ITTTextBoxColumn)AddControl(new Guid("e4e547c7-f5d6-4375-adea-d7f05607a895"));
            gridMHRSPoliklinic = (ITTGrid)AddControl(new Guid("9667d886-dd54-4256-9a51-2e19bbf8ce24"));
            txtMHRSPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("141801fa-43b7-41b2-ae4d-0b3e4c7334c1"));
            txtMHRSPoliklinicMHRSClinic = (ITTTextBoxColumn)AddControl(new Guid("dde966c5-5f0c-49e4-8448-9a8b21d31fa9"));
            ckcMHRSyeGonder = (ITTCheckBoxColumn)AddControl(new Guid("163c14d6-9923-4687-8d11-d9599c91e41e"));
            btnAltKlinikEkle = (ITTButton)AddControl(new Guid("3e8c7516-af5b-4ae5-9678-c723ea043b74"));
            gridMHRSyeEklenenAltPoliklinikler = (ITTGrid)AddControl(new Guid("80204527-ec8b-4608-9c38-9eb0a151e8ff"));
            txtMHRSyeEklenenAltPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("f3ec726c-9860-4576-bc4c-0f8710269fc7"));
            txtMHRSyeEklendiAltKlinik = (ITTTextBoxColumn)AddControl(new Guid("c2f49383-1de3-4974-97c7-c878f21e2e77"));
            base.InitializeControls();
        }

        public MHRSYonetimForm() : base("MHRSYONETIM", "MHRSYonetimForm")
        {
        }

        protected MHRSYonetimForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}