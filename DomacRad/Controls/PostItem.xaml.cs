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
    /// Interaction logic for PostItem.xaml
    /// </summary>
    public partial class PostItem : UserControl
    {
        public PostItem()
        {
            InitializeComponent();
            this.DeletePostItemButton.Click += DeletePostItemButton_Click;
            this.EditPostItembutton.Click += EditPostItembutton_Click;
            
            
        }

        void EditPostItembutton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEditPostItemEvent();
        }

        void DeletePostItemButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseDeletePostItemEvent();
        }
      
        private void RaiseDeletePostItemEvent()
        {
            RoutedEventArgs newEventArg = new RoutedEventArgs(PostItem.DeletePostItemEvent);
            RaiseEvent(newEventArg);
        }

        private void RaiseEditPostItemEvent()
        {
            RoutedEventArgs newEventArg = new RoutedEventArgs(PostItem.EditPostItemEvent);
            RaiseEvent(newEventArg);
            
        }

        public static readonly RoutedEvent EditPostItemEvent = EventManager.RegisterRoutedEvent
         (
        "EditPostItem", //ime eventa
         RoutingStrategy.Bubble,
         typeof(RoutedEventHandler),
         typeof(PostItem) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler EditPostItem //za registraciju/deregistraciju 
        {
            add { AddHandler(EditPostItemEvent, value); }
            remove { RemoveHandler(EditPostItemEvent, value); }
        }

      

       

        public static readonly RoutedEvent DeletePostItemEvent = EventManager.RegisterRoutedEvent
      (
          "DeletePostItem", //ime eventa
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(PostItem) //tip elementa koji posjeduje event

      );

        public event RoutedEventHandler DeletePostItem //za registraciju/deregistraciju 
        {
            add { AddHandler(DeletePostItemEvent, value); }
            remove { RemoveHandler(DeletePostItemEvent, value); }

        }

               
    }
}
