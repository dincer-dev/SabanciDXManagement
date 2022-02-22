﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SabanciDxManagement.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservice2.dincer.ik", ConfigurationName="ServiceReference1.IKWebServiceDincer2")]
    public interface IKWebServiceDincer2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PersonelValue))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(IzinValue))]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getPersonelBilgileriReturn")]
        SabanciDxManagement.ServiceReference1.SonucBean getPersonelBilgileri(string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getPersonelBilgileriReturn")]
        System.Threading.Tasks.Task<SabanciDxManagement.ServiceReference1.SonucBean> getPersonelBilgileriAsync(string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PersonelValue))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(IzinValue))]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getIzinBilgileriReturn")]
        SabanciDxManagement.ServiceReference1.SonucBean getIzinBilgileri(string pass, string sDate, string eDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="getIzinBilgileriReturn")]
        System.Threading.Tasks.Task<SabanciDxManagement.ServiceReference1.SonucBean> getIzinBilgileriAsync(string pass, string sDate, string eDate);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://webservice2.dincer.ik")]
    public partial class SonucBean : object, System.ComponentModel.INotifyPropertyChanged {
        
        private IzinValue[] izinValuesField;
        
        private PersonelValue[] personelBeansField;
        
        private string resultMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public IzinValue[] izinValues {
            get {
                return this.izinValuesField;
            }
            set {
                this.izinValuesField = value;
                this.RaisePropertyChanged("izinValues");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public PersonelValue[] personelBeans {
            get {
                return this.personelBeansField;
            }
            set {
                this.personelBeansField = value;
                this.RaisePropertyChanged("personelBeans");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string resultMessage {
            get {
                return this.resultMessageField;
            }
            set {
                this.resultMessageField = value;
                this.RaisePropertyChanged("resultMessage");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://webservice2.dincer.ik")]
    public partial class IzinValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string adiField;
        
        private string isbasiTarihiField;
        
        private string isyeriKoduField;
        
        private string izinAciklamaField;
        
        private string izinBaslangicSaatiField;
        
        private string izinBaslangicTarihiField;
        
        private string izinBitisSaatiField;
        
        private string izinGuncellemeSaatiField;
        
        private string izinGuncellemeTarihiField;
        
        private string izinSiraNoField;
        
        private string izinSuresiField;
        
        private string izinTipiAdiField;
        
        private string izinTipiKoduField;
        
        private string izinYiliField;
        
        private string referansNoField;
        
        private string sicilNoField;
        
        private string soyadiField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string adi {
            get {
                return this.adiField;
            }
            set {
                this.adiField = value;
                this.RaisePropertyChanged("adi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string isbasiTarihi {
            get {
                return this.isbasiTarihiField;
            }
            set {
                this.isbasiTarihiField = value;
                this.RaisePropertyChanged("isbasiTarihi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string isyeriKodu {
            get {
                return this.isyeriKoduField;
            }
            set {
                this.isyeriKoduField = value;
                this.RaisePropertyChanged("isyeriKodu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinAciklama {
            get {
                return this.izinAciklamaField;
            }
            set {
                this.izinAciklamaField = value;
                this.RaisePropertyChanged("izinAciklama");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinBaslangicSaati {
            get {
                return this.izinBaslangicSaatiField;
            }
            set {
                this.izinBaslangicSaatiField = value;
                this.RaisePropertyChanged("izinBaslangicSaati");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinBaslangicTarihi {
            get {
                return this.izinBaslangicTarihiField;
            }
            set {
                this.izinBaslangicTarihiField = value;
                this.RaisePropertyChanged("izinBaslangicTarihi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinBitisSaati {
            get {
                return this.izinBitisSaatiField;
            }
            set {
                this.izinBitisSaatiField = value;
                this.RaisePropertyChanged("izinBitisSaati");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinGuncellemeSaati {
            get {
                return this.izinGuncellemeSaatiField;
            }
            set {
                this.izinGuncellemeSaatiField = value;
                this.RaisePropertyChanged("izinGuncellemeSaati");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinGuncellemeTarihi {
            get {
                return this.izinGuncellemeTarihiField;
            }
            set {
                this.izinGuncellemeTarihiField = value;
                this.RaisePropertyChanged("izinGuncellemeTarihi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinSiraNo {
            get {
                return this.izinSiraNoField;
            }
            set {
                this.izinSiraNoField = value;
                this.RaisePropertyChanged("izinSiraNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinSuresi {
            get {
                return this.izinSuresiField;
            }
            set {
                this.izinSuresiField = value;
                this.RaisePropertyChanged("izinSuresi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinTipiAdi {
            get {
                return this.izinTipiAdiField;
            }
            set {
                this.izinTipiAdiField = value;
                this.RaisePropertyChanged("izinTipiAdi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinTipiKodu {
            get {
                return this.izinTipiKoduField;
            }
            set {
                this.izinTipiKoduField = value;
                this.RaisePropertyChanged("izinTipiKodu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string izinYili {
            get {
                return this.izinYiliField;
            }
            set {
                this.izinYiliField = value;
                this.RaisePropertyChanged("izinYili");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string referansNo {
            get {
                return this.referansNoField;
            }
            set {
                this.referansNoField = value;
                this.RaisePropertyChanged("referansNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string sicilNo {
            get {
                return this.sicilNoField;
            }
            set {
                this.sicilNoField = value;
                this.RaisePropertyChanged("sicilNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string soyadi {
            get {
                return this.soyadiField;
            }
            set {
                this.soyadiField = value;
                this.RaisePropertyChanged("soyadi");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4161.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://webservice2.dincer.ik")]
    public partial class PersonelValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string calisanGrupKoduField;
        
        private string caskerhField;
        
        private string ccalgrbField;
        
        private string ccikisnField;
        
        private string ccikistField;
        
        private string cdogtarField;
        
        private string cfnksynField;
        
        private string cgiristField;
        
        private string chukkodField;
        
        private string ciliadiField;
        
        private string cilkgirField;
        
        private string cisyeriField;
        
        private string ckadadtField;
        
        private string ckangrbField;
        
        private string ckunvanField;
        
        private string cmedhalField;
        
        private string cogrsevField;
        
        private string corgadtField;
        
        private string corgkodField;
        
        private string cperbadField;
        
        private string cpercinField;
        
        private string cpersadField;
        
        private string cpozkodField;
        
        private string csakkod2Field;
        
        private string csiciliField;
        
        private string cyakrenField;
        
        private string ismailadresiField;
        
        private string masrafyeriadiField;
        
        private string masrafyerikoduField;
        
        private string ozelmailadresiField;
        
        private string tckimliknoField;
        
        private string unvanaciklamasiField;
        
        private string unvankoduField;
        
        private string yoneticipozisyonadiField;
        
        private string yoneticipozisyonkoduField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string calisanGrupKodu {
            get {
                return this.calisanGrupKoduField;
            }
            set {
                this.calisanGrupKoduField = value;
                this.RaisePropertyChanged("calisanGrupKodu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string caskerh {
            get {
                return this.caskerhField;
            }
            set {
                this.caskerhField = value;
                this.RaisePropertyChanged("caskerh");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ccalgrb {
            get {
                return this.ccalgrbField;
            }
            set {
                this.ccalgrbField = value;
                this.RaisePropertyChanged("ccalgrb");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ccikisn {
            get {
                return this.ccikisnField;
            }
            set {
                this.ccikisnField = value;
                this.RaisePropertyChanged("ccikisn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ccikist {
            get {
                return this.ccikistField;
            }
            set {
                this.ccikistField = value;
                this.RaisePropertyChanged("ccikist");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cdogtar {
            get {
                return this.cdogtarField;
            }
            set {
                this.cdogtarField = value;
                this.RaisePropertyChanged("cdogtar");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cfnksyn {
            get {
                return this.cfnksynField;
            }
            set {
                this.cfnksynField = value;
                this.RaisePropertyChanged("cfnksyn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cgirist {
            get {
                return this.cgiristField;
            }
            set {
                this.cgiristField = value;
                this.RaisePropertyChanged("cgirist");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string chukkod {
            get {
                return this.chukkodField;
            }
            set {
                this.chukkodField = value;
                this.RaisePropertyChanged("chukkod");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ciliadi {
            get {
                return this.ciliadiField;
            }
            set {
                this.ciliadiField = value;
                this.RaisePropertyChanged("ciliadi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cilkgir {
            get {
                return this.cilkgirField;
            }
            set {
                this.cilkgirField = value;
                this.RaisePropertyChanged("cilkgir");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cisyeri {
            get {
                return this.cisyeriField;
            }
            set {
                this.cisyeriField = value;
                this.RaisePropertyChanged("cisyeri");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ckadadt {
            get {
                return this.ckadadtField;
            }
            set {
                this.ckadadtField = value;
                this.RaisePropertyChanged("ckadadt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ckangrb {
            get {
                return this.ckangrbField;
            }
            set {
                this.ckangrbField = value;
                this.RaisePropertyChanged("ckangrb");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ckunvan {
            get {
                return this.ckunvanField;
            }
            set {
                this.ckunvanField = value;
                this.RaisePropertyChanged("ckunvan");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cmedhal {
            get {
                return this.cmedhalField;
            }
            set {
                this.cmedhalField = value;
                this.RaisePropertyChanged("cmedhal");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cogrsev {
            get {
                return this.cogrsevField;
            }
            set {
                this.cogrsevField = value;
                this.RaisePropertyChanged("cogrsev");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string corgadt {
            get {
                return this.corgadtField;
            }
            set {
                this.corgadtField = value;
                this.RaisePropertyChanged("corgadt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string corgkod {
            get {
                return this.corgkodField;
            }
            set {
                this.corgkodField = value;
                this.RaisePropertyChanged("corgkod");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cperbad {
            get {
                return this.cperbadField;
            }
            set {
                this.cperbadField = value;
                this.RaisePropertyChanged("cperbad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cpercin {
            get {
                return this.cpercinField;
            }
            set {
                this.cpercinField = value;
                this.RaisePropertyChanged("cpercin");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cpersad {
            get {
                return this.cpersadField;
            }
            set {
                this.cpersadField = value;
                this.RaisePropertyChanged("cpersad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cpozkod {
            get {
                return this.cpozkodField;
            }
            set {
                this.cpozkodField = value;
                this.RaisePropertyChanged("cpozkod");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string csakkod2 {
            get {
                return this.csakkod2Field;
            }
            set {
                this.csakkod2Field = value;
                this.RaisePropertyChanged("csakkod2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string csicili {
            get {
                return this.csiciliField;
            }
            set {
                this.csiciliField = value;
                this.RaisePropertyChanged("csicili");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cyakren {
            get {
                return this.cyakrenField;
            }
            set {
                this.cyakrenField = value;
                this.RaisePropertyChanged("cyakren");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ismailadresi {
            get {
                return this.ismailadresiField;
            }
            set {
                this.ismailadresiField = value;
                this.RaisePropertyChanged("ismailadresi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string masrafyeriadi {
            get {
                return this.masrafyeriadiField;
            }
            set {
                this.masrafyeriadiField = value;
                this.RaisePropertyChanged("masrafyeriadi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string masrafyerikodu {
            get {
                return this.masrafyerikoduField;
            }
            set {
                this.masrafyerikoduField = value;
                this.RaisePropertyChanged("masrafyerikodu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ozelmailadresi {
            get {
                return this.ozelmailadresiField;
            }
            set {
                this.ozelmailadresiField = value;
                this.RaisePropertyChanged("ozelmailadresi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string tckimlikno {
            get {
                return this.tckimliknoField;
            }
            set {
                this.tckimliknoField = value;
                this.RaisePropertyChanged("tckimlikno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string unvanaciklamasi {
            get {
                return this.unvanaciklamasiField;
            }
            set {
                this.unvanaciklamasiField = value;
                this.RaisePropertyChanged("unvanaciklamasi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string unvankodu {
            get {
                return this.unvankoduField;
            }
            set {
                this.unvankoduField = value;
                this.RaisePropertyChanged("unvankodu");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string yoneticipozisyonadi {
            get {
                return this.yoneticipozisyonadiField;
            }
            set {
                this.yoneticipozisyonadiField = value;
                this.RaisePropertyChanged("yoneticipozisyonadi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string yoneticipozisyonkodu {
            get {
                return this.yoneticipozisyonkoduField;
            }
            set {
                this.yoneticipozisyonkoduField = value;
                this.RaisePropertyChanged("yoneticipozisyonkodu");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKWebServiceDincer2Channel : SabanciDxManagement.ServiceReference1.IKWebServiceDincer2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KWebServiceDincer2Client : System.ServiceModel.ClientBase<SabanciDxManagement.ServiceReference1.IKWebServiceDincer2>, SabanciDxManagement.ServiceReference1.IKWebServiceDincer2 {
        
        public KWebServiceDincer2Client() {
        }
        
        public KWebServiceDincer2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KWebServiceDincer2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KWebServiceDincer2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KWebServiceDincer2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SabanciDxManagement.ServiceReference1.SonucBean getPersonelBilgileri(string pass) {
            return base.Channel.getPersonelBilgileri(pass);
        }
        
        public System.Threading.Tasks.Task<SabanciDxManagement.ServiceReference1.SonucBean> getPersonelBilgileriAsync(string pass) {
            return base.Channel.getPersonelBilgileriAsync(pass);
        }
        
        public SabanciDxManagement.ServiceReference1.SonucBean getIzinBilgileri(string pass, string sDate, string eDate) {
            return base.Channel.getIzinBilgileri(pass, sDate, eDate);
        }
        
        public System.Threading.Tasks.Task<SabanciDxManagement.ServiceReference1.SonucBean> getIzinBilgileriAsync(string pass, string sDate, string eDate) {
            return base.Channel.getIzinBilgileriAsync(pass, sDate, eDate);
        }
    }
}
