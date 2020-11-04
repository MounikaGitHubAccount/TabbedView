using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabbedView.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}

