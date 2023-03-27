
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
    /// Demirbaş Detayları
    /// </summary>
    public partial class DeleteRecordDocumentWasteMaterialOutForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi-Hek Edilen Malzeme Sekmesi Çıkış detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentWasteMaterialOut _DeleteRecordDocumentWasteMaterialOut
        {
            get { return (TTObjectClasses.DeleteRecordDocumentWasteMaterialOut)_ttObject; }
        }

        public DeleteRecordDocumentWasteMaterialOutForm() : base("DELETERECORDDOCUMENTWASTEMATERIALOUT", "DeleteRecordDocumentWasteMaterialOutForm")
        {
        }

        protected DeleteRecordDocumentWasteMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}