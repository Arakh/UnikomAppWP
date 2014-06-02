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
    class JurusanViewModel : ViewModelBase
    {
        private ObservableCollection<Jurusan> jurusanCollection = new ObservableCollection<Jurusan>();
        private String namaFakultas;
        private String namaDekan;
        private String idJenjang;

        public String IdJenjang
        {
            get { return idJenjang; }
            set 
            { 
                 idJenjang = value;
                 RaisePropertyChanged("");           
            }

        }

        private int listIndex = -1;

        public String NamaDekan
        {
            get { return namaDekan; }
            set 
            { 
                namaDekan = value;
                RaisePropertyChanged("");
            }
        }

        public String NamaFakultas
        {
            get { return namaFakultas; }
            set 
            { 
                namaFakultas = value;
                RaisePropertyChanged("");
            }
        }

        public ObservableCollection<Jurusan> JurusanCollection
        {
            get { return jurusanCollection; }
            set 
            { 
                jurusanCollection = value;
                RaisePropertyChanged("");
            }
        }


        public JurusanViewModel()
        {
            LoadURL();
        }

        public void LoadURL()
        {
            
            WebClient clientNews = new WebClient();
            clientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadJurusanData);
            clientNews.DownloadStringAsync(new Uri(URL.BASE + "getDataJurusanPrm.php?id_fakultas="+Navigation.Id_+"& id_jenjang="+Navigation.Id_Jenjang));
        }

        private void DownloadJurusanData(object sender, DownloadStringCompletedEventArgs e)
        {
          
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                Jurusan jurusan = new Jurusan();
                jurusan.id_jurusan = item.SelectToken("id_jurusan").ToString();
                jurusan.akreditasi = item.SelectToken("akreditasi").ToString();
                jurusan.nama_jurusan = item.SelectToken("nama_jurusan").ToString();
                jurusan.url_img = item.SelectToken("url_img").ToString();
                NamaFakultas = jurusan.judul_fakultas = item.SelectToken("judul_fakultas").ToString();
                NamaDekan = jurusan.nama_dekan = item.SelectToken("nama_dekan").ToString();

                JurusanCollection.Add(jurusan);
            }

        }

        #region jurusan

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

        public ICommand SetJurusanIdCommand
        {
            get
            {
                return new DelegateCommand(SetJurusanId, CanSetJurusanId);
            }
        }

        private bool CanSetJurusanId(object arg)
        {
            return true;
        }

        private void SetJurusanId(object obj)
        {
            Jurusan selectedItemData = obj as Jurusan;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.id_jurusan;

            listIndex = -1;
        }

        #endregion jurusan
    }
}
