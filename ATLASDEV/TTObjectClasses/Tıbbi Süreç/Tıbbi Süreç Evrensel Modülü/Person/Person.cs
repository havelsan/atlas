
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
    public  partial class Person : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SURNAME":
                    {
                        string value = (string)newValue;
#region SURNAME_SetScript
                        SurnameIsUpdated = true;
#endregion SURNAME_SetScript
                    }
                    break;
                case "NAME":
                    {
                        string value = (string)newValue;
#region NAME_SetScript
                        NameIsUpdated = true;
#endregion NAME_SetScript
                    }
                    break;

            }
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();

#endregion PostUpdate
        }

#region Methods
        public class PersonOLAP
        {

            private string _identityNumber;
            public string IdentityNumber
            {
                get { return _identityNumber; }
                set { _identityNumber = value; }
            }

            private byte[] _resim;
            public byte[] Resim
            {
                get { return _resim; }
                set { _resim = value; }
            }

            private string _nameSurname;
            public string NameSurname
            {
                get { return _nameSurname; }
                set { _nameSurname = value; }
            }

            private string _dogumYeri;
            public string DogumYeri
            {
                get { return _dogumYeri; }
                set { _dogumYeri = value; }
            }

            private string _motherName;
            public string MotherName
            {
                get { return _motherName; }
                set { _motherName = value; }
            }

            private string _fatherName;
            public string FatherName
            {
                get { return _fatherName; }
                set { _fatherName = value; }
            }

            private string _nufusIl;
            public string NufusIl
            {
                get { return _nufusIl; }
                set { _nufusIl = value; }
            }

            private string _mahalleKoy;
            public string MahalleKoy
            {
                get { return _mahalleKoy; }
                set { _mahalleKoy = value; }
            }

            private string _evAdres;
            public string EvAdres
            {
                get { return _evAdres; }
                set { _evAdres = value; }
            }

            private string _isAdres;
            public string IsAdres
            {
                get { return _isAdres; }
                set { _isAdres = value; }
            }

            private string _sicilNo;
            public string SicilNo
            {
                get { return _sicilNo; }
                set { _sicilNo = value; }
            }

            private string _emekliSicilNo;
            public string EmekliSicilNo
            {
                get { return _emekliSicilNo; }
                set { _emekliSicilNo = value; }
            }

            private string _oyakNo;
            public string OyakNo
            {
                get { return _oyakNo; }
                set { _oyakNo = value; }
            }

            private string _maasDerecesi;
            public string MaasDerecesi
            {
                get { return _maasDerecesi; }
                set { _maasDerecesi = value; }
            }

            private string _medeniHal;
            public string MedeniHal
            {
                get { return _medeniHal; }
                set { _medeniHal = value; }
            }


            private string _sacRengi;
            public string SacRengi
            {
                get { return _sacRengi; }
                set { _sacRengi = value; }
            }

            private string _gozRengi;
            public string GozRengi
            {
                get { return _gozRengi; }
                set { _gozRengi = value; }
            }

            private string _tenRengi;
            public string TenRengi
            {
                get { return _tenRengi; }
                set { _tenRengi = value; }
            }

            private string _kurmay;
            public string Kurmay
            {
                get { return _kurmay; }
                set { _kurmay = value; }
            }

            private int _boy;
            public int Boy
            {
                get { return _boy; }
                set { _boy = value; }
            }

            private int _kilo;
            public int Kilo
            {
                get { return _kilo; }
                set { _kilo = value; }
            }


            private int _saglikKuruluRaporuVarmi;
            public int SaglikKuruluRaporuVarmi
            {
                get { return _saglikKuruluRaporuVarmi; }
                set { _saglikKuruluRaporuVarmi = value; }
            }


            private string _yakinlikDerecesiSagKurRap;
            public string YakinlikDerecesiSagKurRap
            {
                get { return _yakinlikDerecesiSagKurRap; }
                set { _yakinlikDerecesiSagKurRap = value; }
            }

            private string _dipNo;
            public string DipNo
            {
                get { return _dipNo; }
                set { _dipNo = value; }
            }

            private string _dogumTarihi;
            public string DogumTarihi
            {
                get { return _dogumTarihi; }
                set { _dogumTarihi = value; }
            }

            private string _sicilTarihi;
            public string SicilTarihi
            {
                get { return _sicilTarihi; }
                set { _sicilTarihi = value; }
            }

            private string _garAtanmaTarihi;
            public string GarAtanmaTarihi
            {
                get { return _garAtanmaTarihi; }
                set { _garAtanmaTarihi = value; }
            }

            private string _sonGorevAtanmaTarihi;
            public string SonGorevAtanmaTarihi
            {
                get { return _sonGorevAtanmaTarihi; }
                set { _sonGorevAtanmaTarihi = value; }
            }

            private string _duhulTarihi;
            public string DuhulTarihi
            {
                get { return _duhulTarihi; }
                set { _duhulTarihi = value; }
            }
            private string _nasbiTarihi;
            public string NasbiTarihi
            {
                get { return _nasbiTarihi; }
                set { _nasbiTarihi = value; }
            }

            private string _donem;
            public string Donem
            {
                get { return _donem; }
                set { _donem = value; }
            }

            private string _unitKapsam;
            public string UnitKapsam
            {
                get { return _unitKapsam; }
                set { _unitKapsam = value; }
            }


            private string _XXXXXX;
            public string XXXXXX
            {
                get { return _XXXXXX; }
                set { _XXXXXX = value; }
            }

            private string _birim;
            public string Birim
            {
                get { return _birim; }
                set { _birim = value; }
            }

            private string _sube;
            public string Sube
            {
                get { return _sube; }
                set { _sube = value; }
            }



            private string _kisim;
            public string Kisim
            {
                get { return _kisim; }
                set { _kisim = value; }
            }


            private string _kaynak;
            public string Kaynak
            {
                get { return _kaynak; }
                set { _kaynak = value; }
            }

            private string _unvan;
            public string Unvan
            {
                get { return _unvan; }
                set { _unvan = value; }
            }

            private string _tmkunvan;
            public string TMKUnvan
            {
                get { return _tmkunvan; }
                set { _tmkunvan = value; }
            }

            private string _sinif;
            public string Sinif
            {
                get { return _sinif; }
                set { _sinif = value; }
            }

            private string _tmkSinif;
            public string TMKSinif
            {
                get { return _tmkSinif; }
                set { _tmkSinif = value; }
            }
            private string _rutbe;
            public string Rutbe
            {
                get { return _rutbe; }
                set { _rutbe = value; }
            }

            private string _tmkRutbe;
            public string TMKRutbe
            {
                get { return _tmkRutbe; }
                set { _tmkRutbe = value; }
            }

            private string _brans;
            public string Brans
            {
                get { return _brans; }
                set { _brans = value; }
            }

            private string _tmkBrans;
            public string TMKBrans
            {
                get { return _tmkBrans; }
                set { _tmkBrans = value; }
            }


            private string _gorevTMK;
            public string GorevTMK
            {
                get { return _gorevTMK; }
                set { _gorevTMK = value; }
            }

            private string _kuvvet;
            public string Kuvvet
            {
                get { return _kuvvet; }
                set { _kuvvet = value; }
            }

            private string _tmkKuvvet;
            public string TMKKuvvet
            {
                get { return _tmkKuvvet; }
                set { _tmkKuvvet = value; }
            }

            private string _tmkKodu;
            public string TmkKodu
            {
                get { return _tmkKodu; }
                set { _tmkKodu = value; }
            }

            private string _sozlesmeBasTar;
            public string SozlesmeBasTar
            {
                get { return _sozlesmeBasTar; }
                set { _sozlesmeBasTar = value; }
            }
            private string _sozlesmeBitTar;
            public string SozlesmeBitTar
            {
                get { return _sozlesmeBitTar; }
                set { _sozlesmeBitTar = value; }
            }

            private string _emekliMuv;
            public string EmekliMuv
            {
                get { return _emekliMuv; }
                set { _emekliMuv = value; }
            }

            private string _sozlesmeliMuv;
            public string SozlesmeliMuv
            {
                get { return _sozlesmeliMuv; }
                set { _sozlesmeliMuv = value; }
            }

            private string _mahkeme;
            public string Mahkeme
            {
                get { return _mahkeme; }
                set { _mahkeme = value; }
            }

            private int _active;
            public int Active
            {
                get { return _active; }
                set { _active = value; }
            }

            private string _samStr;
            public string SamStr
            {
                get { return _samStr; }
                set { _samStr = value; }
            }

            private string _tmkSamStr;
            public string TmkSamStr
            {
                get { return _tmkSamStr; }
                set { _tmkSamStr = value; }
            }
            
            private string _samId;
            public string SamId
            {
                get { return _samId; }
                set { _samId = value; }
            }
            
            private string _cityId;
            public string CityId
            {  
                get { return _cityId; }
                set { _cityId = value; }
            }

            private string _missionId;
            public string MissionId
            {  
                get { return _missionId; }
                set { _missionId = value; }
            }
            
            private string _honorificId;
            public string HonorificId
            {  
                get { return _honorificId; }
                set { _honorificId = value; }
            }
            
            private string _classId;
            public string ClassId
            {  
                get { return _classId; }
                set { _classId = value; }
            }
            
            private string _rankId;
            public string RankId
            {  
                get { return _rankId; }
                set { _rankId = value; }
            }
            
            private string _branchId;
            public string BranchId
            {  
                get { return _branchId; }
                set { _branchId = value; }
            }
            
            private string _maritalStatusId;
            public string MaritalStatusId
            {  
                get { return _maritalStatusId; }
                set { _maritalStatusId = value; }
            }
            
            private string _resourceId;
            public string ResourceId
            {  
                get { return _resourceId; }
                set { _resourceId = value; }
            }
            
            private string _armedForceId;
            public string ArmedForceId
            {  
                get { return _armedForceId; }
                set { _armedForceId = value; }
            }
            
            private string _hairColorId;
            public string HairColorId
            {  
                get { return _hairColorId; }
                set { _hairColorId = value; }
            }
            
            private string _eyeColorId;
            public string EyeColorId
            {  
                get { return _eyeColorId; }
                set { _eyeColorId = value; }
            }
            
            private string _skinColorId;
            public string SkinColorId
            {  
                get { return _skinColorId; }
                set { _skinColorId = value; }
            }
            
            private string _lineToeId;
            public string LineToeId
            {  
                get { return _lineToeId; }
                set { _lineToeId = value; }
            }
            
            private string _reservedOfficerTermId;
            public string ReservedOfficerTermId
            {  
                get { return _reservedOfficerTermId; }
                set { _reservedOfficerTermId = value; }
            }
             
            private string _unitEnclosureId;
            public string UnitEnclosureId
            {  
                get { return _unitEnclosureId; }
                set { _unitEnclosureId = value; }
            }
          
            
            private string _personnelImageId;
            public string PersonnelImageId
            {  
                get { return _personnelImageId; }
                set { _personnelImageId = value; }
            }
            
            private string _ykdsXXXXXXId;
            public string YkdsXXXXXXId
            {  
                get { return _ykdsXXXXXXId; }
                set { _ykdsXXXXXXId = value; }
            } 
            
            public PersonOLAP()
            {

            }


        }


        /*    public static PersonOLAP GetPersonnelInfoFromSagKom(string tcKimlikNo)
              {
                PersonOLAP p = new PersonOLAP();
                //p.Name = Sites.SiteMerkezSagKom.ToString();
                p = Person.RemoteMethods.GetPersonnelFromSaglikKom(Sites.SiteMerkezSagKom,tcKimlikNo);
                return p;
              }*/



        public string FullName
        {
            get
            {
                return Name.ToString() + " " + Surname.ToString();
            }

        }
        
#endregion Methods

    }
}