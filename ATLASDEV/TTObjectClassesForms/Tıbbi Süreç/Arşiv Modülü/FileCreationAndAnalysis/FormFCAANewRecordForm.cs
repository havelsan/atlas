
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
    public partial class FormFCAANewRecord : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            FolderContents.CellValueChanged += new TTGridCellEventDelegate(FolderContents_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FolderContents.CellValueChanged -= new TTGridCellEventDelegate(FolderContents_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void FolderContents_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region FormFCAANewRecord_FolderContents_CellValueChanged
   int count=0 ;
            if(this.FolderContents.CurrentCell.OwningColumn.DataMember == "FILE")
            {
                
                if( this.FolderContents.CurrentCell.Value != null)
                {
                    foreach (EpisodeFolderContent fc in this._FileCreationAndAnalysis.StarterEpisodeFolder[0].FolderContents)
                    {
                        if(this.FolderContents.CurrentCell.RowIndex != count){
                            if(fc.File.ObjectID.ToString() == this.FolderContents.CurrentCell.Value.ToString()){
                                //throw new Exception(); 
                                InfoBox.Show("Cilt İçeriği listesinde mevcut olan " + fc.File.FileName.ToString()  + " belgesini seçtiniz. Listede her belgeden en fazla bir adet bulunabilir. " ,MessageIconEnum.ErrorMessage);
                            }
                        }
                        count++;
                    }
                    
                }
            }
#endregion FormFCAANewRecord_FolderContents_CellValueChanged
        }

        protected override void PreScript()
        {
#region FormFCAANewRecord_PreScript
    base.PreScript();
            if (_FileCreationAndAnalysis.Episode.Patient.PatientFolder != null ){
                this.PatientFolderID.Text=this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.PatientFolderID.Value.ToString();
                if(string.IsNullOrEmpty(this._FileCreationAndAnalysis.OnlyYear))
                    this._FileCreationAndAnalysis.OnlyYear = Common.RecTime().Date.Year.ToString();
            }
#endregion FormFCAANewRecord_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FormFCAANewRecord_PostScript
    base.PostScript(transDef);
            
            
            // Eğer hiç cilt içeriği girilmemişse hata mesajı alınır.
            if(this._FileCreationAndAnalysis.StarterEpisodeFolder[0].FolderContents.Count < 1)
            {
                throw new Exception(SystemMessage.GetMessage(933));
            }
            
            //Cilt içerileri arasında mükerrer belge olup olmadığına bakar. Varsa hata mesajı verir.
            foreach (EpisodeFolderContent fcMain in this._FileCreationAndAnalysis.StarterEpisodeFolder[0].FolderContents)
            {
                int count=0;
                foreach (EpisodeFolderContent fc in this._FileCreationAndAnalysis.StarterEpisodeFolder[0].FolderContents)
                {
                    if( fcMain.File.ObjectID.ToString()== fc.File.ObjectID.ToString()){
                        count++;
                        if(count>1)
                            throw new Exception(SystemMessage.GetMessage(934));
                    }
                }
            }
            
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
                
                //// Eğer seçilen step Analiz ise bütün cilt içeriklerinin tam olup olmadığına bakılmaksızın dosya Analize yollanır.
                //else if(transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States..PatientFileAnalysis))
                //{
                //    selectedLocation = (ResSection)this._FileCreationAndAnalysis.ObjectContext.GetObject(new Guid("43ACA6E1-931D-443D-B846-8829B752CF46"),"ResSection"); // 43ACA6E1-931D-443D-B846-8829B752CF46  => Eksik Dosyalarda
                //    if(string.IsNullOrEmpty(this.Shelf.Text) || string.IsNullOrEmpty(this.Row.Text))
                //        throw new TTException(SystemMessage.GetMessage(932));
                //}
                
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource , FolderTransactionTypeEnum.Analysed, selectedLocation);
                this._FileCreationAndAnalysis.FileLocation = selectedLocation;
                
              
            }
#endregion FormFCAANewRecord_PostScript

            }
                }
}