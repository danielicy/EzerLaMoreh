using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utilities;
using System.IO;
using EzerLaMoreh.Helpers;
using EzerLaMoreh.ViewModel.Helpers;
using EzerLaMoreh.ViewModel;
using System.Reflection;
using Models;

namespace EzerLaMoreh.CustomUser_Controls.ViewModels
{
    public class EditPicViewModel : WorkspaceViewModel
    {
        #region private fields

        private double height;
        private double width;

        private CroppingAdorner _clp;
        private FrameworkElement _felCur = null;
        private Brush _brOriginal;
        private System.Windows.Controls.Image imgCrop;
        private System.Windows.Controls.Image mainImg;

        private System.Windows.Controls.TextBlock tblkClippingRectangle;
        private EzerLaMoreh.CustomUser_Controls.EditPicWindow editPictWindow; 
        private object viewModel;

        #endregion
                
        #region public Properties

        public string picPath = "";

        public string StudPic
        {
            get { return GetStudPic("StudPic"); }
            set { SetPicPath(value); }
            
        }
      
        private void SetPicPath(string path)
        {
            Type type = viewModel.GetType();
            System.Reflection.PropertyInfo[] pi = type.GetProperties();

            foreach (System.Reflection.PropertyInfo p in pi)
            {
                if (p.Name == "StudPic")
                {
                    p.SetValue(viewModel , path, null);
                }

            }
        }

        private string GetStudPic(string PropStr)
        {
            Type type = viewModel.GetType();
            PropertyInfo pt = type.GetProperty(PropStr);
            string str="";
            object ox=null;
            switch (type.Name)
            {
                case "StudentWorkspaceViewModel":
                    StudentWorkspaceViewModel swVM = (StudentWorkspaceViewModel)viewModel;
                   viewModel= ox = swVM;                
                    break;

                case "NewStudentViewModel":
                    NewStudentViewModel nSVM = (NewStudentViewModel)viewModel;
                    viewModel = ox = nSVM;               
                    break;

                default:
                    ox = viewModel;
                    break;
            }
         
            str = (string)pt.GetValue(ox, null);
            return str;
        }        
    
        private System.Windows.Controls.Image MainImg
        {
            get
            {
                return mainImg;
            }
            set
            {
                mainImg = value;
                RefreshWindowSize();
            }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

       
        #endregion

        #region Ctor

        public EditPicViewModel(object sender, EditPicWindow epw)
        {           
            viewModel = sender;
                    
            editPictWindow = epw;

            this.Window_LoadedCommand = new DelegateCommand((o) => this.Window_Loaded());
            this.Window_SizeChangedCommand = new DelegateCommand((o) => this.Window_SizeChanged());
            this.OKCommand = new DelegateCommand((o) => this.OK());
        }
       
        #endregion

        #region Methods

        private void RemoveCropFromCur()
        {
            AdornerLayer aly = AdornerLayer.GetAdornerLayer(_felCur);
            aly.Remove(_clp);
        }

        private void AddCropToElement(FrameworkElement fel)
        {
            if (_felCur != null)
            {
                RemoveCropFromCur();
            }
            //  Rect rcInterior = new Rect(fel.ActualWidth * 0.2, fel.ActualHeight * 0.2, fel.ActualWidth * 0.6, fel.ActualHeight * 0.6);
            Rect rcInterior = new Rect(fel.ActualWidth * 0.2, fel.ActualHeight * 0.2, fel.ActualHeight * 0.43 * 0.8, fel.ActualHeight * 0.43);

            AdornerLayer aly = AdornerLayer.GetAdornerLayer(fel);

            _clp = new CroppingAdorner(fel, rcInterior);

            aly.Add(_clp);
            imgCrop.Source = _clp.BpsCrop();

            _clp.CropChanged += CropChanged;
            _felCur = fel;

            SetClipColorGrey();

        }

        private void RefreshCropImage()
        {
            if (_clp != null)
            {
                Rect rc = _clp.ClippingRectangle;

                tblkClippingRectangle.Text = string.Format(
                    "Clipping Rectangle: ({0:N1}, {1:N1}, {2:N1}, {3:N1})",
                    rc.Left, rc.Top, rc.Right, rc.Bottom);
                imgCrop.Source = _clp.BpsCrop();
            }






        }

        private void RefreshWindowSize()
        {
            double factor = 1000 / mainImg.Source.Height *0.5;
            editPictWindow.Height = mainImg.Source.Height * factor + 100;
            editPictWindow.Width = mainImg.Source.Width * factor;
        }

        private void CropChanged(Object sender, RoutedEventArgs rea)
        {
            RefreshCropImage();
        }

        private void SetClipColorGrey()
        {
            if (_clp != null)
            {
                Color clr = Colors.Black;
                clr.A = 110;
                _clp.Fill = new SolidColorBrush(clr);
            }
        }

        private string SaveBitmap(BitmapSource image, string path, string fileName)
        {
            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            // Define the image palette
            BitmapPalette myPalette = BitmapPalettes.Halftone256;

            string fullPath = path + fileName;
            int cnt=1;
            bool stop = false;
            string tmpStr;
            do
            {
                try
                {
                    File.Delete(fullPath);
                    stop = true;
                }
                catch
                {
                    PixFuncs.DeletePic(fullPath);
                    tmpStr = fileName.Insert(fileName.Length - 4, cnt.ToString());  //.Replace(".", cnt.ToString() + ".");
                    fullPath = path + tmpStr;
                    cnt++;
                }
            }
            while (!stop);

         // PixFuncs.DeletePic(path, true);

            FileStream stream;
           
            stream = new FileStream(fullPath, FileMode.Create);
            

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            try
            {
                TextBlock myTextBlock = new TextBlock();
                myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
                // encoder.FlipHorizontal = true;
                // encoder.FlipVertical = false;
                // encoder.QualityLevel = 30;
                //encoder.Rotation = Rotation.Rotate90;

               // encoder.Frames.Add(BitmapFrame.Create(image));
                BitmapFrame bf = BitmapFrame.Create(image);
                encoder.Frames.Add(bf);
                encoder.Save(stream);               
                
                encoder.Frames.Remove(bf);
            }
            catch
            {
            }
            finally
            {
                stream.Flush();               
                stream.Close();
                stream.Dispose();
                encoder = null;
            }

            return fullPath;               
        }

        #endregion

        #region Commands

        public ICommand Window_SizeChangedCommand { get; private set; }

        public ICommand Window_LoadedCommand { get; private set; }

        private void OK()
        {

            string path = Environment.CurrentDirectory + "\\tmp\\";
            string fileName = "tmpPic.jpg";

            picPath = path + fileName;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
          
            picPath= SaveBitmap(_clp.BpsCrop(), path ,fileName);           
                        
            string fName , pName  ;
            
      
            if (viewModel.GetType().Name == "StudentViewModel")
            {
                StudentViewModel svm = (StudentViewModel) viewModel ;
                fName = svm.Model.FirstName + svm.Model.LastName + ".jpg";

                //extract name of class
                pName = svm.StudPic.Substring(svm.StudPic.IndexOf("pix\\") + 4);
                string  className = pName.Substring(0, svm.StudPic.Substring(svm.StudPic.IndexOf("pix\\") + 4).IndexOf("\\"));

                pName = Environment.CurrentDirectory + "\\pix\\" + className + "\\";
                bool isExists=false ;
                string oldName="";

                if (File.Exists(pName + fName))
                {
                    oldName=fName;
                    fName=fName.Insert(fName.Length - 4, "1");
                    isExists = true;
                }

                File.Copy(picPath, pName + fName, true);
                picPath = pName + fName;
                if(isExists)
                {
                    PixFuncs.DeletePic(pName + oldName);
                }
                
            }

            StudPic=picPath;
             
            this.CloseCommand.Execute(null);


        }

        private void Window_Loaded()//object sender, RoutedEventArgs e)
        {
            MainImg = editPictWindow.mainImg;

            imgCrop = editPictWindow.imgCrop;


            tblkClippingRectangle = editPictWindow.tblkClippingRectangle;

            AddCropToElement(mainImg);
            _brOriginal = _clp.Fill;
            RefreshCropImage();


        }

        private void Window_SizeChanged()//object sender, SizeChangedEventArgs e)
        {
            RefreshCropImage();
        }

        #endregion
    
    }

}

