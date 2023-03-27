
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
    /// Kronik Hastalıklar 
    /// </summary>
    public partial class KronikHastaliklarForm : TTForm
    {
    /// <summary>
    /// Kronik Hastalıklar Veri Seti
    /// </summary>
        protected TTObjectClasses.KronikHastaliklarVeriSeti _KronikHastaliklarVeriSeti
        {
            get { return (TTObjectClasses.KronikHastaliklarVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSSpirometri;
        protected ITTObjectListBox SKRSSpirometri;
        protected ITTLabel labelIlkTaniTarihi;
        protected ITTDateTimePicker IlkTaniTarihi;
        override protected void InitializeControls()
        {
            labelSKRSSpirometri = (ITTLabel)AddControl(new Guid("b8528e9a-aad9-4bf4-9ec5-9870e0e2326a"));
            SKRSSpirometri = (ITTObjectListBox)AddControl(new Guid("ccffbd1d-11c4-4829-8281-cdf1fb99933c"));
            labelIlkTaniTarihi = (ITTLabel)AddControl(new Guid("4cfc84cd-7db0-40a3-a69b-b408a4d49edf"));
            IlkTaniTarihi = (ITTDateTimePicker)AddControl(new Guid("adb9bda8-2f64-4e9b-a053-28314cca79a2"));
            base.InitializeControls();
        }

        public KronikHastaliklarForm() : base("KRONIKHASTALIKLARVERISETI", "KronikHastaliklarForm")
        {
        }

        protected KronikHastaliklarForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}