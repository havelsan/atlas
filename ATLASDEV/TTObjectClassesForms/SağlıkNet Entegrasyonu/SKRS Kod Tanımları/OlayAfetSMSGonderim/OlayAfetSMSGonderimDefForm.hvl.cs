
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
    /// Olay Afet Sms Gönderilecek Kullanıcı Tanımlama
    /// </summary>
    public partial class OlayAfetSMSGonderimDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Olay Afet Bildirimi güncellenirken tanımlanan ildeki afetin sms olarak gönderilmesi
    /// </summary>
        protected TTObjectClasses.OlayAfetSMSGonderim _OlayAfetSMSGonderim
        {
            get { return (TTObjectClasses.OlayAfetSMSGonderim)_ttObject; }
        }

        protected ITTLabel labelSKRSILKodlari;
        protected ITTObjectListBox SKRSILKodlari;
        protected ITTLabel labelResUser;
        protected ITTObjectListBox ResUser;
        override protected void InitializeControls()
        {
            labelSKRSILKodlari = (ITTLabel)AddControl(new Guid("d326faad-a428-477e-bb9b-b7c8baa0e39d"));
            SKRSILKodlari = (ITTObjectListBox)AddControl(new Guid("a904cd19-db62-457e-9be0-14997ede51fa"));
            labelResUser = (ITTLabel)AddControl(new Guid("a45ebc71-a49d-46b7-b9af-c7a0cfdc6130"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("15825a9b-9942-4fe6-bc99-486102f9fd1a"));
            base.InitializeControls();
        }

        public OlayAfetSMSGonderimDefForm() : base("OLAYAFETSMSGONDERIM", "OlayAfetSMSGonderimDefForm")
        {
        }

        protected OlayAfetSMSGonderimDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}