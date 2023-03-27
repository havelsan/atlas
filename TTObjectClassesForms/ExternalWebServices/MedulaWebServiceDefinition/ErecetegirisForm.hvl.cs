
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
    public partial class ErecetegirisForm : TTUnboundForm
    {
        protected ITTButton ttbutton6;
        protected ITTButton ttbutton5;
        protected ITTButton TckimliknoSorgula;
        protected ITTButton faturaKaydet;
        protected ITTButton ttbutton4;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTButton urunDogrula;
        protected ITTButton ttbutton1;
        protected ITTButton ttbtnEreceteOnay;
        protected ITTButton EreceteGiris;
        override protected void InitializeControls()
        {
            ttbutton6 = (ITTButton)AddControl(new Guid("ef416d89-58cd-4f68-8a22-eb7cd3cb8e0c"));
            ttbutton5 = (ITTButton)AddControl(new Guid("bff79355-20c7-4d51-a8c0-a13f261a34cc"));
            TckimliknoSorgula = (ITTButton)AddControl(new Guid("c4c77d1d-b558-46bc-9186-8e3bf9829069"));
            faturaKaydet = (ITTButton)AddControl(new Guid("5bb3d43e-0a16-41d9-9e90-94b1f630f324"));
            ttbutton4 = (ITTButton)AddControl(new Guid("1b329005-56a9-4a8a-ba87-859e51852de6"));
            ttbutton3 = (ITTButton)AddControl(new Guid("d2333196-3b38-4cea-994a-49e726161013"));
            ttbutton2 = (ITTButton)AddControl(new Guid("039f8a92-d2c6-4a30-aedb-0a1c6ed4c049"));
            urunDogrula = (ITTButton)AddControl(new Guid("ff53f027-4a50-490f-92d1-e23e71558759"));
            ttbutton1 = (ITTButton)AddControl(new Guid("d634e63c-da40-48d4-b70f-c4052f43bc3f"));
            ttbtnEreceteOnay = (ITTButton)AddControl(new Guid("da262fbf-fac0-49d6-a88e-2a9e9daf9221"));
            EreceteGiris = (ITTButton)AddControl(new Guid("59c30e8d-fd5e-4e95-80b3-675467a9a66d"));
            base.InitializeControls();
        }

        public ErecetegirisForm() : base("ErecetegirisForm")
        {
        }

        protected ErecetegirisForm(string formDefName) : base(formDefName)
        {
        }
    }
}