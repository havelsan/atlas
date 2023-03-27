
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
    /// İlişkili Takip Hasta Kabul
    /// </summary>
    public partial class IliskiliTakipHastaKabulForm : BaseHastaKabulForm
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
            groupboxTakipNoBilgisi = (ITTGroupBox)AddControl(new Guid("d56d0c91-44a0-4463-8866-2d3afa63e9fc"));
            iliskilendirilecekTakipNo = (ITTTextBox)AddControl(new Guid("c405e090-f441-41de-addc-9b854d07ccd0"));
            labelIliskilendirilecekTakipNo = (ITTLabel)AddControl(new Guid("dbb179d2-991c-416e-948c-00c1c66f91fc"));
            base.InitializeControls();
        }

        public IliskiliTakipHastaKabulForm() : base("ILISKILITAKIPHASTAKABUL", "IliskiliTakipHastaKabulForm")
        {
        }

        protected IliskiliTakipHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}