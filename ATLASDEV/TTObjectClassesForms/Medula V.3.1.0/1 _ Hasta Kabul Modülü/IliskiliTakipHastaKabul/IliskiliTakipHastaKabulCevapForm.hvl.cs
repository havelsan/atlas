
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
    /// İlişkili Takip Hasta Kabul Cevap
    /// </summary>
    public partial class IliskiliTakipHastaKabulCevapForm : BaseHastaKabulCevapForm
    {
    /// <summary>
    /// İlişkili Takip Hasta Kabul
    /// </summary>
        protected TTObjectClasses.IliskiliTakipHastaKabul _IliskiliTakipHastaKabul
        {
            get { return (TTObjectClasses.IliskiliTakipHastaKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxTakipNoBilgisi;
        protected ITTTextBox iliskilendirilecekTakipNo;
        protected ITTLabel labelIliskilendirilecekTakipNo;
        override protected void InitializeControls()
        {
            groupboxTakipNoBilgisi = (ITTGroupBox)AddControl(new Guid("46253a45-1b1c-4af4-954c-24d69d36b295"));
            iliskilendirilecekTakipNo = (ITTTextBox)AddControl(new Guid("07f79aed-a342-4177-bafc-1f3e4252acd2"));
            labelIliskilendirilecekTakipNo = (ITTLabel)AddControl(new Guid("f7ef3344-2798-46e2-9770-5837480a6f7d"));
            base.InitializeControls();
        }

        public IliskiliTakipHastaKabulCevapForm() : base("ILISKILITAKIPHASTAKABUL", "IliskiliTakipHastaKabulCevapForm")
        {
        }

        protected IliskiliTakipHastaKabulCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}