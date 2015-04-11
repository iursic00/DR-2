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

namespace DomacRad.Controls
{
    /// <summary>
    /// Interaction logic for MediaItem.xaml
    /// </summary>
    public partial class MediaItem : UserControl
    {
        public MediaItem()
        {
            InitializeComponent();
            this.EditIcon.MouseDown += EditIcon_MouseDown;
            this.DeleteIcon.MouseDown += DeleteIcon_MouseDown;
        }

        void DeleteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        private void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MediaItem.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
       (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(MediaItem) //tip elementa koji posjeduje event
       );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }
        void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
            "Edit", //ime eventa
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(MediaItem) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
           
        }
        private void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MediaItem.EditEvent);
            RaiseEvent(newEventArgs);

        }
 
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MediaItem), new PropertyMetadata("Text"));



        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(MediaItem), new PropertyMetadata("ImagePath"));

        

        
    }
}
