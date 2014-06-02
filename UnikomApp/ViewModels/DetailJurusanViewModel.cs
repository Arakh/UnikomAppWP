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
    class DetailJurusanViewModel : ViewModelBase
    {
        private ObservableCollection<DetailJurusan> detailJurusanCollection = new ObservableCollection<DetailJurusan>();
       
      

        private int listIndex = -1;

      

        public ObservableCollection<DetailJurusan> DetailJurusanCollection
        {
            get { return detailJurusanCollection; }
            set
            {
                detailJurusanCollection = value;
                RaisePropertyChanged("");
            }
        }


        public DetailJurusanViewModel()
        {
            LoadURL();
        }

        public void LoadURL()
        {

            WebClient clientNews = new WebClient();
            clientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadDetailJurusanData);
            clientNews.DownloadStringAsync(new Uri(URL.BASE + "getdatajurusan.php?id_jurusan="+Navigation.Id));
        }

        private void DownloadDetailJurusanData(object sender, DownloadStringCompletedEventArgs e)
        {

            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                DetailJurusan detailjurusan = new DetailJurusan();
                detailjurusan.id_jurusan_ = item.SelectToken("id_jurusan").ToString();
                detailjurusan.akreditasi = item.SelectToken("akreditasi").ToString();
                detailjurusan.nama_jurusan = item.SelectToken("nama_jurusan").ToString();
                detailjurusan.url_img = item.SelectToken("url_img").ToString();
                detailjurusan.kaprodi = item.SelectToken("kaprodi").ToString();
                detailjurusan.sekretaris = item.SelectToken("sekretaris").ToString();
                detailjurusan.situs = item.SelectToken("situs").ToString();
                detailjurusan.kurikulum = item.SelectToken("kurikulum").ToString();
                detailjurusan.desc_jurusan = item.SelectToken("desc_jurusan").ToString();
                detailJurusanCollection.Add(detailjurusan);
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

        public ICommand SetDetailJurusanIdCommand
        {
            get
            {
                return new DelegateCommand(SetDetailJurusanId, CanSetDetailJurusanId);
            }
        }

        private bool CanSetDetailJurusanId(object arg)
        {
            return true;
        }

        private void SetDetailJurusanId(object obj)
        {
            DetailJurusan selectedItemData = obj as DetailJurusan;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.id_jurusan_;

            listIndex = -1;
        }

        #endregion jurusan
    }
}
