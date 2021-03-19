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
using System.Diagnostics;

namespace DivadloVPF
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public MainWindow()
		{
			InitializeComponent();

			contentControl.Content = new createReservation();

		}


		private void homepage_button(object sender, RoutedEventArgs e)
        {
			Homepage();
		}

		private void scene_button(object sender, RoutedEventArgs e)
		{
			contentControl.Content = new scene();
		}

		private void settings_switch(object sender, RoutedEventArgs e)
		{
			this.Tag = false;
		}

		private void button_switch(object sender, RoutedEventArgs e)
        {
			/*Text Block*/
			TextBlock tb = new TextBlock();

			tb.Text = "Divadlo";
			contentControl.Content = tb;
		}

		

		private void sedadlo_Click(object sender, EventArgs e)
		{


			var formats = new formats();
			string[] xy = formats.formatFromButton((string)((Button)sender).Tag);

			Int32.TryParse(xy[0], out int x);
			Int32.TryParse(xy[1], out int y);
			
			
		}

		public void Homepage()
        {
			/*Text Block*/
			TextBlock tb = new TextBlock();

			tb.Text = "Hlavní strana";
			contentControl.Content = tb;
        }

		private void sceneHP()
        {
			Grid columns = new Grid();

        }
		public void divadloTable(int scene_id)
		{
			TheatreConnection Theatre = new TheatreConnection();
			UsersConnection User = new UsersConnection();
			SceneConnection Scene = new SceneConnection();

			Theatre.updateX(10);

			/* StackPanel */
			StackPanel sp = new StackPanel();

			sp.Margin = new Thickness(5);

			/*Text Block*/
			TextBlock tb = new TextBlock();

			tb.Text = "Divadlo";

			Console.WriteLine();

			Grid sal = new Grid();
			/*sal.HorizontalAlignment = HorizontalAlignment.Center;*/
			sal.VerticalAlignment = VerticalAlignment.Center;
			int radku = Theatre.getY();
			int sloupcu = Theatre.getX();

			int velikost = 30; // velikost ctverce - sedadlo


			this.Width = sloupcu * velikost;
			this.Height = radku * velikost;

			int radek, sloupec;

			for (radek = 0; radek < radku; radek++)
			{
				sal.RowDefinitions.Add(new RowDefinition());
				for (sloupec = 0; sloupec < sloupcu; sloupec++)
				{
					if (radek == 0)
					{
						sal.ColumnDefinitions.Add(new ColumnDefinition());
					}

					Button sedadlo = new Button()
					{
						Height = velikost,
						Width = velikost,
					};

					sedadlo.Click += new RoutedEventHandler(sedadlo_Click);

					sedadlo.Background = Brushes.Green;
					sedadlo.Tag = radek + "-" + sloupec;

					sedadlo.SetValue(Grid.ColumnProperty, sloupec);
					sedadlo.SetValue(Grid.RowProperty, radek);
					sedadlo.Margin = new Thickness(5);

					sal.Children.Add(sedadlo);
				}
			}
			sp.Children.Add(tb);
			sp.Children.Add(sal);

			contentControl.Content = sp;
		}
	}

	
}
