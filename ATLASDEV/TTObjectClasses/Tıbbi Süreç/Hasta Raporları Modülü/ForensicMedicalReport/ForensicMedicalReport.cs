
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
    /// Adli Tıp Raporlarının Girişinin Yapıldığı Temel Nesnedir
    /// </summary>
    public partial class ForensicMedicalReport : EpisodeAction, IWorkListEpisodeAction
    {
        public partial class GetForensicMedicalReport_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();

            #endregion PreInsert
        }

        protected void PostTransition_Completed2Cancelled()
        {
            #region PostTransition_Completed2Cancelled

            DeleteUploadedDocuments();

            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Approval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Cancelled
            #region UndoTransition_Approval2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Approval2Cancelled
        }

        #region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.ForensicMedicalReport;
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                ReportNo.GetNextValue();
            }
        }

        public ForensicMedicalReport(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = ForensicMedicalReport.States.ReportEntry;
            Episode = episodeAction.Episode;
        }

        public void DeleteUploadedDocuments()
        {
            foreach (UploadedDocument doc in UploadedDocuments.Select(""))
            {
                if (doc.MedulaDocumentEntries != null && doc.MedulaDocumentEntries.Count > 0)
                {
                    if (doc.MedulaDocumentEntries.Any(x => x.CurrentStateDefID == MedulaDocumentEntry.States.Saved))
                        throw new TTException("'Adli Muayene Raporu' Medula'ya döküman olarak keydedildiği için işlem iptal edilemez. Önce Medula döküman kaydının iptal edilmesi gerekmektedir.");

                    List<MedulaDocumentEntry> medulaDocumentEntries = doc.MedulaDocumentEntries.ToList();

                    foreach (MedulaDocumentEntry medulaDocumentEntry in medulaDocumentEntries) // Varsa iptal durumdaki MedulaDocumentEntry leri silinir
                        ((ITTObject)medulaDocumentEntry).Delete();
                }

                ((ITTObject)doc).Delete(); // UploadedDocument silinir
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ForensicMedicalReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.Completed && toState == States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ForensicMedicalReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //if (fromState == ForensicMedicalReport.States.Approval && toState == ForensicMedicalReport.States.Cancelled)
            //    UndoTransition_Approval2Cancelled(transDef);
        }

    }
}