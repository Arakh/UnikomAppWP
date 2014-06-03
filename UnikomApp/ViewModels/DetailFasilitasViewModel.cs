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
    class DetailFasilitasViewModel : ViewModelBase
    {
        private ObservableCollection<DetailFasilitas> detailFasilitasCollection = new ObservableCollection<DetailFasilitas>();
        
        private String judulFasilitas;
        private String descFasilitas;
        private String photoFasilitas;
        private String iconFasilitas;
        private int listIndex = -1;

        public ObservableCollection<DetailFasilitas> DetailFasilitasCollection
        {
            get { return detailFasilitasCollection; }
            set
            {
                detailFasilitasCollection = value;
                RaisePropertyChanged("");
            }
        }

        public String JudulFasilitas
        {
            get { return judulFasilitas; }
            set 
            {
                judulFasilitas = value;
                RaisePropertyChanged("");
            }
        }

        public String DescFasilitas
        {
            get { return descFasilitas; }
            set 
            {
                descFasilitas = value;
                RaisePropertyChanged("");
            }
        }

        public String PhotoFasilitas
        {
            get { return photoFasilitas; }
            set
            {
                photoFasilitas = value;
                RaisePropertyChanged("");
            }
        }

        public String IconFasilitas
        {
            get { return iconFasilitas; }
            set 
            { 
                iconFasilitas = value;
                RaisePropertyChanged("");
            }
        }

        public DetailFasilitasViewModel()
        {
            this.LoadURL();
        }

        public void LoadURL()
        {
            WebClient clientNews = new WebClient();
            clientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadFasilitasData);
            clientNews.DownloadStringAsync(new Uri(URL.BASE + "getdatafasilitas.php?id_fasilitas="+Navigation.Id));
        }

        private void DownloadFasilitasData(object sender, DownloadStringCompletedEventArgs e)
        {
            JObject jRoot = JObject.Parse(e.Result);
            JArray jItem = JArray.Parse(jRoot.SelectToken("item").ToString());
            foreach (JObject item in jItem)
            {
                DetailFasilitas detailFasilitas = new DetailFasilitas();
                detailFasilitas.id_fasilitas = item.SelectToken("id_fasilitas").ToString();
                detailFasilitas.img_ic_fas = item.SelectToken("img_ic_fas").ToString();
                JudulFasilitas = detailFasilitas.judul_fas = item.SelectToken("judul_fas").ToString();
                PhotoFasilitas = detailFasilitas.url_img = item.SelectToken("url_img").ToString();
                IconFasilitas = detailFasilitas.url_img_ic = item.SelectToken("url_img_ic").ToString();
                DescFasilitas = detailFasilitas.desc_fas = item.SelectToken("desc_fas").ToString();
                DetailFasilitasCollection.Add(detailFasilitas);
            }
        }

        #region Fasilitas

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

        public ICommand SetFasilitasIdCommand
        {
            get
            {
                return new DelegateCommand(SetFasilitasId, CanSetFasilitasId);
            }
        }

        private bool CanSetFasilitasId(object arg)
        {
            return true;
        }

        private void SetFasilitasId(object obj)
        {
            DetailFasilitas selectedItemData = obj as DetailFasilitas;

            if (selectedItemData != null)
                Navigation.Id = selectedItemData.id_fasilitas;

            listIndex = -1;
        }

        #endregion Fasilitas
    }
}
