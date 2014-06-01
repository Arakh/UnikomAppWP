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
    class FakultasViewModel : ViewModelBase
    {
        private ObservableCollection<Fakultas> fakultasCollection = new ObservableCollection<Fakultas>();
        private ObservableCollection<Fakultas> diplomaCollection = new ObservableCollection<Fakultas>();
        private ObservableCollection<Fakultas> pascasarjanaCollection = new ObservableCollection<Fakultas>();


        private int listIndex = -1;

        public ObservableCollection<Fakultas> FakultasCollection
        {
            get { return fakultasCollection; }
            set
            {
                fakultasCollection = value;
                RaisePropertyChanged("");
            }
        }
        public ObservableCollection<Fakultas> DiplomaCollection
        {
            get { return diplomaCollection; }
            set
            {
                diplomaCollection = value;
                RaisePropertyChanged("");
            }
        }
        public ObservableCollection<Fakultas> PascasarjanaCollection
        {
            get { return pascasarjanaCollection; }
            set
            {
                pascasarjanaCollection = value;
                RaisePropertyChanged("");
            }
        }

        public FakultasViewModel()
        {
            LoadURL();
        }

        public void LoadURL()
        {
            WebClient clientNews = new WebClient();
            clientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadSarjanaData);
            clientNews.DownloadStringAsync(new Uri(URL.BASE + "getDataFakultasPrm.php?id_jenjang=2"));

            WebClient clientNewsDiploma = new WebClient();
            clientNewsDiploma.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadDiplomaData);
            clientNewsDiploma.DownloadStringAsync(new Uri(URL.BASE + "getDataFakultasPrm.php?id_jenjang=1"));

            WebClient clientNewsPascasarjana = new WebClient();
            clientNewsPascasarjana.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadPascasarjanaData);
            clientNewsPascasarjana.DownloadStringAsync(new Uri(URL.BASE + "getDataFakultasPrm.php?id_jenjang=3"));
        
        }



        private void DownloadSarjanaData(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                Fakultas fakultas = new Fakultas();
                fakultas.id_fakultas = item.SelectToken("id_fakultas").ToString();
                fakultas.judul_fakultas = item.SelectToken("judul_fakultas").ToString();
                fakultas.nama_dekan = item.SelectToken("nama_dekan").ToString();
                fakultas.img_ic_fakultas = item.SelectToken("url_img_ic").ToString();
                fakultasCollection.Add(fakultas);
            }
        }

        private void DownloadDiplomaData(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                Fakultas fakultas = new Fakultas();
                fakultas.id_fakultas = item.SelectToken("id_fakultas").ToString();
                fakultas.judul_fakultas = item.SelectToken("judul_fakultas").ToString();
                fakultas.nama_dekan = item.SelectToken("nama_dekan").ToString();
                fakultas.img_ic_fakultas = item.SelectToken("url_img_ic").ToString();
                diplomaCollection.Add(fakultas);
            }
        }
        private void DownloadPascasarjanaData(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                Fakultas fakultas = new Fakultas();
                fakultas.id_fakultas = item.SelectToken("id_fakultas").ToString();
                fakultas.judul_fakultas = item.SelectToken("judul_fakultas").ToString();
                fakultas.nama_dekan = item.SelectToken("nama_dekan").ToString();
                fakultas.img_ic_fakultas = item.SelectToken("url_img_ic").ToString();
                pascasarjanaCollection.Add(fakultas);
            }
        }





        #region sarjana
        
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

        public ICommand SetSarjanaFakultasIdCommand
        {
            get
            {
                return new DelegateCommand(SetFakultasSarjanaId, CanSetFakultasSarjanaId);
            }
        }

        private bool CanSetFakultasSarjanaId(object arg)
        {
            return true;
        }

        private void SetFakultasSarjanaId(object obj)
        {
            Fakultas selectedItemData = obj as Fakultas;

            if (selectedItemData != null)
            {
                Navigation.Id = selectedItemData.id_fakultas;
                Navigation.Id_Jenjang = "2";
            }

            listIndex = -1;
        }



         public ICommand SetDiplomaFakultasIdCommand
        {
            get
            {
                return new DelegateCommand(SetDiplomaSarjanaId, CanSetDiplomaSarjanaId);
            }
        }

        private bool CanSetDiplomaSarjanaId(object arg)
        {
            return true;
        }

        private void SetDiplomaSarjanaId(object obj)
        {
            Fakultas selectedItemData = obj as Fakultas;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.id_fakultas;
                Navigation.Id_Jenjang = "1";
            listIndex = -1;
        }

        public ICommand SetPascasarjanaFakultasIdCommand
        {
            get
            {
                return new DelegateCommand(SetPascaSarjanaId, CanSetPascaSarjanaId);
            }
        }

        private bool CanSetPascaSarjanaId(object arg)
        {
            return true;
        }

        private void SetPascaSarjanaId(object obj)
        {
            Fakultas selectedItemData = obj as Fakultas;

            if (selectedItemData != null)
            Navigation.Id = selectedItemData.id_fakultas;
            Navigation.Id_Jenjang = "3";
            listIndex = -1;
        }
        #endregion sarjana



    }
}
