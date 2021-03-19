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

namespace DivadloVPF
{
    /// <summary>
    /// Interakční logika pro scene.xaml
    /// </summary>
    public partial class scene : Page
    {
        public scene()
        {
            InitializeComponent();

            SceneConnection scene = new SceneConnection();

            List<Scene> scenes = scene.getAll();

            
            foreach(var item in scenes)
            {

                Button but = new Button();
                but.Content = item.name;
                but.Tag = item.id;
                but.Width = 100;
                but.HorizontalAlignment = HorizontalAlignment.Left;
                but.Margin = new Thickness(5);
                but.Click += new RoutedEventHandler(scene_click);
                StackPanelScene.Children.Add(but);
            }


                
        }

        public void scene_click(object sender, RoutedEventArgs e)
        {
            var mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;

            mainWin.contentControl.Content = new MainWindow();

        }


		
	}
}
