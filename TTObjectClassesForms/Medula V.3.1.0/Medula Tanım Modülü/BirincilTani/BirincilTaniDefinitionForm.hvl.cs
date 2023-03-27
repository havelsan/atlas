
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
    /// Birincil Tanı Tanımlama
    /// </summary>
    public partial class BirincilTaniDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Birincil Tanı
    /// </summary>
        protected TTObjectClasses.BirincilTani _BirincilTani
        {
            get { return (TTObjectClasses.BirincilTani)_ttObject; }
        }

        protected ITTLabel labelbirincilTaniKodu;
        protected ITTTextBox birincilTaniKodu;
        protected ITTLabel labelbirincilTaniAdi;
        protected ITTTextBox birincilTaniAdi;
        override protected void InitializeControls()
        {
            labelbirincilTaniKodu = (ITTLabel)AddControl(new Guid("9e04b67d-d4f1-49ca-bdee-0dd89da34d5c"));
            birincilTaniKodu = (ITTTextBox)AddControl(new Guid("29662496-bd1f-4ac0-a4aa-154dc6e86a5a"));
            labelbirincilTaniAdi = (ITTLabel)AddControl(new Guid("89dc1726-40aa-4053-8968-539be92b2644"));
            birincilTaniAdi = (ITTTextBox)AddControl(new Guid("d0396b54-f468-44de-8102-02541def0d72"));
            base.InitializeControls();
        }

        public BirincilTaniDefinitionForm() : base("BIRINCILTANI", "BirincilTaniDefinitionForm")
        {
        }

        protected BirincilTaniDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}