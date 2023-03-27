export enum TTAuditOperationTypeEnum {
/*    [TTEnumDescription("Tanımsız")] */
        Undefined = 0,
/*    [TTEnumDescription("Ekleme")] */
        Insert = 1,
/*    [TTEnumDescription("Güncelleme")] */
        Update = 2,
/*    [TTEnumDescription("Silme")] */
        Delete = 3,
/*    [TTEnumDescription("Detay Ekleme")] */
        AddChild = 4,
/*    [TTEnumDescription("Detay Silme")] */
        DeleteChild = 5,
/*    [TTEnumDescription("Okuma")] */
        Read = 6,
/*    [TTEnumDescription("Sisteme Giriş")] */
        Login = 10,
/*    [TTEnumDescription("Sistemden Çıkış")] */
        Logout = 11,
/*    [TTEnumDescription("Oturum Zaman Aşımı")] */
        SessionTimeout = 12,
/*    [TTEnumDescription("Başarısız Giriş Denemesi")] */
        FailedLogin = 13,
/*    [TTEnumDescription("Rapor Görüntüleme")] */
        ViewReport = 20,
/*    [TTEnumDescription("Rapor Yazdırma")] */
        PrintReport = 21,
/*    [TTEnumDescription("Dışarıya Çıkartma")] */
        ExportReport = 22,
/*    [TTEnumDescription("Grafik Yazdırma")] */
        PrintChart = 23,
/*    [TTEnumDescription("Sınıf Değişikliği")] */
        ChangeType = 24,
/*    [TTEnumDescription("Nesne Çıkarma")]  */
        ExportInstance = 25,
/*    [TTEnumDescription("Nesne Alma")]  */
        ImportInstance = 26,
/*    [TTEnumDescription("Kullanıcı Ekleme")] */
        UserAdd = 30,
/*    [TTEnumDescription("Kullanıcı Rol Ekleme")]   */
        UserAddRole = 31,
/*    [TTEnumDescription("Kullanıcı Rol Silme")]   */
        UserDeleteRole = 32,
/*    [TTEnumDescription("Kullanıcı Şifre Güncelleme")]  */
        UserUpdatePassword = 33,
/*    [TTEnumDescription("Kullanıcı Şifre Geçerlilik Tarihi Güncelleme")]  */
        UserUpdatePasswordExpireDate = 34,
/*    [TTEnumDescription("Kullanıcı Durum Güncelleme")]  */
        UserUpdateStatus = 35,
/*    [TTEnumDescription("Kullanıcı Adı Güncelleme")]  */
        UserUpdateLogonName= 36,
/*    [TTEnumDescription("Kullanıcı Notu Güncelleme")]  */
        UserUpdateNote = 37,
/*    [TTEnumDescription("Kullanıcı Son Giriş Tarihi Güncelleme")] */
        UserUpdateLastLogonDate = 38,
/*    [TTEnumDescription("Kullanıcı Şifre Tarihi Güncelleme")] */
        UserUpdatePasswordDate = 39,
/*    [TTEnumDescription("Kullanıcı Kaynak Güncelleme")] */
        UserUpdateResource= 40
}