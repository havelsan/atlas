
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Dosya Oluşturma ve Analiz
    /// </summary>
    public partial class FormFCAAArchive : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            PatientEpisodeDetails.SelectionChanged += new TTControlEventDelegate(PatientEpisodeDetails_SelectionChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PatientEpisodeDetails.SelectionChanged -= new TTControlEventDelegate(PatientEpisodeDetails_SelectionChanged);
            base.UnBindControlEvents();
        }

        private void PatientEpisodeDetails_SelectionChanged()
        {
#region FormFCAAArchive_PatientEpisodeDetails_SelectionChanged
   if (this.PatientEpisodeDetails.CurrentCell.RowIndex < this._FileCreationAndAnalysis.Episode.Patient.Episodes.Count)
            {
                Episode selectedEpisode = this._FileCreationAndAnalysis.Episode.Patient.Episodes[this.PatientEpisodeDetails.CurrentCell.RowIndex];
              //  this._FileCreationAndAnalysis.SelectedEpisode=selectedEpisode;
            }
#endregion FormFCAAArchive_PatientEpisodeDetails_SelectionChanged
        }

        protected override void PreScript()
        {
#region FormFCAAArchive_PreScript
    base.PreScript();
            if(_FileCreationAndAnalysis.Episode.Patient.PatientFolder != null){
                this.PatientFolderID.Text=this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.PatientFolderID.Value.ToString();
            }
#endregion FormFCAAArchive_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FormFCAAArchive_PostScript
    base.PostScript(transDef);
            if(transDef !=null)
            {
                ResSection selectedLocation = null;
                // Eğer seçilen step Arşivse ve bütün cilt içerikleri tamsa, dosya arşive gönderilir. Eğer ciltlerden herhangibirinde eksik belde varsa, o zaman dosya arşive gönderilemez hatası alınır. 
                if(transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States.Archive))
                {
                    selectedLocation =  (ResSection)this._FileCreationAndAnalysis.ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection"); //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 => Arşivde
                    foreach(EpisodeFolderContent content in this._FileCreationAndAnalysis.StarterEpisodeFolder[0].FolderContents)
                    {
                        if(content.FolderContentStatus.Value == EpisodeFolderContentStatusEnum.InComplete)
                            throw new Exception(SystemMessage.GetMessage(930));
                    }
                    
                    if(string.IsNullOrEmpty(this.Shelf.Text) || string.IsNullOrEmpty(this.Row.Text))
                        throw new TTException(SystemMessage.GetMessage(931));
                }
                else if(transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States.Incomplete))
                { 
                    selectedLocation = (ResSection)this._FileCreationAndAnalysis.ObjectContext.GetObject(new Guid("91129D5E-54EA-4345-82C9-7DD0718EBBB9"),"ResSection"); // 91129D5E-54EA-4345-82C9-7DD0718EBBB9 => Eksik Dosyalarda
                    if(string.IsNullOrEmpty(this.Shelf.Text) || string.IsNullOrEmpty(this.Row.Text))
                        throw new TTException(SystemMessage.GetMessage(932));
                }
                
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource , FolderTransactionTypeEnum.Analysed, selectedLocation);
                this._FileCreationAndAnalysis.FileLocation = selectedLocation;
            }
#endregion FormFCAAArchive_PostScript

            }
                }
}