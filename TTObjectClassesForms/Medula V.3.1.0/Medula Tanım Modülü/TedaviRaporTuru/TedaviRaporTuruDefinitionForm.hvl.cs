
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
    public partial class TedaviRaporTuruDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.TedaviRaporTuru _TedaviRaporTuru
        {
            get { return (TTObjectClasses.TedaviRaporTuru)_ttObject; }
        }

        protected ITTLabel labeltedaviRaporTuruKodu;
        protected ITTTextBox tedaviRaporTuruKodu;
        protected ITTTextBox tedaviRaporTuruAdi;
        protected ITTLabel labeltedaviRaporTuruAdi;
        override protected void InitializeControls()
        {
            labeltedaviRaporTuruKodu = (ITTLabel)AddControl(new Guid("e72b43a3-fd69-426a-bf96-bd1c1b982cd7"));
            tedaviRaporTuruKodu = (ITTTextBox)AddControl(new Guid("f626cffc-0abf-48a7-9402-9f7acececc16"));
            tedaviRaporTuruAdi = (ITTTextBox)AddControl(new Guid("a8096236-5929-4af9-bde9-63cead0ee748"));
            labeltedaviRaporTuruAdi = (ITTLabel)AddControl(new Guid("2a68a852-a044-4a58-b85e-def9369cf18d"));
            base.InitializeControls();
        }

        public TedaviRaporTuruDefinitionForm() : base("TEDAVIRAPORTURU", "TedaviRaporTuruDefinitionForm")
        {
        }

        protected TedaviRaporTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}