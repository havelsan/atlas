
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
    public partial class KadinaYonelikSiddetVeriSetiForm : TTForm
    {
        protected TTObjectClasses.KadinaYonelikSiddetVeriSet _KadinaYonelikSiddetVeriSet
        {
            get { return (TTObjectClasses.KadinaYonelikSiddetVeriSet)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid KadinaYonelikSiddetTuru;
        protected ITTListBoxColumn SKRSSiddetTuruKadinaYonelikSiddetTuru;
        protected ITTGrid KadinaYonelikSiddetSonuc;
        protected ITTListBoxColumn SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("724c9e83-fdb0-43ec-b3e7-67db5be3db0e"));
            KadinaYonelikSiddetTuru = (ITTGrid)AddControl(new Guid("3d7f3ae1-59e7-4182-8689-5e54ce188ec1"));
            SKRSSiddetTuruKadinaYonelikSiddetTuru = (ITTListBoxColumn)AddControl(new Guid("42331927-6851-4517-80d0-f76f16036de5"));
            KadinaYonelikSiddetSonuc = (ITTGrid)AddControl(new Guid("b4dac9d6-e1a3-48b0-a631-0228d71b3c24"));
            SKRSYonlendirmeDegerlendirmeKadinaYonelikSiddetSonuc = (ITTListBoxColumn)AddControl(new Guid("90c36311-2ffe-4866-a7dd-0d3d73f57038"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2975e1a5-f062-4b5a-86ff-c86e737a8044"));
            base.InitializeControls();
        }

        public KadinaYonelikSiddetVeriSetiForm() : base("KADINAYONELIKSIDDETVERISET", "KadinaYonelikSiddetVeriSetiForm")
        {
        }

        protected KadinaYonelikSiddetVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}