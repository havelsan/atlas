
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
    /// Yeni Doğan Hasta Kabul
    /// </summary>
    public partial class YeniDoganHastaKabulForm : BaseHastaKabulForm
    {
    /// <summary>
    /// Yeni Doğan Hasta Kabul
    /// </summary>
        protected TTObjectClasses.YeniDoganHastaKabul _YeniDoganHastaKabul
        {
            get { return (TTObjectClasses.YeniDoganHastaKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxYeniDoganBilgisi;
        protected ITTDateTimePicker bebeginDogumTarihiDatetimepicker;
        protected ITTLabel labelbebeginDogumTarihi;
        protected ITTTextBox cocukSira;
        protected ITTLabel labelcocukSira;
        protected ITTTextBox bebeginDogumTarihi;
        override protected void InitializeControls()
        {
            groupboxYeniDoganBilgisi = (ITTGroupBox)AddControl(new Guid("0e911f8e-8e3f-4616-b051-ebbb2ab0332f"));
            bebeginDogumTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("c2dd2bb1-e9ae-48e0-aa97-3576e035f880"));
            labelbebeginDogumTarihi = (ITTLabel)AddControl(new Guid("887e014a-45a2-41e2-940f-c230f46f0499"));
            cocukSira = (ITTTextBox)AddControl(new Guid("e077c3c7-7fd8-4e16-92b3-5860dbbea5fe"));
            labelcocukSira = (ITTLabel)AddControl(new Guid("661b796d-c935-4013-acea-28200f87790e"));
            bebeginDogumTarihi = (ITTTextBox)AddControl(new Guid("d55c306d-9ab7-4544-a23c-d20806add6ad"));
            base.InitializeControls();
        }

        public YeniDoganHastaKabulForm() : base("YENIDOGANHASTAKABUL", "YeniDoganHastaKabulForm")
        {
        }

        protected YeniDoganHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}