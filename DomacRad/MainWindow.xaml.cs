using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DomacRad.Controls;

namespace DomacRad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HandleMediaItemEdit();
            HandleMediaItemDelete();
            HandlePostItemDelete();
            HandlePostItemEdit();
        }

        private void HandlePostItemEdit()
        {
            foreach (var post in this.rectangleContainer.Children)
            {
                if (!(post is PostItem)) { continue; }
                var postItem = post as PostItem;
                postItem.EditPostItem+=postItem_EditPostItem;
            }
        }

        private void postItem_EditPostItem(object sender, RoutedEventArgs e)
        {
            var dialog = ShowDialog();
        }

        private void HandlePostItemDelete()
        {
            foreach(var post in this.rectangleContainer.Children)
            {
                if (!(post is PostItem)) { continue; }
                var postItem = post as PostItem;
                postItem.DeletePostItem += postItem_DeletePostItem;
            }
        }

        void postItem_DeletePostItem(object sender, RoutedEventArgs e)
        {
            if (!(sender is PostItem)) { return; }
            var post = sender as PostItem;            
            this.rectangleContainer.Children.Remove(post);
        }
            
        private void HandleMediaItemEdit()
        {
            foreach (var child in this.quadratContainer.Children)
            {
                if (!(child is MediaItem)) { continue; }
                var mediaItem = child as MediaItem;
                mediaItem.Edit += new RoutedEventHandler(mediaItem_Edit);
            }
        }
        private void HandleMediaItemDelete()
        {
            foreach (var child in this.quadratContainer.Children)
            {
                if (!(child is MediaItem)) { continue; }
                var mediaItem = child as MediaItem;
                mediaItem.Delete += new RoutedEventHandler(mediaItem_Delete);
            }
        }

        private void mediaItem_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is MediaItem)) { return; }
            var mediaItem = sender as MediaItem;
            MessageBox.Show(mediaItem.Text + " je izbrisan");
            this.quadratContainer.Children.Remove(mediaItem);
        }


        private void mediaItem_Edit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Unesite ime korisnika");
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.left_button.Click += new RoutedEventHandler(left_button_Click);
            this.right_button.Click += new RoutedEventHandler(right_button_Click);
            this.textBox1.MouseDoubleClick += textBox1_MouseDoubleClick;
        }

        void textBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text = "";
        }

        void right_button_Click(object sender, RoutedEventArgs e)
        {
            var element = new PostItem();
            
            this.rectangleContainer.Children.Add(element);
        }

        void left_button_Click(object sender, RoutedEventArgs e)
        {
            var element = new MediaItem();
            element.Text = "user";
            element.ImagePath = "/Resources/Images/user.png";
            element.Margin = new Thickness(10);
            this.quadratContainer.Children.Add(element);
        }
        private Brush _GetRandomBrush()
        {
            var random = new Random();

            var brushesType = typeof(Brushes);
            var properties = brushesType.GetProperties();

            var randomNumber = random.Next(properties.Length);

            return (Brush)properties[randomNumber].GetValue(null, null);        }

    }
}
