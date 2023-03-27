
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
    /// Kullanıcı Tanımı
    /// </summary>
    public partial class ResUserForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            ResourceSpecialities.CellValueChanged += new TTGridCellEventDelegate(ResourceSpecialities_CellValueChanged);
            btnMultiplyUser.Click += new TTControlEventDelegate(btnMultiplyUser_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ResourceSpecialities.CellValueChanged -= new TTGridCellEventDelegate(ResourceSpecialities_CellValueChanged);
            btnMultiplyUser.Click -= new TTControlEventDelegate(btnMultiplyUser_Click);
            base.UnBindControlEvents();
        }

        private void btnMultiplyUser_Click()
        {
            try
            {
                if (this._ResUser == null)
                    throw new Exception("Önce kullanıcı seçmeniz gerekmektedir.");
                if (String.IsNullOrEmpty(this.txtNameForStart.Text))
                    throw new Exception(this.lblNameForStart.Text + " boş olamaz.");
                if (String.IsNullOrEmpty(this.txtLimit.Text))
                    throw new Exception(this.lblLimit.Text + " boş olamaz.");
                if (!Common.IsNumeric(this.txtLimit.Text))
                    throw new Exception(this.lblLimit.Text + " alanı nümerik olmalıdır.");
                string choice = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı","Uyarı", this._ResUser.Name + " kullanıcısı " + this.txtLimit.Text + " kez çoklanacak. Devam etmek istediğinize emin misiniz?");
                if (choice == "H")
                    throw new TTException("İşlemden vazgeçildi.");
                int limit = Convert.ToInt32(this.txtLimit.Text);
                string log = "";

                TTUser _ttUser = this._ResUser.GetMyTTUser();
                if (_ttUser == null)
                    throw new TTException("İlgili kaynağın kullanıcısı (TTUser) bulunamadı.");

                for (int i = 1; i <= limit; i++)
                {
                    try
                    {
                        ResUser newResUser = (ResUser)this._ResUser.Clone();
                        foreach(UserResource uRes in this._ResUser.UserResources)
                        {
                            UserResource userResource = new UserResource(this._ResUser.ObjectContext);
                            userResource.User = newResUser;
                            userResource.Resource = uRes.Resource;
                        }

                        foreach (ResourceSpecialityGrid uSpec in this._ResUser.ResourceSpecialities)
                        {
                            ResourceSpecialityGrid speciality = new ResourceSpecialityGrid(this._ResUser.ObjectContext);
                            speciality.Speciality = uSpec.Speciality;
                            speciality.Resource = newResUser;
                        }
                        TTUser user = TTUser.GetUser(this.txtNameForStart.Text + i.ToString());
                        if (user != null)
                        {
                            log += this.txtNameForStart.Text + i.ToString() + " kullanıcı adına sahip kullanıcı zaten mevcut." + "\r\n";
                            continue;
                        }
                        TTUser newTTUser = TTUser.CreateNewUser(this.txtNameForStart.Text.Trim() + i.ToString(), "1", _ttUser.PwdExpireDate.Value, _ttUser.Status, newResUser.ObjectID, newResUser.ObjectDef.ID);
                        
                        foreach (TTUserRole userRole in _ttUser.Roles)
                        {
                            TTUser.AddUserRole(newTTUser.UserID, userRole.RoleID, (byte)userRole.TransferType);
                        }
                        this._ResUser.ObjectContext.Save();
                        log += newTTUser.Name + " kullanıcısı oluşturuldu." + "\r\n";
                    }
                    catch(TTException ex)
                    {
                        log += ex.ToString() + "\r\n";
                        continue;
                    }
                }
                InfoBox.Show(log);
            }
            catch (TTException ex)
            {
                InfoBox.Show("Hata : " + ex.ToString());
            }
        }


        private void ResourceSpecialities_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region ResUserForm_ResourceSpecialities_CellValueChanged
            if (rowIndex < this.ResourceSpecialities.Rows.Count && rowIndex > -1)
            {
                if (columnIndex == 0 && ((bool)this.ResourceSpecialities.CurrentCell.Value == true))
                {
                    for (int i = 0; i < this.ResourceSpecialities.Rows.Count; i++)
                    {
                        if (i != rowIndex)
                        {
                            this.ResourceSpecialities.Rows[i].Cells[0].Value = false;
                        }
                    }
                }
            }
            #endregion ResUserForm_ResourceSpecialities_CellValueChanged
        }

        protected override void PreScript()
        {
            #region ResUserForm_PreScript
            base.PreScript();

            if (this._ResUser.Person == null)
            {
                Person person = new Person(this._ResUser.ObjectContext);
                this._ResUser.Person = person;
            }

            if (TTUser.CurrentUser.Status != UserStatusEnum.SuperUser)
                throw new TTException("Kullanıcı tanımlarını sadece Super User açabilir");


            this.txtUserName.Text = String.Empty;
            foreach (TTUser user in TTUser.GetAllUsers())
            {
                if (user.TTObjectID == this._ResUser.ObjectID)
                {
                    this.txtUserName.Text = user.Name.ToString();
                    break;
                }
            }
            if ((TTObjectClasses.SystemParameter.GetParameterValue("ALLOWMULTIPLYUSERFORPERFORMANCETEST", "FALSE")) == "TRUE")
            {
                this.lblNameForStart.Visible = true;
                this.lblLimit.Visible = true;
                this.txtNameForStart.Visible = true;
                this.txtLimit.Visible = true;
                this.btnMultiplyUser.Visible = true;
            }
            else
            {
                this.lblNameForStart.Visible = false;
                this.lblLimit.Visible = false;
                this.txtNameForStart.Visible = false;
                this.txtLimit.Visible = false;
                this.btnMultiplyUser.Visible = false;
            }


            if ((TTObjectClasses.SystemParameter.GetParameterValue("WORKWITHPERSONNELINFOSYSTEM", "FALSE")) == "TRUE")
            {
                this.UserTitle.ReadOnly = true;
                this.BirthDate.ReadOnly = true;
                this.CountryOfBirth.ReadOnly = true;
                //  this.CityOfBith.ReadOnly = true;
                // this.TownOfBirth.ReadOnly = true;
                // this.Sex.ReadOnly = true;
                this.CityOfRegistry.ReadOnly = true;
                this.TownOfRegistryPerson.ReadOnly = true;
                this.VillageOfRegistry.ReadOnly = true;
                this.MilitaryClass.ReadOnly = true;
                this.DateOfJoin.ReadOnly = true;
                this.DateOfLeave.ReadOnly = true;
                this.Rank.ReadOnly = true;
                this.DateOfPromotion.ReadOnly = true;
                this.EmploymentRecordID.ReadOnly = true;
                this.DiplomaNo.ReadOnly = true;
                this.ForcesCommand.ReadOnly = true;

            }
            else
            {
                this.UserTitle.ReadOnly = false;
                this.BirthDate.ReadOnly = false;
                this.CountryOfBirth.ReadOnly = false;
                //this.CityOfBith.ReadOnly = false;
                //this.TownOfBirth.ReadOnly = false;
                //this.Sex.ReadOnly = false;
                this.CityOfRegistry.ReadOnly = false;
                this.TownOfRegistryPerson.ReadOnly = false;
                this.VillageOfRegistry.ReadOnly = false;
                this.MilitaryClass.ReadOnly = false;
                this.DateOfJoin.ReadOnly = false;
                this.DateOfLeave.ReadOnly = false;
                this.Rank.ReadOnly = false;
                this.DateOfPromotion.ReadOnly = false;
                this.EmploymentRecordID.ReadOnly = false;
                this.DiplomaNo.ReadOnly = false;
                this.ForcesCommand.ReadOnly = false;

            }
            #endregion ResUserForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region ResUserForm_PostScript
            base.PostScript(transDef);
            this._ResUser.Person.Name = this._ResUser.Person.Name.Trim();
            this._ResUser.Person.Surname = this._ResUser.Person.Surname.Trim();
            this._ResUser.Name = this._ResUser.Person.Name + " " + this._ResUser.Person.Surname;
            if (this._ResUser.ResourceSpecialities.Count == 1)
            {
                this._ResUser.ResourceSpecialities[0].MainSpeciality = true;
            }
            else if (this._ResUser.ResourceSpecialities.Count > 1)
            {
                int main = 0;
                foreach (ResourceSpecialityGrid resSepeciality in this._ResUser.ResourceSpecialities)
                {
                    if (resSepeciality.MainSpeciality == true)
                    {
                        main++;
                    }
                }
                if (main == 0)
                {
                    throw new Exception(SystemMessage.GetMessage(653));
                }
                else if (main > 1)
                {
                    throw new Exception(SystemMessage.GetMessage(654));
                }

            }
            SetTakesPerformanceScore();
            /* if (this._ResUser.Title == UserTitleEnum.Unused)
                 this._ResUser.Title = null;*/

            #endregion ResUserForm_PostScript

        }

        #region ResUserForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            //SITEID ye gore PACS a gonderim yapilmis, o kod kaldirildi. PACS entegrasyonu olup olmadigi bilgisi sistem parametresi ile tutulup gonderim yapilabilir. 
            this._ResUser.SendUserToPACS();
        }
        public void SetTakesPerformanceScore()
        {
            this._ResUser.TakesPerformanceScore = false;
            if (this._ResUser.UserType != null && this._ResUser.Title != null)
            {
                if (this._ResUser.UserType == UserTypeEnum.Doctor || this._ResUser.UserType == UserTypeEnum.Dentist)
                {
                    if (this._ResUser.Title != UserTitleEnum.UzmanOgr &&
                       this._ResUser.Title != UserTitleEnum.DoktoraOgr &&
                       this._ResUser.Title != UserTitleEnum.YanDalUzmanOgr &&
                       this._ResUser.Title != UserTitleEnum.YLisansUzmanOgr &&
                       this._ResUser.Title != UserTitleEnum.Unused &&
                       this._ResUser.Title != UserTitleEnum.UzmanEcz)
                    {
                        this._ResUser.TakesPerformanceScore = true;
                    }
                }
            }
        }
        #endregion ResUserForm_Methods
    }
}