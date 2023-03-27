
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
    public partial class MKYSMaterialGetWebService : TTUnboundForm
    {
        protected ITTButton ttbutton1;
        protected ITTButton getUnitStore;
        protected ITTButton getMaterial;
        protected ITTDateTimePicker gunlemeTarihi;
        protected ITTLabel labelgunlemeTarihi;
        override protected void InitializeControls()
        {
            ttbutton1 = (ITTButton)AddControl(new Guid("c81f9f07-5017-4ae3-9757-39d7675910c0"));
            getUnitStore = (ITTButton)AddControl(new Guid("f3bd6927-85c1-413d-9f7b-3e7a1a757e79"));
            getMaterial = (ITTButton)AddControl(new Guid("e89c609d-4dec-4ff4-a45e-8a33520b0cca"));
            gunlemeTarihi = (ITTDateTimePicker)AddControl(new Guid("2b489370-62a0-43e9-ba5f-ced6053a006a"));
            labelgunlemeTarihi = (ITTLabel)AddControl(new Guid("050c92ff-2f4b-4499-a71d-eff3e7406214"));
            base.InitializeControls();
        }

        public MKYSMaterialGetWebService() : base("MKYSMaterialGetWebService")
        {
        }

        protected MKYSMaterialGetWebService(string formDefName) : base(formDefName)
        {
        }
    }
}