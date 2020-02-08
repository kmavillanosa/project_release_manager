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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectReleaseManager.UI.CustomControls
{
    /// <summary>
    /// Interaction logic for ModalControl.xaml
    /// </summary>
    public partial class ModalControl : UserControl
    {
        public ModalControl()
        {
            InitializeComponent();
        }

        public bool IsLocked
        {
            get { return (bool)GetValue(IsModalOpenProperty); }
            set { SetValue(IsModalOpenProperty, value); }
        }

        public static readonly DependencyProperty IsLockedroperty =
            DependencyProperty.Register("IsLocked", typeof(bool), typeof(ModalControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(IsModalOpenHandler)));

        public bool IsModalOpen
        {
            get { return (bool)GetValue(IsModalOpenProperty); }
            set { SetValue(IsModalOpenProperty, value); }
        }

        public static readonly DependencyProperty IsModalOpenProperty =
            DependencyProperty.Register("IsModalOpen", typeof(bool), typeof(ModalControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(IsModalOpenHandler)));


        public object ModalContent
        {
            get { return (object)GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ModalContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModalContentProperty =
            DependencyProperty.Register("ModalContent", typeof(object), typeof(ModalControl), new PropertyMetadata(null));


        private static void IsModalOpenHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsLocked)
            {
                IsModalOpen = false;
            }
        }



    }
}
