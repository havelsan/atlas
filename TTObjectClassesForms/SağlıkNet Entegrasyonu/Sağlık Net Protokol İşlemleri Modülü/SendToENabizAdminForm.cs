
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
    public partial class SendToENabizAdminForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ErrorGrid.CellContentClick += new TTGridCellEventDelegate(ErrorGrid_CellContentClick);
            query.Click += new TTControlEventDelegate(query_Click);
            packageListGrid.CellContentClick += new TTGridCellEventDelegate(packageListGrid_CellContentClick);
            episodeListGrid.CellContentClick += new TTGridCellEventDelegate(episodeListGrid_CellContentClick);
            sendPackageBase.Click += new TTControlEventDelegate(sendPackageBase_Click);
            sysGonder.Click += new TTControlEventDelegate(sysGonder_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ErrorGrid.CellContentClick -= new TTGridCellEventDelegate(ErrorGrid_CellContentClick);
            query.Click -= new TTControlEventDelegate(query_Click);
            packageListGrid.CellContentClick -= new TTGridCellEventDelegate(packageListGrid_CellContentClick);
            episodeListGrid.CellContentClick -= new TTGridCellEventDelegate(episodeListGrid_CellContentClick);
            sendPackageBase.Click -= new TTControlEventDelegate(sendPackageBase_Click);
            sysGonder.Click -= new TTControlEventDelegate(sysGonder_Click);
            base.UnBindControlEvents();
        }

        private void ErrorGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SendToENabizAdminForm_ErrorGrid_CellContentClick
   if (columnIndex == 3)
            {
                
                TTObjectContext objectcontext = new TTObjectContext(false);
                var errorCode = ErrorGrid.Rows[rowIndex].Cells[0].Value.ToString();
                DateTime dt_First = Convert.ToDateTime(dtpickerFirst.Text);
                DateTime dt_Last = Convert.ToDateTime(dtpickerLast.Text);
                BindingList<ResponseOfENabiz> roen = ResponseOfENabiz.GetResponseOfENabizWithErrorCodeAndDates(objectcontext,errorCode,dt_First,dt_Last.AddDays(1));
                List<Guid> changedItems = new List<Guid>();
                foreach (ResponseOfENabiz item in roen)
                {
                    if(!changedItems.Contains(item.SendToENabiz.InternalObjectID.Value))
                    {
                        item.SendToENabiz.Status = 0;
                        changedItems.Add(item.SendToENabiz.InternalObjectID.Value);
                    }
                    item.ResponseCode = null;
                    item.ResponseMessage = null;
                }
                
                objectcontext.Save();
                objectcontext.Dispose();
            }
#endregion SendToENabizAdminForm_ErrorGrid_CellContentClick
        }

        private void query_Click()
        {
#region SendToENabizAdminForm_query_Click
   PackageCountGrid.Rows.Clear();
            ErrorGrid.Rows.Clear();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetCountOfToBeSentPackage(objectcontext);
            DateTime dt_First = Convert.ToDateTime(dtpickerFirst.Text);
            DateTime dt_Last = Convert.ToDateTime(dtpickerLast.Text);
            IList responseOfList = ResponseOfENabiz.GetCountOfResponseData(objectcontext,dt_First,dt_Last.AddDays(1));

            CreatePackageCountGrid(sendToBeList, responseOfList);

            IList errorList = ResponseOfENabiz.GetListOfError(objectcontext, dt_First, dt_Last.AddDays(1));


            CreateErrorListGrid(errorList);
#endregion SendToENabizAdminForm_query_Click
        }

        private void packageListGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SendToENabizAdminForm_packageListGrid_CellContentClick
   if (columnIndex == 4)
            { 
                TTObjectContext objectcontext = new TTObjectContext(false);
                string objectID = packageListGrid.Rows[rowIndex].Cells[0].Value.ToString();
                int packageType = Convert.ToInt32(packageListGrid.Rows[rowIndex].Cells[1].Value);
                SendToENabiz s = new SendToENabiz();
                System.Threading.Thread t;
                
                switch (packageType)
                {
                        case 101: s.ENABIZSend101(objectID); break;
                        case 102: s.ENABIZSend102(objectID); break;
                        case 103: s.ENABIZSend103(objectID); break;
                        case 104: s.ENABIZSend104(objectID); break;
                        case 105: s.ENABIZSend105(objectID); break;
                        case 106: s.ENABIZSend106(objectID); break;
                        case 201: s.ENABIZSend201(objectID); break;
                        case 252: s.ENABIZSend252(objectID); break;
                        case 901: s.ENABIZSend901(); break;
                        default: InfoBox.Show("Geçerli bir paket tipi değil. "); break;
                }

                 
                      
                var episodeID = selectedEpisodeLabel.Text;
                 
                
                BindingList<SubEpisode> sep = SubEpisode.GetByEpisode(objectcontext, episodeID.ToString());

                createSubActionGridGrid(sep);
            
                  
                 
                objectcontext.Dispose();
            }
#endregion SendToENabizAdminForm_packageListGrid_CellContentClick
        }

        private void episodeListGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SendToENabizAdminForm_episodeListGrid_CellContentClick
   TTObjectContext objectcontext = new TTObjectContext(true);
                var episodeID = episodeListGrid.Rows[rowIndex].Cells[0].Value;
                
                selectedEpisodeLabel.Text = episodeID.ToString();
                
                BindingList<SubEpisode> sep = SubEpisode.GetByEpisode(objectcontext, episodeID.ToString());

                createSubActionGridGrid(sep);
            
                 
                objectcontext.Dispose();
#endregion SendToENabizAdminForm_episodeListGrid_CellContentClick
        }

        private void sendPackageBase_Click()
        {
#region SendToENabizAdminForm_sendPackageBase_Click
   System.Threading.Thread t;
            try
            {
                SendToENabiz s = new SendToENabiz();
                
                int packageType = Convert.ToInt32(packageTypeCombo.SelectedItem.Value);
                switch (packageType)
                {
                    case 101: t = new System.Threading.Thread(() => s.ENABIZSend101(null)); t.Start(); break;
                    case 102: t = new System.Threading.Thread(() => s.ENABIZSend102(null)); t.Start(); break;
                    case 103: t = new System.Threading.Thread(() => s.ENABIZSend103(null)); t.Start(); break;
                    case 104: t = new System.Threading.Thread(() => s.ENABIZSend104(null)); t.Start(); break;
                    case 105: t = new System.Threading.Thread(() => s.ENABIZSend105(null)); t.Start(); break;
                    case 106: t = new System.Threading.Thread(() => s.ENABIZSend106(null)); t.Start(); break;
                    case 201: t = new System.Threading.Thread(() => s.ENABIZSend201(null)); t.Start(); break;   
                    case 207: t = new System.Threading.Thread(() => s.ENABIZSend207(null)); t.Start(); break;   //
                    case 247: t = new System.Threading.Thread(() => s.ENABIZSend247(null)); t.Start(); break;   //
                    case 252: t = new System.Threading.Thread(() => s.ENABIZSend252(null)); t.Start(); break;
                    case 901: t = new System.Threading.Thread(() => s.ENABIZSend901()); t.Start(); break;
                    default: InfoBox.Show("Lütfen geçerli bir paket tipi seçiniz."); break;
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex.ToString());
            }
#endregion SendToENabizAdminForm_sendPackageBase_Click
        }

        private void sysGonder_Click()
        {
#region SendToENabizAdminForm_sysGonder_Click
   DateTime dt = DateTime.Now;
            try
            {
                var responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, txtSendXML.Text);

                txtResponceXML.Text = responce;

                TimeSpan ts = (DateTime.Now - dt);

                ttlabel12.Text = ts.TotalMilliseconds.ToString();

                InfoBox.Show("Gönderim tamamlandı. Toplam süre: "+ts.TotalMilliseconds.ToString()+" milisaniye.");
            }
            catch(Exception ex)
            {
                ttlabel12.Text = "Hata oluştu !";
                InfoBox.Show(ex.ToString());
            }
#endregion SendToENabizAdminForm_sysGonder_Click
        }

#region SendToENabizAdminForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            MaskedTextBox tc = (MaskedTextBox)this.tbTC;

            tc.KeyDown -= new KeyEventHandler(tcEntered);
            tc.KeyDown += new KeyEventHandler(tcEntered);

            dtpickerFirst.NullableValue = DateTime.Today;
            dtpickerLast.NullableValue = DateTime.Today;
        }

        private void tcEntered(object sender, KeyEventArgs e)
        {
            PackageCountGrid.Rows.Clear();
            if (e.KeyValue.ToString() == "13")//Enter Key Pressed
            {
                loadAllGrid(tbTC.Text);
                
            }
        }

        private void loadAllGrid(string tc)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            BindingList<Patient> patientList = Patient.GetPatientsByUniqueRefNo(objectcontext, Convert.ToInt64(tc));

            if (patientList.Count > 0)
            {
                ttLableNameAndSurname.Text = patientList[0].Name + " " + patientList[0].Surname;

                if (patientList[0].BirthDate.HasValue)
                    ttLabelBirthDate.Text = patientList[0].BirthDate.Value.ToString("dd.MM.yyyy");

                BindingList<Episode> episodeList = Episode.GetEpisodesByPatient(objectcontext, patientList[0].ObjectID.ToString(), string.Empty);
                createEpisodeGrid(episodeList);
            }
        }
        
        public void createEpisodeGrid(BindingList<Episode> episodeList)
        {
            episodeListGrid.Rows.Clear();
            foreach (Episode episode in episodeList)
            {
                addRowToEpisodeListGridview(episode.ObjectID,
                                            episode.OpeningDate.Value.ToString("dd.MM.yyyy"),
                                            episode.HospitalProtocolNo.Value.ToString(),
                                            "",
                                            episode.AdmissionSpecOrRes.ToString());
            }
        }

        public void CreatePackageCountGrid(IList sendtoENabiz,IList responseOfENabiz)
        {
            foreach (ENabızPackageTypeEnum pte in Enum.GetValues(typeof(ENabızPackageTypeEnum)))
            {
                getAndAddOneRow(sendtoENabiz, responseOfENabiz, pte );
            }
        }

        private void getAndAddOneRow(IList sendtoENabizList, IList responseOfENabizList, ENabızPackageTypeEnum pte)
        {
            string name ;
            int sendtoenabiz = 0;
            int success = 0;
            int unsuccess = 0;
            int unabletosent = 0;
            
            name = ((int)pte).ToString() + " - " + pte.ToString();

            foreach (SendToENabiz.GetCountOfToBeSentPackage_Class sendtoENabiz in sendtoENabizList)
            {
                if (sendtoENabiz.PackageCode.Equals(((int)pte).ToString()))
                {
                    sendtoenabiz = Convert.ToInt32(sendtoENabiz.Count);
                    break;
                }
            }

            foreach (ResponseOfENabiz.GetCountOfResponseData_Class responseOfENabiz in responseOfENabizList)
            {
                if (responseOfENabiz.PackageCode.Equals(((int)pte).ToString()))
                {
                    if (Convert.ToInt32(responseOfENabiz.Status) == (int)SendToENabizEnum.Successful)
                    {
                        success = Convert.ToInt32(responseOfENabiz.Count);
                    }
                    else if (Convert.ToInt32(responseOfENabiz.Status) == (int)SendToENabizEnum.UnSuccessful)
                    {
                        unsuccess = Convert.ToInt32(responseOfENabiz.Count);
                    }
                    else if (Convert.ToInt32(responseOfENabiz.Status) == (int)SendToENabizEnum.UnableToSent)
                    {
                        unabletosent = Convert.ToInt32(responseOfENabiz.Count);
                    }
                }
            }
            addRowToPackageCountGridview(name, sendtoenabiz, success, unsuccess, unabletosent);

        }

        public void CreateErrorListGrid(IList errorList)
        {
            foreach (ResponseOfENabiz.GetListOfError_Class item in errorList)
            {
                addRowToErrorListGridview(item.ResponseCode, Convert.ToString(item.Msg), Convert.ToInt32(item.Count));
            }
           

        }
                
                
        public void addRowToPackageCountGridview(string name,int sendtoenabiz,int success,int unsuccess, int unabletosent)
        {            
            ITTGridRow row = PackageCountGrid.Rows.Add();
            row.Cells[0].Value = name;
            row.Cells[1].Value = sendtoenabiz;
            row.Cells[2].Value = success;
            row.Cells[3].Value = unsuccess;
            row.Cells[4].Value = unabletosent;
        }
        
        public void addRowToErrorListGridview(string code,string name,int count)
        {            
            ITTGridRow row = ErrorGrid.Rows.Add();
            row.Cells[0].Value = code;
            row.Cells[1].Value = name;
            row.Cells[2].Value = count;
        }

        public void addRowToEpisodeListGridview(Guid ObjectID, string eDate, string protocol,string reason, string branch)
        {
            ITTGridRow row = episodeListGrid.Rows.Add();
            row.Cells[0].Value = ObjectID;
            row.Cells[1].Value = eDate;
            row.Cells[2].Value = protocol;
            row.Cells[3].Value = reason;
            row.Cells[4].Value = branch; 
        }
        
        public void addRowToPackageListview(Guid ObjectID, string packageCode, string name,SendToENabizEnum? status)
        {
            ITTGridRow row = packageListGrid.Rows.Add();

            row.Cells[0].Value = ObjectID.ToString();
            row.Cells[1].Value = packageCode;
            row.Cells[2].Value = name;
            row.Cells[3].Value = (Common.GetEnumValueDefOfEnumValueV2("SendToENabizEnum", Convert.ToInt32(status))).DisplayText;
            //row.Cells[3].Value = status.Value;
        }

        private void createSubActionGridGrid(BindingList<SubEpisode> sep)
        { 
            packageListGrid.Rows.Clear();
            TTObjectContext objectcontext = new TTObjectContext(true);
            foreach (SubEpisode item in sep)
            {
                 BindingList<SendToENabiz> ste =  SendToENabiz.GetbySubEpisode(objectcontext,item.ObjectID);
                 
                 foreach(SendToENabiz s in ste)
                 {
                     if(s.InternalObjectID.HasValue && s.Status.HasValue)
                         getExtraDataOfSendToeNabiz(s.InternalObjectID.Value,s.Status.Value,Convert.ToInt32(s.PackageCode));
                 }
                //addRowToSubEpisodeListGridview(item.ObjectID,(i++).ToString(),"","","","");
                //addRowToSubEpisodeListGridview(item.ObjectID,item.ResSection.ToString());
            }
        }
        private void getExtraDataOfSendToeNabiz(Guid objectID, SendToENabizEnum? status,int PackageCode)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            string name = "";
            if(PackageCode == (int)ENabızPackageTypeEnum.HizmetBilgisiKayit)
            {
                BindingList<SubActionProcedure.GetProcedureNameAndCode_Class> pList =  SubActionProcedure.GetProcedureNameAndCode(objectcontext,objectID);
                if(pList.Count > 0)
                {
                     name = pList[0].Procedurecode +"-"+pList[0].Procedurename;
                }
                else 
                {
                    BindingList<SubActionMaterial.GetNameByObjectID_Class> mList =  SubActionMaterial.GetNameByObjectID( objectcontext,objectID);
                    if(mList.Count > 0)
                    {
                        name = mList[0].Name;
                    }
                    else
                        name = "Hizmet/İlaç/Sarf Bilgisi Kayıt";
                
                }
                addRowToPackageListview(objectID,PackageCode.ToString(),name, status );
            }
            else if(PackageCode == (int)ENabızPackageTypeEnum.LabBilgisiKayit)
            {
                addRowToPackageListview(objectID,PackageCode.ToString(),"Lab bilgisi kayıt" , status );
            }
            else
            {
                foreach (ENabızPackageTypeEnum pte in Enum.GetValues(typeof(ENabızPackageTypeEnum)))
                {
                    
                    if(PackageCode == (int)pte)
                        addRowToPackageListview(objectID,PackageCode.ToString(), pte.ToString() , status );
                }
            }
            
        }
        
#endregion SendToENabizAdminForm_Methods
    }
}