
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
namespace TTObjectClasses
{
    /// <summary>
    /// Medula Döküman Kayıt
    /// </summary>
    public partial class MedulaDocumentEntry : TTObject
    {
        protected override void PreInsert()
        {
            if (SameSEPAndDocumentExists())
                throw new TTException("Aynı takip ve döküman bilgilerine sahip aktif birden çok Medula Döküman Kaydı olamaz.");
        }

        protected override void PreUpdate()
        {
            if (SameSEPAndDocumentExists())
                throw new TTException("Aynı takip ve döküman bilgilerine sahip aktif birden çok Medula Döküman Kaydı olamaz.");
        }

        public bool SameSEPAndDocumentExists()
        {
            if (CurrentStateDefID == MedulaDocumentEntry.States.Saved)
            {
                if (SubEpisodeProtocol.MedulaDocumentEntries.Any(x => x.ObjectID != ObjectID &&
                                                                      x.SubEpisodeProtocol.ObjectID == SubEpisodeProtocol.ObjectID &&
                                                                      x.UploadedDocument.ObjectID == UploadedDocument.ObjectID &&
                                                                      x.CurrentStateDefID == MedulaDocumentEntry.States.Saved))
                    return true;
            }

            return false;
        }
    }
}