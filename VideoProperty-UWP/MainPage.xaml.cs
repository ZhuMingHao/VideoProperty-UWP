using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VideoProperty_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {

            StorageFolder picturesFolder = KnownFolders.VideosLibrary;

            StorageFileQueryResult queryResult = picturesFolder.CreateFileQuery(CommonFileQuery.OrderByDate);
             
            IReadOnlyList<StorageFile> folderList =
                await queryResult.GetFilesAsync();

            foreach (StorageFile tem in folderList)
            {
                if (tem.Name == "hello.mp4")
                {
                    VideoProperties videoProperties = await tem.Properties.GetVideoPropertiesAsync();
                    videoProperties.Subtitle = "Video";              
                    videoProperties.Keywords.Add("Liked");
                    await videoProperties.SavePropertiesAsync();
                    // Application now has read/write access to the picked file
                    var keywors = videoProperties.Keywords;
                    foreach (var item in keywors)
                    {
                        var res  = item;
                    }
                }
            
            }


            //var picker = new Windows.Storage.Pickers.FileOpenPicker();
            //picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            //picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            //picker.FileTypeFilter.Add(".jpg");
            //picker.FileTypeFilter.Add(".jpeg");
            //picker.FileTypeFilter.Add(".mp4");

            //Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            //if (file != null)
            //{
            //    VideoProperties videoProperties = await file.Properties.GetVideoPropertiesAsync();
            //    videoProperties.Keywords.Add("Liked");
            //    await videoProperties.SavePropertiesAsync();
            //    // Application now has read/write access to the picked file
            //    var keywors = videoProperties.Keywords;
            //    foreach(var item in keywors)
            //    {
            //        var tem = item;
            //    }
            //}
            //else
            //{
            
            //}
            
        }
    }
}
