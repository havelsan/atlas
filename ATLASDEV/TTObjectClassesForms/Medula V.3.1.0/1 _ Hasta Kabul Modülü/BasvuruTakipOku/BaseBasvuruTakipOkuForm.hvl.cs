
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
    /// BaseBasvuruTakipOkuForm
    /// </summary>
    public partial class BaseBasvuruTakipOkuForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Başvuru Takip Oku
    /// </summary>
        protected TTObjectClasses.BasvuruTakipOku _BasvuruTakipOku
        {
            get { return (TTObjectClasses.BasvuruTakipOku)_ttObject; }
        }

        protected ITTTextBox hastaBasvuruNo;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("e655259b-737c-427f-b56c-7d13ba9cacb4"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("27384579-8b05-41df-b1c6-01a877d51649"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("04deed48-7229-4947-929b-10ae24e87236"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("1a446c68-7d46-454a-8643-ea88348280b4"));
            base.InitializeControls();
        }

        public BaseBasvuruTakipOkuForm() : base("BASVURUTAKIPOKU", "BaseBasvuruTakipOkuForm")
        {
        }

        protected BaseBasvuruTakipOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}