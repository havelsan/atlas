
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
    public partial class IlacRaporuKaydetTakipNoIleForm : BaseIlacRaporuKaydetForm
    {
        protected TTObjectClasses.IlacRaporuKaydetTakipNoIle _IlacRaporuKaydetTakipNoIle
        {
            get { return (TTObjectClasses.IlacRaporuKaydetTakipNoIle)_ttObject; }
        }

        protected ITTTextBox takipNoRaporDVO;
        protected ITTLabel labeltakipNoRaporDVO;
        override protected void InitializeControls()
        {
            takipNoRaporDVO = (ITTTextBox)AddControl(new Guid("728f303b-4b05-4503-89e5-d49f8ae92fac"));
            labeltakipNoRaporDVO = (ITTLabel)AddControl(new Guid("53ab2ef0-c084-4d83-afaa-8f0d08757464"));
            base.InitializeControls();
        }

        public IlacRaporuKaydetTakipNoIleForm() : base("ILACRAPORUKAYDETTAKIPNOILE", "IlacRaporuKaydetTakipNoIleForm")
        {
        }

        protected IlacRaporuKaydetTakipNoIleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}