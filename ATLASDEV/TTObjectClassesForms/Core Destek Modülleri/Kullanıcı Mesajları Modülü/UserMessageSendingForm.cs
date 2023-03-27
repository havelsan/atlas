
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
    /// Mesaj Gönderme
    /// </summary>
    public partial class UserMessageSendingForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            IsSplashMessage.CheckedChanged += new TTControlEventDelegate(IsSplashMessage_CheckedChanged);
            MessageFeedback.CheckedChanged += new TTControlEventDelegate(MessageFeedback_CheckedChanged);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbuttonSelect.Click += new TTControlEventDelegate(ttbuttonSelect_Click);
            IsSystemMessage.CheckedChanged += new TTControlEventDelegate(IsSystemMessage_CheckedChanged);
            btnSend.Click += new TTControlEventDelegate(btnSend_Click);
            btnOK.Click += new TTControlEventDelegate(btnOK_Click);
            btnCancel.Click += new TTControlEventDelegate(btnCancel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            IsSplashMessage.CheckedChanged -= new TTControlEventDelegate(IsSplashMessage_CheckedChanged);
            MessageFeedback.CheckedChanged -= new TTControlEventDelegate(MessageFeedback_CheckedChanged);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbuttonSelect.Click -= new TTControlEventDelegate(ttbuttonSelect_Click);
            IsSystemMessage.CheckedChanged -= new TTControlEventDelegate(IsSystemMessage_CheckedChanged);
            btnSend.Click -= new TTControlEventDelegate(btnSend_Click);
            btnOK.Click -= new TTControlEventDelegate(btnOK_Click);
            btnCancel.Click -= new TTControlEventDelegate(btnCancel_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton3_Click()
        {
#region UserMessageSendingForm_ttbutton3_Click
   //Cursor current = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;
            
            TTObjectContext context = new TTObjectContext(true);
            try
            {
                using(MultiSelectForm multiForm = new MultiSelectForm())
                {
                    IList<ResSection.PoliclinicClinicListNQL_Class> units = ResSection.PoliclinicClinicListNQL(context,null);
                    foreach(ResSection.PoliclinicClinicListNQL_Class unit in units)
                        multiForm.AddMSItem(unit.Name, unit.ObjectID.Value.ToString(), unit.TTObject);
                    
                    //Cursor.Current = current;//set Cursor to default for Modal Dialog
                    string sKey = multiForm.GetMSItem(this, "Gönderilecek Birimi Seçiniz",false,false,true);
                    if(!string.IsNullOrEmpty(sKey))
                    {
                        //Cursor.Current = Cursors.WaitCursor;//wait again
                        if(!string.IsNullOrEmpty(this.ToUsersBox.Text))
                            this.ToUsersBox.Text += ";";
                        
                        foreach(KeyValuePair<string, string> selectedItem in multiForm.MSSelectedItems)
                        {
                            if(!this.mUnit_DefIDs.ContainsKey(selectedItem.Key))
                            {
                                ResSection rDef = (ResSection)context.GetObject(new Guid(selectedItem.Key), "ResSection");
                                this.mUnit_DefIDs.Add(selectedItem.Key, rDef);
                                this.ToUsersBox.Text += rDef.Name + ";";
                                
                                //Getting users data
                                if(rDef.ResourceUsers != null)
                                {
                                    foreach(UserResource userResource in rDef.ResourceUsers)
                                    {
                                        if (userResource.User != null && !this.m_toUserIDs.Contains(userResource.User.ObjectID.ToString()))
                                        {
                                            this.m_toUserIDs.Add(userResource.User.ObjectID.ToString());
                                            this.m_userMessageUnits.Add(rDef.ObjectID.ToString());
                                        }
                                    }
                                }
                            }
                            
                        }
                        this.ToUsersBox.Text = this.ToUsersBox.Text.Remove(this.ToUsersBox.Text.Length-1,1);
                    }
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
            finally
            {
                //Cursor.Current = current;
                
                context.Dispose();
                context = null;
            }
#endregion UserMessageSendingForm_ttbutton3_Click
        }

        private void IsSplashMessage_CheckedChanged()
        {
#region UserMessageSendingForm_IsSplashMessage_CheckedChanged
   if(Common.CurrentUser.IsSuperUser == false && (bool)IsSplashMessage.Value)
            {
                InfoBox.Show("Açılış mesajı atma yetkiniz yoktur");
                IsSplashMessage.Value = false;
                return;
            }
#endregion UserMessageSendingForm_IsSplashMessage_CheckedChanged
        }

        private void MessageFeedback_CheckedChanged()
        {
#region UserMessageSendingForm_MessageFeedback_CheckedChanged
   if(this.IsSystemMessage.Value == true)
            {
                this.MessageFeedback.Value = false;
                InfoBox.Show("Sistem mesajı için geribildirim oluşturamazsınız.", MessageIconEnum.InformationMessage);
            }
#endregion UserMessageSendingForm_MessageFeedback_CheckedChanged
        }

        private void ttbutton1_Click()
        {
#region UserMessageSendingForm_ttbutton1_Click
   if(this.m_toUserIDs.Count == 0)
                return;
            
           // Cursor current = Cursor.Current;
           // Cursor.Current = Cursors.WaitCursor;
            
            TTObjectContext context = new TTObjectContext(true);
            try
            {
                using(MultiSelectForm multiForm = new MultiSelectForm())
                {
                    foreach(ResSection rDef in this.mUnit_DefIDs.Values)
                        multiForm.AddMSItem(rDef.Name, rDef.ObjectID.ToString());
                    
                    foreach(UserMessageGroupDefinition pDef in this.m_DefIDs.Values)
                        multiForm.AddMSItem(pDef.Caption, pDef.ObjectID.ToString());
                    
                    foreach(ResUser user in this.m_users.Values)
                        multiForm.AddMSItem(user.Name, user.ObjectID.ToString());
                    
                   // Cursor.Current = current;//set Cursor to default for Modal Dialog
                    string sKey = multiForm.GetMSItem(this, "Silinecek Grup/Personel Seçiniz",false,false,true);
                    if(!string.IsNullOrEmpty(sKey))
                    {
                       // Cursor.Current = Cursors.WaitCursor;//wait again
                        foreach(KeyValuePair<string, string> selectedItem in multiForm.MSSelectedItems)
                        {
                            if(this.m_users.ContainsKey(selectedItem.Key))
                            {
                                this.m_toUserIDs.Remove(selectedItem.Key);
                                this.m_users.Remove(selectedItem.Key);
                            }
                            
                            if(this.m_DefIDs.ContainsKey(selectedItem.Key))
                            {
                                UserMessageGroupDefinition pDef = this.m_DefIDs[selectedItem.Key];
                                
                                if(pDef.ClassType != null) // Yeni Grup tanımlarında ClassType alanı boş geliyor.
                                {
                                    if(pDef.ClassType.Value == GroupClassType.ResUser)
                                    {
                                        IList<ResUser.GetResUser_Class> users = ResUser.GetResUser(pDef.Condition);
                                        foreach(ResUser.GetResUser_Class user in users)
                                        {
                                            if(this.m_toUserIDs.Contains(user.ObjectID.Value.ToString()))
                                                this.m_toUserIDs.Remove(user.ObjectID.Value.ToString());
                                        }
                                    }
                                    else if(pDef.ClassType.Value == GroupClassType.UserResource)
                                    {
                                        IList<UserResource> userress = UserResource.GetUserResource(context, pDef.Condition);
                                        foreach(UserResource userres in userress)
                                        {
                                            if(this.m_toUserIDs.Contains(userres.User.ObjectID.ToString()))
                                                this.m_toUserIDs.Remove(userres.User.ObjectID.ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if(pDef.UserMessageGroupUsers != null)
                                    {
                                        IList<UserMessageGroupUsers> groupUsers = UserMessageGroupUsers.GetUserMessageGroupUsers(context, pDef.Condition);
                                        foreach (UserMessageGroupUsers groupUser in groupUsers)
                                        {
                                           if(this.m_toUserIDs.Contains(groupUser.ResUser.ObjectID.ToString()))
                                               this.m_toUserIDs.Remove(groupUser.ResUser.ObjectID.ToString());
                                            
                                        }
                                    }
                                    
                                }
                                this.m_DefIDs.Remove(selectedItem.Key);
                            }
                            
                            if(this.mUnit_DefIDs.ContainsKey(selectedItem.Key))
                            {
                                ResSection rDef = this.mUnit_DefIDs[selectedItem.Key];
                                if(rDef.ResourceUsers != null)
                                {
                                    IList<UserResource> userress = UserResource.GetUserResource(context, "WHERE Resource = '" + rDef.ObjectID.ToString() + "'");
                                    foreach(UserResource ur in userress)
                                    {
                                        if(ur.User != null)
                                        {
                                            if(this.m_toUserIDs.Contains(ur.User.ObjectID.ToString()))
                                                this.m_toUserIDs.Remove(ur.User.ObjectID.ToString());
                                        }
                                    }
                                }
                                this.mUnit_DefIDs.Remove(selectedItem.Key);
                            }
                        }
                        
                        this.ToUsersBox.Text = "";
                        foreach(UserMessageGroupDefinition pDef in this.m_DefIDs.Values)
                            this.ToUsersBox.Text += pDef.Caption + ";";
                        
                        foreach(ResSection rDef in this.mUnit_DefIDs.Values)
                            this.ToUsersBox.Text += rDef.Name + ";";
                        
                        foreach(ResUser user in this.m_users.Values)
                            this.ToUsersBox.Text += user.Name + ";";
                        
                        if(this.ToUsersBox.Text.Length != 0)
                            this.ToUsersBox.Text = this.ToUsersBox.Text.Remove(this.ToUsersBox.Text.Length-1,1);
                    }
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
            finally
            {
                //Cursor.Current = current;
                
                context.Dispose();
                context = null;
            }
#endregion UserMessageSendingForm_ttbutton1_Click
        }

        private void ttbutton2_Click()
        {
#region UserMessageSendingForm_ttbutton2_Click
   // (by Tuğba) Grup seçme yetkisinin tüm kullanıcılara açık olması istendiğinden superUser kontrolü kaldırıldı.
            // if(TTUser.CurrentUser.Status == UserStatusEnum.SuperUser)
            // {
           // Cursor current = Cursor.Current;
           // Cursor.Current = Cursors.WaitCursor;
            
            TTObjectContext context = new TTObjectContext(true);
            try
            {
                using(MultiSelectForm multiForm = new MultiSelectForm())
                {
                    IList<UserMessageGroupDefinition.GetAllMessageGroupDef_Class> groups = UserMessageGroupDefinition.GetAllMessageGroupDef();
                    foreach(UserMessageGroupDefinition.GetAllMessageGroupDef_Class group in groups)
                        multiForm.AddMSItem(group.Caption, group.ObjectID.Value.ToString(), group.TTObject);
                    
                    //Cursor.Current = current;//set Cursor to default for Modal Dialog
                    string sKey = multiForm.GetMSItem(this, "Gönderilecek Kullanıcı Grubu Seçiniz",false,false,true);
                    if(!string.IsNullOrEmpty(sKey))
                    {
                        Cursor.Current = Cursors.WaitCursor;//wait again
                        if(!string.IsNullOrEmpty(this.ToUsersBox.Text))
                            this.ToUsersBox.Text += ";";
                        
                        foreach(KeyValuePair<string, string> selectedItem in multiForm.MSSelectedItems)
                        {
                            if(!this.m_DefIDs.ContainsKey(selectedItem.Key))
                            {
                                UserMessageGroupDefinition pDef = (UserMessageGroupDefinition)context.GetObject(new Guid(selectedItem.Key), "UserMessageGroupDefinition");
                                this.m_DefIDs.Add(selectedItem.Key, pDef);
                                this.ToUsersBox.Text += pDef.Caption + ";";
                                
                                //Getting users data
                                if(pDef.ClassType != null)
                                {
                                    if(pDef.ClassType.Value == GroupClassType.ResUser)
                                    {
                                        IList<ResUser.GetResUser_Class> users = ResUser.GetResUser(pDef.Condition);
                                        foreach(ResUser.GetResUser_Class user in users)
                                        {
                                            if(!this.m_toUserIDs.Contains(user.ObjectID.Value.ToString()))
                                            {
                                                this.m_toUserIDs.Add(user.ObjectID.Value.ToString());
                                                this.m_userMessageGroups.Add(pDef.ObjectID.ToString());
                                            }
                                        }
                                    }
                                    else if(pDef.ClassType.Value == GroupClassType.UserResource)
                                    {
                                        IList<UserResource> userress = UserResource.GetUserResource(context, pDef.Condition);
                                        foreach(UserResource userres in userress)
                                        {
                                            //if(!this.m_toUserIDs.Contains(userres.User.ObjectID.ToString()))
                                            this.m_toUserIDs.Add(userres.User.ObjectID.ToString());
                                            this.m_userMessageGroups.Add(pDef.ObjectID.ToString());
                                        }
                                    }
                                }
                                else//Yeni grup tanımlarında ClassType kolonu bos gelecek
                                {
                                    foreach(UserMessageGroupUsers groupUser in pDef.UserMessageGroupUsers)
                                    {
                                        this.m_toUserIDs.Add(groupUser.ResUser.ObjectID.ToString());
                                        this.m_userMessageGroups.Add(pDef.ObjectID.ToString());
                                    }
                                }
                            }
                        }
                        this.ToUsersBox.Text = this.ToUsersBox.Text.Remove(this.ToUsersBox.Text.Length-1,1);
                    }
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
            finally
            {
                //Cursor.Current = current;
                
                context.Dispose();
                context = null;
            }
            /* (by Tuğba) Grup seçme yetkisinin tüm kullanıcılara açık olması istendiğinden superUser kontrolü kaldırıldı.
             *  }
            else
            {
                InfoBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", MessageIconEnum.InformationMessage);
            }*/
#endregion UserMessageSendingForm_ttbutton2_Click
        }

        private void ttbuttonSelect_Click()
        {
#region UserMessageSendingForm_ttbuttonSelect_Click
   // XXXXXX 4
           // Cursor current = Cursor.Current;
           // Cursor.Current = Cursors.WaitCursor;
            
            TTObjectContext context = new TTObjectContext(true);
            try
            {
                if (this.m_users.Count > 0)
                {
                    if (Common.CurrentUser != null && !(Common.CurrentUser.IsSuperUser))
                    {
                        InfoBox.Show("Birden çok personele mesaj gönderilmesi kısıtlanmıştır.");
                        return;
                    }
                }
                IList<ResUser.GetResUser_Class> users = ResUser.GetResUser(" AND ISACTIVE = 1");
                using(MultiSelectForm multiForm = new MultiSelectForm())
                {
                    foreach(ResUser.GetResUser_Class user in users)
                    {
                        if(user.Title != null && user.Title != UserTitleEnum.Unused)
                            multiForm.AddMSItem(TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title.Value).DisplayText +" "+ user.Name, user.ObjectID.ToString());
                        else
                            multiForm.AddMSItem(user.Name, user.ObjectID.ToString());
                    }
                    
                    //Cursor.Current = current;//set Cursor to default for Modal Dialog
                    
                    // parametre listesi (this, caption, autoSelect, QAccesss, MultiSelect = true )
                    bool bMultiplePersonelSelect = (TTObjectClasses.SystemParameter.GetParameterValue("AllowMultipleMessage", "TRUE") == "TRUE") ? true : false;
                    string sKey = multiForm.GetMSItem(this, "Gönderilecek Personel Seçiniz", false, true, bMultiplePersonelSelect);
                    if(!string.IsNullOrEmpty(sKey))
                    {
                        if (multiForm.MSSelectedItems.Count > 1)
                        {
                            if ((bool)IsSplashMessage.Value == false && (bool)IsSystemMessage.Value == false && bMultiplePersonelSelect == false)
                            {
                                InfoBox.Show("Açılış yada sistem mesajı olmayan mesajların birden çok kullanıcıya gönderilmesi kısıtlanmıştır.");
                                return;
                            }
                            
                            if(Common.CurrentUser != null && !(Common.CurrentUser.IsSuperUser))
                            {
                                InfoBox.Show("Birden çok kullanıcıya mesaj gönderme yetkiniz yoktur.");
                                return;
                            }
                            
                        }
                        else
                        {
                            this.m_toUserIDs.Clear();
                            this.m_users.Clear();
                        }
                        
                       // Cursor.Current = Cursors.WaitCursor;//wait again
//                        if(!string.IsNullOrEmpty(this.ToUsersBox.Text))
//                            this.ToUsersBox.Text += ";";
                        foreach(KeyValuePair<string, string> selectedItem in multiForm.MSSelectedItems)
                        {
                            //if(!this.m_toUserIDs.Contains(selectedItem.Key))
                            if(!this.m_users.ContainsKey(selectedItem.Key))
                            {
                                this.ToUsersBox.Text = this.ToUsersBox.Text + selectedItem.Value + "; ";
                                this.m_toUserIDs.Add(selectedItem.Key);
                                
                                IList<ResUser> userList = ResUser.GetResUserByID(context, selectedItem.Key);
                                this.m_users.Add(selectedItem.Key, userList[0]);
                            }
                        }
                        this.ToUsersBox.Text = this.ToUsersBox.Text.Remove(this.ToUsersBox.Text.Length-1, 1);
                    }
                }
                //users.Clear();
                //users = null;
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
            finally
            {
              //  Cursor.Current = current;
                
                context.Dispose();
                context = null;
            }
#endregion UserMessageSendingForm_ttbuttonSelect_Click
        }

        private void IsSystemMessage_CheckedChanged()
        {
#region UserMessageSendingForm_IsSystemMessage_CheckedChanged
   bool hasRight = false;
            
            if(Common.CurrentUser.IsSuperUser)
                hasRight = true;
            else
            {
                foreach(TTUserRole role in Common.CurrentUser.Roles)
                {
                    if(role.RoleID.ToString() == "9d86e62c-b200-4912-8924-73d666d7f1c5")
                        hasRight = true;
                }
            }
            
            if(!hasRight & (bool)IsSystemMessage.Value)
            {
                InfoBox.Show("Sistem mesajı atma yetkiniz yoktur");
                IsSystemMessage.Value = false;
                return;
            }
            
            if(this.MessageFeedback.Value == true)
            {
                this.IsSystemMessage.Value = false;
                InfoBox.Show("Sistem mesajı için geribildirim oluşturamazsınız.", MessageIconEnum.InformationMessage);
            }
            
            if((bool)IsSystemMessage.Value)
            {
                ExpireDate.ReadOnly = false;
                this.ExpireDate.NullableValue = this.MessageDate.NullableValue.Value.AddDays(1);
            }
            else
            {
                ExpireDate.ReadOnly = true;
                ExpireDate.NullableValue = null;
            }
#endregion UserMessageSendingForm_IsSystemMessage_CheckedChanged
        }

        private void btnSend_Click()
        {
#region UserMessageSendingForm_btnSend_Click
   this.OnSendClick(this.btnSend, EventArgs.Empty);
#endregion UserMessageSendingForm_btnSend_Click
        }

        private void btnOK_Click()
        {
#region UserMessageSendingForm_btnOK_Click
   this.OnOKClick(this.btnOK, EventArgs.Empty);
#endregion UserMessageSendingForm_btnOK_Click
        }

        private void btnCancel_Click()
        {
#region UserMessageSendingForm_btnCancel_Click
   this.OnCancelClick(this.btnCancel, EventArgs.Empty);
#endregion UserMessageSendingForm_btnCancel_Click
        }

#region UserMessageSendingForm_Methods
        private List<string> m_toUserIDs = new List<string>();
        private List<string> m_userMessageGroups = new List<string>();
        private List<string> m_userMessageUnits = new List<string>();
        private TTObjectContext m_objectContext = new TTObjectContext(false);
        private Patient m_patient;
        private Guid? m_savedMessageID;
        
        private Dictionary<string, UserMessageGroupDefinition> m_DefIDs = new Dictionary<string, UserMessageGroupDefinition>();
        private Dictionary<string, ResSection> mUnit_DefIDs = new Dictionary<string, ResSection>();
        private Dictionary<string, ResUser> m_users = new Dictionary<string, ResUser>();
        
        
        public void SetFieldsForDrafts(Guid? messageID, string subject, object pRTFBody, bool? isSys, bool? messageFeedback)
        {
            this.Subject.Text = subject;
            this.IsSystemMessage.Value = isSys;
            this.MessageFeedback.Value = messageFeedback;
            this.MessageBody.ControlValue = pRTFBody;
            this.m_savedMessageID = messageID;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            Button pSend = (Button)this.btnSend;
            //pSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //pSend.DialogResult = DialogResult.OK;
            
            Button pOK = (Button)this.btnOK;
           // pOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //pOK.DialogResult = DialogResult.OK;
            
            Button pCancel = (Button)this.btnCancel;
            //pCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pCancel.DialogResult = DialogResult.Cancel;
            
            //this.AcceptButton = pOK;
            this.CancelButton = pCancel;
            
            this.MessageDate.ControlValue = (DateTime)DateTime.Now;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            this.m_objectContext.Dispose();
        }
        
        private void OnSendClick(object sender, EventArgs e)
        {
            if(!this.ValidateFields())
                return;
            
            this.OnSendClickInternal();
        }
        
        private void OnOKClick(object sender, EventArgs e)
        {
            if(!this.ValidateFields())
                return;
            
            this.OnOKClickInternal();
        }
        
        private void OnOKClickInternal()
        {
            Guid savePoint = this.m_objectContext.BeginSavePoint();
            try
            {
                UserMessage theMessage = null;
                if(this.m_savedMessageID==null)
                    theMessage = new UserMessage(this.m_objectContext);
                else
                    theMessage = (UserMessage)this.m_objectContext.GetObject(this.m_savedMessageID.Value,"UserMessage");
                theMessage.InitializeUnSentMessage();
                theMessage.ToUser = theMessage.Sender;//not implemented...YY
                theMessage.Subject = this.Subject.Text;
                theMessage.MessageBody = this.MessageBody.ControlValue;
                theMessage.IsSystemMessage = this.IsSystemMessage.Value;
                theMessage.MessageFeedback = this.MessageFeedback.Value;
                theMessage.Patient = this.m_patient;
                theMessage.ExpireDate = this.ExpireDate.NullableValue.Value;
                theMessage.ValidateFields();
                theMessage.CheckErrorsEx();

                this.m_objectContext.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.m_objectContext.RollbackSavePoint(savePoint);
                InfoBox.Show(ex);
            }
        }
        
        private void OnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        private bool ValidateFields()
        {
            if(string.IsNullOrEmpty(this.ToUsersBox.Text))
            {
                InfoBox.Show("Gönderilen personel boş olmamalıdır.");
                return false;
            }
            if(string.IsNullOrEmpty(this.Subject.Text))
            {
                InfoBox.Show("Başlık boş olmamalıdır.");
                return false;
            }
            if(string.IsNullOrEmpty(this.MessageBody.Text))
            {
                InfoBox.Show("Mesaj boş olmamalıdır.");
                return false;
            }

            if ((bool)IsSplashMessage.Value && (bool)IsSystemMessage.Value)
            {
                InfoBox.Show("Bir mesaj hem açılış hem sistem mesajı olmamalıdır.");
                return false;
            }
            
            if((bool)IsSystemMessage.Value)
            {
                if(this.ExpireDate.NullableValue.HasValue==false)
                {
                    InfoBox.Show("Sistem mesajlarında 'Geçerlilik Bitiş Tarihi' zorunludur.");
                    return false;
                }
            }
            
            return true;
        }
        
        private void OnSendClickInternal()
        {
            Guid savePoint = this.m_objectContext.BeginSavePoint();
            try
            {
                //TODO: burada save edilen mesaj gönderilirken silinmeli...YY
                if(this.m_savedMessageID!=null)
                {
                    UserMessage theMessage = null;
                    theMessage = (UserMessage)this.m_objectContext.GetObject(this.m_savedMessageID.Value,"UserMessage");
                    //theMessage.Status = MessageStatusEnum.SavedDeleted;
                    //theMessage.Delete();
                }
                //*********Send messages here............YY
                //UserMessage.SendMessageInternal(this.m_objectContext,this.m_toUserIDs,this.Subject.Text,this.MessageBody.ControlValue,this.IsSystemMessage.Value,this.m_patient);
                UserMessage.SendMessageInternalWithGroupsV4(this.m_objectContext,this.m_toUserIDs,this.m_userMessageGroups,this.Subject.Text,this.MessageBody.ControlValue, this.IsSystemMessage.Value, this.MessageFeedback.Value, this.m_patient, this.IsSplashMessage.Value, this.ExpireDate.NullableValue);

                this.m_objectContext.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.m_objectContext.RollbackSavePoint(savePoint);
                InfoBox.Show(ex);
            }
        }
        
        public Patient Patient
        {
            get{return this.m_patient;}
            set{this.m_patient = value;}
        }
        
#endregion UserMessageSendingForm_Methods
    }
}