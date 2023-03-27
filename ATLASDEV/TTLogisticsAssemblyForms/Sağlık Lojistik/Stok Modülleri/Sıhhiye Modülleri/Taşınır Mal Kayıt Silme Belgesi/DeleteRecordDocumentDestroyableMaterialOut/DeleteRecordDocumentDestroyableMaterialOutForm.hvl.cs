
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
    /// Malzeme Detayları
    /// </summary>
    public partial class DeleteRecordDocumentDestroyableMaterialOutForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi Yok Edilen malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentDestroyableMaterialOut _DeleteRecordDocumentDestroyableMaterialOut
        {
            get { return (TTObjectClasses.DeleteRecordDocumentDestroyableMaterialOut)_ttObject; }
        }

        public DeleteRecordDocumentDestroyableMaterialOutForm() : base("DELETERECORDDOCUMENTDESTROYABLEMATERIALOUT", "DeleteRecordDocumentDestroyableMaterialOutForm")
        {
        }

        protected DeleteRecordDocumentDestroyableMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}