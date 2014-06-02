using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnikomApp.Common;
using UnikomApp.Helper;
using UnikomApp.Models;

namespace UnikomApp.ViewModels
{
    class PrestasiViewModel : ViewModelBase
    {
        private ObservableCollection<Prestasi> prestasiCollection = new ObservableCollection<Prestasi>();
        private String judulPrestasi;
        private String tahunPrestasi;
        private int listIndex = -1;

        public String JudulPrestasi
        {
            get { return judulPrestasi; }
            set 
           { 
               judulPrestasi = value;
               RaisePropertyChanged("");
           }
        }

        public String TahunPrestasi
        {
               get { return tahunPrestasi; }
               set 
               { 
                   tahunPrestasi = value;
                   RaisePropertyChanged("");
               }
        }

        public ObservableCollection<Prestasi> PrestasiCollection
        {
            get { return prestasiCollection; }
            set 
            { 
                prestasiCollection = value;
                RaisePropertyChanged("");
            }
        }


        public PrestasiViewModel()
        {
            LoadURL();
        }

        public void LoadURL()
        {
            WebClient clientNews = new WebClient();
            clientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadJurusanData);
            clientNews.DownloadStringAsync(new Uri(URL.BASE + "getdataprestasi.php"));
        }

        private void DownloadJurusanData(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                Prestasi prestasi = new Prestasi();
                prestasi.id_prestasi = item.SelectToken("id_prestasi").ToString();
                prestasi.judul_prestasi = item.SelectToken("judul_prestasi").ToString();
                prestasi.tahun_prestasi = item.SelectToken("tahun_prestasi").ToString();
                PrestasiCollection.Add(prestasi);
            }
        }

        #region prestasi

        public int ListIndex
        {
            get { return listIndex; }
            set
            {
                if (listIndex != value)
                    listIndex = value;
                RaisePropertyChanged("");
            }
        }

        public ICommand SetPrestasiIdCommand
        {
            get
            {
                return new DelegateCommand(SetPrestasiId, CanSetPrestasiId);
            }
        }

        private bool CanSetPrestasiId(object arg)
        {
            return true;
        }

        private void SetPrestasiId(object obj)
        {
            Prestasi selectedItemData = obj as Prestasi;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.id_prestasi;

            listIndex = -1;
        }

        #endregion prestasi
    }
}
